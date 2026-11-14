using System;
using System.ComponentModel.DataAnnotations;
namespace ProyectoWeb.Models
{
	public class PersonModelCreate
	{
        public string Uuid { get; }
        [Required, StringLength(50, MinimumLength = 4)]
		public string Name { get; }
        [Required]
        public int Age { get; }
        [Required]
        public double Salary { get; }
	}
}

