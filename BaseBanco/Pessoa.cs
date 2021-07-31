using Humanizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseBanco
{
    public class Pessoa
    {
        public string CPF { get; private set; }
        public string Nome { get; private set; }       
        public DateTime DataNascimento { get; private set; }

        private readonly DateTime _dataNascimentoMinima = new DateTime(1900, 01, 01);

        /// <summary>
        /// Retorna o tempo até o próximo aniversário.
        /// </summary>
        /// <returns>String com tempo até o próximo aniversário formatada pelo Humanizer.</returns>
        public string TempoAteProximoAniversario()
        {            
            TimeSpan tempoAteProximoAniversario = DateTime.Now - new DateTime(DateTime.Now.Year, DataNascimento.Month, DataNascimento.Day);
            return TimeSpanHumanizeExtensions.Humanize(tempoAteProximoAniversario);
        }

        /// <summary>
        /// Cria uma instância de <see cref="Pessoa"/>.            
        /// </summary>         
        /// <param name="cpf">Define o valor da propriedade <see cref="CPF"></see>. Não pode ser vazia.</param> 
        /// <param name="nome">Define o valor da propriedade <see cref="Nome"></see>. Não pode ser vazia.</param>         
        /// <param name="dataNascimento">Define o valor da propriedade <see cref="DataNascimento"></see>. Não pode ser menor que <see cref="_dataNascimentoMinima"/> .</param> 
        ///<exception cref="ArgumentException"></exception>
        public Pessoa(string cpf, string nome, DateTime dataNascimento)
        {                        
            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentException($"A propriedade {cpf} não pode ser vazia.");

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException($"A propriedade {nome} não pode ser vazia.");
                        
            if (dataNascimento < _dataNascimentoMinima)
                throw new ArgumentException($"A propriedade {nameof(dataNascimento)} não pode inferior à {_dataNascimentoMinima:dd/MM/yyyy}.");

            CPF = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}

