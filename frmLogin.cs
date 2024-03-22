using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BUSINESS;
namespace DVLD_PROJECT
{
    public partial class frmLogin : Form
    {

        private string filePath = "rememberMe.txt";
        public frmLogin()
        {
            InitializeComponent();
            loadUserInfoFromFile(filePath);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbUserName.Text))
            {
                errorProvider1.SetError(tbUserName, "Username should not be empty");
            }
            else if (string.IsNullOrEmpty(tbPassword.Text))
            {
                errorProvider1.SetError(tbPassword, "Password should not be empty");
            }
            else
            {
                if (clsUser.IsUserAuthenticated(tbUserName.Text, tbPassword.Text))
                {
                    MessageBox.Show("User is Authenticated !");
                    RememberTheUser();

                }
                errorProvider1.SetError(tbUserName, "");
                errorProvider1.SetError(tbPassword, "");


            }   
        }
        private void RememberTheUser()
        {
            string filePath = "rememberMe.txt";

            if (!cbRememberMe.Checked)
            {
                return;
            }   
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(tbUserName.Text);
                        writer.WriteLine(tbPassword.Text);
                    }
                }
                catch (Exception ex)
                {
                MessageBox.Show("Error Occurs while Saving the user info");
                }
            }

        private void loadUserInfoFromFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    tbUserName.Text = reader.ReadLine();
                    tbPassword.Text = reader.ReadLine();
                    cbRememberMe.Checked = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cbRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if(!cbRememberMe.Checked) {
                File.Delete("rememberMe.txt");
            
            }
        }
    }
}
