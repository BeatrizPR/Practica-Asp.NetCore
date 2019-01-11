using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Route("company/[controller]/[action]")]
    public class AboutController
    {
        //[Route("[action]")]
        public string Phone()
        {
            return "1+123+123+123";
        }
        //[Route("address")]
        public string Address()
        {
            return "Spain";
        }
    }
}
