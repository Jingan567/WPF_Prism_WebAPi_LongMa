﻿using Example;
using Prism.DryIoc;
using Prism.Ioc;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfForPrism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 这是将创建应用程序主窗口的方法。
        /// 应该使用 App 类的 Container 属性来创建窗口，因为它会处理任何依赖项。
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
