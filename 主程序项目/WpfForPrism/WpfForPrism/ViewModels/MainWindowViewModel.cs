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

    internal class MainWindowViewModel : BindableBase
    {
        //BindableBase 这是Prism中用于绑定的类
        private UserControl _showControl;
        public UserControl ShowControl
        {
            get { return _showControl; }
            set
            {
                _showControl = value;
                RaisePropertyChanged(nameof(ShowControl));
            }
        }
        public DelegateCommand<string> ShowCmd { get; private set; }

        public MainWindowViewModel()
        {
            ShowCmd = new DelegateCommand<string>(OnShowCmdExecuted);
        }

        private void OnShowCmdExecuted(string viewName)
        {
            switch (viewName)
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
    }
}
