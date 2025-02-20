using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using WpfForPrism.Views;

namespace WpfForPrism.ViewModels
{
	public class MainWindow2ViewModel : BindableBase
	{
        public DelegateCommand<string> ShowCmd { get; set; }

        private readonly IRegionManager _regionManager;

        /// <summary>
        /// 这个构造函数的参数要自己写
        /// </summary>
        /// <param name="regionManager"></param>
        public MainWindow2ViewModel(IRegionManager regionManager)
        {
            ShowCmd = new DelegateCommand<string>(ShowCmd_Executed);
            _regionManager = regionManager;
        }

    
        private void ShowCmd_Executed(string viewName)
        {
            _regionManager.Regions["contentRegion"].RequestNavigate(viewName);
        }

    }
}
