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
    public partial class FormGameEvent : Form
    {
        // Informacje na temat eventu katastrofy
        private GameEvent CurrentEvent { get; set; }
        // Lista wszystkich przycisków odpowiedzi
        public List<Button> ResponseButtonList { get; set;}
        // Nazwa wybranego zasobu do utraty
        public string SelectedPenaltyStatName { get; set; }
        // Liczba procentowa wybranego zasobu do utraty
        public int SelectedPenaltyPercentage { get; set; }
    
        /// <summary>
        /// Inicjalizuje okno eventu katastrofy
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="avaiableStats"></param>
        public FormGameEvent(int eventID , List<bool> avaiableStats )
        {
            InitializeComponent();
            
            CurrentEvent = new GameEvent(eventID);
            ResponseButtonList = new List<Button>
            {
                buttonEventResponse1,
                buttonEventResponse2,
                buttonEventResponse3
            };
            labelEventTitle.Text = CurrentEvent.EventTitle;
            labelEventContent.Text = CurrentEvent.EventContent;
            buttonEventResponse1.Text = CurrentEvent.EventAnswerA;
            buttonEventResponse2.Text = CurrentEvent.EventAnswerB;
            buttonEventResponse3.Text = CurrentEvent.EventAnswerC;
            labelEventResultA.Text =
                $"{CurrentEvent.PenaltyStatNameList[0]}: -{CurrentEvent.PenaltyStatPercentageList[0].ToString()}%";
            labelEventResultB.Text =
                $"{CurrentEvent.PenaltyStatNameList[1]}: -{CurrentEvent.PenaltyStatPercentageList[1].ToString()}%";
            labelEventResultC.Text =
                $"{CurrentEvent.PenaltyStatNameList[2]}: -{CurrentEvent.PenaltyStatPercentageList[2].ToString()}%";
            CheckButtonAvaibility(avaiableStats);
        }
        /// <summary>
        /// Zmienia dostępność do przycisku w zależności od dostępności zasobów
        /// </summary>
        /// <param name="avaiableStats"></param>
        private void CheckButtonAvaibility(List<bool> avaiableStats)
        {
            for (int i = 0; i < CurrentEvent.PenaltyStatNameList.Count; i++)
            {
                switch (CurrentEvent.PenaltyStatNameList[i])
                {
                    case "Pieniądze":
                    {
                        ResponseButtonList[i].Enabled = avaiableStats[0];
                        ResponseButtonList[i].BackColor = avaiableStats[0] ? Color.Green : Color.Gray;
                            break;
                    }
                    case "Prestiż":
                    {
                        ResponseButtonList[i].Enabled = avaiableStats[1];
                        ResponseButtonList[i].BackColor = avaiableStats[1] ? Color.Green : Color.Gray;
                            break;
                    }
                    case "Studenci":
                    {
                        ResponseButtonList[i].Enabled = avaiableStats[2];
                        ResponseButtonList[i].BackColor = avaiableStats[2] ? Color.Green : Color.Gray;
                            break;
                    }
                    case "Prace naukowe":
                    {
                        ResponseButtonList[i].Enabled = avaiableStats[3];
                        ResponseButtonList[i].BackColor = avaiableStats[3] ? Color.Green : Color.Gray;
                            break;
                    }
                    case "Wynalazki":
                    {
                        ResponseButtonList[i].Enabled = avaiableStats[4];
                        ResponseButtonList[i].BackColor = avaiableStats[4] ? Color.Green : Color.Gray;
                            break;
                    }
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Ustawia wybraną karę do odczytu i zamyka okno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEventResponse_Click(object sender, EventArgs e)
        {
            // przycisk, który wywołał odpowiedź
            Button senderButton = (Button) sender;
            // indeks naciśniętego przycisku
            int responesIndex = Int32.Parse(senderButton.Name[senderButton.Name.Length - 1].ToString())-1;
            SelectedPenaltyStatName = CurrentEvent.PenaltyStatNameList[responesIndex];
            SelectedPenaltyPercentage = CurrentEvent.PenaltyStatPercentageList[responesIndex];
            Close();
        }
    }
}
