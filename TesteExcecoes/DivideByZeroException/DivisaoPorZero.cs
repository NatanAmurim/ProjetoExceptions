using System;

namespace TesteExcecoes.TesteDivideByZeroException
{
    public static class DivisaoPorZero
    {
        private static int Divisao(int dividendo, int divisor)
        {
            try
            {
                return dividendo / divisor;
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException(message: "Não é possível dividir por zero");
            }

            
        }

        public static void TestarDivisao(int dividendo, int divisor)
        {           
            Console.WriteLine(Divisao(dividendo, divisor));                       
        }
    }
}
