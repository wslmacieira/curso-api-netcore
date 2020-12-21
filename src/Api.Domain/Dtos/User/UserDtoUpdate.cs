using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "Id é obrigátorio")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no maximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail formato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no maximo {1} caracteres")]
        public string Email { get; set; }
    }
}
