using System;
using System.ComponentModel.DataAnnotations;
namespace ProyectoWebMvc.Models
{
	public class PersonModelCreate
	{
        [Required, StringLength(50, MinimumLength = 4)]
		public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public double Salary { get; set; }
	}
}

