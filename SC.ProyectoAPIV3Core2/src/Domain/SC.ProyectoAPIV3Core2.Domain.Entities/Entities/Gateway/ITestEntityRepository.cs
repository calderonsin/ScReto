using System;
using System.Collections.Generic;

namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway
{
    /// <summary>
    /// ITestEntityRepository
    /// </summary>
    public interface ITestEntityRepository
    {
        /// <summary>
        /// FindAll
        /// </summary>
        /// <returns>Entity list</returns>
        List<Entity> FindAll(Entity entity = null);
    }
}