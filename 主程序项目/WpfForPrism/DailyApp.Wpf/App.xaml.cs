using DailyApp.Wpf.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DailyApp.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 设置启动窗口
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
           return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<LoginUC>(); 
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            #region 登录前弹窗判断
            var dialogService = Container.Resolve<IDialogService>();
            dialogService.ShowDialog("LoginUC", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    Environment.Exit(0);//终止此进程并向作系统返回退出代码。
                    return;
                }
            });
            #endregion
            base.OnInitialized();
        }
    }

}
