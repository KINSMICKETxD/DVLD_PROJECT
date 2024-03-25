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

namespace DVLD_PROJECT.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {

        private clsPerson person;
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public ctrlPersonCard(string nationalNumber)
        {
            InitializeComponent();
            loadPersonDataToControl(nationalNumber);
        }

        public void loadPersonDataToControl(string nationalNumber)
        {
            person = clsPerson.findByNationalNumb(nationalNumber);
            lbPersonId.Text = person.personId.ToString();
            lbName.Text = person.firstName + " " + person.lastName;
            lbNationalNum.Text = person.nationalNumber.ToString();
            if(person.gendor == 0)
            {
                lbGendor.Text = "Male";
            }
            else
            {
                lbGendor.Text = "Female";
            }
            lbEmail.Text = person.email;
            lbAddress.Text = person.addresse;
            lbDateOfBirth.Text = person.dateOfBirth.ToShortDateString();
            lbPhone.Text = person.phoneNumber;
            lbCountry.Text = person.countryName;
            loadImage(person.imagePath);
        }

        public void loadPersonDataToControl(int personID)
        {
            person = clsPerson.find(personID);
            if(person != null)
            {
                lbPersonId.Text = person.personId.ToString();
                lbName.Text = person.firstName + " " + person.lastName;
                lbNationalNum.Text = person.nationalNumber.ToString();
                if (person.gendor == 0)
                {
                    lbGendor.Text = "Male";
                }
                else
                {
                    lbGendor.Text = "Female";
                }
                lbEmail.Text = person.email;
                lbAddress.Text = person.addresse;
                lbDateOfBirth.Text = person.dateOfBirth.ToShortDateString();
                lbPhone.Text = person.phoneNumber;
                lbCountry.Text = person.countryName;
                loadImage(person.imagePath);
            }
            else
            {
                MessageBox.Show("Person Doesn't exist !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
        private void loadImage(string imagePath)
        {
            if (imagePath != null)
            {
                try
                {
                    PersonPicture.Load(imagePath);
                }catch(Exception ex) {
                    loadDefaultPicture(lbGendor.Text);
                }
            }
            else
            {
                loadDefaultPicture(lbGendor.Text);
            }
        }

        private void loadDefaultPicture(string gendor)
        {
            if (gendor.Equals("Male"))
            {
                PersonPicture.Image = Properties.Resources.Male_512;
            }
            else
            {
                PersonPicture.Image = Properties.Resources.Female_512;

            }
        }

        private void lnkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(int.TryParse(lbPersonId.Text,out int personId))
            {
                frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson(personId);
                frmAddUpdatePerson.ShowDialog();
                loadPersonDataToControl(person.nationalNumber);
            }
            
        }




    }
}
