using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal.Sintegra
{
    public enum IdentificacaoEstruturas
    {
        ICMS_CONVENIO_5795_30_02 = 1,
        ICMS_CONVENIO_5795_142_02 = 2,
        ICMS_CONVENIO_5795_76_03 = 3
    }

    public enum IdentificacaoNaturezaOperacoes
    {
        COM_SUBSTITUICAO_TRIBUTARIA = 1,
        SEM_SUBSTITUICAO_TRIBUTARIA = 2,
        TOTALIDADE_OPERACOES = 3
    }

    public enum Finalidades
    {
        NORMAL = 1,
        RETIFICACAO_TOTAL = 2,
        RETIFICACAO_ADITIVA = 3,
        RETIFICACAO_CORRETIVA = 4,
        DESFAZIMENTO = 5
    }

    public enum Modalidade_frete
    {
        OUTROS = 0,
        CIF = 1,
        FOB = 2
    }
}
