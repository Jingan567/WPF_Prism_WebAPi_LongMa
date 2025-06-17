using DailyApp.Wpf.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace DailyApp.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private List<LeftMenuInfo> _LeftMenuList;
        public List<LeftMenuInfo> LeftMenuList
        {
            get
            {
                return _LeftMenuList;
            }
            set
            {
                _LeftMenuList = value;
                RaisePropertyChanged(nameof(LeftMenuList));
            }
        }

        public MainWindowViewModel(IRegionManager manager)
        {
            this.RegionManager = manager;
            
            MoveNextCommand = new DelegateCommand(MoveNext);
            MovePrevCommand = new DelegateCommand(MovePre);
            NavigateCmd = new DelegateCommand<LeftMenuInfo>(Nevigate);
            Title = "这是登录成功后的界面";
            LeftMenuList = new List<LeftMenuInfo>();

            CreateMenu();
        }

        /// <summary>
        /// 创建菜单项
        /// </summary>
        private void CreateMenu()
        {
            LeftMenuList.Add(new LeftMenuInfo()
            {
                Icon = "Home",
                MenuName = "首页",
                ViewName = "HomeUC"
            });

            LeftMenuList.Add(new LeftMenuInfo()
            {
                Icon = "NotebookOutline",
                MenuName = "待办事项",
                ViewName = "WaitUC"
            });

            LeftMenuList.Add(new LeftMenuInfo()
            {
                Icon = "NotebookPlus",
                MenuName = "备忘录",
                ViewName = "MemoUC"
            });

            LeftMenuList.Add(new LeftMenuInfo()
            {
                Icon = "Cog",
                MenuName = "设置",
                ViewName = "SettingsUC"
            });
        }

        public string Title { set; get; }
        //private string Title { set; get; }私有属性不能用于绑定

        #region 区域导航实现导航功能
        private readonly IRegionManager RegionManager;
        /// <summary>
        /// 导航命令
        /// </summary>
        public DelegateCommand<LeftMenuInfo> NavigateCmd { get; set; }

        /// <summary>
        /// 导航
        /// </summary>
        /// <param name="menu">菜单信息</param>
        private void Nevigate(LeftMenuInfo menu)
        {
            if (menu == null || string.IsNullOrEmpty(menu.ViewName)) return;
            RegionManager.Regions["MainViewRegion"].RequestNavigate(menu.ViewName, callback);
        }

        private void callback(NavigationResult result)
        {
            journal = result.Context?.NavigationService.Journal;
        }
        #endregion

        #region 导航前进 后退
        IRegionNavigationJournal journal;
        public DelegateCommand MovePrevCommand { get; set; }
        public DelegateCommand MoveNextCommand { get; set; }

        private void MovePre()
        {
            if (journal != null && journal.CanGoBack) journal.GoBack();
        }

        private void MoveNext()
        {
            if (journal != null && journal.CanGoForward) journal.GoForward();
        }
        #endregion

        #region 默认首页
        public void SetDefaultNav()
        {
            RegionManager.Regions["MainViewRegion"].RequestNavigate("HomeUC", callback);
        }
        #endregion
    }
}
