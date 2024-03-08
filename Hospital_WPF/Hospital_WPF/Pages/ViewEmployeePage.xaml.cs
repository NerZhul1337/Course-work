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
    public partial class ViewEmployeePage : Page
    {
        public ViewEmployeePage()
        {
            InitializeComponent();

            UpdateLstView();
        }

        private void NavToAddEmployeePageBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.Navigate(new AddEmployeePage());
        }

        private void DelEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            var EmployeeForRemoving =
                LstViewEmployee.SelectedItems.Cast<Doctors_Table>().ToList();

            if(MessageBox.Show
                ($"Удалить {EmployeeForRemoving.Count} записей о сотрудниках?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    DBHospitalEntities.GetContext().Doctors_Table.RemoveRange(EmployeeForRemoving);

                    DBHospitalEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            LstViewEmployee.ItemsSource = DBHospitalEntities.GetContext().Doctors_Table.ToList();

        }

        private void NavToMainViewPage_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.GoBack();
        }

        private void NavToEditEmployeePagebtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.Navigate(new EditEmployeePage((sender as Button).DataContext as Doctors_Table));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DBHospitalEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LstViewEmployee.ItemsSource = DBHospitalEntities.GetContext().Doctors_Table.ToList();
            }
        }

        private void SrcSurnameDoctorTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateLstView();
        }

        private void SrcSpecializationTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateLstView();
        }

        private void UpdateLstView()
        {
            var LstContext = DBHospitalEntities.GetContext().Doctors_Table.ToList();

            LstContext = LstContext.Where(x => x.Surname_doctor.ToLower().Contains(SrcSurnameDoctorTxtBox.Text.ToLower())).ToList();

            LstContext = LstContext.Where(x => x.Specialization.ToLower().Contains(SrcSpecializationTxtBox.Text.ToLower())).ToList();

            LstViewEmployee.ItemsSource = LstContext;

            var CountEmployee = LstContext.Count();

            var CountDoctors = LstContext.Where(x => x.id_access_level == 3).Count();

            var CountChiefPhysician = LstContext.Where(x => x.id_access_level == 2).Count();

            var CountAdministration = LstContext.Where(x => x.id_access_level == 1).Count();

            LstBoxAnalyticsData.Items[0] = $"Количество работников - {CountEmployee}\n" +
                $"Количество докторов - {CountDoctors}\n" +
                $"Количество главных врачей - {CountChiefPhysician}\n" +
                $"Количество администраторов - {CountAdministration}";
        }
    }
}