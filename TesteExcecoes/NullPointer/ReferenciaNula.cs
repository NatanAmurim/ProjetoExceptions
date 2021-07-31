using BaseBanco;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteExcecoes.TesteNullPointer
{
    public static class ReferenciaNula
    {

        public static string TestarReferenciaNula(Pessoa pessoa) 
        {
            try
            {
                return pessoa.Nome;
            }
            catch (NullReferenceException) 
            {
                throw new NullReferenceException("Não é possível acessar uma referência nula");                    
            }
           
        }

    }
}
