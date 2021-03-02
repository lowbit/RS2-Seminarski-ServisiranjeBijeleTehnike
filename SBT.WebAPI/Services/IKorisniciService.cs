﻿using SBT.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Services
{
    public interface IKorisniciService
    {
        List<Model.KorisniciModel> Get(KorisniciSearchRequest request);
        Model.KorisniciModel GetById(int id);
        Model.KorisniciModel Insert(KorisniciInsertRequest request);
        Model.KorisniciModel Update(int id, KorisniciInsertRequest request);
        Model.KorisniciModel Authenticiraj(string username, string pass);
    }
}
