using System;

namespace crudPessoaFisica.Models
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Renda { get; set; }
        public string Cpf { get; set; }
    }
}
