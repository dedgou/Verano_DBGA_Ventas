﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "País")]
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string Name { get; set; } = null!;

        //Relación muchos, un país tiene muchos estados.
        public ICollection<State>? States { get; set; }
        public int StatesNumber => States == null ? 0 : States.Count;
    }
}
