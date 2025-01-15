using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfForPrism.Views;

namespace WpfForPrism.ViewModels
{
    internal class MainWindow1ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private UserControl _showControl;
        public UserControl ShowControl
        {
            get { return _showControl; }
            set
            {
                _showControl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowControl)));
            }
        }
        
        public MainWindow1ViewModel()
        {
            ShowControl = new UCA();
            ShowCmd = new RoutedCommand();
            var bind = new CommandBinding(ShowCmd);
            bind.Executed += ShowCmd_Executed;
            bind.CanExecute += Bind_CanExecute;
        }

        private void Bind_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ShowCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string par = e.Parameter as string;
            switch (par)
            {
                case "ViewA":
                    ShowControl = new UCA();
                    break;
                case "ViewB":
                    ShowControl = new UCB();
                    break;
                case "ViewC":
                    ShowControl = new UCC();
                    break;
            }
        }

        
        public RoutedCommand ShowCmd {  get; private set; }
    }
}
