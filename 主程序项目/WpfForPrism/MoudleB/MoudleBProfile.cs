using MoudleB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoudleB
{
    public class ModleBProfile : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
           
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="containerRegistry"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewB>();
        }
    }
}
