using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Quadridge2.Models;
using Quadridge2.Dtos;

namespace Quadridge2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Client, ClientDto>();
            Mapper.CreateMap<ClientDto, Client>();
        }
    }
}