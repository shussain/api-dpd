﻿using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class DrugProductController : ApiController
    {
        static readonly IDrugProductRepository databasePlaceholder = new DrugProductRepository();
       
        public IEnumerable<DrugProduct> GetBySearchCriteria(string din, string brandname, string company, string lang)
        {
            return databasePlaceholder.GetAllByCriteria(din, brandname, company, lang);
        }

        public DrugProduct GetDrugProductByID(int id, string lang)
        {
            DrugProduct drugProduct = databasePlaceholder.Get(id, lang);
            if (drugProduct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return drugProduct;
        }

        public IEnumerable<DrugProduct> GetAllDrugProduct(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }
    }
}
