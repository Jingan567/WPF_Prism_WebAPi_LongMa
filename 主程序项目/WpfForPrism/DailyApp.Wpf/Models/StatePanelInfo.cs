using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.Wpf.Models
{
    /// <summary>
    /// 首页统计面板信息
    /// </summary>
    public class StatePanelInfo
    {
        /// <summary>
        /// 统计项图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 统计项名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 统计结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 背景颜色
        /// </summary>
        public string BackColor { get; set; }

        /// <summary>
        /// 点击 跳转到的界面名称
        /// </summary>
        public string ViewName { get; set; }
    }
}
