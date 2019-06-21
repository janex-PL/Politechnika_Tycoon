using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanKliszczZadDom1
{
    public partial class FormMainMenu : Form
    {
        // Gotowść aplikacji do gry
        public bool AppReadyToStartGame { get; private set; }
        // Nazwa uczelni
        public string UniversityName { get; private set; }
        // Imię i nazwisko rektora
        public string RectorName { get; private set; }
        public FormMainMenu()
        {
            InitializeComponent();
            AppReadyToStartGame = false;
        }

        /// <summary>
        /// Zamyka program z poziomu menu głównego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
           Close();
        }

        /// <summary>
        /// Zaczyna nową grę i zamyka okno menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartNewGame_Click(object sender, EventArgs e)
        {
            UniversityName = textBoxUniversityName.Text;
            RectorName = textBoxRectorName.Text;
            AppReadyToStartGame = true;
            Close();
        }
    }
}
