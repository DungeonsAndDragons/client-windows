using DnD.View;

namespace DnD
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            var login = new LoginWindow();
            var result = login.ShowDialog();
            if (result == true)
            {
                InitializeComponent();
                DataContext = login.Login.Player;
            }
            else
            {
                Close();
            }
        }
    }
}