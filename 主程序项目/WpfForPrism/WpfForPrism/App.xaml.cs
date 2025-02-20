using Example;
using MoudleA;
using Prism.DryIoc;
using Prism.Ioc;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfForPrism.Views;
using MoudleB;

namespace WpfForPrism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 设置启动页
        /// 这是将创建应用程序主窗口的方法。
        /// 应该使用 App 类的 Container 属性来创建窗口，因为它会处理任何依赖项。
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            //Container 容器
            //Resolve<MainWindow> 从容器中解析出MainWindow
            return Container.Resolve<MainWindow1>();
        }
        /// <summary>
        /// 注入服务，需要什么服务就注入什么服务。
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MoudleAProfile>();
            moduleCatalog.AddModule<ModleBProfile>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
