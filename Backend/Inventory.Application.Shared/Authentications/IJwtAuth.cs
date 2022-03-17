using Inventory.Application.Shared.Authentications.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.Authentications
{
   public interface IJwtAuth
   {
        TokenOutputDto Authentication(string username, string password);
   }
}
