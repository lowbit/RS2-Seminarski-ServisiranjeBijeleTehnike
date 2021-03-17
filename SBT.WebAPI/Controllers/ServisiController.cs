using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBT.Model;
using SBT.Model.Requests;
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
        [HttpGet("GetServisiByUser")]
        public ActionResult<List<Model.ServisModel>> GetServisiByUser([FromQuery]SearchMobileServiceRequest request)
        {
            return _service.GetServisiByUser(request);
        }
        [HttpGet("GetVrsteStatusa")]
        public ActionResult<List<Model.StatusServisaModel>> GetVrsteStatusa()
        {
            return _service.GetVrsteStatusa();
        }
    }
}
