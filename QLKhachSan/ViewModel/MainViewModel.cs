using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static QLKhachSan.ViewModel.BasicViewModel;

namespace QLKhachSan.ViewModel
{
   

    public class MainViewModel:BasicViewModel
    {
                    
        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public MainViewModel()
        {        
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                IsLoaded = true;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
            );           
        }
        
    }
}
