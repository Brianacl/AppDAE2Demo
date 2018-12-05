using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<Eva_cat_edificios> postEdificio(Eva_cat_edificios edificio)
        {
            var json = JsonConvert.SerializeObject(edificio);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var respuestaGet = await Cliente.PostAsync("api/edificios", content);
            if (respuestaGet.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine("---> Se guardó el edificio :'v");
            }
            return null;
        }

        public async Task<Eva_cat_edificios> getEdificio(int? id)
        {
            HttpResponseMessage respuestaGet = await Cliente.GetAsync("api/edificios/"+id);
            if (respuestaGet.IsSuccessStatusCode)
            {
                var respuesta = await respuestaGet.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Eva_cat_edificios>(respuesta);
            }
            return null;
        }

        public async Task<Eva_cat_edificios> deleteEdificio(int? id)
        {
            var respuestaGet = await Cliente.DeleteAsync("api/edificios/" + id);
            if (respuestaGet.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine(respuestaGet.IsSuccessStatusCode);
            }
            return null;
        }

        public async void putEdificio(Eva_cat_edificios postEdificio)
        {
            try
            {
                var json = JsonConvert.SerializeObject(postEdificio);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await Cliente.PutAsync("api/edificios/"+postEdificio.IdEdificio, content);

                    if (response.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine("Edificios successfully saved.");
                    }
                    else
                        System.Diagnostics.Debug.WriteLine("Estatus --> " + response.StatusCode);
            }
            catch (Exception e)
            {
                
                if (e.InnerException != null)
                    System.Diagnostics.Debug.WriteLine("Inner exception: {0}", e.InnerException);
            }
            
        }//POST a edificios

    }
}
