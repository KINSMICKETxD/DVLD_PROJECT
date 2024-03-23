using DVLD_PROJECT.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_PROJECT
{
    public partial class frmMain : Form
    {

        public bool isSignOut { get; private set; }
        public frmMain()
        {
            InitializeComponent();
            isSignOut = false;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frmListPeople = new frmListPeople();

            frmListPeople.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSignOut = true;
            this.Close();
            
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
