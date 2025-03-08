using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Study.Api.Controllers
{
    /// <summary>
    /// Route 路由
    /// 学习的Api接口
    /// </summary>
    [Route("api/[controller]/[action]")]//推荐小写，大写也没关系
    //[Route("apitest/[controller]/[action]")]//这个控制器下的每一个动作都会变成两个,apitest可以随便改
    [ApiController]
    public class StudyController : ControllerBase
    {
        /// <summary>
        /// 功能一
        /// </summary>
        /// <returns>返回学生的姓名</returns>
        [HttpGet]//默认路由//Get方法获取一个值
        public IActionResult Func1()
        {
            return Ok("龙马哥");
        }

        /// <summary>
        /// 功能一 返回学生的姓名
        /// </summary>
        /// <param name="name">传入姓名</param>
        /// <returns>返回学生的姓名</returns>
        [HttpGet("{name}")]
        //{}应该是类比占位符
        //​精确路由
        //不允许隐式重载
        public IActionResult Func1(string name)
        {
            return Ok(name);
        }

        [HttpPost]//创建资源
        public IActionResult Func2([FromBody]Dictionary<string,string> dic)
        {
            return Ok("龙马哥");
        }
    }
}
