using System;

namespace Domain.Dtos.Cep
{
    public class CepDtoCreateResult
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
