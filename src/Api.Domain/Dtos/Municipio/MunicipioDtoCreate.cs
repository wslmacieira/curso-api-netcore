using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Municipio
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Nome de Município é obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome de Município de ter no máximo {1} caratcteres.")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE Inválido")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de Uf é obrigatorio")]
        public Guid UfId { get; set; }

    }
}
