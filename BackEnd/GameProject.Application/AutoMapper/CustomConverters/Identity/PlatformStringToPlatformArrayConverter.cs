using AutoMapper;
using GameProject.Application.Models.Identity;
using GameProject.Identity.Models;

namespace GameProject.Application.AutoMapper.CustomConverters.Identity;

public class PlatformStringToPlatformArrayConverter : IValueConverter<string, string[]>
{
    public string[] Convert(string sourceMember, ResolutionContext context)
    {
        return sourceMember.Split(';');
    }
}