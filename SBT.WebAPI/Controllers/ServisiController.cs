using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBT.Model;
using SBT.WebAPI.Services;

namespace SBT.WebAPI.Controllers
{
    [Authorize]
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
        [HttpGet("GetServisiList")]
        public ActionResult<List<Model.ServisModel>> GetServisiList([FromQuery] Model.Requests.SearchRequestServis request)
        {
            return _service.GetServisiList(request);
        }
        [HttpGet("{id}")]
        public Model.ServisModel GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost("AddServis")]
        public ActionResult<Model.ServisModel> AddServis(Model.Requests.ServisInsertRequest request)
        {
            return _service.AddServis(request);
        }
        [HttpGet("GetServisiByUser/{id}")]
        public ActionResult<List<Model.ServisModel>> GetServisiByUser(int id)
        {
            return _service.GetServisiByUser(id);
        }
    }
}
