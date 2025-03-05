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
    public class MainWindow3_模块ViewModel : BindableBase
    {

        #region DiInterface
        /// <summary>
        /// 导航记录
        /// </summary>
        private IRegionNavigationJournal? _journal;
        private readonly IRegionManager _regionManager;
        /// <summary>
        /// 对话框服务
        /// </summary>
        private readonly IDialogService _dialogService;
        #endregion

        #region Commands
        public DelegateCommand<string> ShowCmd { get; set; }
        /// <summary>
        /// 后退命令
        /// </summary>
        public DelegateCommand BackCmd { get; set; }

        public DelegateCommand<string> ShowDialogCmd { get; set; }
        #endregion


        /// <summary>
        /// 这个构造函数的参数要自己写
        /// </summary>
        /// <param name="regionManager"></param>
        public MainWindow3_模块ViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            ShowCmd = new DelegateCommand<string>(ShowCmd_Executed);
            BackCmd = new DelegateCommand(BackCmd_Action);
            ShowDialogCmd = new DelegateCommand<string>(ShowDialogCmd_Action);
            _regionManager = regionManager;
            _dialogService = dialogService;
        }

        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void ShowDialogCmd_Action(string viewName)
        {
            DialogParameters paras = new DialogParameters();
            paras.Add("Title", "动态传递的标题");
            paras.Add("para1", "参数值1");
            paras.Add("para2", "参数值2");
            _dialogService.ShowDialog(viewName, paras, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    string para1 = callback.Parameters.GetValue<string>("para1");
                }
            });
        }

        private void BackCmd_Action()
        {
            if (_journal != null && _journal.CanGoBack)
                //_journal.CanGoBack主要用来防止页面只有一个，没办法进行操作和后退
                _journal.GoBack();
        }

        private void ShowCmd_Executed(string viewName)
        {
            NavigationParameters paras = new NavigationParameters();//这是一个字典
            paras.Add("MsgA", "大家好，我是A");
            _regionManager.Regions["contentRegion"].RequestNavigate(viewName, CallBack =>
            {
                _journal = CallBack.Context?.NavigationService.Journal;
                //Context这里的上下文可能是空的。
            }, paras);
        }
    }
}
