﻿using DVLD_BUSINESS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_PROJECT.Users
{
    public partial class frmAddNewUpdateUser : Form
    {
        public enum eSaveMode { addNew, update }

        private eSaveMode mode;
        public frmAddNewUpdateUser()
        {
            InitializeComponent();
            mode = eSaveMode.addNew;
        }

        public frmAddNewUpdateUser(int userID,int personID)
        {
            InitializeComponent();
            fillFormWithData(personID,userID);
            ctrlPersonCardWithFilter1.disableFilter();
            btnNext.Enabled = false;
            mode = eSaveMode.update;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           if(clsUser.isUserExist(ctrlPersonCardWithFilter1.personID))
            {
                MessageBox.Show("Selected Person already has a user,choose another one","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if(ctrlPersonCardWithFilter1.personID != -1)
                {
                    tabControl1.SelectedIndex++;
                }
                else
                {
                    MessageBox.Show("Please Enter a person information first !", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "userName should not be empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "password should not be empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "password should not be empty");
            }
            else if (!txtConfirmPassword.Text.Equals(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "password confirmation should match password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsUser user;
            if(mode == eSaveMode.update)
            {
                user = clsUser.find(int.Parse(lbUserId.Text));
            }
            else
            {
                user = new clsUser();
            }

            loadUserDataToObjectAndSave(user);
        }

        private bool loadUserDataToObjectAndSave(clsUser user)
        {
            user.personId = ctrlPersonCardWithFilter1.personID;
            if(!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                user.userName = txtUserName.Text;
                user.password = txtPassword.Text;
                if (chkbIsActive.Checked)
                {
                    user.isActive = true;
                }
                else
                {
                    user.isActive = false;
                }
                if (user.saveUser())
                {
                    MessageBox.Show("User Saved Successfully !", "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("User Info should not be empty !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            return false;
            
        }

        public void loadPersonInfoToForm(int personID)
        {
            ctrlPersonCardWithFilter1.loadDataToControl(personID);
        }
        public void loadUserInfoToForm(int userId)
        {
            clsUser user = clsUser.find(userId);
            lbUserId.Text = user.userid.ToString();
            txtUserName.Text = user.userName;
            txtPassword.Text = user.password;
            txtConfirmPassword.Text = txtPassword.Text;
            chkbIsActive.Checked = user.isActive;
        }

        public void fillFormWithData(int personID,int userId)
        {
            loadPersonInfoToForm(personID);
            loadUserInfoToForm(userId);
            lbAddUpdateUser.Text = "Update User";
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
