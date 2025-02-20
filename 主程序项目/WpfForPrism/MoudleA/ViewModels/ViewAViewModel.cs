using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MoudleA.ViewModels
{
    public class ViewAViewModel : BindableBase, IConfirmNavigationRequest//, INavigationAware
    {
        /// <summary>
        /// 绑定的内容
        /// </summary>
        private string _Msg;

        /// <summary>
        /// 绑定的内容
        /// </summary>
        public string Msg
        {
            get { return _Msg; }
            set { _Msg = value; }
        }

        public ViewAViewModel()
        {

        }

        /// <summary>
        /// 是否重用实例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 导航离开之后，触发
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// 导航已经过来，接收参数，To在From后面
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("MsgA"))
                Msg = navigationContext.Parameters.GetValue<string>("MsgA");
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;
            if (MessageBox.Show("确定切换吗？", "温馨提示", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                result = false;
            }
            continuationCallback(result);//
        }
    }
}
