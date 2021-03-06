using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Cep
{
    public class CepDtoUpdate
    {
        [Required(ErrorMessage = "Id é obrigatorio")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "CEP é obrigatorio")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro é obrigatorio")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        [Required(ErrorMessage = "Municipio é obrigatorio")]
        public Guid MunicipioId { get; set; }
    }
}
