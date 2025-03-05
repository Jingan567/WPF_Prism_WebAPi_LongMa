using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoudleA.ViewModels
{
    public class ViewCViewModel : BindableBase, IDialogAware
    {
        public DelegateCommand Comfirm {  get; set; }
        public DelegateCommand Quit {  get; set; }

        public ViewCViewModel()
        {
            //RequestClose = new DialogCloseListener();//我自己在这里new了一个，这里不new也会在容器里面通过反射被注入对象
            Comfirm = new DelegateCommand(Confirm_Action);
            Quit = new DelegateCommand(Quit_Action);
        }

        private void Quit_Action()
        {
            RequestClose.Invoke(ButtonResult.No);//这个传完参数，会关闭兑换框
        }

        private void Confirm_Action()
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("张三", 100);
            parameters.Add("黎诗", 100);
            RequestClose.Invoke(parameters, ButtonResult.Yes);
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
                    //SetProperty(ref _title, value,nameof(Title));// 触发属性变更通知,这个简单测试一下好像没反应
                }
            }
        }

        /// <summary>
        /// 这个事件一旦触发会执行关闭流程，无论传入的参数是什么。先执行CanCloseDialog => OnDialogClosed
        /// 这个将事件public event Action<IDialogResult> RequestClose包装了一下
        /// </summary>
        public DialogCloseListener RequestClose { get; }
        /// <summary>
        /// 自己定义一个关闭窗体的信号变量
        /// </summary>
        private bool _canCloseDialog = true;

        /// <summary>
        /// 是否能够关闭对话框
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            //return true;
            //return false;//页面关闭按钮还在，只是不能关闭页面了

            return _canCloseDialog;//天才和蠢材只在一念之间
            #region 蠢材写法
            //if (_canCloseDialog)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            #endregion
        }

        /// <summary>
        /// 关闭，需要处理的事情
        /// 所有触发关闭关闭都走这个事件，可以传递参数
        /// </summary>
        public void OnDialogClosed()
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("张三", 100);
            parameters.Add("黎诗", 100);
            RequestClose.Invoke(parameters, ButtonResult.OK);
        }

        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("Title");
            string p1 = parameters.GetValue<string>("para1");
            string p2 = parameters.GetValue<string>("para2");
        }
    }
}
