using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBT.Model;
using SBT.WebAPI.Services;

namespace SBT.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServisiController : ControllerBase
    {
        private readonly IServisiService _service;

        public ServisiController(IServisiService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Model.ServisModel>> GetList()
        {
            return _service.GetList(); ;
        }
    }
}
