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

        // Eliminar una ciudad en base a su ID
        // Actualizar el nombre de una cidudad en base a su ID
        // Activar y desactivar ciudad en base a su ID


        // Liste las ciudades activas
        // Me Elimine varias ciudades en base a un listado de IDs



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

        [HttpDelete("DeleteCity/{id}", Name = "DeleteCity")]
        public ResponseGeneralModel<string?> DeleteCity(int id)
        {
            using(PruebaContext pruebaContext = new PruebaContext())
            {
                Ciudad? cityFind = pruebaContext.Ciudades.FirstOrDefault((x) => x.CiudadId == id);
                if(cityFind != null)
                {
                    pruebaContext.Ciudades.Remove(cityFind);
                    pruebaContext.SaveChanges();
                    return new ResponseGeneralModel<string?>(true, null, "Ciudad eliminada", null);
                } else
                {
                    return new ResponseGeneralModel<string?>(false, null, "Ciudad no encontrada", null);
                }
            }
        }

        [HttpPut("UpdateNameCity/{id}", Name = "UpdateNameCity")]
        public ResponseGeneralModel<string?> UpdateNameCity(int id, UpdateNameCityRequestModel requestModel)
        {
            using(PruebaContext pruebaContext = new PruebaContext())
            {
                Ciudad? cityFind = pruebaContext.Ciudades.FirstOrDefault((x) => x.CiudadId == id);
                if(cityFind != null)
                {
                    cityFind.CiudadNombre = requestModel.name;
                    pruebaContext.SaveChanges();
                    return new ResponseGeneralModel<string?>(true, null, "Ciudad actualizada", null);
                } else
                {
                    return new ResponseGeneralModel<string?>(false, null, "Ciudad no encontrada", null);
                }
            }
        }

        [HttpPut("ChangeStatusCity/{id}", Name = "ChangeStatusCity")]
        public ResponseGeneralModel<string?> ChangeStatusCity(int id)
        {
            using(PruebaContext pruebaContext = new PruebaContext())
            {
                Ciudad? cityFind = pruebaContext.Ciudades.FirstOrDefault((x) => x.CiudadId == id);
                if(cityFind != null)
                {
                    cityFind.Estado = cityFind.Estado == 1 ? 0 : 1;
                    pruebaContext.SaveChanges();
                    return new ResponseGeneralModel<string?>(true, null, "Ciudad actualizada el estado", null);
                } else
                {
                    return new ResponseGeneralModel<string?>(false, null, "Ciudad no encontrada", null);
                }
            }
        }
    }
}
