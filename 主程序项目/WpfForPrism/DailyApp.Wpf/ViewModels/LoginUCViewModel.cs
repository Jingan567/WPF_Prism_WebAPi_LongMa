using DailyApp.Wpf.DTOS;
using DailyApp.Wpf.HttpClients;
using DailyApp.Wpf.MsgEvents;
using Prism.Commands;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DailyApp.Wpf.ViewModels
{
    public class LoginUCViewModel : BindableBase, IDialogAware
    {
        #region Commands
        public DelegateCommand Login { get; set; }

        //注册命令
        public DelegateCommand Register { get; set; }
        public DelegateCommand RollBack { get; set; }
        //public DelegateCommand<int?> ChangePartUI { get; set; }//T for DelegateCommand<T> is not an object nor Nullable.改成可为空就可以了。可能原因前端传过来的是string，可能有空值，编译器不允许
        public DelegateCommand<string> ChangePartUI { get; set; }//页面传过来的是string
        #endregion

        #region EventAggregator
        private readonly IEventAggregator aggregator;
        #endregion

        public LoginUCViewModel(HttpRestClient _httpRestClient, IEventAggregator _aggregator)
        {
            Login = new DelegateCommand(Login_Action);
            Register = new DelegateCommand(Register_Action);
            //RollBack = new DelegateCommand(RollBack_Action);
            ChangePartUI = new DelegateCommand<string>(ChangePartUI_Action);

            //实例化注册信息防止空指针异常
            AccountInfoDTO = new AccountInfoDTO();

            //请求客户端
            httpRestClient = _httpRestClient;

            //发布订阅
            aggregator = _aggregator;
        }

        #region CommandsAction
        private void ChangePartUI_Action(string index)
        {
            SelectedIndex = Convert.ToInt32(index);
        }

        private void Login_Action()
        {
            string pwd = Password;
            //模拟登录
            RequestClose.Invoke(ButtonResult.OK);
        }

        private void Register_Action()
        {
            string errStr;
            //数据校验
            if (!NotNull(AccountInfoDTO.Name, AccountInfoDTO.Account, AccountInfoDTO.Password, AccountInfoDTO.ConfirmPassword))
            {
                errStr = "信息不全，请补充完整！";
                aggregator.GetEvent<MsgEvent>().Publish(errStr);
                //MessageBox.Show(errStr);
                return;
            }
            if (AccountInfoDTO.Password != AccountInfoDTO.ConfirmPassword)
            {
                //对密码进行加密之后，第二次界面密码是一样的，但后端密码不一致，所以会提示两次密码不一致
                //目前我采取的是将确认密码也加密了
                errStr = "两次输入的密码不一致！请重新输入！";
                aggregator.GetEvent<MsgEvent>().Publish(errStr);
                //MessageBox.Show(errStr);
                return;
            }

            //调用Api
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Method = Method.POST;
            apiRequest.Route = "Account/Register";

            //对密码进行处理
            AccountInfoDTO.Password = Md5Helper.GetMd5(AccountInfoDTO.Password);//这个赋值没有改变对象，不会触发界面更新
            //RaisePropertyChanged(nameof(AccountInfoDTO));调用这个就可以 实时更新界面
            AccountInfoDTO.ConfirmPassword = Md5Helper.GetMd5(AccountInfoDTO.ConfirmPassword);


            apiRequest.Parameters = AccountInfoDTO;//这里的密码是明文，后端需要加密

            var response = httpRestClient.Execute(apiRequest);
            if (response.ResultCode == 1)
            {
                //MessageBox.Show(response.Msg);
                aggregator.GetEvent<MsgEvent>().Publish(response.Msg);
                SelectedIndex = 0;//注册成功，切换到登录
            }
            else
            {
                //MessageBox.Show(response.Msg);
                aggregator.GetEvent<MsgEvent>().Publish(response.Msg);
            }
        }

        /// <summary>
        /// 是否没有空值
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>有空值返回false，全不为空返回true</returns>
        private bool NotNull(params string[] parameters)
        {
            bool res = false;
            for (int i = 0; i < parameters.Length; i++)
            {
                res = string.IsNullOrEmpty(parameters[i]);
                if (res)
                {
                    return !res;
                }
            }
            return !res;
        }

        private void RollBack_Action()
        {
            SelectedIndex = 0;
        }
        #endregion

        private string _title = "登录窗口";

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// 这个RequestClose会由容器向里面注入,没有set,但是确实注入成功了，不清楚怎么做到的
        /// </summary>
        public DialogCloseListener RequestClose { get; }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            //RequestClose.Invoke(ButtonResult.OK);
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        #region 显示内容的索引
        private int _selectedIndex;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    RaisePropertyChanged(nameof(SelectedIndex));
                }
            }
        }
        #endregion

        #region 密码
        private string password = "";

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        #endregion

        #region 注册信息
        private AccountInfoDTO accountInfoDTO;

        public AccountInfoDTO AccountInfoDTO
        {
            get { return accountInfoDTO; }
            set
            {
                accountInfoDTO = value;
                RaisePropertyChanged(nameof(AccountInfoDTO));
            }
        }
        private string retryPassword;

        public string RetryPassword
        {
            get { return retryPassword; }
            set
            {
                retryPassword = value;
                RaisePropertyChanged(nameof(RetryPassword));
            }
        }


        #endregion

        #region RestClient客户端字段
        private readonly HttpRestClient httpRestClient;
        #endregion

    }
}
