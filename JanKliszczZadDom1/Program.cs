using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanKliszczZadDom1
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

            FormMainMenu formMainMenu = new FormMainMenu();

            Application.Run(formMainMenu);
            
            if (formMainMenu.AppReadyToStartGame)
            {
                string universityName = formMainMenu.UniversityName;
                string rectorName = formMainMenu.RectorName;
                formMainMenu.Dispose();
                Application.Run(new FormGame(universityName,rectorName));
            }


        }
    }
}
