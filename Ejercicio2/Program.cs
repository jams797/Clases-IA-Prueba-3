using Ejercicio2;


int opcion = -1;

ProcesoHelper procH = new ProcesoHelper();
string password = new Library.Helpers.EncryptHelper().EncryptPassword("1234");




while (opcion != 0)
{
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("1. Ingresar persona");
    Console.WriteLine("2. Listar Personas");
    Console.WriteLine("3. Buscar personas por nombre");
    Console.WriteLine("4. Buscar la persona con mayor edad");
    Console.WriteLine("5. Eliminar persona por id");
    Console.WriteLine("6. Buscar personas con sueldo mayor al consultado");
    Console.WriteLine("7. Eliminar personas menores o igual a una edad especifica");
    Console.WriteLine("8. Actualizar el sueldo de una persona");
    Console.WriteLine("0. Salir");
    Console.WriteLine("");

    opcion = MetodosHelper.ReadNumberInt("Escoja una opción");
    Console.Clear();
    switch (opcion)
    {
        case 1:
            procH.CrearPersona();
            break;
        case 2:
            procH.ListarPersonas();
            break;
        case 3:
            procH.BuscarPersonaPorNombre();
            break;
        case 4:
            procH.ObtenerPersonaMayorATodos();
            break;
        case 5:
            procH.EliminarPersonaPorId();
            break;
        case 6:
            procH.BuscarPersonaMayorSueldoConsultado();
            break;
        case 7:
            procH.EliminarPersonasMenoresIgualEdadEspecifica();
            break;
        case 8:
            procH.ActualizarSueldPersonaPorId();
            break;


    }

    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("Persione una tecla para continuar....");
    Console.ReadKey();
    Console.Clear();
}

// PersonaModel, van a dicionar un campo de sueldo
// Ingreso de persona debe tambien ingresar el sueldo
// Debo poder listar las personas que tengan un sueldo mayor al que se quiere consultar (dato de busqueda)
// Eliminar personas que sean menores o iguales a una edad especifica
// Modificar el sueldo de una persona