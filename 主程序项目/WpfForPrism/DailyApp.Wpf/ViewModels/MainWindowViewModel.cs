using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyApp.Wpf.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
        public MainWindowViewModel()
        {
            Title = "这是登录成功后的界面";
        }

        public string Title { set; get; }
        //private string Title { set; get; }私有属性不能用于绑定

    }
}
