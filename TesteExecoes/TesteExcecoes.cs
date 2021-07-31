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
                throw new NullReferenceException("N�o � poss�vel acessar uma refer�ncia nula");
            }

        }
    }
}
