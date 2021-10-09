using BOL.EntitiesDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomRepositories
{
   public class CountryRepository :BaseRepository<Country> 
    {
        IdentityContext _identityContext;
        public CountryRepository(IdentityContext identityContext):base(identityContext)
        {
            _identityContext = identityContext;
        }
        public string CountryAge(int id) {

            return _identityContext.Countries.SingleOrDefault(i=>i.ID==id).Name;
        }

    }
}
