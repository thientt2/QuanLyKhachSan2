using QLKhachSan.ViewModel;
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

namespace QLKhachSan
{
    /// <summary>
    /// Interaction logic for ChangePWWindow.xaml
    /// </summary>
    public partial class ChangePWWindow : Window
    {
        public ChangePWWindow()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            // Gọi phương thức xóa thông tin trong ViewModel
            if (DataContext is ChangePasswordViewModel viewModel)
            {
                viewModel.ClearPasswords();
            }
        }
    }
}