using DVLD_BUSINESS;
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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(int userId)
        {
            InitializeComponent();
            ctrlUserCard1.loadUserDataToControl(userId);
        }

        

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (!ctrlUserCard1.password.Equals(txtCurrentPassword.Text))
            {
                e.Cancel =true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password is wrong");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Password is Empty");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtConfimPassword_Validating(object sender, CancelEventArgs e)
        {
            if(!txtNewPassword.Text.Equals(txtConfimPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfimPassword, "Password should match");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfimPassword, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsUser.updatePassword(ctrlUserCard1.userId, txtNewPassword.Text))
            {
                MessageBox.Show("Password Updated Successfully !","Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error Occurs while updating password!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
