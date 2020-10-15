using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBT.WebAPI.Database;
using SBT.WebAPI.Services;

namespace SBT.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UredjajiController : ControllerBase
    {
        private readonly IUredjajiService _service;
        public UredjajiController(IUredjajiService service)
        {
            _service = service;
        }

        [HttpGet("GetUredjajiList")]
        public ActionResult<List<Model.UredjajModel>> GetUredjajiList()
        {
            return _service.GetUredjajiList();
        }
        [HttpGet("GetKategorijeList")]
        public ActionResult<List<Model.KategorijaModelAdd>> GetKategorijeList()
        {
            return _service.GetKategorijeList();
        }
        [HttpGet("GetProizvodjaciList")]
        public ActionResult<List<Model.ProizvodjacModel>> GetProizvodjaciList()
        {
            return _service.GetProizvodjaciList();
        }
        [HttpGet("GetUredjajiByKategorijeList")]
        public ActionResult<List<Model.UredjajModel>> GetUredjajiByKategorijeList(int kategorijaId)
        {
            return _service.GetUredjajiByKategorijeList(kategorijaId);
        }
        [HttpGet("GetUredjajiByProizvodjaciList")]
        public ActionResult<List<Model.UredjajModel>> GetUredjajiByProizvodjaciList(int proizvodjacId)
        {
            return _service.GetUredjajiByProizvodjaciList(proizvodjacId);
        }
        [HttpPost("AddKategorija")]
        public ActionResult<Model.KategorijaModelAdd> AddKategorija(Model.Requests.KategorijaModelRequest kategorija)
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
        public ActionResult<Model.UredjajModel> EditUredjaj(int uredjajId, Model.Requests.UredjajModelRequest uredjaj)
        {
            return _service.EditUredjaj(uredjajId, uredjaj);
        }
    }
}
