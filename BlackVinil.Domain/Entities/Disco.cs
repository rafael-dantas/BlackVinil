using System;
using System.Collections.Generic;
using System.Text;

namespace BlackVinil.Domain.Entities
{
    public class Disco
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string href { get; set; }
        public string Imagem { get; set; }
        public double Preco { get; set; }
        public double CashBack { get; set; }
        public GeneroMusical Genero { get; set; }
    }
}
