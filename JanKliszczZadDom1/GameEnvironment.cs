using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanKliszczZadDom1
{
    class GameEnvironment
    {
        // Lista wszystkich wydziałów
        public List<Department> DepartmentList { get; set; }
        // Statystyki uzbiernaych zasobów
        public UniversityStats CurrentStats { get; set; }
        public List<int> SpeedUpgradePriceList { get; set; }
        // System rzeczywistego czasu gry
        public GameCustomDateSystem DateSystem { get; set; }
        // Podstawowa wartość czasu, po którym następuje postęp prac wydziałów
        public int ProgressBarBaseTimeValue { get; set; }
        // Poziom przyspieszenia licznika logicznego
        public int ProgressBarSpeedUpLevel { get; set; }
        // Wartość licznika logicznego, przy której mozna dokonać jego resetu
        public int LogicCounterRefreshValue { get; set; }
        // Nazwa uniwersytetu
        public string UniversityName { get; set; }
        // Imię i nazwisko rektora
        public string RectorName { get; set; }
        // Okienko eventu katastrofy
        private FormGameEvent IncomingEventForm { get; set; }

        /// <summary>
        /// Tworzy logiczne środowisko do gry
        /// </summary>
        public GameEnvironment()
        {
            CurrentStats = new UniversityStats();
            DateSystem = new GameCustomDateSystem();
            DepartmentList = new List<Department>();
            SpeedUpgradePriceList = new List<int>()
            {
                100000,
                1000,
                1000,
                100,
                100

            };
            ProgressBarBaseTimeValue = 50;
            ProgressBarSpeedUpLevel = 0;
            // Lista nazw wydziałów
            List<string> departmentNamesList = new List<string>
            {
                "Zarządzania",
                "Chemiczny",
                "Mechaniczny",
                "Architektury",
                "Elektroniki"
            };
            for (int i = 0; i < departmentNamesList.Count; i++)
            {
                // modyfikator poziomu
                int levelModifier = i + 1;
                DepartmentList.Add(new Department(departmentNamesList[i],0,levelModifier,false));
            }
            UpdateLogicCounterRefreshValue();


        }
        /// <summary>
        /// Aktualizuje wartość licznika logicznego do resetowania
        /// </summary>
        public void UpdateLogicCounterRefreshValue()
        {
            // zmienna pomocnicza do obliczania NWD
            int result = 1;
            for (int i = ProgressBarBaseTimeValue; i < ProgressBarBaseTimeValue + DepartmentList.Count * 10; i += 10)
            { 
                result *= i;
            }
            LogicCounterRefreshValue = result;
        }

        public void UpdateSpeedUpgradePriceList()
        {
            for (int i = 0; i < SpeedUpgradePriceList.Count; i++)
                SpeedUpgradePriceList[i] += SpeedUpgradePriceList[i] * ProgressBarSpeedUpLevel;
        }
        /// <summary>
        /// Sprawdza, czy wydzial może zatrudnić pracownika
        /// </summary>
        /// <param name="departmentIndex"></param>
        /// <returns></returns>
        public bool IsEmploymentAvailable(int departmentIndex)
        {
            if (DepartmentList[departmentIndex].GetCurrentMoneyPrice() > CurrentStats.MoneyCollected
                     || DepartmentList[departmentIndex].GetCurrentPrestigePointsPrice() >
                     CurrentStats.PrestigePointsCollected)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Odbiera nagrodę od wydziału za wykonaną pracę
        /// </summary>
        /// <param name="departmentIndex"></param>
        public void GetRewardFromDepartment(int departmentIndex)
        {
            // Lista z poszczególnymi wartościami zasobów do odbioru
            List<int> payloadList = new List<int>
            {
                DepartmentList[departmentIndex].GetMoneyPayload(),
                DepartmentList[departmentIndex].GetPrestigePointsPayload(),
                DepartmentList[departmentIndex].GetStudentsPayload(),
                DepartmentList[departmentIndex].GetSciencePapersPayload(),
                DepartmentList[departmentIndex].GetInventionsPayload()
            };
            CurrentStats.Update(payloadList);
        }
        /// <summary>
        /// Zatrudniania pracownika na wydziale
        /// </summary>
        /// <param name="departmentIndex"></param>
        public void HireWorkerInDepartment(int departmentIndex)
        {
            // Lista z wartościami poszczególnych zasobów do zabrania
            List<int> priceList = new List<int>
            {
                DepartmentList[departmentIndex].GetCurrentMoneyPrice()*(-1),
                DepartmentList[departmentIndex].GetCurrentPrestigePointsPrice()*(-1),
                0,
                0,
                0
            };
            CurrentStats.Update(priceList);
            DepartmentList[departmentIndex].HireNewWorker();
        }
        /// <summary>
        /// Zwraca czas, po którym wydział aktualizuje postęp
        /// </summary>
        /// <param name="departmentIndex"></param>
        /// <returns></returns>
        public int GetPayloadActivationTimeInterval(int departmentIndex)
        {
            // czas pierwotny, bez ulepszenia
            int primaryTime = ProgressBarBaseTimeValue + 10 * departmentIndex;
            return primaryTime - 10*ProgressBarSpeedUpLevel;
        }
        /// <summary>
        /// Zwraca wartość postępu cyfryzacji w procentach
        /// </summary>
        /// <returns></returns>
        public string GetSpeedUpPercentageString()
        {
            return (ProgressBarSpeedUpLevel * 25).ToString() + "%";
        }
        /// <summary>
        /// Wywołuje event katastrofę
        /// </summary>
        /// <param name="eventID"></param>
        public void SummonGameEvent(int eventID)
        {
            IncomingEventForm = new FormGameEvent(eventID, CurrentStats.GetAvailableStatsList());
            IncomingEventForm.ShowDialog();
            List<int> penaltyList = new List<int>
            {
                0,
                0,
                0,
                0,
                0
            };
            switch (IncomingEventForm.SelectedPenaltyStatName)
            {
                case "Pieniądze":
                {
                    penaltyList[0] = -1 * ( CurrentStats.MoneyCollected * IncomingEventForm.SelectedPenaltyPercentage / 100);
                    break;
                }
                case "Prestiż":
                {
                    penaltyList[1] = -1 * ( CurrentStats.PrestigePointsCollected * IncomingEventForm.SelectedPenaltyPercentage / 100);
                    break;
                }
                case "Studenci":
                {
                    penaltyList[2] = -1 * ( CurrentStats.StudentsCollected * IncomingEventForm.SelectedPenaltyPercentage / 100);
                    break;
                }
                case "Prace naukowe":
                {
                    penaltyList[3] = -1 * (CurrentStats.SciencePapersCollected * IncomingEventForm.SelectedPenaltyPercentage / 100);
                    break;
                }
                case "Wynalazki":
                {
                    penaltyList[4] = -1 * (CurrentStats.InventionsCollected * IncomingEventForm.SelectedPenaltyPercentage / 100);
                    break;
                }

            }
            CurrentStats.Update(penaltyList);
            IncomingEventForm.Dispose();
        }

        

    }
}
