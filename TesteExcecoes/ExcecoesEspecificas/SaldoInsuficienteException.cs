using System;
using System.Collections.Generic;
using System.Text;

namespace TesteExcecoes.ExcecoesEspecificas
{
    public class SaldoInsuficienteException : Exception
    {
        public double Saldo{get;}
        public double ValorSaque { get; }

        public SaldoInsuficienteException(string mensagem): base(mensagem) 
        { 
            
        }

        public SaldoInsuficienteException()
        {
                
        }
        public SaldoInsuficienteException(double saldo, double valorSaque): 
            this($"O saldo em conta é menor que o valor de saque.\nSaldo atual: {saldo}\nValor de saque: {valorSaque}.")
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
    }
}
