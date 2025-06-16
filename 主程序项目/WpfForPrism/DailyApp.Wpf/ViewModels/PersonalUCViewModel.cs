using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Windows.Input;
using MaterialDesignColors.ColorManipulation;

namespace DailyApp.Wpf.ViewModels
{
    public class PersonalUCViewModel : BindableBase
    {
        public PersonalUCViewModel()
        {
            ChangeHueCommand = new DelegateCommand<object>(ChangeHue);
        }

        #region 设置主体背景颜色
        private bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (SetProperty(ref _isDarkTheme, value))
                {
                    ModifyTheme(theme => theme.SetBaseTheme(value ? BaseTheme.Dark : BaseTheme.Light));
                }
            }
        }

        private static void ModifyTheme(Action<Theme> modificationAction)
        {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }
        #endregion

        #region 设置顶部背景色
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;


        public DelegateCommand<object> ChangeHueCommand { get; }

        private void ChangeHue(object? obj)
        {
            Theme theme = paletteHelper.GetTheme();
            Color color = (Color)obj;
            theme.PrimaryLight = new ColorPair(color.Lighten());
            theme.PrimaryMid = new ColorPair(color);
            theme.PrimaryDark = new ColorPair(color.Darken());

            paletteHelper.SetTheme(theme);
        }
        #endregion
    }
}
