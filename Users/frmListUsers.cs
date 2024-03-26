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
    public partial class frmListUsers : Form
    {
        public frmListUsers()
        {
            InitializeComponent();
            loadUsersData();
        }


        private void loadUsersData()
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 16);

            DataTable dt = clsUser.getAllUsers();
            dataGridView1.DataSource = dt;
            if(dt.Rows.Count > 0 )
            {

                dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[0].Width = 140;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 160;

                dataGridView1.Columns[2].HeaderText = "Full Name";
                dataGridView1.Columns[2].Width = 400;

                dataGridView1.Columns[3].HeaderText = "UserName";
                dataGridView1.Columns[3].Width = 180;

                dataGridView1.Columns[4].HeaderText = "is Active";
                dataGridView1.Columns[4].Width = 180;
            }
        }

        private void lbFilterText_TextChanged(object sender, EventArgs e)
        {
            switch (cbFilterOptions.Text)
            {
                case "User ID":
                    filterDataByUserID(lbFilterText.Text);
                    break;
                case "Person ID":
                    filterDataByPersonID(lbFilterText.Text);
                    break;
                case "FullName":
                    filterDataByFullName(lbFilterText.Text);
                    break;
                case "UserName":
                    filterDataByUserName(lbFilterText.Text);
                    break;
                default:

                    break;
            }
        }

        
        private void filterDataByUserID(string userID)
        {
            if (!string.IsNullOrEmpty(lbFilterText.Text))
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "UserID = " + userID;
                dataGridView1.DataSource = bs;
            }
            else
            {
                loadUsersData();
            }
        }

        private void filterDataByFullName(string option)
        {
            if (!string.IsNullOrEmpty(option))
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;

                bs.Filter = "FullName like '%" + option + "%'";

                dataGridView1.DataSource = bs;
            }
            else
            {
                loadUsersData();
            }
        }

        private void filterDataByPersonID(string personID)
        {
            if (!string.IsNullOrEmpty(personID))
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "PersonID = " + personID;
                dataGridView1.DataSource = bs;
            }
            else
            {
                loadUsersData();
            }
        }

        private void filterDataByUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "UserName like '%" + userName + "%'";

                dataGridView1.DataSource = bs;
            }
            else
            {
                loadUsersData();
            }
        }

        private void filterDataByIsActive()
        {
            
            if(cbIsActiveFilter.Text == "Yes")
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "isActive = " + 1;
                dataGridView1.DataSource = bs;
            }else if(cbIsActiveFilter.Text == "No")
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "isActive = " + 0;
                dataGridView1.DataSource = bs;
            }
            else
            {
                return;
            }
        }

        private void cbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cbFilterOptions.SelectedIndex == 5)
            {
                lbFilterText.Visible = false;
                cbIsActiveFilter.Visible = true;
            }
            else if(cbFilterOptions.SelectedIndex == 0)
            {
                lbFilterText.Visible = false;
                cbIsActiveFilter.Visible = false;

            }
            else
            {
                lbFilterText.Visible = true;
                cbIsActiveFilter.Visible = false;
            }
            loadUsersData();
        }

        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbIsActiveFilter.SelectedIndex == 1)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "isActive = " + 1;
                dataGridView1.DataSource = bs;
            }else if(cbIsActiveFilter.SelectedIndex == 2)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "isActive = " + 0;
                dataGridView1.DataSource = bs;
            }
            else
            {
                loadUsersData();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateUser frmAddUser = new frmAddNewUpdateUser();
            frmAddUser.ShowDialog();
            loadUsersData();
        }

        private void showDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int userID;
            int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),out userID);
            frmUserInfo frmUserInfo = new frmUserInfo(userID);
            frmUserInfo.ShowDialog();
        }

        private void addNewUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateUser newUser = new frmAddNewUpdateUser();
            
            newUser.ShowDialog();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int userId;
            int personId;
            int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out userId);
            int.TryParse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), out personId);
            frmAddNewUpdateUser editUser = new frmAddNewUpdateUser(userId,personId);
            editUser.ShowDialog();
            loadUsersData();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int userId;
            int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out userId);
            if (clsUser.deleteUserById(userId))
            {
                MessageBox.Show("User delete Successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("user have data linked to it", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadUsersData();
        }
    }

    
}
