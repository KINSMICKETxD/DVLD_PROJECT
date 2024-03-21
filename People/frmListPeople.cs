using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BUSINESS;
namespace DVLD_PROJECT.People
{
    public partial class frmListPeople : Form
    {
        public frmListPeople()
        {
            InitializeComponent();
            loadDataToGridView();
            label4.Text = (dataGridView1.RowCount-1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != 0) {
            
                filterOption.Visible = true;
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.ShowDialog();
        }

      

        private void loadDataToGridView()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14); // Change the font size to 12pt
            DataTable dt = clsPerson.getPeople();

            dataGridView1.DataSource = dt;

            if(dataGridView1.Rows.Count>0 )
            {
                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "National No.";
                dataGridView1.Columns[1].Width = 120;

                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "Second Name";
                dataGridView1.Columns[3].Width = 140;

                dataGridView1.Columns[4].HeaderText = "Third Name";
                dataGridView1.Columns[4].Width = 120;

                dataGridView1.Columns[5].HeaderText = "Last Name";
                dataGridView1.Columns[5].Width = 120;

                dataGridView1.Columns[6].HeaderText = "Gendor";
                dataGridView1.Columns[6].Width = 120;

                dataGridView1.Columns[7].HeaderText = "Date Of Birth";
                dataGridView1.Columns[7].Width = 140;

                dataGridView1.Columns[8].HeaderText = "Nationality";
                dataGridView1.Columns[8].Width = 120;

                dataGridView1.Columns[9].HeaderText = "Phone";
                dataGridView1.Columns[9].Width = 140;

                dataGridView1.Columns[10].HeaderText = "Email";
                dataGridView1.Columns[10].Width = 400;
            }
            
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string nationalNumber = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                frmShowPersonInfo frmShowPersonInfo = new frmShowPersonInfo(nationalNumber);
                frmShowPersonInfo.ShowDialog();
            }
        }

        private void tsmAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.ShowDialog();
            loadDataToGridView();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string strpersonID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                int.TryParse(strpersonID, out int personID);
                frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson(personID);
                frmAddUpdatePerson.ShowDialog();
                loadDataToGridView();
            }
            
        }

        private void tsmDeletePerson_Click(object sender, EventArgs e)
        {
            string strpersonID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int.TryParse(strpersonID, out int personID);

            if (MessageBox.Show("Are you sure you want to delete this Person ?","Confirm Delete",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.deletePersonById(personID))
                {
                    MessageBox.Show("Person Deleted Successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Person was not deleted because it has data linked to it","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            loadDataToGridView();
        }
    }
}
