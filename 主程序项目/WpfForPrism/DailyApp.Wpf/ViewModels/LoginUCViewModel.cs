using DailyApp.Wpf.HttpClients;
using Prism.Commands;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyApp.Wpf.ViewModels
{
    public class LoginUCViewModel : BindableBase, IDialogAware
    {
        #region Commands
        public DelegateCommand Login { get; set; }
        public DelegateCommand Register { get; set; }
        public DelegateCommand RollBack { get; set; }
        //public DelegateCommand<int?> ChangePartUI { get; set; }//T for DelegateCommand<T> is not an object nor Nullable.改成可为空就可以了。可能原因前端传过来的是string，可能有空值，编译器不允许
        public DelegateCommand<string> ChangePartUI { get; set; }//页面传过来的是string
        #endregion

        public LoginUCViewModel()
        {
            Login = new DelegateCommand(Login_Action);
            Register = new DelegateCommand(Register_Action);
            //RollBack = new DelegateCommand(RollBack_Action);
            ChangePartUI = new DelegateCommand<string>(ChangePartUI_Action);
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
            HttpRestClient restClient = new HttpRestClient();
            restClient.Execute(new ApiRequest() { 
                Route= "Account/Register",
                Method = Method.POST,
                ContentType = "application/json",
                Parameters = new { UserName = "admin", Password = "123456" }
            });
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

    }
}
