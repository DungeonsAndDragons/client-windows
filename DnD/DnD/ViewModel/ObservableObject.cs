using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DnD.ViewModel
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        private static string version = typeof(ObservableObject).Assembly.GetName().Version.ToString();

        public string Version => version;

        protected void SetPropertyValue<T>(ref T field, T value, [CallerMemberName]string property = null)
        {
            field = value;
            SendPropertyUpdate(property);
        }

        protected void SendPropertyUpdate([CallerMemberName]string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}