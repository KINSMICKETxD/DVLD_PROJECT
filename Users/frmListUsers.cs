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
    }

    
}
