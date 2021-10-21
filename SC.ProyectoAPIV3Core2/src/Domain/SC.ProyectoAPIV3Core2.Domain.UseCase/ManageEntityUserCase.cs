using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Domain.UseCase
{
    /// <summary>
    /// ManageTestEntityUserCase
    /// </summary>
    public class ManageTestEntityUserCase
    {
        private readonly ITestEntityRepository testEntityRepository;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="testEntityRepository"></param>
        public ManageTestEntityUserCase(ITestEntityRepository testEntityRepository)
        {
            this.testEntityRepository = testEntityRepository;
        }

        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <returns>Entity list</returns>
        public async Task<IList<Entity>> GetAllUsers(Entity entity = null) => testEntityRepository.FindAll(entity);


    }

}
