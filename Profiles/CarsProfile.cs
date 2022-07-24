using AutoMapper;
using DotNetSixMinimalApi.Dtos;
using DotNetSixMinimalApi.Models;

namespace DotNetSixMinimalApi.Profiles;

public class CarsProfile: Profile
{
    public CarsProfile()
    {
            // source -> target
            CreateMap<Car, GetCarDto>();
            CreateMap<CreateCarDto, Car>();
            CreateMap<UpdateCarDto, Car>();
            
    }
}