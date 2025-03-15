using DailyApp.Wpf.MsgEvents;
using System.Windows.Controls;

namespace DailyApp.Wpf.Views
{
    /// <summary>
    /// Interaction logic for LoginUC
    /// </summary>
    public partial class LoginUC : UserControl
    {
        /// <summary>
        /// Prism框架提供，发布订阅
        /// </summary>
        private IEventAggregator aggregator { get; set; }
        public LoginUC(IEventAggregator _aggregator)
        {
            InitializeComponent();
            aggregator = _aggregator;
            aggregator.GetEvent<MsgEvent>().Subscribe(msg =>
            {
                ReLogBar.MessageQueue?.Enqueue(msg);//这个地方是界面上的控件
            });
        }
    }
}
