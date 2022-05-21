using AutoMapper;

namespace Inventory.Application
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ModelMappingProfile>();
            });
        }
    }
}
