using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Fiscal.Sintegra;

namespace CamadaNegocio.Fiscal.Sintegra
{
    

    public class TCN_Tipo10_11
    {
        public  static Linha CriarRegistroTipo10_11(string Cd_empresa,
                                                    DateTime Dt_ini,
                                                    DateTime Dt_fin,
                                                    Finalidades Finalidade)
        {
            Tipo10_11 tp_registro = new TCD_Tipo10_11().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                                            }
                                        }, 0, string.Empty);
            if(tp_registro == null)
                throw new Exception("Não existe dados da empresa " + Cd_empresa.Trim() + " para montar registro 10 e 11");
            tp_registro.Data_final = Dt_fin;
            tp_registro.Data_inicial = Dt_ini;
            tp_registro.Finalidade = Finalidade;
            #region "Registro 10"
            //Tipo do Registro
            Linha ln = "10";
            //CNPJ do estabelecimento informante
            ln += tp_registro.Cnpj.Trim().SoNumero().FormatStringEsquerda(14, '0');
            //Inscricao estadual do estabelecimento informante
            ln += tp_registro.Insc_estadual.Trim().FormatStringDireita(14, ' ');
            //Razao social do contribuinte
            ln += tp_registro.Nome_contribuinte.Trim().FormatStringDireita(35, ' ');
            //Municipio do contribuinte
            ln += tp_registro.Municipio_contribuinte.Trim().FormatStringDireita(30, ' ');
            //Unidade da federacao do contribuinte
            ln += tp_registro.Uf.Trim().FormatStringDireita(2, ' ');
            //Telefone do contribuinte
            ln += tp_registro.Fone.SoNumero().FormatStringEsquerda(10, '0');
            //Data inicial do periodo referente as informacoes prestadas
            ln += tp_registro.Data_inicial.Value.ToString("yyyyMMdd");
            //Data final do periodo referente as informacoes prestadas
            ln += tp_registro.Data_final.Value.ToString("yyyyMMdd");
            //Codigo do convenio utilizado no arquivo magnetico
            ln += tp_registro.Codigo_convenio == IdentificacaoEstruturas.ICMS_CONVENIO_5795_30_02 ? "1" :
                tp_registro.Codigo_convenio == IdentificacaoEstruturas.ICMS_CONVENIO_5795_142_02 ? "2" :
                tp_registro.Codigo_convenio == IdentificacaoEstruturas.ICMS_CONVENIO_5795_76_03 ? "3" : string.Empty;
            //Codigo de identificacao da natureza das operacoes informadas
            ln += tp_registro.Codigo_identificacao == IdentificacaoNaturezaOperacoes.COM_SUBSTITUICAO_TRIBUTARIA ? "1" :
                tp_registro.Codigo_identificacao == IdentificacaoNaturezaOperacoes.SEM_SUBSTITUICAO_TRIBUTARIA ? "2" :
                tp_registro.Codigo_identificacao == IdentificacaoNaturezaOperacoes.TOTALIDADE_OPERACOES ? "3" : string.Empty;
            //Codigo finalidade do arquivo
            ln += tp_registro.Finalidade == Finalidades.NORMAL ? "1" :
                tp_registro.Finalidade == Finalidades.RETIFICACAO_TOTAL ? "2" :
                tp_registro.Finalidade == Finalidades.RETIFICACAO_ADITIVA ? "3" :
                tp_registro.Finalidade == Finalidades.RETIFICACAO_CORRETIVA ? "4" :
                tp_registro.Finalidade == Finalidades.DESFAZIMENTO ? "5" : string.Empty;
            ln += "\r\n";
            #endregion

            #region "Registro 11"
            //Tipo do Registro
            ln += "11";
            //Logradouro da Empresa
            ln += tp_registro.Logradouro.Trim().FormatStringDireita(34, ' ');
            //Numero endereco da empresa
            ln += tp_registro.Numero.Trim().SoNumero().FormatStringEsquerda(5, '0');
            //Complemento
            ln += tp_registro.Complemento.Trim().FormatStringDireita(22, ' ');
            //Bairro
            ln += tp_registro.Bairro.Trim().FormatStringDireita(15, ' ');
            //CEP
            ln += tp_registro.Cep.Trim().SoNumero().FormatStringEsquerda(8, '0');
            //Nome Contato
            ln += tp_registro.Contato.Trim().FormatStringDireita(28, ' ');
            //Telefone 
            ln += tp_registro.Fone.Trim().SoNumero().FormatStringEsquerda(12, '0');
            ln += "\r\n";
            #endregion

            return ln;
        }
    }
}
