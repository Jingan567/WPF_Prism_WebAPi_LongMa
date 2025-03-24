using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace DailyApp.Wpf.Assets
{
    public static class IconHelper
    {
        // 字体文件路径（示例路径，需根据实际项目调整）
        //private const string FontPath = "/YourProjectName;component/Assets/Fonts/iconfont.ttf#iconfont";
        #region 失败
        //private const string FontPath = "pack://application:,,,//DailyApp.Wpf;component/Assets/Fonts/iconfont.ttf#iconfont";//不行
        //private const string FontPath = "file:///E:\\Code\\VsStudio\\Jingan567\\WPF_Prism_WebAPi_LongMa\\主程序项目\\WpfForPrism\\DailyApp.Wpf\\Assets\\Fonts";
        //private const string FontPath = "/DailyApp.Wpf;component/Assets/Fonts/#iconfont";
        //private const string FontPath = "file:///E:/Code/VsStudio/Jingan567/WPF_Prism_WebAPi_LongMa/主程序项目/WpfForPrism/DailyApp.Wpf/Assets/Fonts/iconfont.ttf#iconfont";
        //private const string FontPath = "file://E:/Code/VsStudio/Jingan567/WPF_Prism_WebAPi_LongMa/主程序项目/WpfForPrism/DailyApp.Wpf/Assets/Fonts/iconfont.ttf#iconfont";
        //var fontFamily = new FontFamily(new Uri("file:///E:\\Code\\VsStudio\\Jingan567\\WPF_Prism_WebAPi_LongMa\\主程序项目\\WpfForPrism\\DailyApp.Wpf\\Assets\\Fonts\\iconfont.ttf"), "iconfont");
        #endregion

        #region 成功
        //private const string FontPath = "file:///E:\\Code\\VsStudio\\Jingan567\\WPF_Prism_WebAPi_LongMa\\主程序项目\\WpfForPrism\\DailyApp.Wpf\\Assets\\Fonts\\#iconfont";//这个样子加载成功了
        //private const string FontPath = "file:///E:\\Code\\VsStudio\\Jingan567\\WPF_Prism_WebAPi_LongMa\\主程序项目\\WpfForPrism\\DailyApp.Wpf\\Assets\\Fonts\\iconfont.ttf#iconfont";//成功
        //var fontFamily = new FontFamily("file:///E:\\Code\\VsStudio\\Jingan567\\WPF_Prism_WebAPi_LongMa\\主程序项目\\WpfForPrism\\DailyApp.Wpf\\Assets\\Fonts\\#iconfont");
        //var fontFamily = new FontFamily("iconfont");//字体安装到电脑后，这样子也行
        //var fontFamily = new FontFamily(new Uri("file:///E:\\Code\\VsStudio\\Jingan567\\WPF_Prism_WebAPi_LongMa\\主程序项目\\WpfForPrism\\DailyApp.Wpf\\Assets\\Fonts\\iconfont.ttf",UriKind.RelativeOrAbsolute), "iconfont");
        //var fontFamily = new FontFamily(new Uri("pack://application:,,,//DailyApp.Wpf;component/Assets/Fonts/iconfont.ttf#iconfont", UriKind.RelativeOrAbsolute), "iconfont");
        //var fontFamily = new FontFamily(new Uri("pack://application:,,,//DailyApp.Wpf;component/Assets/Fonts/iconfont.ttf#iconfont"), "iconfont");
        #endregion


        /// <summary>
        /// 动态生成矢量图标的 DrawingImage
        /// </summary>
        /// <param name="unicode">Unicode字符（如 "\ue600"）</param>
        /// <param name="brush">图标颜色</param>
        /// <param name="emSize">字体大小（EM单位）</param>
        public static DrawingImage CreateIcon(string unicode, Brush brush = null, double emSize = 100)
        {
            var fontFamily = new FontFamily(new Uri("pack://application:,,,//DailyApp.Wpf;component/Assets/Fonts/iconfont.ttf#iconfont"), "iconfont");
            var typeface = new Typeface(
                fontFamily,
                FontStyles.Normal,    // 样式（如 Normal、Italic）
                FontWeights.Bold,     // 粗细（如 Normal、Bold）
                FontStretches.Normal  // 拉伸（如 Normal、Condensed）
            );

            // 1. 创建格式化文本对象
            var formattedText = new FormattedText(
                unicode,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                typeface,// 加载字体
                         //new Typeface(FontPath), // 加载字体
                emSize,
                brush ?? Brushes.Black, // 默认黑色
                VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip // DPI适配
            );

            // 2. 生成几何路径
            Geometry geometry = formattedText.BuildGeometry(new Point(0, 0));

            // 3. 创建 GeometryDrawing
            GeometryDrawing drawing = new GeometryDrawing(
                brush ?? Brushes.Black,
                null, // 无边框
                geometry
            );

            // 4. 创建并返回 DrawingImage
            return new DrawingImage(drawing);
        }

        /// <summary>
        /// 缓存常用图标（提升性能）
        /// </summary>
        private static readonly Dictionary<string, DrawingImage> IconCache = new Dictionary<string, DrawingImage>();

        public static DrawingImage GetCachedIcon(string unicode, Brush brush = null)
        {
            string cacheKey = $"{unicode}_{brush}";
            if (!IconCache.TryGetValue(cacheKey, out var image))
            {
                image = CreateIcon(unicode, brush);
                IconCache[cacheKey] = image;
            }
            return image;
        }
    }
}
