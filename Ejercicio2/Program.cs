using Ejercicio2;

List<PersonaModel> listaPersonas = new List<PersonaModel>()
{
    new PersonaModel("Jose", 20),
    new PersonaModel("Marco", 22),
};


int opcion = -1;


while (opcion != 0)
{
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("1. Ingresar persona");
    Console.WriteLine("2. Listar Personas");
    Console.WriteLine("3. Buscar personas por nombre");
    Console.WriteLine("4. Buscar la persona con mayor edad");
    Console.WriteLine("0. Salir");
    Console.WriteLine("");

    opcion = MetodosHelper.LeerNumeroEntero("Escoja una opción");
    Console.Clear();
    switch (opcion)
    {
        case 1:
            string nombre = MetodosHelper.LeerDato("Ingresa el nombre de la persona");
            int edad = MetodosHelper.LeerNumeroEntero("Ingresa la edad de la persona");
            listaPersonas.Add(new PersonaModel(nombre, edad));
            break;
        case 2:
            MetodosHelper.MostrarPersonasDeUnaLista(listaPersonas);
            break;
        case 3:
            string nombreB = MetodosHelper.LeerDato("Ingresa el nombre de la persona a buscar");
            List<PersonaModel> personasBuscadas = listaPersonas.Where((perM) => perM.nombre.ToLower().Contains(nombreB.ToLower())).ToList();
            MetodosHelper.MostrarPersonasDeUnaLista(personasBuscadas);
            break;
        case 4:
            PersonaModel? personaF = listaPersonas.MaxBy((perM) => perM.edad);
            if(personaF != null)
            {
                MetodosHelper.MostrarPersonasEnConsola(personaF);
            } else
            {
                Console.WriteLine("No hay personas en la lista");
            }
            break;


    }

    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("Persione una tecla para continuar....");
    Console.ReadKey();
    Console.Clear();
}