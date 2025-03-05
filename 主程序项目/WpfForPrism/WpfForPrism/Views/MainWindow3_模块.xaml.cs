using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfForPrism.Views
{
    /// <summary>
    /// MainWindow2.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow3_模块 : Window
    {
        private readonly IEventAggregator EventAggregator;
        public MainWindow3_模块(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            EventAggregator = eventAggregator;
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPubClick(object sender, RoutedEventArgs e)
        {
            EventAggregator.GetEvent<MsgEvent>().Publish("Hello, 我想出去旅游！");
        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubClick(object sender, RoutedEventArgs e)
        {
            EventAggregator.GetEvent<MsgEvent>().Subscribe(MsgEvent_Action);
        }

        private void MsgEvent_Action(string obj)
        {
            MessageBox.Show($"我收到的订阅消息：{obj.ToString()}");//这里应该不会阻塞，但是看执行的时候还是有先后
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelSubClick(object sender, RoutedEventArgs e)
        {
            EventAggregator.GetEvent<MsgEvent>().Unsubscribe(MsgEvent_Action);
        }
    }
}
