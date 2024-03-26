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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_PROJECT.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public int personID { get; set; } = -1;


        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void txtFilterOption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterOption.SelectedIndex == 0 && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if(cbFilterOption.SelectedIndex == 0)
            {
                personID = Convert.ToInt32(txtFilterOption.Text);
                ctrlPersonCard1.loadPersonDataToControl(personID);
            }
            else
            {
                string nationalNumber = txtFilterOption.Text;
                ctrlPersonCard1.loadPersonDataToControl(nationalNumber);
            }
        }


        public void loadDataToControl(int personID)
        {
            txtFilterOption.Text = personID.ToString();
            cbFilterOption.SelectedIndex = 0;
            ctrlPersonCard1.loadPersonDataToControl(personID);
        }
        public void loadDataToControl(string nationalNumber)
        {
            txtFilterOption.Text = nationalNumber;
            cbFilterOption.SelectedIndex = 1;
            ctrlPersonCard1.loadPersonDataToControl(nationalNumber);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.dataBack += dataBack;

            frm.ShowDialog();
        }
        private void dataBack(object sender,int personID)
        {
            this.personID = personID;
            loadDataToControl(personID);
        }
    }
}
