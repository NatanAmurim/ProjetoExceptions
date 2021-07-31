using System;
using System.Collections.Generic;
using System.Text;

namespace TesteExcecoes.ExcecoesEspecificas
{
    /// <summary>
    /// Esta exceção é lançada ao se tentar realizar uma operação que retire saldo da conta quando o mesmo não for suficiente.
    /// </summary>
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public double Saldo{get;}
        public double ValorSaque { get; }

        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(string mensagem): base(mensagem) 
        { 
            
        }

        public SaldoInsuficienteException(string mensagem, Exception innerException) : base(mensagem, innerException)
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
