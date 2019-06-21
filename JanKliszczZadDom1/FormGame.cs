using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace JanKliszczZadDom1
{

    public partial class FormGame : Form
    {
        // Logiczny licznik czasu dla pasków postępu
        public int LogicGameTimeCounter { get; set; }
        // Lista wszystkich pasków postępu
        public List<VerticalProgressBar> VerticalProgressBarList { get; set; }
        // Lista wszystkich przycisków zatrudniania
        public List<Button> EmployButtonList { get; set; }
        // Lista wszystkich etykiet z nazwami wydziałów
        public List<Label> CustomDepartmentNameLabelList { get; set; }
        // Lista wszystkich etykiet z liczbami pracowników
        public List<Label> DepartmentWorkersAmountLabelList { get; set; }
        // Lista wszystkich etykiet z cenami zatrudnienia
        public List<Label> DepartmentWorkersPriceLabelList { get; set; }
        // Lista wszystkich etykiet z nagrodami
        public List<Label> PayloadLabelList { get; set; }
        // Logiczne środowisko gry
        private GameEnvironment WorkingGameEnvironment { get; set; }
        
        /// <summary>
        /// Inicijalizuje okno do gry
        /// </summary>
        /// <param name="universityName"></param>
        /// <param name="rectorName"></param>
        public FormGame(string universityName, string rectorName)
        {
            InitializeComponent();
            VerticalProgressBarList = new List<VerticalProgressBar>
            {
                verticalProgressBarLevel1,
                verticalProgressBarLevel2,
                verticalProgressBarLevel3,
                verticalProgressBarLevel4,
                verticalProgressBarLevel5
            };
            EmployButtonList = new List<Button>
            {
                buttonEmployLevel1,
                buttonEmployLevel2,
                buttonEmployLevel3,
                buttonEmployLevel4,
                buttonEmployLevel5
            };
            CustomDepartmentNameLabelList = new List<Label>
            {
                labelCustomDepartmentNameLevel1,
                labelCustomDepartmentNameLevel2,
                labelCustomDepartmentNameLevel3,
                labelCustomDepartmentNameLevel4,
                labelCustomDepartmentNameLevel5
            };
            DepartmentWorkersAmountLabelList = new List<Label>
            {
                labelWorkersAmountLevel1,
                labelWorkersAmountLevel2,
                labelWorkersAmountLevel3,
                labelWorkersAmountLevel4,
                labelWorkersAmountLevel5
            };
            DepartmentWorkersPriceLabelList = new List<Label>()
            {
                labelWorkerPriceLevel1,
                labelWorkerPriceLevel2,
                labelWorkerPriceLevel3,
                labelWorkerPriceLevel4,
                labelWorkerPriceLevel5
            };
            PayloadLabelList = new List<Label>()
            {
                labelPayloadLevel1,
                labelPayloadLevel2,
                labelPayloadLevel3,
                labelPayloadLevel4,
                labelPayloadLevel5
            };

            WorkingGameEnvironment = new GameEnvironment();

            WorkingGameEnvironment.UniversityName = universityName;
            WorkingGameEnvironment.RectorName = rectorName;
            labelUniversityName.Text = universityName;
            labelRectorName.Text = rectorName;

            for (int i = 0; i < WorkingGameEnvironment.DepartmentList.Count; i++)
            {
                UpdateWorkersAmount(i);
                UpdateWorkerPriceLabel(i);
                UpdatePayloadLabel(i);
            }
            UpdateEmployButtons();
            UpdateDepartmentNameLabels();
            UpdateGameDateTimeLabel();
            UpdateUniversityStatsLabel();
            UpdateSpeedUpgradePriceLabelAndButton();
            timerRealGameTime.Interval = WorkingGameEnvironment.DateSystem.WeekDuration;
            timerLogicGameTime.Start();
            timerRealGameTime.Start();
        }
        /// <summary>
        /// Aktualizuje etykiety z nazwami wydziałów
        /// </summary>
        private void UpdateDepartmentNameLabels()
        {
            for (int i = 0; i < CustomDepartmentNameLabelList.Count; i++)
            {
                CustomDepartmentNameLabelList[i].Text = WorkingGameEnvironment.DepartmentList[i].DepartmentName;
            }
        }
        /// <summary>
        /// Aktualizuje przycisk i informacje związane z ulepszeniem prędkości
        /// </summary>
        public void UpdateSpeedUpgradePriceLabelAndButton()
        {
            buttonUpgradeSpeedUp.Enabled = false;
            buttonUpgradeSpeedUp.BackColor = Color.Gray;
            labelSpeedUpgradePrice.Text = $"Pieniądze: {WorkingGameEnvironment.SpeedUpgradePriceList[0]}\n" +
                                          $"Prestiż: {WorkingGameEnvironment.SpeedUpgradePriceList[1]}\n" +
                                          $"Studenci: {WorkingGameEnvironment.SpeedUpgradePriceList[2]}\n" +
                                          $"Prace naukowe: {WorkingGameEnvironment.SpeedUpgradePriceList[3]}\n" +
                                          $"Wynalazki: {WorkingGameEnvironment.SpeedUpgradePriceList[4]}";

            if (WorkingGameEnvironment.SpeedUpgradePriceList[0] > WorkingGameEnvironment.CurrentStats.MoneyCollected)
                return;
            if (WorkingGameEnvironment.SpeedUpgradePriceList[1] > WorkingGameEnvironment.CurrentStats.PrestigePointsCollected)
                return;
            if (WorkingGameEnvironment.SpeedUpgradePriceList[2] > WorkingGameEnvironment.CurrentStats.StudentsCollected)
                return;
            if (WorkingGameEnvironment.SpeedUpgradePriceList[3] > WorkingGameEnvironment.CurrentStats.SciencePapersCollected)
                return;
            if (WorkingGameEnvironment.SpeedUpgradePriceList[4] > WorkingGameEnvironment.CurrentStats.InventionsCollected)
                return;
            buttonUpgradeSpeedUp.Enabled = true;
            buttonUpgradeSpeedUp.BackColor = Color.Green;


        }
        /// <summary>
        /// Aktualizuje logiczny licznik czasu i zeruje licznik, gdy osiąga wartość największego wspólnego dzielnika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerLogicGameTime_Tick(object sender, EventArgs e)
        {
            LogicGameTimeCounter += 10;
            UpdateProgressBars();
            if (LogicGameTimeCounter % WorkingGameEnvironment.LogicCounterRefreshValue == 0)
            {
                LogicGameTimeCounter = 0;
            }
            
        }
        /// <summary>
        /// Aktualizuje nazwy wydziałów w oknie
        /// </summary>
        private void UpdateGameDateTimeLabel()
        {
            labelGameDateTime.Text = WorkingGameEnvironment.DateSystem.GetDateString();
        }
        /// <summary>
        /// Ustawia dostępność przycisków zatrudnienia w zależności od posiadanych zasobów
        /// </summary>
        private void UpdateEmployButtons()
        {
            for (int i = 0; i < EmployButtonList.Count; i++)
            {
                bool isEmploymentAvaiable = WorkingGameEnvironment.IsEmploymentAvailable(i);
                EmployButtonList[i].Enabled = isEmploymentAvaiable;
                EmployButtonList[i].BackColor = isEmploymentAvaiable ? Color.Green : Color.Gray;
            }
        }
        /// <summary>
        /// Aktualizuje paski postępu oraz aktywuje nagrodę, gdy pasek zostanie wypełniony
        /// </summary>
        private void UpdateProgressBars()
        {
            for (int i = 0; i < VerticalProgressBarList.Count; i++)
            {
                int activationTime = WorkingGameEnvironment.GetPayloadActivationTimeInterval(i);
                if (WorkingGameEnvironment.DepartmentList[i].DepartmentIsWorking && LogicGameTimeCounter % (activationTime) == 0)
                {
                    if (VerticalProgressBarList[i].Value == 100)
                    {
                        VerticalProgressBarList[i].Value = 0;
                        WorkingGameEnvironment.GetRewardFromDepartment(i);
                        UpdateUniversityStatsLabel();
                        UpdateSpeedUpgradePriceLabelAndButton();
                        UpdateEmployButtons();
                    }
                    else
                        VerticalProgressBarList[i].Increment(2);
                }
            }
        }
        /// <summary>
        /// Aktualizuje modyfikator szybkości
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeSpeedUp_Click(object sender, EventArgs e)
        {
            if (WorkingGameEnvironment.ProgressBarSpeedUpLevel < 4)
            {
                WorkingGameEnvironment.ProgressBarSpeedUpLevel++;
                progressBarSpeedUpgrade.Value = WorkingGameEnvironment.ProgressBarSpeedUpLevel * 25;
                labelSpeedUpLevel.Text = WorkingGameEnvironment.GetSpeedUpPercentageString();
                WorkingGameEnvironment.CurrentStats.Update(new List<int>()
                {
                    -1*WorkingGameEnvironment.SpeedUpgradePriceList[0],
                    -1*WorkingGameEnvironment.SpeedUpgradePriceList[1],
                    -1*WorkingGameEnvironment.SpeedUpgradePriceList[2],
                    -1*WorkingGameEnvironment.SpeedUpgradePriceList[3],
                    -1*WorkingGameEnvironment.SpeedUpgradePriceList[4]
                });
                UpdateSpeedUpgradePriceLabelAndButton();
            }
            if (WorkingGameEnvironment.ProgressBarSpeedUpLevel == 4)
            {
                buttonUpgradeSpeedUp.Enabled = false;
                labelSpeedUpgradePrice.Text = "";
            }
        }
        /// <summary>
        /// Aktualizuje realny czas w środowisku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRealGameTime_Tick(object sender, EventArgs e)
        {
            WorkingGameEnvironment.DateSystem.IncrementDate();
            UpdateGameDateTimeLabel();
            if (WorkingGameEnvironment.DateSystem.Months % 6 == 0 && WorkingGameEnvironment.DateSystem.Weeks == 1)
            {
                WorkingGameEnvironment.DateSystem.IncrementDate();
                ExecuteGameEvent(1);
            }
            if ((WorkingGameEnvironment.DateSystem.Months + 3) % 6 == 0 && WorkingGameEnvironment.DateSystem.Weeks == 1)
            {
                WorkingGameEnvironment.DateSystem.IncrementDate();
                ExecuteGameEvent(2);
            }
        }
        /// <summary>
        /// Aktualizuje etykietę z ceną zatrudnienia pracownika na wydziale
        /// </summary>
        /// <param name="departmentIndex"></param>
        private void UpdateWorkerPriceLabel(int departmentIndex)
        {
            DepartmentWorkersPriceLabelList[departmentIndex].Text =
                WorkingGameEnvironment.DepartmentList[departmentIndex].GetWorkerPriceString();
        }
        /// <summary>
        /// Aktualizuje eytkietę z liczbą zatrudnionych pracowników na wydziale
        /// </summary>
        /// <param name="departmentIndex"></param>
        private void UpdateWorkersAmount(int departmentIndex)
        {
            DepartmentWorkersAmountLabelList[departmentIndex].Text =
                WorkingGameEnvironment.DepartmentList[departmentIndex].WorkersAmount.ToString();
        }
        /// <summary>
        /// Aktualizuje etykietę z informacją o aktualnych zasobach
        /// </summary>
        private void UpdateUniversityStatsLabel()
        {
            labelUniversityStats.Text = WorkingGameEnvironment.CurrentStats.GetUniversityStatsString();
        }
        /// <summary>
        /// Zatrudnia pracownika na wybranym wydziale i aktualizuje informacje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEmploy_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            int departmentIndex = Int32.Parse(senderButton.Name[senderButton.Name.Length - 1].ToString()) - 1;
            WorkingGameEnvironment.HireWorkerInDepartment(departmentIndex);
            UpdateWorkersAmount(departmentIndex);
            UpdateWorkerPriceLabel(departmentIndex);
            UpdatePayloadLabel(departmentIndex);
            UpdateEmployButtons();
            UpdateUniversityStatsLabel();
        }
        /// <summary>
        /// Aktualizuje dane o nagrodzie dla wydziału
        /// </summary>
        /// <param name="departmentIndex"></param>
        private void UpdatePayloadLabel(int departmentIndex)
        {
            PayloadLabelList[departmentIndex].Text =
                WorkingGameEnvironment.DepartmentList[departmentIndex].GetPayloadString();
        }
        /// <summary>
        /// Uruchamia nowe zdarzenie
        /// </summary>
        /// <param name="eventID"></param>
        public void ExecuteGameEvent(int eventID)
        {
            timerRealGameTime.Stop();
            timerLogicGameTime.Stop();
            WorkingGameEnvironment.SummonGameEvent(eventID);
            UpdateUniversityStatsLabel();
            UpdateEmployButtons();
            UpdateSpeedUpgradePriceLabelAndButton();
            timerRealGameTime.Start();
            timerLogicGameTime.Start();

        }
        /// <summary>
        /// Zamyka grę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExitGame_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
