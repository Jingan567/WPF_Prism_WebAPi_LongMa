using DailyApp.Wpf.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace DailyApp.Wpf.ViewModels
{
    public class SettingsUCViewModel : BindableBase
    {
        #region 左侧菜单
        private List<LeftMenuInfo> leftMenuInfos;

        public List<LeftMenuInfo> LeftMenuList
        {
            get { return leftMenuInfos; }
            set
            {
                leftMenuInfos = value;
                RaisePropertyChanged(nameof(LeftMenuList));
            }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public SettingsUCViewModel(IRegionManager _RegionManager)
        {
            CreateMenu();
            NavigateCmd = new DelegateCommand<LeftMenuInfo>(Nevigate);
            RegionManager = _RegionManager;
        }

        private readonly IRegionManager RegionManager;

        private void Nevigate(LeftMenuInfo menu)
        {
            if (menu == null || string.IsNullOrEmpty(menu.ViewName)) return;
            RegionManager.Regions["SettingRegion"].RequestNavigate(menu.ViewName);
        }

        /// <summary>
        /// 创建菜单项
        /// </summary>
        private void CreateMenu()
        {
            LeftMenuList = new List<LeftMenuInfo>();
            LeftMenuList.Add(new LeftMenuInfo()
            {
                Icon = "Palette",
                MenuName = "个性化",
                ViewName = "PersonalUC"
            });

            LeftMenuList.Add(new LeftMenuInfo()
            {
                Icon = "Cog",
                MenuName = "系统设置",
                ViewName = "SysSetUC"
            });

            LeftMenuList.Add(new LeftMenuInfo()
            {
                Icon = "Information",
                MenuName = "关于更多",
                ViewName = "AboutUsUC"
            });
        }


        /// <summary>
        /// 导航命令
        /// </summary>
        public DelegateCommand<LeftMenuInfo> NavigateCmd { get; set; }
    }
}
