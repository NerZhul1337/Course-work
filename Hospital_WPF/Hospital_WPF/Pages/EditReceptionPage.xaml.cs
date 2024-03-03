using Hospital_WPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для EditReceptionPage.xaml
    /// </summary>
    public partial class EditReceptionPage : Page
    {
        
        private Reception_Table _receptiontable = new Reception_Table();
        public EditReceptionPage(Reception_Table SelectedReception)
        {

            InitializeComponent();

            if (SelectedReception != null)
                _receptiontable = SelectedReception;
            DataContext = _receptiontable;

            TxtBoxChangedAdditionToDiagnose.MaxLength = 150;
            TxtBoxChangedAdditionToDiagnose.ToolTip = "Максимальная длина строки 150 символов";
            TxtBoxChangedAppointment.MaxLength = 150;
            TxtBoxChangedAppointment.ToolTip = "Максимальная длина строки 150 символов";
            TxtBoxChangedComplaints.MaxLength = 150;
            TxtBoxChangedComplaints.ToolTip = "Максимальная длина строки 150 символов";
            
        }

        private void SaveChangesInReceptionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxChangedComplaints.Text != "" || TxtBoxChangedAdditionToDiagnose.Text != "" || TxtBoxChangedAppointment.Text != "")
            {
                Reception_Table receptionTable = new Reception_Table()
                {
                    id_reception = _receptiontable.id_reception,
                    id_doctor_reception = _receptiontable.id_doctor_reception,
                    id_medical_records_reception = _receptiontable.id_medical_records_reception,
                    Date_of_reception = DateTime.Parse(DtPickChangedDateOfReception.SelectedDate.Value.Date.ToString()),
                    Complaints = TxtBoxChangedComplaints.Text,
                    Appointment = TxtBoxChangedAppointment.Text,
                    id_diagnose_reception = _receptiontable.id_diagnose_reception,
                    addition_to_diagnose = TxtBoxChangedAdditionToDiagnose.Text,
                };

                try
                {
                    DBHospitalEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно изменены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameClass.frmobj.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            

        }

        private void GoBackToMainViewPageBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.GoBack();
        }
    }
}
