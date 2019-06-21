using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanKliszczZadDom1
{
    class GameEvent
    {
        // Tytuł zdarzenia
        public string EventTitle { get; set; }
        // Wiadomość zdarzenia
        public string EventContent { get; set; }
        // Odpowiedź A
        public string EventAnswerA { get; set; }
        // Odpowiedź B
        public string EventAnswerB { get; set; }
        // Odpowiedź C
        public string EventAnswerC { get; set; }
        // Lista procentowych wartości kary
        public List<int> PenaltyStatPercentageList { get; set; }
        // Lista zasobów, które mogą zostać zabrane
        public List<string> PenaltyStatNameList { get; set; }

        /// <summary>
        /// Tworzy nowy event ze zdefiniowaną zawartością
        /// </summary>
        /// <param name="eventID"></param>
        public GameEvent(int eventID)
        {
            PenaltyStatPercentageList = new List<int>
            {
                25,
                50,
                75
            };
            switch (eventID)
            {
                case 1:
                {
                    EventTitle = "Sesja nadeszła!";
                    EventContent =
                        "Magnificencjo Rektorze, sesja nadeszła!\nWszyscy studenci na uczelni wpadli w panikę,\ntrzeba podjąć natychmiastowe działania!";
                    EventAnswerA = "Pracownicy mają ich uczyć przez całą dobę!";
                    EventAnswerB = "Zróbmy łatwiejsze egzaminy!";
                    EventAnswerC = "Niech studenci wiedzą, że sesja ich zniszczy!";
                    PenaltyStatNameList = new List<string>
                    {
                        "Pieniądze",
                        "Prestiż",
                        "Studenci"
                    };
                    break;
                }
                case 2:
                {
                    EventTitle = "Wizyta ministra!";
                    EventContent =
                        "Magnificencjo Rektorze, minister szkolnictwa\nwyższego przyjechał do nas w ramach wizyty\nkontrolnej. Jest bardzo niezadowolony rozrzutnością\nnaszej politechniki, konieczne są natychmiastowe\nzmiany w strukturze uczelni!";
                    EventAnswerA = "Przekupmy go naszymi najnowocześniejszymi wynalazkami!";
                    EventAnswerB = "Thanos pomoże mi pozbyć się studentów!";
                    EventAnswerC = "Hahaha! Niech on mnie nie rozśmiesza...";
                    PenaltyStatNameList = new List<string>
                    {
                        "Wynalazki",
                        "Studenci",
                        "Pieniądze"
                    };
                    break;
                }
                default:
                    break;
            }
        }
    }
}
