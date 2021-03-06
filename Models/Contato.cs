﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LojaVirtual.Libraries.Lang;

namespace LojaVirtual.Models
{
    public class Contato
    {
            [Required(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E001")]
            [MinLength(4, ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E002")]
            public string Nome { get; set; }

            [Required(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E001")]
            [EmailAddress(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E004")]
            public string Email { get; set; }

            [Required(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E001")]
            [MinLength(10, ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E002")]
            [MaxLength(1000, ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E003")]
            public string Texto { get; set; }
    }
}
