using System;
using System.Collections.Generic;
using System.Text;
using TesteExcecoes.ExcecoesEspecificas;

namespace TesteExcecoes
{
    public class Conta
    {

        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public double Saldo { get; private set; }

        /// <summary>
        /// Cria uma instância de conta.
        /// Exceções: 
        /// Caso a <paramref name="agencia"/> ou <paramref name="numero"/> ou <paramref name="saldo"/> sejam menores que zero, uma exceção do tipo ArgumentException é lançada.                            
        /// <para>Teste</para> <paramref name="agencia"/>
        /// </summary> 
        /// <param name="numero">Indica o número da conta da conta e deve ser maior que zero.</param> 
        // <param name="saldo">Indica o saldo da conta e deve ser maior que zero.</param>  
        // <param name="agencia"> Indica a agencia da conta e de ser maior que zero.</param>
        public Conta(int agencia, int numero, double saldo)
        {
            VerificacaoArgumentoNumericoNaoPodeSerMenorQueZero(agencia, nameof(agencia));
            VerificacaoArgumentoNumericoNaoPodeSerMenorQueZero(numero, nameof(numero));
            VerificacaoArgumentoNumericoNaoPodeSerMenorQueZero(saldo, nameof(saldo));            

            Agencia = agencia;
            Numero = numero;
            Saldo = saldo;
        }

        public void Depositar(double valor) 
        {
            VerificacaoArgumentoNumericoNaoPodeSerMenorQueZero(valor, nameof(valor));
            Saldo += valor;            
        }

        public void Sacar(double valor) 
        {
            if (valor <= 0)
                throw new ArgumentException(message: $"O valor de saque não pode ser menor ou igual a zero.");

            if (Saldo < valor) 
            {                
                throw new SaldoInsuficienteException(saldo: Saldo, valorSaque: valor);
            }
            
            
            Saldo -= valor;
        }

        public void Transferir(Conta contaDestino, double valor) 
        {
            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException e)
            {                
                throw new OperacaoFinanceiraException("Operação inválida", e);
            }
            
            contaDestino.Depositar(valor);
        }

        /// <summary>
        /// Lança uma exceção do tipo ArgumentException caso o argumento do tipo double seja menor ou igual a zero.
        /// </summary>
        private void VerificacaoArgumentoNumericoNaoPodeSerMenorQueZero(double valor, string nomeArgumento) 
        {
            if (valor <= 0)
                throw new ArgumentException(message: $"O argumento {nomeArgumento} não pode ser menor ou igual a zero.");
        }           
        
    }
}
