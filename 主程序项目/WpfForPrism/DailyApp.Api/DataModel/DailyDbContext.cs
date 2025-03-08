using Microsoft.EntityFrameworkCore;

namespace DailyApp.Api.DataModel
{
    /// <summary>
    /// 数据库上下文,生成迁移应该也是根据这个类来生成的
    /// </summary>
    public class DailyDbContext: DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public DailyDbContext(DbContextOptions<DailyDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// 账号表，实体需要迁移到数据库中的表，这么写就可以了
        /// </summary>
        public DbSet<AccountInfo> AccountInfos { get; set; }

        //如果有其他的实体，直接在下面添加就可以了
    }
}
