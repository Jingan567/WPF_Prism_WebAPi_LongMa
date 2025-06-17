
using System.ComponentModel.DataAnnotations;//提供用于为 ASP.NET MVC 和 ASP.NET 数据控件定义元数据的特性类。
using System.ComponentModel.DataAnnotations.Schema;//为用于定义 ASP.NET MVC 和 ASP.NET 数据控件的元数据的属性类提供支持。
//Annotation是注解的意思

namespace DailyApp.Api.DataModel
{
    /// <summary>
    /// 账户信息
    /// </summary>
    [Table("AccountInfo")]//不指定表名默认是类名
    public class AccountInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]//主键 自增
        public int AccountId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        [MaxLength(255)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(255)]
        public string Password { get; set; }
    }
}
