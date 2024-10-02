using AspNetCore.Identity.MongoDbCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Domain.Entities
{
    public class Role : MongoIdentityRole<Guid>
    {
    }
}
