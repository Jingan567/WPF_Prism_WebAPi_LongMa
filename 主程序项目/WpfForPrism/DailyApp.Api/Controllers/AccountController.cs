using DailyApp.Api.ApiResponses;
using DailyApp.Api.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private readonly DailyDbContext db;

        /// <summary>
        /// 构造函数，通过构造函数注入数据库上下文
        /// </summary>
        /// <param name="context"></param>
        public AccountController(DailyDbContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="accountInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(DTOS.AccountInfoDTO accountInfo)
        {
            ApiResponse response = new ApiResponse(); //响应的数据
            //业务
            try
            {
                //1、账号是否存在
                var dbAccount = db.AccountInfos?
                    .Where(a => a.Account == accountInfo.Account)
                    .FirstOrDefault(); //
                //2、如果不存在则添加账号
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(response);
        }
    }
}