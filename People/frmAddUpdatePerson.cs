using DVLD_BUSINESS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_PROJECT.People
{
    public partial class frmAddUpdatePerson : Form
    {
        enum eMode { addnew, update };

        private eMode mode;

        private string imagePath;

        private string oldImagePath;


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
            loadPersonInfoToTheForm(personId);
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

        private void loadPersonInfoToTheForm(int personId)
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
                    PersonImage.Image = Properties.Resources.Male_512;
                    rbFemale.Checked = false;
                }
                else
                {
                    rbMale.Checked = false;
                    PersonImage.Image = Properties.Resources.Female_512;
                    rbFemale.Checked = true;
                }

                comboBox1.SelectedIndex = person.nationalityCountryID-1;

                dateTimePicker1.Value = person.dateOfBirth;

                //setting up the person picture :

                loadPersonImage(person.imagePath);



            }
            
        }
        private void loadPersonImage(string imagePath)  
        {
            PersonImage.SizeMode = PictureBoxSizeMode.Zoom;

            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    PersonImage.Load(imagePath);
                    linkRemoveImage.Visible = true;
                }
                catch (Exception ex)
                {
                    if (rbMale.Checked)
                    {
                        PersonImage.Image = Properties.Resources.Male_512;
                    }
                    else
                    {
                        PersonImage.Image = Properties.Resources.Female_512;
                    }
                }
            }
            

        
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                PersonImage.Image = Properties.Resources.Male_512;
            }
            else
            {
                PersonImage.Image = Properties.Resources.Female_512;
            }
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  
            }
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                e.Cancel = true;
                tbFirstName.Focus();
                errorProvider1.SetError(tbFirstName, "FirstName should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbFirstName, "");
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                PersonImage.Image = Properties.Resources.Female_512;
            }
            else
            {
                PersonImage.Image = Properties.Resources.Male_512;
            }
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                e.Cancel = true;
                tbLastName.Focus();
                errorProvider1.SetError(tbLastName, "LastName should have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbLastName, "");
            }
        }

        private void tbNationalNumb_Validating(object sender, CancelEventArgs e)
        {
            if(clsPerson.IsPersonExist(tbNationalNumb.Text) && mode==eMode.addnew)
            {
                e.Cancel= true;
                tbNationalNumb.Focus();
                errorProvider1.SetError(tbNationalNumb, "National Number is used for another person!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNationalNumb, "");
            }
            if (string.IsNullOrWhiteSpace(tbNationalNumb.Text))
            {
                e.Cancel = true;
                tbNationalNumb.Focus();
                errorProvider1.SetError(tbNationalNumb, "National number is required !");
            }

        }

        private bool isEmailValid(string email)
        {

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";


            Match match = Regex.Match(email, pattern);


            return match.Success;
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!isEmailValid(tbEmail.Text))
            {
                e.Cancel = true;
                tbEmail.Focus();
                errorProvider1.SetError(tbEmail, "Please enter a valid email!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbEmail, "");
            }
        }

        private void tbAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                e.Cancel = true;
                tbAddress.Focus();
                errorProvider1.SetError(tbAddress, "Address is required !");
            }
        }

        private void linkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to delete this image","delete Image",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (rbFemale.Checked)
                {
                    PersonImage.Image = Properties.Resources.Female_512;
                }
                else
                {
                    PersonImage.Image = Properties.Resources.Male_512;
                }
                linkRemoveImage.Visible = false;
                imagePath = null;
            }

        }

        private void linkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            openFileDialog1.InitialDirectory = @"c:\";

            openFileDialog1.Title = "Open";

            openFileDialog1.DefaultExt = "png";

            openFileDialog1.Filter = "Image Files (*.png)|*.png";

            openFileDialog1.FilterIndex = 0;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                try
                {
                    PersonImage.Load(openFileDialog1.FileName);
                    linkRemoveImage.Visible = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error occurs while loading the image !","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsPerson person;
            if (mode == eMode.update)
            {
               person  = clsPerson.find(int.Parse(lbPersonID.Text));
                
            }
            else
            {
                
               person = new clsPerson();
            }

            loadPersonInfoFromTheForm(person);


            if (person.savePerson())
            {
                loadPersonInfoToTheForm(person.personId);
                mode = eMode.update;
                lbAddPerson.Text = "Update Person";
                MessageBox.Show("Person Saved successfully !","Success Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error occurs while saving the Person !","Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void loadPersonInfoFromTheForm(clsPerson person)
        {
            person.nationalNumber = tbNationalNumb.Text;
            person.firstName = tbFirstName.Text;
            person.secondName = tbSecondName.Text;
            person.thirdName = tbThirdName.Text;
            person.lastName = tbLastName.Text;

            if (rbMale.Checked)
            {
                person.gendor = 0;
            }
            else
            {
                person.gendor = 1;
            }
            person.email = tbEmail.Text;
            person.addresse = tbAddress.Text;

            person.dateOfBirth = dateTimePicker1.Value;
            person.phoneNumber = tbPhone.Text;
            person.nationalityCountryID = comboBox1.SelectedIndex+1;

            CopyAndPasteNewImage(person);
        }

        private void CopyAndPasteNewImage(clsPerson person)
        {

            if (linkRemoveImage.Visible && imagePath != null)
            {
                if(person.imagePath != null)
                {
                    try
                    {
                        File.Delete(person.imagePath);
                        
                    }catch (Exception) { }
                }
                try
                {
                    string destination = @"C:\DVLD_PEOPLE_IMAGES\" + Guid.NewGuid().ToString() + ".png";
                    File.Copy(imagePath, destination);
                    person.imagePath = destination;
                }
                catch (Exception ex) { }
            }
            if (linkRemoveImage.Visible == false)
            {
                try
                {
                    File.Delete(person.imagePath);
                }
                catch (Exception) { }
                person.imagePath = null;
            }


        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPhone.Text))
            {
                e.Cancel = true;
                tbPhone.Focus();
                errorProvider1.SetError(tbPhone, "Phone number is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPhone, "");
            }
        }
    }
}
