using Hospital_WPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для PatientViewPage.xaml
    /// </summary>
    public partial class PatientViewPage : Page
    {
        private Patients_Medical_Records_Table _records = new Patients_Medical_Records_Table();
        public PatientViewPage()
        {
            InitializeComponent();

            var allpatients = DBHospitalEntities.GetContext().Patients_Medical_Records_Table.Distinct().ToList();
            allpatients.Insert(0, new Patients_Medical_Records_Table
            {
                Surname_patient = "Выберите пациента: "
            });

            CmbSelectPatientMedRec.ItemsSource = allpatients;
            CmbSelectPatientMedRec.SelectedValuePath = "id_medical_records";
            CmbSelectPatientMedRec.DisplayMemberPath = "Surname_patient";
        }

        private void CmbSelectPatientMedRec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSelectPatientMedRec.SelectedIndex > 0)
            {
                FrameClass.PatientID = int.Parse(CmbSelectPatientMedRec.SelectedValue.ToString());

                var patientrec = DBHospitalEntities.GetContext().Patients_Medical_Records_Table.Where(x => x.id_medical_records == FrameClass.PatientID).FirstOrDefault();

                if (patientrec.Patronymic_patient != null) 
                { 
                    FIOPatientTxtBlock.Text = $"{patientrec.Surname_patient} {patientrec.Name_patient} {patientrec.Patronymic_patient}";
                }
                else
                {
                    FIOPatientTxtBlock.Text = $"{patientrec.Name_patient} {patientrec.Surname_patient}";
                }

                AgePatientTxtBlock.Text = patientrec.Age_patient.ToString();

                BirthDatePatientTxtBlock.Text = patientrec.Birth_date_patient.Date.ToString();

                InsuranceNumberPatientTxtBlock.Text = patientrec.Insurance_policy_number_patient.ToString();

                AddressPatientTxtBlock.Text = patientrec.Addres_patient.ToString();

            }
            else
            {
                FIOPatientTxtBlock.Text = "ФИО пациента";
                AgePatientTxtBlock.Text = "Возраст пациента";
                BirthDatePatientTxtBlock.Text = "Дата рождения пациента";
                InsuranceNumberPatientTxtBlock.Text = "Номер полиса ОМС пациента";
                AddressPatientTxtBlock.Text = "Адрес пациента";
            }
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.GoBack();
        }

    }
}
