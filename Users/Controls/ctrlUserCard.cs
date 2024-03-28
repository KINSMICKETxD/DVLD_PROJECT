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

namespace DVLD_PROJECT.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        public string password { private set; get; }

        public int userId { private set; get; }
        
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        public void loadUserDataToControl(int userId)
        {
            clsUser user = clsUser.find(userId);
            ctrlPersonCard1.loadPersonDataToControl(user.personId);
            this.userId = user.userid;
            lbUserID.Text = user.userid.ToString();
            lbUserName.Text = user.userName.ToString();
            password = user.password.ToString();
            if (user.isActive)
            {
                lbIsActive.Text = "Yes";
            }
            else
            {
                lbIsActive.Text = "false";
            }
        }
    }
}
