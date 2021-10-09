using BOL.Entities.ViewModels;
using BOL.EntitiesDBContext;
using DAL.BaseRepositories;
using DAL.CustomRepositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static N_Tier_Task.App_Start.IdentityConfig;

namespace N_Tier_Task.Controllers
{
    public class ValuesController : ApiController
    {
        public readonly IBaseRepository<Country> _countryRepository;
        //public readonly ApplicationUserManager _applicationUserManager;
        //public readonly ApplicationSignInManager _applicationSignInManager;
        public readonly IdentityContext _identityContext;


        public ValuesController()
        { }

        public ValuesController(IBaseRepository<Country> countryRepository/*, ApplicationUserManager applicationUserManager , ApplicationSignInManager applicationSignInManager*/,IdentityContext identityContext) {

            _countryRepository = countryRepository;
            _identityContext = identityContext;
            //_applicationUserManager = applicationUserManager;
            //_applicationSignInManager = applicationSignInManager;
        }
 

        // POST api/values
        public void Post([FromBody] Country country)
        {
            _countryRepository.Insert(country);

        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser() { Email = model.Email , UserName = model.Name };
           // IdentityResult result = await _applicationUserManager.CreateAsync(user, model.Password);
            ApplicationUserStore Store = new ApplicationUserStore(_identityContext);
            ApplicationUserManager userManager = new ApplicationUserManager(Store);
            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Json("Added");
            }
            else {
                return Json(result.Errors);
            }
            
        }

        // PUT api/values/5

    }
}
