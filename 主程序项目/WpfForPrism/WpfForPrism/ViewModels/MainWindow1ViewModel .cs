using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfForPrism.CustomCommands;
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
            ShowCmd = new DoCommand(ShowCmd_Executed);
        }



        private void ShowCmd_Executed(string viewName)
        {
            string par = viewName;
            //虽然实现了功能，但是每个页面都是新对象，所有操作都没办法保留。
            switch (par)
            {
                case "UCA":
                    ShowControl = new UCA();
                    break;
                case "UCB":
                    ShowControl = new UCB();
                    break;
                case "UCC":
                    ShowControl = new UCC();
                    break;
            }
        }

        
        public DoCommand ShowCmd {  get; private set; }
    }
}
