using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace FirstDxpTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            //Application.Run(new Form1());
            Application.Run(new LoginForm());
            //Application.Run(new Test());
            //Application.Run(new Data());
            //Application.Run(new GridControl());
            //Application.Run(new GridView());
            //Application.Run(new ChartControl());
            //Application.Run(new Dev_01());
        }
    }
}
