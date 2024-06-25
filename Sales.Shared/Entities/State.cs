using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Estado/Departamento")]
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string Name { get; set; } = null!;

        //Relación 1, un estado tiene un país
        public Country? Country { get; set; }

        //Relación muchos, un estado tiene muchas ciudades
        public ICollection<City> Cities { get; set; }
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

    }
}
