using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoudleB.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        public ViewBViewModel()
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;//配置完这个之后，就每次都是一个新对象，对页面的操作消失。默认是重用的！！！
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}
