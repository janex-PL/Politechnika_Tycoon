using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanKliszczZadDom1
{
    class UniversityStats
    {
        // Ilosć uzbieranych pieniędzy
        public int MoneyCollected { get; set; }
        // Ilość uzbieranych punktów prestiżu
        public int PrestigePointsCollected { get; set; }
        // Ilość uzbiernaych studentów
        public int StudentsCollected { get; set; }
        // Ilość uzbieranych prac naukowych
        public int SciencePapersCollected { get; set; }
        // Ilość uzbieranych wynalazków
        public int InventionsCollected { get; set; }

        /// <summary>
        /// Inicjalizuje początkowe wartości zasobów
        /// </summary>
        public UniversityStats()
        {
            MoneyCollected = 2000;
            PrestigePointsCollected = 10;
            StudentsCollected = 0;
            SciencePapersCollected = 0;
            InventionsCollected = 0;
        }
        /// <summary>
        /// Aktualizuje liczbę zasobów
        /// </summary>
        /// <param name="payloadList"></param>
        public void Update(List<int> payloadList)
        {
            MoneyCollected += payloadList[0];
            PrestigePointsCollected += payloadList[1];
            StudentsCollected += payloadList[2];
            SciencePapersCollected += payloadList[3];
            InventionsCollected += payloadList[4];
        }
        /// <summary>
        /// Zwraca informację o zasobach w postaci stringa
        /// </summary>
        /// <returns></returns>
        public string GetUniversityStatsString()
        {
            return 
                $"Pieniądze: {MoneyCollected}\nPunkty prestiżu: {PrestigePointsCollected}\nStudenci: {StudentsCollected}\nPrace naukowe: {SciencePapersCollected}\nWynalazki: {InventionsCollected}";
        }
        /// <summary>
        /// Zwraca liste dostępów do zasobów
        /// </summary>
        /// <returns></returns>
        public List<bool> GetAvailableStatsList()
        {
            return new List<bool>
            {
                MoneyCollected > 0,
                PrestigePointsCollected > 0,
                StudentsCollected > 0,
                SciencePapersCollected > 0,
                InventionsCollected > 0
            };
        }
    }
}
