﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string Name { get; set; } = null!;

        //Relación 1, una ciudad tiene un estado
        public State? State { get; set; }
    }
}
