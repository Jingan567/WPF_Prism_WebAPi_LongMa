using DailyApp.Wpf.DTOS;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyApp.Wpf.ViewModels
{
    /// <summary>
    /// 备忘录模型
    /// </summary>
	public class MemoUCViewModel : BindableBase
	{
        #region 备忘录事项视图模型
        private List<MemoInfoDTO> _memoList;

        public List<MemoInfoDTO> MemoList
        {
            get { return _memoList; }
            set
            {
                _memoList = value;
                RaisePropertyChanged(nameof(MemoList));
            }
        }
        #endregion
        public MemoUCViewModel()
        {
            CreateMemoList();
            ShowAddCommand = new DelegateCommand(ShowAddMemo);
        }

        private void CreateMemoList()
        {
            MemoList = new List<MemoInfoDTO>();
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据1", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据2", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据3", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据4", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据1", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据2", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据3", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据4", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据1", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据2", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据3", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据4", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据1", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据2", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据3", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据4", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据1", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据2", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据3", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据4", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据1", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据2", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据3", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据4", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据1", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据2", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据3", Content = "仔细给客户演示测试" });
            MemoList.Add(new MemoInfoDTO() { Title = "测试数据4", Content = "仔细给客户演示测试" });
        }

        #region 显示添加备忘录
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
        /// 显示添加备忘录
        /// </summary>
        private void ShowAddMemo()
        {
            IsShow = true;
        }

        public DelegateCommand ShowAddCommand { get; set; }
        #endregion
    }
}
