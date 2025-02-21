using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoudleA.ViewModels
{
    public class ViewCViewModel : BindableBase, IDialogAware
    {
        public ViewCViewModel()
        {
            RequestClose = new DialogCloseListener();
        }

        private string _title = "这是对话框的标题";//
        /// <summary>
        /// 这个在哪里绑定到对话框标题上，没看出来。
        /// 之前接口里面有这个属性，现在接口里面也没有啊
        /// 并且这个名字还不能更改，否则就不显示了
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged(nameof(Title));//属性更改通知界面
                }
            }
        }


        public DialogCloseListener RequestClose { get; }

        /// <summary>
        /// 是否能够关闭对话框
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
            //return false;//页面关闭按钮还在，只是不能关闭页面了
        }

        /// <summary>
        /// 关闭，需要处理的事情
        /// </summary>
        public void OnDialogClosed()
        {

        }

        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("Title");
        }
    }
}
