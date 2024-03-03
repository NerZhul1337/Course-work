using Hospital_WPF.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace Hospital_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainViewPage.xaml
    /// </summary>
    public partial class MainViewPage : Page
    {

        public MainViewPage(Doctors_Table Level)
        {
            InitializeComponent();

            var Lvlaccuser = Level.id_access_level;

            var allDiagnosis = DBHospitalEntities.GetContext().Diagnoses_Table.Distinct().ToList();
            allDiagnosis.Insert(0, new Diagnoses_Table
            {
                Name_diagnose_rus = "Выберите диагноз: "
            });

            CmbDiagnos.ItemsSource = allDiagnosis;
            CmbDiagnos.SelectedValuePath = "id_diagnose";
            CmbDiagnos.DisplayMemberPath = "Name_diagnose_rus";

            UpdateDtg();

            if (Lvlaccuser == 3)
            {
                NavToViewEmployeePageBtn.Visibility = Visibility.Collapsed;
            }
            if (Lvlaccuser == 1)
            {
                NavToAddReceptionPageBtn.Visibility = Visibility.Collapsed;
                ExcelOutPutInTemplate.Visibility = Visibility.Collapsed;
            }
            else if (Lvlaccuser == 2)
            {
                NavToAddReceptionPageBtn.Visibility = Visibility.Collapsed;
                ExcelOutPutInTemplate.Visibility = Visibility.Collapsed;
            }

            TxtBlockPrivetstvie.TextWrapping = TextWrapping.Wrap;
            TxtBlockPrivetstvie.Text = $"Здравствуйте, {Level.Surname_doctor} {Level.Name_doctor}";
        }

        private void UpdateDtg()
        {
            if (Classes.FrameClass.LvlAccID == 3)
            {
                var currentreception = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).ToList();
                    if (CmbDiagnos.SelectedIndex > 0)
                        currentreception = currentreception.Where(x => x.id_doctor_reception == Classes.FrameClass.UserID).Where(x => x.id_diagnose_reception == int.Parse(CmbDiagnos.SelectedValue.ToString())).ToList();
                    
                    currentreception = currentreception.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Patients_Medical_Records_Table.Surname_patient.ToLower().Contains(SrcSurnamePatientTxtBox.Text.ToLower())).ToList();
;                   if (RadBtnAsc.IsChecked.Value)
                        currentreception = currentreception.Where(x => x.id_doctor_reception == FrameClass.UserID).OrderBy(x => x.Date_of_reception).ToList();
                    if (RadBtnDesc.IsChecked.Value)
                        currentreception = currentreception.Where(x => x.id_doctor_reception == FrameClass.UserID).OrderByDescending(x => x.Date_of_reception).ToList();

                DtgReceptionsView.ItemsSource = currentreception;
            }
            else 
            {
                var currentreception = DBHospitalEntities.GetContext().Reception_Table.ToList();
                
                if (CmbDiagnos.SelectedIndex > 0)
                    currentreception = currentreception.Where(x => x.id_diagnose_reception == int.Parse(CmbDiagnos.SelectedValue.ToString())).ToList();
                
                currentreception = currentreception.Where(x => x.Patients_Medical_Records_Table.Surname_patient.ToLower().Contains(SrcSurnamePatientTxtBox.Text.ToLower())).ToList();
                if (RadBtnAsc.IsChecked.Value)
                    currentreception = currentreception.OrderBy(x => x.Date_of_reception).ToList();
                if (RadBtnDesc.IsChecked.Value)
                    currentreception = currentreception.OrderByDescending(x => x.Date_of_reception).ToList();

                DtgReceptionsView.ItemsSource = currentreception;
            }
        }

        private void CmbDiagnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDtg();
        }

        private void CmbPatientsRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDtg();
        }

        private void RadBtnAsc_Click(object sender, RoutedEventArgs e)
        {
            UpdateDtg();
        }

        private void RadBtnDesc_Click(object sender, RoutedEventArgs e)
        {
            UpdateDtg();
        }

        private void ResetFiltrBtn_Click(object sender, RoutedEventArgs e)
        {
            CmbDiagnos.SelectedIndex = 0;
            SrcSurnamePatientTxtBox.Text = "";
            RadBtnAsc.IsChecked = false;
            RadBtnDesc.IsChecked = false;
            if (Classes.FrameClass.LvlAccID == 3)
            {
                DtgReceptionsView.ItemsSource = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).ToList();
            }
            else
            {
                DtgReceptionsView.ItemsSource = DBHospitalEntities.GetContext().Reception_Table.ToList();
            }
        }

        private void ExcelOutPutInTemplate_Click(object sender, RoutedEventArgs e)
        {
            if (DtgReceptionsView.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Выберите историю болезни для экспорта данных в Excel", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(DtgReceptionsView.SelectedCells.Count >= 1 )
            {
                var PatientReception = DtgReceptionsView.SelectedItems.Cast<Reception_Table>().ToList();
                try
                {
                    var app = new Excel.Application();
                    Excel.Workbook wb = app.Workbooks.Add();
                    app.SheetsInNewWorkbook = 1;
                    Excel.Worksheet worksheet =
                        app.Worksheets.Item[1];
                    worksheet.Name = "Сведения о приёме";

                    int IndexRows = 1;

                    worksheet.Cells[1][IndexRows] = "Осмотр доктора";
                    worksheet.Cells[1][IndexRows+1] = "Дата осмотра: ";
                    worksheet.Cells[1][IndexRows+2] = "ФИО пациента: ";
                    worksheet.Cells[1][IndexRows+3] = "Дата рождения: ";
                    worksheet.Cells[1][IndexRows+4] = "ФИО доктора: ";
                    worksheet.Cells[1][IndexRows+5] = "Жалобы: ";
                    worksheet.Cells[1][IndexRows+6] = "Диагноз: ";
                    worksheet.Cells[1][IndexRows+7] = "Дополнение к диагнозу: ";
                    worksheet.Cells[1][IndexRows+9] = "Назначение: ";
                    worksheet.Cells[1][IndexRows+11] = "Подпись доктора: ";

                    foreach (var _patientreception in PatientReception)
                    {
                        worksheet.Cells[2][IndexRows+1] = _patientreception.Date_of_reception;
                        worksheet.Cells[2][IndexRows+2] = _patientreception.Patients_Medical_Records_Table.Surname_patient + " " + 
                            _patientreception.Patients_Medical_Records_Table.Name_patient + " " + _patientreception.Patients_Medical_Records_Table.Patronymic_patient;
                        worksheet.Cells[2][IndexRows+3] = _patientreception.Patients_Medical_Records_Table.Birth_date_patient;
                        worksheet.Cells[2][IndexRows+4] = _patientreception.Doctors_Table.Surname_doctor + " " + 
                            _patientreception.Doctors_Table.Name_doctor + " " + _patientreception.Doctors_Table.Patronymic_doctor;
                        worksheet.Cells[2][IndexRows+5] = _patientreception.Complaints;
                        worksheet.Cells[2][IndexRows+6] = _patientreception.Diagnoses_Table.Name_diagnose_rus;
                        worksheet.Cells[2][IndexRows+7] = _patientreception.addition_to_diagnose;
                        worksheet.Cells[2][IndexRows+9] = _patientreception.Appointment;

                        Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[1][IndexRows], worksheet.Cells[3][IndexRows+9]];
                        rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
                            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
                            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
                            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
                            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle =
                            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
                            Excel.XlLineStyle.xlLineStyleNone;

                        Excel.Range rangeBoldBorders = worksheet.Range[worksheet.Cells[2][IndexRows + 11], worksheet.Cells[2][IndexRows + 11]];
                        rangeBoldBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                        Excel.Range rangeLeft = worksheet.Range[worksheet.Cells[1][IndexRows], worksheet.Cells[1][IndexRows+9]];
                        rangeLeft.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                        Excel.Range rangeCenter = worksheet.Range[worksheet.Cells[2][IndexRows], worksheet.Cells[2][IndexRows+9]];
                        rangeCenter.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range rangeBold = worksheet.Range[worksheet.Cells[1][IndexRows], worksheet.Cells[1][IndexRows+11]];
                        rangeBold.Font.Bold = true;

                        Excel.Range rangeFontSizeHeader = worksheet.Range[worksheet.Cells[1][IndexRows], worksheet.Cells[1][IndexRows+11]];
                        rangeFontSizeHeader.Font.Size = 16;

                        Excel.Range rangeFontSize = worksheet.Range[worksheet.Cells[2][IndexRows], worksheet.Cells[2][IndexRows+9]];
                        rangeFontSize.Font.Size = 14;

                        Excel.Range rangeFontFamily = worksheet.Range[worksheet.Cells[1][IndexRows], worksheet.Cells[2][IndexRows+11]];
                        rangeFontFamily.Font.Name = "Times New Roman";

                        worksheet.Columns.AutoFit();
                        worksheet.Rows.AutoFit();

                    }

                    app.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DBHospitalEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                if (Classes.FrameClass.LvlAccID == 3)
                {
                    DtgReceptionsView.ItemsSource = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).ToList();
                }
                else
                {
                    DtgReceptionsView.ItemsSource = DBHospitalEntities.GetContext().Reception_Table.ToList();
                }
                
            }
        }

        private void NavToAddReceptionPageBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.Navigate(new AddReceptionPage());
        }

        private void DelReceptionBtn_Click(object sender, RoutedEventArgs e)
        {
            var ReceptionsForRemoving =
                DtgReceptionsView.SelectedItems.Cast<Reception_Table>().ToList();

            if (MessageBox.Show
                ($"Удалить {ReceptionsForRemoving.Count()}" + " записей о приёмах?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    DBHospitalEntities.GetContext().Reception_Table.
                        RemoveRange(ReceptionsForRemoving);

                    DBHospitalEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (Classes.FrameClass.LvlAccID == 3)
                    {
                        DtgReceptionsView.ItemsSource = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).ToList();
                    }
                    else
                    {
                        DtgReceptionsView.ItemsSource = DBHospitalEntities.GetContext().Reception_Table.ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void NavToViewMedRecPageBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.Navigate(new PatientViewPage());
        }

        private void NavToViewEmployeePageBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.Navigate(new ViewEmployeePage());
        }

        private void NavToEditReceptionsPageBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.Navigate(new EditReceptionPage((sender as Button).DataContext as Reception_Table));
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.Navigate(new AuthorizationPage());
            Classes.FrameClass.UserID = 0;
            Classes.FrameClass.LvlAccID = 0;
            Classes.FrameClass.UserName = string.Empty;
            Classes.FrameClass.UserSurname = string.Empty;
        }

        private void StatsBtn_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmobj.Navigate(new StatsPage());
        }

        private void SrcSurnamePatientTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDtg();
        }
    }
}
