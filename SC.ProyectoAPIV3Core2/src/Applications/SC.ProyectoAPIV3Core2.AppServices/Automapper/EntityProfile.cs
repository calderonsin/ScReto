using AutoMapper;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Helpers.Commons;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.AppServices.Automapper
{
    /// <summary>
    /// EntityProfile
    /// </summary>
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Entity, DrivenAdapters.Mongo.Entities.Entity>();
            CreateMap<DrivenAdapters.Mongo.Entities.Entity, Entity>();
            CreateMap<DrivenAdapters.Sql.Entities.ClienteAdapter, Cliente>();
            CreateMap<Cliente_dto, Cliente>().ReverseMap();
            CreateMap<Credito_dto, Credito>().ReverseMap();
            CreateMap<ClienteDtoHelper, Cliente>().ReverseMap();
        }
    }
}
