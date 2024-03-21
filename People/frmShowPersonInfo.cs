﻿using DVLD_PROJECT.People.Controls;
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
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo()
        {
            InitializeComponent();
        }

        public frmShowPersonInfo(string nationalNumber)
        {
            InitializeComponent();
            ctrlPersonCard1.loadPersonDataToControl(nationalNumber);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
