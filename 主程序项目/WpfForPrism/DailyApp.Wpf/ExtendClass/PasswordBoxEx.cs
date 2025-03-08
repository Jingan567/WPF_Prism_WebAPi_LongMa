using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace DailyApp.Wpf.ExtendClass
{
    /// <summary>
    /// 这个类是为了解决PasswordBox的Password属性不能绑定的问题
    /// </summary>
    public class PasswordBoxEx
    {
        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxEx), new PropertyMetadata((d, e) =>
            {
                if (e.OldValue != e.NewValue)
                {
                    PasswordBox? pb = d as PasswordBox;
                    if (pb != null && (string)e.NewValue != pb.Password)
                    {
                        pb.Password = e.NewValue as string;
                        if (pb.Password != null)
                            SetSelection(pb, pb.Password.Length, 0);
                    }
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

        #region 附加属性是否绑定
        public static bool GetIsBind(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsBindProperty);
        }

        public static void SetIsBind(DependencyObject obj, bool value)
        {
            obj.SetValue(IsBindProperty, value);
        }

        // 这个附加属性实际上使用来将Password的属性改变事件后面挂载事件去改变PasswordBoxEx.Password的值
        public static readonly DependencyProperty IsBindProperty =
            DependencyProperty.RegisterAttached("IsBind", typeof(bool), typeof(PasswordBoxEx), new PropertyMetadata((d, e) =>
            {
                PasswordBox? pb = d as PasswordBox;
                if (pb != null)
                {
                    if ((bool)e.NewValue)
                    {
                        pb.PasswordChanged += Pb_PasswordChanged;
                    }
                    else
                    {
                        pb.PasswordChanged -= Pb_PasswordChanged;
                    }
                }
            }));

        private static void Pb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox? pb = sender as PasswordBox;
            if (pb != null)
            {
                SetPassword(pb, pb.Password);
            }
        }
        #endregion
    }
}
