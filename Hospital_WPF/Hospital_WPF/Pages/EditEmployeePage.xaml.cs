using Hospital_WPF.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EditEmployeePage.xaml
    /// </summary>
    public partial class EditEmployeePage : Page
    {
        private Doctors_Table _doctortable = new Doctors_Table();

        public byte[] img_bytes;

        public byte[] image_bytes;
        public int MaxValue = 5242880;
        public int MinValue = 0;

        public EditEmployeePage(Doctors_Table SelectedDoctor)
        {
            InitializeComponent();

            var allAccessLevel = DBHospitalEntities.GetContext().Access_Level_Table.Distinct().ToList();
            allAccessLevel.Insert(0, new Access_Level_Table
            {
                Name_of_access_level = "Уровень доступа:"
            });

            CmbAccessLevelEmp.ItemsSource = allAccessLevel;
            CmbAccessLevelEmp.SelectedValuePath = "id_access_level";
            CmbAccessLevelEmp.DisplayMemberPath = "Name_of_access_level";

            if (SelectedDoctor != null)
            {
                _doctortable = SelectedDoctor;
            }

            DataContext = _doctortable;
            TxtBoxChangedNameEmp.MaxLength = 50;
            TxtBoxChangedSurnameEmp.MaxLength = 50;
            TxtBoxChangedLoginEmp.MaxLength = 50;
            TxtBoxChangedSpecializationEmp.MaxLength = 50;
            PassBoxChangedPasswordEmpFirstCheck.MaxLength = 25;
            PassBoxChangedPasswordEmpSecondCheck.MaxLength = 25;
            TxtBoxChangedNameEmp.ToolTip = "Вводить только буквы. Максимальная длина строки 50 символов";
            TxtBoxChangedSurnameEmp.ToolTip = "Вводить только буквы. Максимальная длина строки 50 символов";
            TxtBoxChangedSpecializationEmp.ToolTip = "Вводить только буквы. Максимальная длина строки 50 символов";
            TxtBoxChangedLoginEmp.ToolTip = "Введите свой адрес электронной почты";
            PassBoxChangedPasswordEmpFirstCheck.PasswordChar = '*';
            PassBoxChangedPasswordEmpSecondCheck.PasswordChar = '*';

            //image_bytes = SelectedDoctor.EmployeeImage;
        }

        private void SaveChangesInDoctorsTableBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxChangedNameEmp.Text == "" || TxtBoxChangedSurnameEmp.Text == "" ||
                TxtBoxChangedLoginEmp.Text == "" || TxtBoxChangedSpecializationEmp.Text == "" ||
                PassBoxChangedPasswordEmpFirstCheck.Password == "" || PassBoxChangedPasswordEmpSecondCheck.Password == "" || 
                CmbAccessLevelEmp.SelectedIndex <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (PassBoxChangedPasswordEmpFirstCheck.Password.Length < 6 || PassBoxChangedPasswordEmpSecondCheck.Password.Length < 6)
            {
                MessageBox.Show("Минимальная длина пароля 6 символов, максимальная - 25", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string[] datalogin = TxtBoxChangedLoginEmp.Text.Split('@');
                if (datalogin.Length == 2)
                {
                    string[] data2login = datalogin[1].Split('.');
                    if (data2login.Length == 2)
                    {
                        if(PassBoxChangedPasswordEmpFirstCheck.Password != PassBoxChangedPasswordEmpSecondCheck.Password)
                        {
                            MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if(image_bytes == null || image_bytes.Length > MinValue)
                        {
                            Doctors_Table doctors_Table = new Doctors_Table()
                            {
                                Name_doctor = TxtBoxChangedNameEmp.Text,
                                Surname_doctor = TxtBoxChangedSurnameEmp.Text,
                                Patronymic_doctor = _doctortable.Patronymic_doctor,
                                Specialization = TxtBoxChangedSpecializationEmp.Text,
                                Experience = _doctortable.Experience,
                                id_access_level = int.Parse(CmbAccessLevelEmp.SelectedValue.ToString()),
                                User_login = TxtBoxChangedLoginEmp.Text,
                                User_pass = PassBoxChangedPasswordEmpSecondCheck.Password,
                            };
                            try
                            {
                                DBHospitalEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                                FrameClass.frmobj.GoBack();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                        else
                        {
                            Doctors_Table doctors_Table = new Doctors_Table()
                            {
                                Name_doctor = TxtBoxChangedNameEmp.Text,
                                Surname_doctor = TxtBoxChangedSurnameEmp.Text,
                                Patronymic_doctor = _doctortable.Patronymic_doctor,
                                Specialization = TxtBoxChangedSpecializationEmp.Text,
                                Experience = _doctortable.Experience,
                                id_access_level = int.Parse(CmbAccessLevelEmp.SelectedValue.ToString()),
                                User_login = TxtBoxChangedLoginEmp.Text,
                                User_pass = PassBoxChangedPasswordEmpSecondCheck.Password,
                            };
                            try
                            {
                                DBHospitalEntities.GetContext().SaveChanges();
                                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                                FrameClass.frmobj.GoBack();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста введите логин формата x@x.x", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста введите логин формата x@x.x", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.GoBack();
        }
    }
}
