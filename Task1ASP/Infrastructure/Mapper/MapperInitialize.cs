using AutoMapper;

namespace Task1ASP.Infrastructure.Mapper
{
    public class MapperInitialize
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ForAllMaps((map, expression) => map.PreserveReferences = true);

                cfg.AddProfile(new DomainModelToViewModel());
                cfg.AddProfile(new ViewModelToDomainModel());
            });

            return config;
        }
    }
}