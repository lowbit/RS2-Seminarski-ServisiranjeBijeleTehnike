using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBT.WebAPI.Services;

namespace SBT.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ZahtjeviController : ControllerBase
    {
        private readonly IZahtjeviService _service;
        public ZahtjeviController(IZahtjeviService service)
        {
            _service = service;
        }

        [HttpGet("GetUredjajiList")]
        public ActionResult<List<Model.ZahtjevModel>> GetUredjajiList()
        {
            return _service.GetZahtjeviList();
        }
    }
}
