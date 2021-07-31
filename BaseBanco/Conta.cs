using System;
using System.Collections.Generic;
using System.Text;
using TesteExcecoes.ExcecoesEspecificas;

namespace BaseBanco
{
    public class Conta
    {
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public double Saldo { get; private set; }

        /// <summary>
        /// Cria uma instância de conta.            
        /// </summary>         
        /// <param name="agencia">Define o valor da propriedade <see cref="Agencia"></see> e deve ser maior que zero.</param> 
        /// <param name="numero">Define o valor da propriedade <see cref="Numero"></see> e deve ser maior que zero.</param> 
        /// <param name="saldo">Define o valor da propriedade <see cref="Saldo"></see> e deve ser maior que zero.</param> 
        ///<exception cref="ArgumentException">Quando um ou mais parâmetros são menores que zero, uma exceção deste tipo é lançada.</exception>
        public Conta(int agencia, int numero, double saldo)
        {
            if (agencia <= 0)
                throw new ArgumentException(message: $"O argumento {agencia} não pode ser menor ou igual a zero.");
            if (numero <= 0)
                throw new ArgumentException(message: $"O argumento {numero} não pode ser menor ou igual a zero.");
            if (saldo <= 0)
                throw new ArgumentException(message: $"O argumento {saldo} não pode ser menor ou igual a zero.");
                      
            Agencia = agencia;
            Numero = numero;
            Saldo = saldo;
        }

        ///<remarks>Efetua a entrada de um valor na <see cref="Conta"/>.</remarks>
        ///<exception cref = "ArgumentException" ></exception>
        public void Depositar(double valor) 
        {
            if (valor <= 0)
                throw new ArgumentException(message: $"O argumento {valor} não pode ser menor ou igual a zero.");
            Saldo += valor;            
        }
       
        ///<remarks>Efetua a retirada de um valor da <see cref="Conta"/>.</remarks>
        ///<exception cref = "SaldoInsuficienteException" ></exception>
        ///<exception cref = "ArgumentException" ></exception>
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

        ///<param name="contaDestino">Define a <see cref="Conta"/> para qual será destinada a transferência.</param>
        ///<param name="valor">Define o valor que será transferido.</param>
        ///<exception cref = "NullReferenceException" ></exception>
        ///<exception cref = "OperacaoFinanceiraException" ></exception>
        public void Transferir(Conta contaDestino, double valor) 
        {
            if (contaDestino == null)
                throw new NullReferenceException($"A propriedade {contaDestino} destino não pode ser vazias.");
            try
            {
                Sacar(valor);
                contaDestino.Depositar(valor);
            }
            catch (SaldoInsuficienteException e)
            {                
                throw new OperacaoFinanceiraException("Operação inválida", e);
            }                       
        }

    }
}
