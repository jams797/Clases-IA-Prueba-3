using ConexionDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoApiMvc.Models.City;
using ProyectoApiMvc.Models.General;

namespace ProyectoApiMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet("GetCities", Name = "GetCities")]
        public ResponseGeneralModel<List<GetCitiesResponseModel>> GetCities()
        {
            using(PruebaContext pruebaContext = new PruebaContext())
            {
                return new ResponseGeneralModel<List<GetCitiesResponseModel>>(true, pruebaContext.Ciudades.Select(
                    (x) => new GetCitiesResponseModel()
                    {
                        name = x.CiudadNombre,
                        isActive = x.Estado == 1,
                        dateCreate = x.FechaHoraReg
                    }
                ).ToList(), "", null);
            }
        }

        // [Metodo][Req/Resp][Model]

        [HttpPost("SaveCity", Name = "SaveCity")]
        public ResponseGeneralModel<string?> SaveCity(SaveCityRequestModel requestModel)
        {
            using(PruebaContext pruebaContext = new PruebaContext())
            {
                pruebaContext.Ciudades.Add(new Ciudad()
                {
                    CiudadNombre = requestModel.name,
                    Estado = 1,
                    FechaHoraReg = DateTime.Now
                });
                pruebaContext.SaveChanges();
                
            }
            return new ResponseGeneralModel<string?>(true, null, "Ciudad creada", null);
        }
    }
}
