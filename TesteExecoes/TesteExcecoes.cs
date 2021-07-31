using BaseBanco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TesteExecoes
{
    [TestClass]
    public class TesteExceco
    {
        [TestMethod]
        public static void TestarReferenciaNula(Pessoa pessoa)
        {
            try
            {
                Assert.IsFalse(true);                
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Não é possível acessar uma referência nula");
            }

        }
    }
}
