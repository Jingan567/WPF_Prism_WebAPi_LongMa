using DailyApp.Wpf.DTOS;
using DailyApp.Wpf.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyApp.Wpf.ViewModels
{
    public class HomeUCViewModel : BindableBase
    {
        #region 统计面板数据
        private List<StatePanelInfo> statePanelList;
        public List<StatePanelInfo> StatePanelList
        {
            get { return statePanelList; }
            set
            {
                statePanelList = value;
                RaisePropertyChanged(nameof(StatePanelList));
            }
        }
        #endregion

        #region 待办事项数据
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

        #region 备忘录数据 
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

        public HomeUCViewModel()
        {
            CreateStatePanelList();
            CreateWaitList();
            CreateMemoList();
        }

        private void CreateMemoList()
        {
            MemoList = new List<MemoInfoDTO>()
            {
                new MemoInfoDTO()
                {
                     MemoId= 0,
                    Title="吕龙龙是个大傻逼",
                    Content="吕龙龙是个大傻逼",
                    Status=0
                },
                 new MemoInfoDTO()
                {
                    MemoId = 1,
                    Title="吕龙龙是个大傻逼",
                    Content="吕龙龙是个大傻逼",
                    Status=0
                }
            };
        }

        /// <summary>
        /// 创建数据
        /// </summary>
        private void CreateStatePanelList()
        {
            StatePanelList = new List<StatePanelInfo>
            {
                new StatePanelInfo
                {
                    Icon = "ClockFast",
                    ItemName = "汇总",
                    Result = "9",
                    BackColor = "#FF0CA0FF",
                    ViewName = "WaitUC"
                },
                new StatePanelInfo
                {
                    Icon = "ClockCheckOutline",
                    ItemName = "已完成",
                    Result = "9",
                    BackColor = "#FF02FB98",
                    ViewName = "WaitUC"
                },
                new StatePanelInfo
                {
                    Icon = "ChartLineVariant",
                    ItemName = "完成比例",
                    Result = "90%",
                    BackColor = "#FF02C6DC",
                    ViewName = ""
                },
                new StatePanelInfo
                {
                    Icon = "PlaylistStar",
                    ItemName = "备忘录",
                    Result = "20",
                    BackColor = "#FFFFA000",
                    ViewName = "MemoUC"
                }
            };
        }

        /// <summary>
        /// 创建待办信息
        /// </summary>
        private void CreateWaitList()
        {
            WaitList = new List<WaitInfoDTO>()
            {
                new WaitInfoDTO()
                {
                    WaitId = 0,
                    Title="吕龙龙是个大傻逼",
                    Content="吕龙龙是个大傻逼",
                    Status=0
                },
                 new WaitInfoDTO()
                {
                    WaitId = 1,
                    Title="吕龙龙是个大傻逼",
                    Content="吕龙龙是个大傻逼",
                    Status=0
                }
            };
        }
    }
}
