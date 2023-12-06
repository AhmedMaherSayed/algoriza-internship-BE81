using AutoMapper;
using Core.Domain;
using Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Services.Helpers
{
    public class MappingUserDtTOProfile : Profile
    {

        public MappingUserDtTOProfile()
        {

            CreateMap<UserDTO, ApplicationUser>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>  $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => HashPassord(src.Password)))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => SaveImage(src.Image)))
                //  it is mandatory and unique cause there ia an index on its
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
                .ReverseMap();
        }

        private string SaveImage(IFormFile? image)
        {
            if (image == null)
                return null;

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            string filePath = Path.Combine("Images", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                 image.CopyTo(fileStream);
            }
            
           return filePath; 

        }


        private string HashPassord(string password)
        {
            return new PasswordHasher<ApplicationUser>().HashPassword(null, password);
        }
    }
}
