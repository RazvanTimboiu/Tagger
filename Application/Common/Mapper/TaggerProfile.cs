using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using AutoMapper;

namespace Application.Common.Mapper
{
    public class TaggerProfile: Profile
    {
        public TaggerProfile()
        {
            CreateMap<Domain.Entities.Account, User>();
        }
    }
}
