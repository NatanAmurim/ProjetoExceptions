using BaseBanco;
using System;
using TesteExcecoes.ExcecoesEspecificas;
using TesteExcecoes.TesteDivideByZeroException;
using TesteExcecoes.TesteNullPointer;

namespace TesteExcecoes
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                DateTime dataNascimento = new DateTime(1998, 08, 01);
                Pessoa pessoa = new Pessoa("1", "Teste", dataNascimento);                
                Console.WriteLine(pessoa.TempoAteProximoAniversario());
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }

            try
            {                
                DivisaoPorZero.TestarDivisao(1, 0);
            }
            catch (DivideByZeroException e)
            {

                Console.WriteLine($"Erro: {e.Message}");
            }
            catch (ArgumentNullException) { }


            try
            {
                ReferenciaNula.TestarReferenciaNula(null);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }


            try
            {
                Conta conta = new Conta(0,0,0);
                conta.Sacar(10);
                conta.Depositar(1);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }

            try
            {
                Conta conta = new Conta(1, 1, 1);
                conta.Sacar(-10);
            }
            catch (SaldoInsuficienteException e)
            {                
                Console.WriteLine($"Erro: {e.Message}");
            }
            catch (ArgumentException e) 
            {
                Console.WriteLine($"Erro: {e.Message}");
                
            }

            try
            {
                Conta contaOrigem = new Conta(1, 1, 1);
                Conta contaDestino = new Conta(1, 1, 1);

                contaOrigem.Transferir(contaDestino, 10);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                Console.WriteLine($"Stack: {e.StackTrace}");
               
            }

            Console.ReadKey();
             

        }
    }
}
