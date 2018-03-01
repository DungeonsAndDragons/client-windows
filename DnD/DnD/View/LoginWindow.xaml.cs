using DnD.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace DnD.View
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        public LoginViewModel Login { get; }

        public LoginWindow()
        {
            DataContext = Login = new LoginViewModel();
            Login.PropertyChanged += Login_PropertyChanged;
            InitializeComponent();
        }

        private void Login_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Login.LoginSuccessfull) && Login.LoginSuccessfull)
            {
                DialogResult = true;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Login.Password = ((PasswordBox)sender).SecurePassword;
        }
    }
}
