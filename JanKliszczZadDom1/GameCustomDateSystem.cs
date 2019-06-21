using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanKliszczZadDom1
{
    class GameCustomDateSystem
    {
        // Liczba lat
        public int Years { get; set; }
        // Liczba miesięcy
        public int Months { get; set; }
        // Liczba tygodni
        public int Weeks { get; set; }
        // Czas trwania jednego tygodnia
        public int WeekDuration { get; set; }

        /// <summary>
        /// Tworzy system czasowy dla nowej gry
        /// </summary>
        public GameCustomDateSystem()
        {
            Years = 1;
            Months = 1;
            Weeks = 1;
            WeekDuration = 10000;
        }
        /// <summary>
        /// Dodaje miniony tydzień i formatuje pozostałe pola czasu
        /// </summary>
        public void IncrementDate()
        {
            // Minął tydzień - dodaj tydzień
            Weeks++;
            // Minął miesiąc - dodaj miesiąc
            if (Weeks == 5)
            {
                Weeks = 1;
                Months++;
            }
            // Minął rok - dodaj rok
            if (Months == 13)
            {
                Months = 1;
                Years++;
            }
            
        }
        /// <summary>
        /// Zwraca aktualny czas w postaci string 
        /// </summary>
        /// <returns></returns>
        public string GetDateString()
        {
            return $"Tydzień: {Weeks}\nMiesiąc: {Months}\nRok: {Years}";
        }
    }
}
