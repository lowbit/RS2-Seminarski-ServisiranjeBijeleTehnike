using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBT.WebAPI.Database;
using SBT.WebAPI.Services;

namespace SBT.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UredjajiController : ControllerBase
    {
        private readonly IUredjajiService _service;
        public UredjajiController(IUredjajiService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<Model.UredjajModel> GetUredjajById(int id)
        {
            return _service.GetUredjajById(id);
        }
        [HttpGet("GetUredjajiList")]
        public ActionResult<List<Model.UredjajModel>> GetUredjajiList([FromQuery]Model.Requests.SearchRequest request)
        {
            return _service.GetUredjajiList(request);
        }
        [HttpGet("GetKategorijeList")]
        public ActionResult<List<Model.KategorijaModel>> GetKategorijeList()
        {
            return _service.GetKategorijeList();
        }
        [HttpGet("GetKategorijeListNotEmpty")]
        public ActionResult<List<Model.KategorijaModel>> GetKategorijeListNotEmpty()
        {
            return _service.GetKategorijeListNotEmpty();
        }
        [HttpGet("GetProizvodjaciList")]
        public ActionResult<List<Model.ProizvodjacModel>> GetProizvodjaciList()
        {
            return _service.GetProizvodjaciList();
        }
        [HttpGet("GetUredjajiByKategorijaList")]
        public ActionResult<List<Model.UredjajModel>> GetUredjajiByKategorijeList([FromQuery] int id)
        {
            return _service.GetUredjajiByKategorijaList(id);
        }
        [HttpGet("GetUredjajiByProizvodjaciList")]
        public ActionResult<List<Model.UredjajModel>> GetUredjajiByProizvodjaciList(int proizvodjacId)
        {
            return _service.GetUredjajiByProizvodjaciList(proizvodjacId);
        }
        [HttpPost("AddKategorija")]
        public ActionResult<Model.KategorijaModel> AddKategorija(Model.Requests.KategorijaModelRequest kategorija)
        {
            return _service.AddKategorija(kategorija);
        }
        [HttpPost("AddProizvodjac")]
        public ActionResult<Model.ProizvodjacModel> AddProizvodjac(Model.Requests.ProizvodjacModelRequest proizvodjac)
        {
            return _service.AddProizvodjac(proizvodjac);
        }
        [HttpPost("AddUredjaj")]
        public ActionResult<Model.UredjajModel> AddUredjaj(Model.Requests.UredjajModelRequest uredjaj)
        {
            return _service.AddUredjaj(uredjaj);
        }
        [HttpPut("EditUredjaj/{id}")]
        public ActionResult<Model.UredjajModel> EditUredjaj(int id, Model.Requests.UredjajModelRequest uredjaj)
        {
            return _service.EditUredjaj(id, uredjaj);
        }
    }
}
