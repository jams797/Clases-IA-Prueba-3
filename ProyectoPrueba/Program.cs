using Library.Models;


List<PersonModel> listPerson = new List<PersonModel>();

string password = new Library.Helpers.EncryptHelper().EncryptPassword("1234");
//if(password == passwordBD) { }

Console.WriteLine("Hello, World!");

