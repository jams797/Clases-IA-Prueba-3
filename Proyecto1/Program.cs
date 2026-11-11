using System.Globalization;
using Proyecto1;
//int
//double
//decimal
//float
//boolean
//string

// List
// Dictionary
// Datetime

// Datetime

// ICollection
// IEnumerable


// var




Dictionary<string, int> dict1 = new Dictionary<string, int>();
dict1["d1"] = 1;
dict1["d2"] = 14;
dict1["d2"] = 4;

Dictionary<int, int> dict2 = new Dictionary<int, int>();
dict2[0] = 15;
dict2[12] = 3;
dict2[23] = 34;
dict2[45] = 12;

List<string> listaNombres = new List<string>()
{
    "Jose",
    "Pepe",
    "Maria",
    "Marco"
};



//  variable del recorrido ; condicional ; incremental
List<int> listaKeys = dict2.Keys.ToList();
for (int i = 0; i < dict2.Count; i++)
{
    //Console.WriteLine(dict2[listaKeys[i]]);
}
List<string> listaKeys2 = dict1.Keys.ToList();
for (int i = 0; i < dict1.Count; i++)
{
    //Console.WriteLine(dict1[listaKeys2[i]]);
}

foreach (string nombre in listaNombres)
{
    //Console.WriteLine(nombre);
}

DateTime fechaH = DateTime.Now;
DateTime fechaH2 = new DateTime(2026, 06, 20, 19, 20, 20);

//Console.WriteLine(DateTime.Now);
//Console.WriteLine(fechaH2.ToString("d", new CultureInfo("fr-FR")));


// PersonaModel persona1 = new PersonaModel(20, "Pepe");

List<PersonaModel> listaPersonas = new List<PersonaModel>()
{
    new PersonaModel(20, "Pepe", new List<MascotaModel>(){new MascotaModel("Firulais", MascotaModel.TipoMascota.Perro)}),
    new PersonaModel(25, "Marco", new List<MascotaModel>(){new MascotaModel("Firulais", MascotaModel.TipoMascota.Gato) }),
    new PersonaModel(30, "Maria", new List<MascotaModel>()),
    new PersonaModel(22, "Lucas", new List<MascotaModel>(){new MascotaModel("Garfield", MascotaModel.TipoMascota.Gato), new MascotaModel("Minino", MascotaModel.TipoMascota.Gato) })
};

int personasConGatos = 0;
foreach(PersonaModel persona in listaPersonas)
{
    string mensaje = $"{persona.nombre} tiene {persona.edad} años";
    if(persona.mascota.Count > 0)
    {
        mensaje += $", tiene {persona.mascota.Count} mascotas";
        foreach(MascotaModel mascM in persona.mascota)
        {
            if(mascM.tipo == MascotaModel.TipoMascota.Gato)
            {
                personasConGatos++;
                continue;
            }
        }
    }
    Console.WriteLine(mensaje);
}

//foreach (PersonaModel persona in listaPersonas)
//{
//    string mensaje = $"{persona.nombre} tiene {persona.edad} años";
//    Console.WriteLine(mensaje);
//}
// select
// find
// Exist
// where
// count
// firts - firstdefault
// last - lastdefault

// foreach

listaPersonas.ForEach((persona) => Console.WriteLine($"{persona.nombre} tiene {persona.edad} años"));

// ( (x) => <<proceso>> )

// SELECT t1.nombre, t1.edad, t1.sexo FROM Tabla1 as t1 WHERE id > 10
// ( (t1) => t1.camp1 >= 10 )

int cantidadMascotaBuscada = listaPersonas.Where(
                        (persona) => persona.mascota.Exists(
                                            (masct) => masct.tipo == MascotaModel.TipoMascota.Perro
                                    )
                    ).Count();

var tmp = listaPersonas.Select((perM) => new PersonaModel(perM.edad, perM.nombre, null)).ToList();

Console.WriteLine($"Cuantas personas que tienen perro hay en el grupo?: {cantidadMascotaBuscada}");

//Console.WriteLine($"Cuantas personas que tienen gato hay en el grupo?: {personasConGatos}");



/*
int num1 = numeroIngresado("1°");
int num2 = numeroIngresado("2°");
int num3 = numeroIngresado("3°");
*/

/*
if(valor1_temp is null)
{
    valor1 = "0";
} else
{
    valor1 = valor1_temp;
}
// variable recibe valor = condicional ? verdadero : falso
valor1 = (valor1_temp is null) ? "0" : valor1_temp;
valor1 = valor1_temp ?? "0";
*/
//Console.WriteLine($"La suma es: {num1 + num2 + num3}");

