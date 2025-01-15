using Example;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismStarted.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        //单步执行初始化对象的时候，还会将Get方法也初始化一下。顺序都是从上往下
        //1、字段和属性的初始化最先
        //2、Get方法
        //3、构造函数

        #region 获取数据源
        private WpfForPrism.Services.ICustomerStore _customerStore = null;

        public MainWindowViewModel(WpfForPrism.Services.ICustomerStore customerStore)
        {
            _customerStore = customerStore;
        }
        #endregion


        /// <summary>
        /// ObservableCollection 是一个特殊的集合，当集合中的数据发生变化时，它会通知绑定到它的视图进行更新。
        /// </summary>
        public ObservableCollection<string> Customers { get; private set; } =
            new ObservableCollection<string>();


        private string _selectedCustomer = null;
        public string SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (SetProperty<string>(ref _selectedCustomer, value))
                {
                    Debug.WriteLine(_selectedCustomer ?? "no customer selected");
                }
            }
        }

        #region 命令
        private DelegateCommand _commandLoad = null;
        public DelegateCommand CommandLoad =>
            _commandLoad ?? (_commandLoad = new DelegateCommand(CommandLoadExecute));

        private void CommandLoadExecute()
        {
            Customers.Clear();
            List<string> list = _customerStore.GetAll();
            foreach (string item in list)
                Customers.Add(item);
        }
        #endregion
    }
}
