using FullCartApp.Application.Contracts.ViewModels.User;
using FullCartApp.Core.Aggregates;
using FullCartApp.Core.Aggregates.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Mappers
{
    public class ProfleMapper : MapperBase<Profile, ProfileVM>
    {
        public override Profile MapFromDestinationToSource(ProfileVM destinationEntity)
        {
          throw new NotImplementedException();  
        }

        public override ProfileVM MapFromSourceToDestination(Profile sourceEntity)
        {
            if (sourceEntity == null) return null;
            return new ProfileVM { 
            
               Name = sourceEntity.Name,
               Address= sourceEntity.Address, 
               UserId= sourceEntity.UserId, 
              
            };
        }
    }
}
