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

namespace DVLD_PROJECT.People
{
    public partial class frmAddUpdatePerson : Form
    {
        enum eMode { addnew, update };

        private eMode mode;

        private string malePicPath = "C:\\Users\\KINSM\\Documents\\DVLD_PROJECT_ICONS\\Icons\\Male 512.png";

        private string femalePicPath = "C:\\Users\\KINSM\\Documents\\DVLD_PROJECT_ICONS\\Icons\\Female 512.png";




        public frmAddUpdatePerson()
        {
            InitializeComponent();
            initiateDateTime();
            mode = eMode.addnew;
            lbAddPerson.Text = "Add New Person";
        }
        public frmAddUpdatePerson(int personId)
        {
            InitializeComponent();
            initiateDateTime();
            loadPersonInfo(personId);
            mode = eMode.update;
            lbAddPerson.Text = "Update Person";
        }

        private void initiateDateTime()
        {
            int validYear = DateTime.Now.Year - 18;
            int currentMonth = DateTime.Now.Month;
            int currentDay = DateTime.Now.Day;
            dateTimePicker1.MaxDate = new DateTime(validYear, currentMonth, currentDay);
        }

        private void loadPersonInfo(int personId)
        {
            clsPerson person = clsPerson.find(personId);
            if(person != null)
            {
                lbPersonID.Text = personId.ToString();
                tbFirstName.Text = person.firstName;
                tbSecondName.Text = person.secondName;
                tbThirdName.Text = person.thirdName;
                tbLastName.Text = person.lastName;

                tbNationalNumb.Text = person.nationalNumber;
                tbEmail.Text = person.email;
                tbAddress.Text = person.addresse;
                tbPhone.Text = person.phoneNumber;

                if(person.gendor == 0)
                {
                    rbMale.Checked = true;
                    PersonImage.Load(malePicPath);
                    rbFemale.Checked = false;
                }
                else
                {
                    rbMale.Checked = false;
                    PersonImage.Load(femalePicPath);
                    rbFemale.Checked = true;
                }

                comboBox1.SelectedIndex = 90-1;

                dateTimePicker1.Value = person.dateOfBirth;

                //setting up the person picture :

                if (!person.imagePath.Equals("")){
                    PersonImage.SizeMode = PictureBoxSizeMode.Zoom;
                    PersonImage.Load(person.imagePath);
                }
                
            }
            
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                PersonImage.Load(malePicPath);
            }
            else
            {
                PersonImage.Load(femalePicPath);
            }
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  
            }
        }
    }
}
