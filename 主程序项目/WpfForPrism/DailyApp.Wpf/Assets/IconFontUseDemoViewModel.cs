using Prism.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DailyApp.Wpf.Assets
{
    public class IconFontUseDemoViewModel : BindableBase
    {
        // 绑定到 Image.Source 的属性
        private ImageSource _minimizeIcon;
        public ImageSource MinimizeIcon
        {
            get => _minimizeIcon;
            set{
                _minimizeIcon = value;
                RaisePropertyChanged(nameof(MinimizeIcon));
            }
        }

        public IconFontUseDemoViewModel()
        {
            // 动态生成图标（使用缓存版本）
            MinimizeIcon = IconHelper.GetCachedIcon("\ue62d", Brushes.Red);
        }
    }
}
