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
    /// Логика взаимодействия для StatsPage.xaml
    /// </summary>
    public partial class StatsPage : Page
    {
        public StatsPage()
        {
            InitializeComponent();

            if (FrameClass.UserID == 3)
            {
                var CountPatient = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Count();
                var CountAllergy = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 1).Count();
                var CountLuxation = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 2).Count();
                var CountPneumonia = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 3).Count();
                var CountTachycardia = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 4).Count();
                var CountCapitis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 5).Count();
                var CountAvitominosis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 6).Count();
                var CountAmenrheo = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 7).Count();
                var CountConjunctivitis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 8).Count();
                var CountSeborrhoea = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 9).Count();
                var CountMastitis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 10).Count();
                var CountVaricocele = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 11).Count();
                var CountTracheitis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 12).Count();
                var CountPhimao = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 13).Count();
                var CountEncopresis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 14).Count();
                var CountDelirium = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.id_doctor_reception == FrameClass.UserID).Where(x => x.Diagnoses_Table.id_diagnose == 15).Count();
                LstBoxStats.Items.Add($"Общее количество ваших пациентов - {CountPatient}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с аллергией - {CountAllergy}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с вывихом - {CountLuxation}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с пневмонией - {CountPneumonia}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с тахикардией - {CountTachycardia}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с головной болью - {CountCapitis}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с авитаминозом - {CountAvitominosis}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с аменореей - {CountAmenrheo}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с конъюктивитом - {CountConjunctivitis}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с себореей - {CountSeborrhoea}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с маститом - {CountMastitis}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с варикоцеле - {CountVaricocele}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с трахеитом - {CountTracheitis}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с фимозом - {CountPhimao}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с энкопрезом - {CountEncopresis}");
                LstBoxStats.Items.Add($"Количество ваших пациентов с делирием - {CountDelirium}");
            }
            else
            {
                var CountPatient = DBHospitalEntities.GetContext().Reception_Table.Count();
                var CountAllergy = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 1).Count();
                var CountLuxation = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 2).Count();
                var CountPneumonia = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 3).Count();
                var CountTachycardia = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 4).Count();
                var CountCapitis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 5).Count();
                var CountAvitominosis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 6).Count();
                var CountAmenrheo = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 7).Count();
                var CountConjunctivitis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 8).Count();
                var CountSeborrhoea = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 9).Count();
                var CountMastitis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 10).Count();
                var CountVaricocele = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 11).Count();
                var CountTracheitis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 12).Count();
                var CountPhimao = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 13).Count();
                var CountEncopresis = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 14).Count();
                var CountDelirium = DBHospitalEntities.GetContext().Reception_Table.Where(x => x.Diagnoses_Table.id_diagnose == 15).Count();
                LstBoxStats.Items.Add($"Общее количество пациентов - {CountPatient}");
                LstBoxStats.Items.Add($"Общее количество пациентов с аллергией - {CountAllergy}");
                LstBoxStats.Items.Add($"Общее количество пациентов с вывихом - {CountLuxation}");
                LstBoxStats.Items.Add($"Общее количество пациентов с пневмонией - {CountPneumonia}");
                LstBoxStats.Items.Add($"Общее количество пациентов с тахикардией - {CountTachycardia}");
                LstBoxStats.Items.Add($"Общее количество пациентов с головной болью - {CountCapitis}");
                LstBoxStats.Items.Add($"Общее количество пациентов с авитаминозом - {CountAvitominosis}");
                LstBoxStats.Items.Add($"Общее количество пациентов с аменореей - {CountAmenrheo}");
                LstBoxStats.Items.Add($"Общее количество пациентов с конъюктивитом - {CountConjunctivitis}");
                LstBoxStats.Items.Add($"Общее количество пациентов с себореей - {CountSeborrhoea}");
                LstBoxStats.Items.Add($"Общее количество пациентов с маститом - {CountMastitis}");
                LstBoxStats.Items.Add($"Общее количество пациентов с варикоцеле - {CountVaricocele}");
                LstBoxStats.Items.Add($"Общее количество пациентов с трахеитом - {CountTracheitis}");
                LstBoxStats.Items.Add($"Общее количество пациентов с фимозом - {CountPhimao}");
                LstBoxStats.Items.Add($"Общее количество пациентов с энкопрезом - {CountEncopresis}");
                LstBoxStats.Items.Add($"Общее количество пациентов с делирием - {CountDelirium}");
            }
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmobj.GoBack();
        }
    }
}
