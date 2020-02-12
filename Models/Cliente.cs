using LojaVirtual.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace LojaVirtual.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessage = "Nome deve ter no minimo 4 caracteres!")]
        public string Nome { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E001")]
        public DateTime Nascimento { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E001")]
        public string Sexo { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E001")]
        public string CPF { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E001")]
        public string Telefone { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E004")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensgem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(6, ErrorMessage = "Senha deve ter no minimo 4 caracteres!")]
        public string Senha { get; set; }
    }
}
