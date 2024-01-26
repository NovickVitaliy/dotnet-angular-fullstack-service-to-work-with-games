using AutoMapper;
using GameProject.Application.Models.Identity;

namespace GameProject.Application.AutoMapper.CustomConverters.Identity;

public class PlatformStringToPlatformArrayConverter : IValueConverter<string, string[]>
{
    public string[] Convert(string sourceMember, ResolutionContext context)
    {
        return sourceMember.Split(';');
    }
}