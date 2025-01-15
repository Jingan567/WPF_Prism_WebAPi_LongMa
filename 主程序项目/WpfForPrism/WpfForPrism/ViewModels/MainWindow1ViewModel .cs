using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfForPrism.Views;

namespace WpfForPrism.ViewModels
{
    internal class MainWindow1ViewModel: INotifyPropertyChanged
    {
		private UserControl _showControl;
		public UserControl ShowControl
        {
			get { return _showControl; }
			set { _showControl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowControl)));
            }
		}
        public MainWindow1ViewModel()
        {
            ShowControl = new UCA();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
