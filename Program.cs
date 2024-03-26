using DVLD_PROJECT.People;
using DVLD_PROJECT.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_PROJECT
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //callLoginForm(new frmLogin());
            Application.Run(new frmUserInfo(32));

        }

        private static void callLoginForm(frmLogin frmLogin)
        {
            Application.Run(frmLogin);
            if(frmLogin.isUserAuthenticated)
            {
                callMainForm(new frmMain());
            }
        } 
        private static void callMainForm(frmMain frmMain)
        {
            Application.Run(frmMain);
            if (frmMain.isSignOut)
            {
                callLoginForm(new frmLogin());
            }
        }
    }
}
