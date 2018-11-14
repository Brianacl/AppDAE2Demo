using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppDAE2Demo.Models;
using Newtonsoft.Json;

namespace AppDAE2Demo.Areas.General.Services
{
    public class SrvCatEdificiosList
    {
        HttpClient Cliente = new HttpClient();

        public SrvCatEdificiosList()
        {
            Cliente.BaseAddress = new Uri("http://localhost:2643/");
            Cliente.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Eva_cat_edificios>> getListCatEdificios()
        {
            HttpResponseMessage respuestaGet = await Cliente.GetAsync("api/edificios");
            if(respuestaGet.IsSuccessStatusCode)
            {
                var respuesta = await respuestaGet.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Eva_cat_edificios>>(respuesta);
            }
            return null;
        }

    }
}
