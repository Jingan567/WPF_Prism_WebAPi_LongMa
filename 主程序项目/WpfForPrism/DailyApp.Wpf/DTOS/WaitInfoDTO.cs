using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.Wpf.DTOS
{
    public class WaitInfoDTO
    {
        /// <summary>
        /// 待办事项ID
        /// </summary>
        public int WaitId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 状态，用整型数字比Bool更好一点
        /// </summary>
        public int Status { get; set; }
    }
}