// 0 - si
// 1 - si
// 2 - si

List<int> numerosIngresados = new List<int>();
int suma = 0;
int multiplicar = 1;
int numeroMayor = 0;
int cantidadNumeros = 0; // leerNumeroEntero("Ingrese la cantidad de numeros que desea calcular", true);
//while(numerosIngresados.Count < cantidadNumeros)
//{
//    int num = leerNumeroEntero($"Ingresa el {numerosIngresados.Count + 1}° numero:", false);
//    numerosIngresados.Add(num);
//    suma += num;
//    multiplicar = multiplicar * num;
//    numeroMayor = (num > numeroMayor) ? num : numeroMayor;
//}
//Console.WriteLine($"La suma es: {suma}");
//Console.WriteLine($"El promedio es: {suma / cantidadNumeros}");
//Console.WriteLine($"El numero multiplicado es: {multiplicar}");
//Console.WriteLine($"El numero mayor es: {numeroMayor}");

//string? valorTmp = Console.ReadLine() ?? "0";



int numeroIngresado(string posicion)
{
    bool valor_correcto = false;
    int num = 0;
    while (valor_correcto == false)
    {
        Console.WriteLine($"Ingresa el {posicion} numero:");
        string? valor = Console.ReadLine() ?? "0";
        valor_correcto = int.TryParse(valor, out num);
    }
    return num;
}

int leerNumeroEntero(string mensaje, bool mayor0)
{
    bool valor_correcto = false;
    int num = 0;
    while (valor_correcto == false || (num <= 0 && mayor0))
    {
        Console.WriteLine(mensaje);
        string? valor = Console.ReadLine() ?? "0";
        valor_correcto = int.TryParse(valor, out num);
    }
    return num;
}

// 1. Variable que me indique la cantidad de numeros a ingresar
// 2. Sumar esos valores y mostrarlos en consola
// 3. Sacar el promedio de esos numeros


































//int cantidad = 1;

// breaK;
// continue;
// return;
// exit;


//string nombre1 = "Joséyyyyy";

//switch(nombre1.Count())
//{
//    case < 3:
//        Console.WriteLine("Tiene menos de 3 caracteres");
//        break;
//    case >= 3 and <= 5:
//        Console.WriteLine("Tiene entre 3 y 5 caracteres");
//        break;
//    case > 5:
//        Console.WriteLine("Tiene mas de 5 caracteres");
//        break;
//}

//int numeroV = 1;
//int numeroV2 = 20;
//switch (numeroV)
//{
//    case 1:
//        Console.WriteLine("Hola Buen dia");
//        break;
//    case 2:
//        Console.WriteLine("Hola Buenas noches");
//        break;
//    default:
//        Console.WriteLine("Adios");
//        break;

//}

//void ejecutar()
//{
//    Console.WriteLine("inicio");
//    if (numeroV > 1)
//    {
//        return;
//    }
//    Console.WriteLine("Proceso ejecutado...");
//}




//List<string> nombresBuscar = new List<string>()
//{
//    "Jose",
//    "Pepe",
//    "Marco"
//};

//string buscarInicial = "p";

//foreach(string nombreB in nombresBuscar)
//{
//    Console.WriteLine($"Buscando en: {nombreB}");
//    if (nombreB[0].ToString().ToLower() == buscarInicial)
//    {
//        continue;
//    }
//    Console.WriteLine($"Mostrar: {nombreB}");
//}

// Jose
// 0: J, 1:o......




//bool EnviarCorreo(int intento)
//{
//    if(intento <= 3)
//    {
//        // enviar correo
//        if(true)
//        {
//            // sadasdas
//            return true;
//        } else
//        {
//            return EnviarCorreo(intento + 1);
//        }
//    } else
//    {
//        return false;
//    }
//}


//EmpleadoModel emp = new EmpleadoModel(17, "Lucas", new List<MascotaModel>() { new MascotaModel("Garfield", "gato"), new MascotaModel("Minino", "gato") }, 400);

//Console.WriteLine($"Su nombre es: {emp.nombre}");
//Console.WriteLine($"Es mayor edad: {(emp.esMayorEdad() ? "SI" : "NO")}");

//EmpleadoModel.calcularProceso(emp.sueldo);





// 1. Crear listas de clase de persona, que tenga nombre, apellido, edad
// 2. Realizar busquedad de personas que sean mayores de edad y mostralas
// 3. Mostrar que personas coinciden que su nombre empiece con la misma letra su nombre y su apellido (Ej: Marco Moran)
// 4. Buscar la primer persona que su edad sea mayor de edad y su nombre empiece con C




// ----
