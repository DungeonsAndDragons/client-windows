using DnD.Model;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Input;

namespace DnD.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        public ICommand LoginCommand => new ActionCommand(Login);

        public string Username
        {
            get => username;
            set => SetPropertyValue(ref username, value);
        }

        public SecureString Password
        {
            get => password;
            set => SetPropertyValue(ref password, value);
        }

        public bool LoginFailed
        {
            get => loginFailed;
            private set => SetPropertyValue(ref loginFailed, value);
        }

        public bool LoginSuccessfull
        {
            get => loginSuccess;
            private set => SetPropertyValue(ref loginSuccess, value);
        }

        public PlayerViewModel Player => playerViewModel;


        public string PlaintextPassword => SecureStringToString(password);

        private string username;
        private SecureString password;
        private bool loginFailed;
        private bool loginSuccess;
        private PlayerViewModel playerViewModel;

        public void Login()
        {
            LoginSuccessfull = true;
            Player player = new Player
            {
                Name = username
            };
            playerViewModel = new PlayerViewModel(player);
        }

        private string SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
