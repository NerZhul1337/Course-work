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
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();

            TxtBoxLogAuth.MaxLength = 50;
            PassBoxPassAuth.MaxLength = 25;

            TxtBoxLogAuth.ToolTip = "Введите ваш логин";
            PassBoxPassAuth.ToolTip = "Введите ваш пароль, длина которого не менее 6 символов";
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            String Login = TxtBoxLogAuth.Text;
            String Password = PassBoxPassAuth.Password;

            if (Login != "" && Password != "")
            {
                var Level = DBHospitalEntities.GetContext().Doctors_Table.FirstOrDefault(x => x.User_login == TxtBoxLogAuth.Text && x.User_pass == PassBoxPassAuth.Password);
                if (Level != null)
                {
                    if (Level.Access_Level_Table.id_access_level == 1)
                    {
                        MessageBox.Show($"Администратор - {Level.Name_doctor} авторизован!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                        FrameClass.frmobj.Navigate(new MainViewPage(Level));
                        TxtBoxLogAuth.Text = null;
                        PassBoxPassAuth.Password = null;
                        FrameClass.UserName = Level.Name_doctor;
                        FrameClass.UserSurname = Level.Surname_doctor;
                    }
                    else if (Level.Access_Level_Table.id_access_level == 2)
                    {
                        MessageBox.Show($"Главный врач - {Level.Name_doctor}, авторизован!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                        FrameClass.frmobj.Navigate(new MainViewPage(Level));
                        TxtBoxLogAuth.Text = null;
                        PassBoxPassAuth.Password = null;
                        FrameClass.UserName = Level.Name_doctor;
                        FrameClass.UserSurname = Level.Surname_doctor;
                    }
                    else if (Level.Access_Level_Table.id_access_level == 3)
                    {
                        MessageBox.Show($"Доктор - {Level.Name_doctor}, авторизован!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                        FrameClass.frmobj.Navigate(new MainViewPage(Level));
                        TxtBoxLogAuth.Text = null;
                        PassBoxPassAuth.Password = null;
                        Classes.FrameClass.UserID = Level.id_doctor;
                        Classes.FrameClass.LvlAccID = Level.id_access_level;
                        FrameClass.UserName = Level.Name_doctor;
                        FrameClass.UserSurname = Level.Surname_doctor;
                    }
                }
                else MessageBox.Show("Данный пользователь не существует", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
