using System;
namespace Library.Models
{
	public class PersonModel
	{
        public string name { get; }
        public int age { get; }
        public string id { get; }
        public double salary { get; private set; }
        public double input { get; private set; }
        public PersonModel(string name, int age, double salary)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = name;
            this.age = age;
            UpdateSalary(salary);
        }

        public void UpdateSalary(double salary)
        {
            this.salary = salary;
            this.input = (salary * 9.11) / 100;
        }
    }
}

