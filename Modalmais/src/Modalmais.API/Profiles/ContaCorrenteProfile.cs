﻿using AutoMapper;
using Modalmais.API.DTOs;
using Modalmais.Business.Models;

namespace Modalmais.API.Profiles
{
    public class ContaCorrenteProfile : Profile
    {
        public ContaCorrenteProfile()
        {
            CreateMap<ChavePixRequest, ChavePix>().ReverseMap();

            //CreateMap<ContaCorrente, ContaCorrenteResponse>().ReverseMap();
        }
    }
}