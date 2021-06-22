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
                DivisaoPorZero.TestarDivisao(1, 0);
            }
            catch (DivideByZeroException e)
            {

                Console.WriteLine($"Erro: {e.Message}");
            }


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
                Console.WriteLine($"Erro: {e.GetBaseException().Message}");
                Console.WriteLine($"Argumento com problema: {e.ParamName}");
            }

            Console.ReadKey();
             

        }
    }
}
