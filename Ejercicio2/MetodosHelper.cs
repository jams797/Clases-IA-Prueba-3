using System;
namespace Ejercicio2
{
	public class MetodosHelper
	{
		public MetodosHelper()
		{
        }

        static public string LeerDato(string mensaje)
        {
            string? datoLeido = null;
            while (datoLeido == null)
            {
                Console.WriteLine(mensaje);
                datoLeido = Console.ReadLine();
            }
            return datoLeido ?? "";
        }

        static public int LeerNumeroEntero(string mensaje)
        {
            bool valor_correcto = false;
            int num = 0;
            while (valor_correcto == false)
            {
                string? valor = LeerDato(mensaje);
                valor_correcto = int.TryParse(valor, out num);
            }
            return num;
        }

        static public void MostrarPersonasDeUnaLista(List<PersonaModel> listaPersonas)
        {
            listaPersonas.ForEach((perM) => MostrarPersonasEnConsola(perM));
        }

        static public void MostrarPersonasEnConsola(PersonaModel perM)
        {
            Console.WriteLine($"La persona con nombre {perM.nombre} tiene {perM.edad} años");
        }
    }
}

