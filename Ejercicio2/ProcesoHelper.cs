using System;
using Library.Models;
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
            int edad = MetodosHelper.ReadNumberInt("Ingresa la edad de la persona");
            double sueldo = MetodosHelper.LeerNumeroDouble("Ingresar el sueldo de la persona");
            VariablesHelper.listaPersonas.Add(new PersonModel(nombre, edad, sueldo));
        }

        public void ListarPersonas()
        {
            MetodosHelper.MostrarPersonasDeUnaLista(VariablesHelper.listaPersonas);
        }

        public void BuscarPersonaPorNombre()
        {
            string nombreB = MetodosHelper.LeerDato("Ingresa el nombre de la persona a buscar");
            List<PersonModel> personasBuscadas = VariablesHelper.listaPersonas.Where((perM) => perM.name.ToLower().Contains(nombreB.ToLower())).ToList();
            MetodosHelper.MostrarPersonasDeUnaLista(personasBuscadas);
        }

        public void ObtenerPersonaMayorATodos()
        {
            //PersonaModel? personaF = VariablesHelper.listaPersonas.MaxBy((perM) => perM.edad);
            int personaFB = VariablesHelper.listaPersonas.Max((perM) => perM.age);
            PersonModel? personaF = VariablesHelper.listaPersonas.FirstOrDefault((perM) => perM.age == personaFB);
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
            PersonModel? personaEliminar = VariablesHelper.listaPersonas.FirstOrDefault((perM) => perM.id == idEliminar);
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

        public void BuscarPersonaMayorSueldoConsultado()
        {
            double sueldoB = MetodosHelper.LeerNumeroDouble("Ingrese el sueldo a consultar");
            List<PersonModel> listaF = VariablesHelper.listaPersonas.Where((perM) => perM.salary > sueldoB).ToList();
            MetodosHelper.MostrarPersonasDeUnaLista(listaF);
        }

        public void EliminarPersonasMenoresIgualEdadEspecifica()
        {
            int edad = MetodosHelper.ReadNumberInt("Ingresa la edad con la que se va a eliminar");
            VariablesHelper.listaPersonas.RemoveAll((perM) => perM.age <= edad);
            Console.WriteLine("Personas Eliminadas");
        }

        public void ActualizarSueldPersonaPorId()
        {
            string id = MetodosHelper.LeerDato("Ingresa el id de la persona a actualizar el sueldo");
            PersonModel? persona = VariablesHelper.listaPersonas.FirstOrDefault((personaM) => personaM.id == id);
            if (persona != null)
            {
                Console.WriteLine($"Sueldo anterior -> ${persona.salary}");
                double sueldoModificar = MetodosHelper.LeerNumeroDouble("Ingrese el nuevo sueldo");
                persona.UpdateSalary(sueldoModificar);
                Console.WriteLine("Sueldo modificado");
            } else
            {
                Console.WriteLine("La persona no existe");
            }
        }
    }
}

