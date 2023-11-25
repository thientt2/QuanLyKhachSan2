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
        //public ICommand CloseCommand
        //{
        //    get { return new RelayCommand<object>((o) => ((Window)o).Close(), (o) => true); }
        //}
        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null? false : true; }, (p) => {
                FrameworkElement window=GetWindowParent(p);
                var w = window as Window;
                if(w != null)
                {
                    w.Close();
                }
            }
            );
        }
        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
    }
}
