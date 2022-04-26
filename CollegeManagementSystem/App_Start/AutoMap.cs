using AutoMapper;
using CMS.Business.Contracts;
using CMS.Business.Dtos;
using CMS.DataModel;
using System.Reflection;

namespace CollegeManagementSystem.App_Start
{
    public class AutoMap : IAutoMap
    {
        //private readonly IRuntimeMapper _mapper;

        //private readonly Mapper _mapper;
        public AutoMap()
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Course, CourseDto>().ReverseMap();
                mc.CreateMap<Course, CourseViewDto>().ReverseMap();
                mc.CreateMap<Subject, SubjectDto>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public IMapper _mapper { get; }

        public TDestination MapTo<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
        public TDestination MapTo<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}