﻿using DailyApp.Wpf.Assets;
using DailyApp.Wpf.HttpClients;
using DailyApp.Wpf.ViewModels;
using DailyApp.Wpf.Views;
using Prism.Ioc;
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
            //测试
            //return Container.Resolve<IconFontUseDemo>();
            return Container.Resolve<MainWindow>();//设置主界面
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //登录
            containerRegistry.RegisterDialog<LoginUC>();

            //请求
            containerRegistry.GetContainer().Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUri"));
            //made : Parameters.Of.Type<string>(serviceKey: "webUri")这个应该是可选参数的一种写法，Type是委托ParameterSelector的拓展写法

            #region 原版写法
            //containerRegistry.GetContainer().Register<HttpRestClient>(
            //   made: Made.Of(parameters: Parameters.Of.Type<string>(serviceKey: "webUri")));

            #region 语法糖实现
            // 定义隐式转换操作符：从 ParameterSelector → Made
            // public static implicit operator Made(ParameterSelector parameters)
            //    => new Made { Parameters = parameters };
            #endregion 
            #endregion

            containerRegistry.RegisterForNavigation<IconFontUseDemo, IconFontUseDemoViewModel>();

            //导航页
            containerRegistry.RegisterForNavigation<HomeUC, HomeUCViewModel>();//首页
            containerRegistry.RegisterForNavigation<WaitUC, WaitUCViewModel>();//待办事项
            containerRegistry.RegisterForNavigation<MemoUC, MemoUCViewModel>();//备忘录
            containerRegistry.RegisterForNavigation<SettingsUC, SettingsUCViewModel>();//设置

            containerRegistry.RegisterForNavigation<PersonalUC, PersonalUCViewModel>();//个性化页面
            containerRegistry.RegisterForNavigation<AboutUsUC, AboutUsUCViewModel>();//更多页面
            containerRegistry.RegisterForNavigation<SysSetUC, SysSetUCViewModel>();//系统设置页面


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

                //主界面数据上下文
                var mainViewModel = App.Current.MainWindow.DataContext as MainWindowViewModel;
                mainViewModel?.SetDefaultNav();
            });
            #endregion
            base.OnInitialized();
        }
    }

}
