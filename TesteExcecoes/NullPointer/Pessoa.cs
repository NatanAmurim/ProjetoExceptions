using System;
using System.Collections.Generic;
using System.Text;

namespace TesteExcecoes.TesteNullPointer
{
    public class Pessoa
    {
        public string CPF { get; private set; }
        public string Nome { get; private set; }

        public Pessoa(string cpf, string nome)
        {           
            CPF = cpf;
            Nome = nome;
        }
    }
}
