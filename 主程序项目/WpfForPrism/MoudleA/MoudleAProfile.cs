using MoudleA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoudleA
{
    public class MoudleAProfile : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
           
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();//这个位置也将页面类型注入到了容器中
            //containerRegistry.RegisterForNavigation<ViewC>();//这个位置也将页面类型注入到了容器中，
                                                             //这个注册错了，但是能正常使用
            containerRegistry.RegisterDialog<ViewC>();//正确注册导航页面的方法
        }
    }
}
