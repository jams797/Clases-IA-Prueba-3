using System;
namespace Ejercicio2
{
	public class ProcesoHelper
	{
		public ProcesoHelper()
		{
		}

        
        public void CrearPersona()
        {
            string nombre = MetodosHelper.LeerDato("Ingresa el nombre de la persona");
            int edad = MetodosHelper.LeerNumeroEntero("Ingresa la edad de la persona");
            VariablesHelper.listaPersonas.Add(new PersonaModel(nombre, edad));
        }

        public void ListarPersonas()
        {
            MetodosHelper.MostrarPersonasDeUnaLista(VariablesHelper.listaPersonas);
        }

        public void BuscarPersonaPorNombre()
        {
            string nombreB = MetodosHelper.LeerDato("Ingresa el nombre de la persona a buscar");
            List<PersonaModel> personasBuscadas = VariablesHelper.listaPersonas.Where((perM) => perM.nombre.ToLower().Contains(nombreB.ToLower())).ToList();
            MetodosHelper.MostrarPersonasDeUnaLista(personasBuscadas);
        }

        public void ObtenerPersonaMayorATodos()
        {
            //PersonaModel? personaF = VariablesHelper.listaPersonas.MaxBy((perM) => perM.edad);
            int personaFB = VariablesHelper.listaPersonas.Max((perM) => perM.edad);
            PersonaModel? personaF = VariablesHelper.listaPersonas.FirstOrDefault((perM) => perM.edad == personaFB);
            if (personaF != null)
            {
                MetodosHelper.MostrarPersonasEnConsola(personaF);
            }
            else
            {
                Console.WriteLine("No hay personas en la lista");
            }
        }


        public void EliminarPersonaPorId()
        {
            string idEliminar = MetodosHelper.LeerDato("Ingresa el id de la persona a eliminar");
            PersonaModel? personaEliminar = VariablesHelper.listaPersonas.FirstOrDefault((perM) => perM.id == idEliminar);
            if (personaEliminar != null)
            {
                VariablesHelper.listaPersonas.Remove(personaEliminar);
                Console.WriteLine("Persona eliminada");
            }
            else
            {
                Console.WriteLine("Persona no encontrada");
            }
        }
    }
}

