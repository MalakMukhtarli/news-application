using System.Reflection;
using AutoMapper;
using NewsApplication.Application.ViewModels.Announcements;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());


        CreateMap<Announcement, AnnouncementViewModel>()
            .ForMember(x => x.Id, y =>
                y.MapFrom(y => y.Id))
            .ForMember(x => x.Title, y =>
                y.MapFrom(y => y.Title));
        // .ForMember(x => x.LikeCount, y => 
        //     y.MapFrom(y => y.Likes.Count))
        // .ForMember(x => x.DislikeCount, y => 
        //     y.MapFrom(y => y.Likes.Count));
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = GetMappedTypes(assembly);

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping")
                             ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");

            methodInfo?.Invoke(instance, new object[] { this });
        }
    }

    private static List<Type> GetMappedTypes(Assembly assembly)
    {
        return assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();
    }
}