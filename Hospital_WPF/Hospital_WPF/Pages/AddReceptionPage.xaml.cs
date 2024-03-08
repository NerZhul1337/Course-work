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
    public partial class AddReceptionPage : Page
    {
        public AddReceptionPage()
        {
            InitializeComponent();

            var alldiagnosis = DBHospitalEntities.GetContext().Diagnoses_Table.Distinct().ToList();
            alldiagnosis.Insert(0, new Diagnoses_Table
            {
                Name_diagnose_rus = "Выберите диагноз: "
            });

            CmbAddDiagnoseToReception.ItemsSource = alldiagnosis;
            CmbAddDiagnoseToReception.SelectedValuePath = "id_diagnose";
            CmbAddDiagnoseToReception.DisplayMemberPath = "Name_diagnose_rus";

            var allmedrec = DBHospitalEntities.GetContext().Patients_Medical_Records_Table.Distinct().ToList();
            allmedrec.Insert(0, new Patients_Medical_Records_Table
            {
                Surname_patient = "Выберите пациента: "
            });

            CmbAddMedRecToReception.ItemsSource = allmedrec;
            CmbAddMedRecToReception.SelectedValuePath = "id_medical_records";
            CmbAddMedRecToReception.DisplayMemberPath = "Surname_patient";

            TxtBoxAddAdditionsToDiagnoseToReception.MaxLength = 50;
            TxtBoxAddAdditionsToDiagnoseToReception.ToolTip = "Максимальная длина 50 символов";
            TxtBoxAddAppointmentToReception.MaxLength = 50;
            TxtBoxAddAppointmentToReception.ToolTip = "Максимальная длина 50 символов";
            TxtBoxAddComplaintsToReception.MaxLength = 50;
            TxtBoxAddComplaintsToReception.ToolTip = "Максимальная длина 50 символов";
        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.GoBack();
        }

        private void BtnSaveAddPatient_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxAddAdditionsToDiagnoseToReception.Text != "" || TxtBoxAddAppointmentToReception.Text != "" ||
                TxtBoxAddComplaintsToReception.Text != "" || CmbAddDiagnoseToReception.SelectedIndex >= 0 || 
                CmbAddMedRecToReception.SelectedIndex >= 0)
            {
                Reception_Table reception_Table = new Reception_Table
                {
                    id_doctor_reception = FrameClass.UserID,
                    id_medical_records_reception = int.Parse(CmbAddMedRecToReception.SelectedValue.ToString()),
                    Date_of_reception = DateTime.Now,
                    Complaints = TxtBoxAddComplaintsToReception.Text,
                    Appointment = TxtBoxAddAppointmentToReception.Text,
                    id_diagnose_reception = int.Parse(CmbAddDiagnoseToReception.SelectedValue.ToString()),
                    addition_to_diagnose = TxtBoxAddAdditionsToDiagnoseToReception.Text,
                };
                if (reception_Table.id_reception == 0)
                {
                    DBHospitalEntities.GetContext().Reception_Table.Add(reception_Table);
                }
                try
                {
                    DBHospitalEntities.GetContext().SaveChanges();
                    MessageBoxResult BoxResult = MessageBox.Show("Запись успешно добавлена. Добавить ещё?", "Сообщение",
                         MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (BoxResult == MessageBoxResult.Yes)
                    {
                        TxtBoxAddAdditionsToDiagnoseToReception.Clear();
                        TxtBoxAddAppointmentToReception.Clear();
                        TxtBoxAddComplaintsToReception.Clear();
                        CmbAddDiagnoseToReception.SelectedIndex = 0;
                        CmbAddMedRecToReception.SelectedIndex = 0;
                    }
                    else
                    {
                        FrameClass.frmobj.GoBack();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!","Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
    }
}