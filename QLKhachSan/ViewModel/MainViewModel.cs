using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLKhachSan.ViewModel
{
    public class MainViewModel:BasicViewModel
    {
        public bool IsLoaded = false;
        public MainViewModel()
        {
            
            if (!IsLoaded)
            {
                IsLoaded = true;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
        }
        
    }
}
