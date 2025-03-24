using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Media3D;

namespace DailyApp.Wpf.Assets
{
    class IconFontHelper
    {
       static IconFontHelper() 
        {
            MinimizeIcon = GetIconGeometry("\ue62d", "pack://application:,,,//DailyApp.Wpf;component/Assets/Fonts/iconfont.ttf#iconfont");
        }
        // 在 Window 或 ViewModel 中定义生成方法
        private static Geometry GetIconGeometry(string iconUnicode, string fontFamilyPath)
        {
            var formattedText = new FormattedText(
                iconUnicode,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(new FontFamily(new Uri(fontFamilyPath), "iconfont"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                24, // 字体大小（不影响最终缩放）
                Brushes.Black,
                VisualTreeHelper.GetDpi(new Window()).PixelsPerDip
            );

            return formattedText.BuildGeometry(new Point(0, 0));
        }

        private static Geometry? minimizeIcon;
        public static Geometry MinimizeIcon
        {
            get
            {
                return minimizeIcon;
            }
            set
            {
                minimizeIcon = value;
            }
        }
    }
}
