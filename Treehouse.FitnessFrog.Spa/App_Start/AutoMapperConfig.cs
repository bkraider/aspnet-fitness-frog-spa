using AutoMapper;
using Treehouse.FitnessFrog.Shared.Models;


namespace Treehouse.FitnessFrog.Spa
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Entry, EntryDto>().ReverseMap();
            });
        }
    }
}