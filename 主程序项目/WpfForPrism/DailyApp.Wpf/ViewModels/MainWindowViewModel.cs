using DailyApp.Wpf.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public MainWindowViewModel()
        {
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
                ViewName = "IndexView"
            });

            LeftMenuList.Add(new LeftMenuInfo()
            {
                Icon = "NotebookOutline",
                MenuName = "待办事项",
                ViewName = "ToDoView"
            });

            LeftMenuList.Add(new LeftMenuInfo()
            {
                Icon = "NotebookPlus",
                MenuName = "备忘录",
                ViewName = "MemoView"
            });

            LeftMenuList.Add(new LeftMenuInfo()
            {
                Icon = "Cog",
                MenuName = "设置",
                ViewName = "SettingsView"
            });
        }

        public string Title { set; get; }
        //private string Title { set; get; }私有属性不能用于绑定

    }
}
