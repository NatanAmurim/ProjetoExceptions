using System;
using System.Collections.Generic;
using System.Text;

namespace TesteExcecoes.ExcecoesEspecificas
{
    public class OperacaoFinanceiraException: Exception
    {
        public OperacaoFinanceiraException()
        {

        }

        public OperacaoFinanceiraException(string mensagem): base(mensagem)
        {

        }

        public OperacaoFinanceiraException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {

        }

    }
}
