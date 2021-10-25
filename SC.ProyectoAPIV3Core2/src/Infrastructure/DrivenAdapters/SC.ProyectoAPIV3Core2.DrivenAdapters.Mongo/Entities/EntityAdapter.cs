using AutoMapper;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using System;
using System.Collections.Generic;

namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Mongo
{
    /// <summary>
    /// EntityAdapter
    /// </summary>
    public class EntityAdapter : ITestEntityRepositorio
    {
        private readonly IMapper mapper;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="mapper"></param>
        public EntityAdapter(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// EncontrarTodo
        /// </summary>
        /// <returns>Entity list</returns>
        public List<Entity> FindAll(Entity entity = null)
        {
            if (entity == null)
            {
                return mapper.Map<List<Entity>>(new List<Entities.Entity> { new Entities.Entity { Id = Guid.NewGuid(), descrip = "Test" } });
            }
            return mapper.Map<List<Entity>>(new List<Entities.Entity> { new Entities.Entity { Id = entity.Id, descrip = entity.descrip } });
        }
    }
}