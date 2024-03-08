using Hospital_WPF.Classes;
using Microsoft.Office.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Xml.Linq;

namespace Hospital_WPF.Pages
{
    public partial class AddEmployeePage : Page
    {

        public byte[] image_bytes;

        public int MaxValue = 5242880;

        public int MinValue = 0;
        public AddEmployeePage()
        {
            InitializeComponent();

            TxtBoxAddNameEmployee.MaxLength = 50;
            TxtBoxAddSurnameEmployee.MaxLength = 50;
            TxtBoxAddPatronymicEmployee.MaxLength = 50;
            TxtBoxAddSpecializationEmployee.MaxLength = 50;
            TxtBoxAddExperienceEmployee.MaxLength = 50;
            PassBoxFirstCheck.MaxLength = 25;
            PassBoxSecondCheck.MaxLength = 25;
            TxtBoxAddLoginEmployee.MaxLength = 50;

            PassBoxFirstCheck.PasswordChar = '*';
            PassBoxSecondCheck.PasswordChar = '*';

            TxtBoxAddNameEmployee.ToolTip = "Можно вводить только буквы";

            TxtBoxAddSurnameEmployee.ToolTip = "Можно вводить только буквы";
            TxtBoxAddPatronymicEmployee.ToolTip = "Можно вводить только буквы";
            TxtBoxAddExperienceEmployee.ToolTip = "Можно вводить только цифры";
            TxtBoxAddSpecializationEmployee.ToolTip = "Можно вводить только буквы";

            TxtBoxAddLoginEmployee.ToolTip = "Введите вад адрес электронной почты";

            PassBoxFirstCheck.ToolTip = "Введите пароль длиной не менее 6 символов";

            PassBoxSecondCheck.ToolTip = "Введите пароль длиной не менее 6 символов";
        }

        private void BtnSaveAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxAddNameEmployee.Text == "" || TxtBoxAddSurnameEmployee.Text == "" ||
                TxtBoxAddSpecializationEmployee.Text == "" || TxtBoxAddExperienceEmployee.Text == "" ||
                PassBoxFirstCheck.Password == "" || PassBoxSecondCheck.Password == "" ||
                TxtBoxAddLoginEmployee.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (PassBoxFirstCheck.Password.Length < 6 || PassBoxSecondCheck.Password.Length < 6)
            {
                MessageBox.Show("Минимальная длина пароля 6 символов, максимальная - 25.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string[] datalogin = TxtBoxAddLoginEmployee.Text.Split('@');
                if (datalogin.Length == 2)
                {
                    string[] data2login = datalogin[1].Split('.');
                    if (data2login.Length == 2)
                    {
                        if (PassBoxFirstCheck.Password != PassBoxSecondCheck.Password)
                        {
                            MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if(image_bytes.Length > MinValue)
                        {
                            Doctors_Table doctors_Table = new Doctors_Table()
                            {
                                Name_doctor = TxtBoxAddNameEmployee.Text,
                                Surname_doctor = TxtBoxAddSurnameEmployee.Text,
                                Patronymic_doctor = TxtBoxAddPatronymicEmployee.Text,
                                Specialization = TxtBoxAddSpecializationEmployee.Text,
                                Experience = int.Parse(TxtBoxAddExperienceEmployee.Text),
                                id_access_level = 3,
                                User_login = TxtBoxAddLoginEmployee.Text,
                                User_pass = PassBoxSecondCheck.Password,
                                EmployeeImage = image_bytes,
                            };
                            if (doctors_Table.id_doctor == 0)
                            {
                                DBHospitalEntities.GetContext().Doctors_Table.Add(doctors_Table);
                            }
                            try
                            {
                                DBHospitalEntities.GetContext().SaveChanges();
                                MessageBoxResult boxResult = MessageBox.Show("Сотрудник успешно добавлен. Добавить ещё?", "Сообщение",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (boxResult == MessageBoxResult.Yes)
                                {
                                    TxtBoxAddNameEmployee.Clear();
                                    TxtBoxAddSurnameEmployee.Clear();
                                    TxtBoxAddPatronymicEmployee.Clear();
                                    TxtBoxAddSpecializationEmployee.Clear();
                                    TxtBoxAddExperienceEmployee.Clear();
                                    TxtBoxAddLoginEmployee.Clear();
                                    PassBoxFirstCheck.Clear();
                                    PassBoxSecondCheck.Clear();
                                    image_bytes.SetValue(image_bytes, MinValue);
                                }
                                else
                                {
                                    FrameClass.frmobj.GoBack();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            Doctors_Table doctors_Table = new Doctors_Table()
                            {
                                Name_doctor = TxtBoxAddNameEmployee.Text,
                                Surname_doctor = TxtBoxAddSurnameEmployee.Text,
                                Patronymic_doctor = TxtBoxAddPatronymicEmployee.Text,
                                Specialization = TxtBoxAddSpecializationEmployee.Text,
                                Experience = int.Parse(TxtBoxAddExperienceEmployee.Text),
                                id_access_level = 3,
                                User_login = TxtBoxAddLoginEmployee.Text,
                                User_pass = PassBoxSecondCheck.Password,
                                EmployeeImage = null,
                            };
                            if (doctors_Table.id_doctor == 0)
                            {
                                DBHospitalEntities.GetContext().Doctors_Table.Add(doctors_Table);
                            }
                            try
                            {
                                DBHospitalEntities.GetContext().SaveChanges();
                                MessageBoxResult boxResult = MessageBox.Show("Сотрудник успешно добавлен. Добавить ещё?", "Сообщение",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (boxResult == MessageBoxResult.Yes)
                                {
                                    TxtBoxAddNameEmployee.Clear();
                                    TxtBoxAddSurnameEmployee.Clear();
                                    TxtBoxAddPatronymicEmployee.Clear();
                                    TxtBoxAddSpecializationEmployee.Clear();
                                    TxtBoxAddExperienceEmployee.Clear();
                                    TxtBoxAddLoginEmployee.Clear();
                                    PassBoxFirstCheck.Clear();
                                    PassBoxSecondCheck.Clear();
                                    image_bytes.SetValue(image_bytes, MinValue);
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
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите логин формата x@x.x", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите логин формата x@x.x", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            
        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmobj.GoBack();
        }

        private void UploadEmpImgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите изображение: ";
            ofd.Filter = "Все рисунки|*.jpg;*.jpeg;*.png|" +
                "Формат JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Формат PNG (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                image_bytes = File.ReadAllBytes(ofd.FileName);
                MessageBox.Show(ofd.FileName.ToString());

                if (image_bytes.Length > MaxValue)
                {
                    MessageBox.Show("Размер изображения превышает 5 МБ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    
                    var bi = new BitmapImage();
                    bi.BeginInit();
                    bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.UriSource = new Uri(ofd.FileName);
                    bi.EndInit();
                    ImageEmployeeElement.Source = bi;
                }
            }
            else
            {
                var bi = new BitmapImage();
                string path = System.IO.Path.GetFullPath(@"..\..\Resources\DoctorIcon.jpg");
                bi.BeginInit();
                bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
                bi.EndInit();
                ImageEmployeeElement.Source = bi;
            }
        }
    }
}