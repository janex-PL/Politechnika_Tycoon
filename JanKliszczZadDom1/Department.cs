using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanKliszczZadDom1
{
    class Department
    {
        // Nazwa wydziału
        public string DepartmentName { get; set; }
        // Liczba pracowników
        public int WorkersAmount { get; set; }

        // Podstawowa nagroda pieniężna
        public int MoneyBaseAward { get; set; }
        // Podstawowa nagroda prestiżu
        public int PrestigePointsBaseAward { get; set; }
        // Podstawowa nagroda studentów
        public int StudentBaseAward { get; set; }
        // Podstawowa nagroda prac naukowych
        public int SciencePaperBaseAward { get; set; }
        // Podstawowa nagroda wynalazków
        public int InventionsBaseAward { get; set; }

        // Podstawowa cena pieniężna
        public int MoneyBasePrice { get; set; }
        // Podstawowa cena prestiżowa
        public int PrestigePointsBasePrice { get; set; }
        

        // Poziom wydziału
        public int DepartmentLevel { get; set; }
        // Status aktywności wydziału
        public bool DepartmentIsWorking { get; set; }
        
        /// <summary>
        /// Tworzy nowy wydział
        /// </summary>
        /// <param name="departmentName"></param>
        /// <param name="workersAmount"></param>
        /// <param name="level"></param>
        /// <param name="departmentIsWorking"></param>
        public Department( string departmentName, int workersAmount, int level, bool departmentIsWorking)
        {
            DepartmentName = departmentName;
            WorkersAmount = workersAmount;
            MoneyBaseAward = 500 + (500 * (level-1));
            PrestigePointsBaseAward = 5 * level;
            StudentBaseAward = level;
            SciencePaperBaseAward = level;
            InventionsBaseAward = level;
            MoneyBasePrice = 1500 * (int) Math.Pow(3.0, (double) level - 1);
            PrestigePointsBasePrice = 10 * (int) Math.Pow(4.0, (double) level - 1);
            DepartmentLevel = level;
            DepartmentIsWorking = departmentIsWorking;
        }
        /// <summary>
        /// Zwraca informację o cenie zatrudnienia pracownika w postaci stringa
        /// </summary>
        /// <returns></returns>
        public string GetWorkerPriceString()
        {
            return $"Pieniądze: {GetCurrentMoneyPrice()}\nPunkty prestiżu: {GetCurrentPrestigePointsPrice()}";
        }
        /// <summary>
        /// Zwraca informacje o nagrodzie w formie stringa
        /// </summary>
        /// <returns></returns>
        public string GetPayloadString()
        {
            return $"Pieniądze: {GetMoneyPayload()}\nPrestiż: {GetPrestigePointsPayload()}\nStudenci: {GetStudentsPayload()}\nPrace naukowe: {GetSciencePapersPayload()}\nWynalazki: {GetInventionsPayload()}";
        }
        /// <summary>
        /// Zatrudnia nowego pracownika i aktywuje pracę wydziału
        /// </summary>
        public void HireNewWorker()
        {
            WorkersAmount++;
            if (DepartmentIsWorking == false)
                DepartmentIsWorking = true;
        }
        /// <summary>
        /// Zwraca aktualną cenę pienieżną zatrudnienia pracownika
        /// </summary>
        /// <returns></returns>
        public int GetCurrentMoneyPrice()
        {
            // Cena podstawowa, jeśli brak pracowników
            // Cena zmodyfikowana, jeśli są pracownicy
            return WorkersAmount == 0 ? MoneyBasePrice :MoneyBasePrice + (MoneyBasePrice * (WorkersAmount+1))/2;
        }
        /// <summary>
        /// Zwraca aktualną cenę prestiżową zatrudnienia pracownika
        /// </summary>
        /// <returns></returns>
        public int GetCurrentPrestigePointsPrice()
        {
            // Cena podstawowa, jeśli brak pracowników
            // Cena zmodyfikowana, jeśli są pracownicy
            return WorkersAmount == 0 ? PrestigePointsBasePrice : PrestigePointsBasePrice + (PrestigePointsBasePrice * (WorkersAmount+1))/2;
        }
        /// <summary>
        /// Zwraca aktualną nagrodę pieniężną
        /// </summary>
        /// <returns></returns>
        public int GetMoneyPayload()
        {
            return WorkersAmount == 0 ? 0 : MoneyBaseAward + (MoneyBaseAward*(WorkersAmount))/2;
        }
        /// <summary>
        /// Zwraca aktualną nagrodę prestiżową
        /// </summary>
        /// <returns></returns>
        public int GetPrestigePointsPayload()
        {
            return WorkersAmount == 0 ? 0 : PrestigePointsBaseAward +(PrestigePointsBaseAward * (WorkersAmount))/2;
        }
        /// <summary>
        /// Zwraca aktualną nagrodę studentów
        /// </summary>
        /// <returns></returns>
        public int GetStudentsPayload()
        {
            return StudentBaseAward * WorkersAmount / 5;
        }
        /// <summary>
        /// Zwraca aktualną nagrodę prac naukowych
        /// </summary>
        /// <returns></returns>
        public int GetSciencePapersPayload()
        {
            return SciencePaperBaseAward * WorkersAmount / 10;
        }
        /// <summary>
        /// Zwraca aktualną nagrodę wynalazków
        /// </summary>
        /// <returns></returns>
        public int GetInventionsPayload()
        {
            return InventionsBaseAward * WorkersAmount / 20;
        }

    }
}
