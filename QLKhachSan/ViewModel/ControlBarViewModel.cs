using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public class ControlBarViewModel:BasicViewModel
    {
        #region commands
        public ICommand CloseWindowCommand { get; set; }
        #endregion
        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => { GetWindowParent(p); });
        }
        void GetWindowParent(UserControl p)
        {
            FrameworkElement t = p.Parent as FrameworkElement;
            
        }
    }
}
