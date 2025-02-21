using Example;
using MoudleA;
using MoudleB;
using Prism.DryIoc;
using Prism.Ioc;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfForPrism.Views;
using WpfForPrism.ViewModels;

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
            return Container.Resolve<MainWindow3_模块>();
        }
        /// <summary>
        /// 注入服务，需要什么服务就注入什么服务。
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<UCA>();
            //containerRegistry.RegisterForNavigation<UCB>();
            //containerRegistry.RegisterForNavigation<UCC>();
            //containerRegistry.RegisterForNavigation<UCC,UCBViewModel>();
        }

        #region 配置模块
        #region 从项目引用中配置模块 
        /// <summary>
        /// 配置模块的方法
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MoudleAProfile>();//这是项目引用的时候配置模块 
            moduleCatalog.AddModule<ModleBProfile>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
        #endregion

        #region 配置模块_从文件夹读取dll
        ///// <summary>
        ///// 从文件夹下最新的dll中读取出来
        ///// </summary>
        ///// <returns></returns>
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath=@".\Modules"};
        //}
        #endregion
        #endregion
    }
}
