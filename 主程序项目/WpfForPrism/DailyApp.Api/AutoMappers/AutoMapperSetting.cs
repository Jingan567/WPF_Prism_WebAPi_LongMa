using AutoMapper;
using DailyApp.Api.DataModel;
using DailyApp.Api.DTOS;

namespace DailyApp.Api.AutoMappers
{
    /// <summary>
    /// model之前转换设置
    /// </summary>
    public class AutoMapperSetting : Profile
    {
        public AutoMapperSetting()
        {
            //创建映射关系，前面的转后面的
            CreateMap<AccountInfoDTO, AccountInfo>();
        }
    }
}
