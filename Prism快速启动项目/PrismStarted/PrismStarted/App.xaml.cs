using Example;
using PrismStarted.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PrismStarted
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
            //这个方法比上面的CreateShell先执行
            containerRegistry.Register<WpfForPrism.Services.ICustomerStore, WpfForPrism.Services.DbCustomerStore>();
            // register other needed services here
        }
    }

}
