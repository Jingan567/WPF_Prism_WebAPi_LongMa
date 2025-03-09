using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.Wpf.DTOS
{
    /// <param name="Name"> 姓名 </param>
    /// <param name="Account"> 登录账号 </param>
    /// <param name="Password"> 密码 </param>
    /// <param name="ConfirmPassword">确认密码</param>
    public record AccountInfoDTO(string Name, string Account, string Password, string ConfirmPassword);
}
