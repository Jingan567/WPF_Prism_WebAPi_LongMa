using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DailyApp.Wpf.ExtendClass.NewPasswordBox
{
    public class PasswordBoxNewEx
    {
        public static string GetNewPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(NewPasswordProperty);
        }

        public static void SetNewPassword(DependencyObject obj, string value)
        {
            obj.SetValue(NewPasswordProperty, value);
        }

        public static readonly DependencyProperty NewPasswordProperty =
            DependencyProperty.RegisterAttached("NewPassword", typeof(string), typeof(PasswordBoxNewEx), new PropertyMetadata("", (d, e) =>
            {
                PasswordBox? passwordBox = d as PasswordBox;
                if (passwordBox != null && e.NewValue?.ToString() != passwordBox.Password)
                {
                    passwordBox.Password = e.NewValue as string;
                    if (passwordBox.Password != null)
                        SetSelection(passwordBox, passwordBox.Password.Length, 0);
                }
            }));

        /// <summary>
        /// 设置光标位置
        /// </summary>
        /// <param name="passwordBox"></param>
        /// <param name="start">光标开始位置</param>
        /// <param name="length">选中长度</param>
        private static void SetSelection(PasswordBox passwordBox, int start, int length)
        {
            passwordBox?.GetType()
                       .GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)?
                       .Invoke(passwordBox, new object[] { start, length });
        }
    }

    /// <summary>
    /// Password行为 Password变化 自定义附加属性跟着变化
    /// </summary>
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        /// <summary>
        /// 附加 注入事件
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox? passwordBox = sender as PasswordBox;
            if (passwordBox != null && PasswordBoxNewEx.GetNewPassword(passwordBox) != passwordBox.Password)
            {
                PasswordBoxNewEx.SetNewPassword(passwordBox, passwordBox.Password);
            }
        }

        /// <summary>
        /// 销毁 移除事件
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= OnPasswordChanged;
        }
    }
}
