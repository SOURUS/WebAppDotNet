using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAppsysGalkin.Data.Model;
using TestAppysGalkin.Web.ViewModels.Home;
using TestAppysGalkin.Web.ViewModels.User;

namespace TestAppysGalkin.Web.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Producer, ProducerViewModel>();
                config.CreateMap<HeadPhone, HeadPhoneViewModel>();

                config.CreateMap<Product, ProductViewModel>()
                    .ForMember(d => d.Producer,
                        opt => opt.MapFrom(src => src.Producer))
                    .ForMember(d => d.HeadPhone,
                        opt => opt.MapFrom(src => src.HeadPhone));

                config.CreateMap<Message, RecievedMessageViewModel>()
                    .ForMember(d => d.Name,
                        opt => opt.MapFrom(src => src.FromUser.Login));
                    
                config.CreateMap<Message, SentMessageViewModel>()
                    .ForMember(d => d.Name,
                        opt => opt.MapFrom(src => src.ToUser.Login));
            });
        }
    }
}