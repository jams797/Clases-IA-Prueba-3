//int
//double
//decimal
//float
//boolean
//string

// List
// Array
// Datetime

// ICollection


// var


/*
int num1 = 6;
int num2 = 7;


int num3;
int num4;
num3 = 4;

num4 = 12;


int suma = num1 + num2 + num3 + num4;

string texto = "Suma";
string texto2 = ":";


string textoFinal = $"{texto}{texto2} {suma}";
string textoFinal2 = texto + texto2 + " " + suma;

double promedio = suma / 4.0;


Console.WriteLine(textoFinal);
Console.WriteLine(promedio);
int cart1;
saludo("José", out cart1);
//saludo("Pepe");
//saludo("Maria");

Persona persona = new Persona();
persona.edad = 20;
persona.nombre = "Marco";

saludoPersona(persona);

string numeroString = "23a";

int enteroString = 0;
try
{
    enteroString = int.Parse(numeroString);
}
catch {
}
bool seTransformo = int.TryParse(numeroString, out enteroString);

int sumaNueva = 12 + enteroString;
Console.WriteLine("Transformado " + sumaNueva);



void saludo(string nombre, out int totalCaracteres)
{
    totalCaracteres = contarCaracteres(nombre);
    Console.WriteLine($"Hola {nombre}, tu nombre tiene {totalCaracteres} caracteres");
}

void saludoPersona(Persona persona)
{
    Console.WriteLine($"Hola {persona.nombre.ToUpper()}, tienes {persona.edad} años");
}

int contarCaracteres(string nombre)
{
    return nombre.Count();
}


class Persona
{
    // public - protected - private
    public int edad;
    public string nombre;

    public string dato1()
    {
        return "www";
    }
}*/