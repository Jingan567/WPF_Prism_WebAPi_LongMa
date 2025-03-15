using AutoMapper;
using DailyApp.Api.ApiResponses;
using DailyApp.Api.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        /// AutoMapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// 构造函数，通过构造函数注入数据库上下文
        /// </summary>
        /// <param name="context"></param>
        public AccountController(DailyDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="accountInfo"></param>
        /// <returns>-1 账号已存在；1 表示注册成功；-99 表示服务器异常</returns>
        [HttpPost]
        public IActionResult Register(DTOS.AccountInfoDTO accountInfoDTO)//疑问：这里的参数到底是怎么传进来的
        {
            ApiResponse response = new ApiResponse(); //响应的数据
            //业务
            try
            {
                //1、账号是否存在（没有考虑高并发的情况）
                var dbAccount = db.AccountInfos?
                    .Where(a => a.Account == accountInfoDTO.Account)
                    .FirstOrDefault();
                if (dbAccount != null)
                {
                    response.ResultCode = -1;
                    response.Msg = "账号已存在";
                    return Ok(response);
                }
                else
                {
                    //2、如果不存在则添加账号（缺点：属性特别多的话，写起来过于麻烦）

                    //db.AccountInfos.Add(new AccountInfo
                    //{
                    //    这个是直接赋值的方式
                    //    Account = accountInfoDTO.Account,
                    //    Name = accountInfoDTO.Name,
                    //    Password = accountInfoDTO.Password
                    //});

                    //DTO=>Model,这里可以使用AutoMapper。因为数据库只认Model，不认DTO

                    AccountInfo accountInfo = mapper.Map<AccountInfo>(accountInfoDTO);

                    db.AccountInfos?.Add(accountInfo);
                    var lines = db.SaveChanges();//保存 受影响的行数
                    if (lines == 1)
                    {
                        response.ResultCode = 1;//账号注册成功
                        response.Msg = "注册成功";
                    }
                    else
                    {
                        response.ResultCode = -99;
                        response.Msg = "服务器忙...请稍等...";
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return Ok(response);
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="pwd">密码（MD5）</param>
        /// <returns>登录信息</returns>
        [HttpGet]
        public IActionResult Login(string account, string pwd)//这里可以使用DTO，也可以是这样子写
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var dnAccountInfo = db.AccountInfos
                    .Where(t => t.Account == account).FirstOrDefault();

                if (dnAccountInfo == null)
                {
                    response.ResultCode = -1;//账号错误
                    response.Msg = "账号不存在";
                    return Ok(response);
                }

                if (dnAccountInfo.Password != pwd)
                {
                    response.ResultCode = -2;//密码错误
                    response.Msg = "密码错误";
                    return Ok(response);
                }

                response.ResultCode = 1;//登录成功
                response.Msg = "登录成功";
                response.ResultData = dnAccountInfo;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ResultCode = -99;//未知错误
                response.Msg = "服务器忙...请稍等...";
            }
            return Ok(response);
        }


    }
}