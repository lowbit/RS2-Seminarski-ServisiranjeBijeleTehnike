using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBT.Model.Requests;
using SBT.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.KorisniciModel> Get([FromQuery] KorisniciSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public Model.KorisniciModel Insert(KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public Model.KorisniciModel Update(int id, [FromBody] KorisniciInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        public Model.KorisniciModel GetById(int id)
        {
            return _service.GetById(id);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("Authenticate/{username},{password}")]
        public Model.KorisniciModel Authenticate(string username, string password)
        {
            return _service.Authenticiraj(username, password);
        }
    }
}
