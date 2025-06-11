using DailyApp.Wpf.DTOS;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyApp.Wpf.ViewModels
{
    public class WaitUCViewModel : BindableBase
    {
        #region 待办事项视图模型
        private List<WaitInfoDTO> _waitList;

        public List<WaitInfoDTO> WaitList
        {
            get { return _waitList; }
            set
            {
                _waitList = value;
                RaisePropertyChanged(nameof(WaitList));
            }
        }
        #endregion

        /// <summary>
        //构造函数
        /// </summary>
        public WaitUCViewModel()
        {
            CreateWaitList();
            ShowAddCommand = new DelegateCommand(ShowAddWait);
        }

        private void CreateWaitList()
        {
            WaitList = new List<WaitInfoDTO>();
            WaitList.Add(new WaitInfoDTO() { Title = "测试数据1", Content = "仔细给客户演示测试" });
            WaitList.Add(new WaitInfoDTO() { Title = "测试数据2", Content = "仔细给客户演示测试" });
            WaitList.Add(new WaitInfoDTO() { Title = "测试数据3", Content = "仔细给客户演示测试" });
            WaitList.Add(new WaitInfoDTO() { Title = "测试数据4", Content = "仔细给客户演示测试" });
        }

        #region 显示添加待办
        private bool isShow;

        public bool IsShow
        {
            get { return isShow; }
            set
            {
                isShow = value;
                RaisePropertyChanged(nameof(IsShow));
            }
        }
        /// <summary>
        /// 显示添加待办
        /// </summary>
        private void ShowAddWait()
        {
            IsShow = true;
        }

        public DelegateCommand ShowAddCommand { get; set; }
        #endregion
    }
}
