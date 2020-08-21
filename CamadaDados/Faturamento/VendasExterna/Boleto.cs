using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;

namespace CamadaDados.Faturamento.VendasExterna
{
    public class Licenca
    {
        public string CODIGO { get; set; }
        public string ATIVA { get; set; }
        public string GRATUITA { get; set; }
        public string PAIS { get; set; }
        public string NOME { get; set; }
        public string APELIDO { get; set; }
        public string DOCUMENTO { get; set; }
    }

    public class Integracao
    {
        public REFERENCIA Referencia { get; set; }
        public List<REGISTROS> Registros { get; set; }
    }

    public class Sistema
    {
        public string DESCRICAO { get; set; }
    }

    public class REFERENCIA
    { public string CODIGO { get; set; } }

    public class REGISTROS
    {
        public string CODIGO { get; set; }
        public string DESCRICAO { get; set; }
    }

    public class Token
    {
        public string token_acesso { get; set; }
        public string token_renovacao { get; set; }
        public string usuario { get; set; }
        public string licenca { get; set; }
        public int validade { get; set; }
        public DateTime Dt_cad { get; set; } = DateTime.Now;
        public bool St_valido => Dt_cad.AddSeconds(Convert.ToDouble(validade)) >= DateTime.Now;
    }

    public class Pessoas_enderecos
    {
        public REFERENCIA REFERENCIAS { get; set; }
    }

    public class Referencias
    {
        public string CODIGO { get; set; }
        public List<Pessoas_enderecos> PESSOAS_ENDERECOS { get; set; }
    }

    public class Retorno
    {
        public Referencias REFERENCIAS { get; set; }

    }

    public class BaixarBoleto
    {
        public string CODIGO { get; set; }
        public string VALOR_PAGO { get; set; }
        public string DATA_PAGAMENTO { get; set; }
    }

    public class Cliente
    {
        public string CODIGO { get; set; }
        public string DOCUMENTO { get; set; }
        public string NOME { get; set; }
    }

    public class Atendimento
    {
        public string CODIGO { get; set; }
        public Cliente CLIENTE { get; set; }
    }

    public class Atend
    {
        public Atendimento ATENDIMENTO { get; set; }
    }

    public class Boleto
    {
        public string CODIGO { get; set; }
        public DateTime VENCIMENTO { get; set; }
        public DateTime PROCESSAMENTO { get; set; }
        public decimal VALOR { get; set; }
        public string NOSSO_NUMERO { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public string CODIGO_BANCO { get; set; }
        public string LINHA_DIGITAVEL { get; set; }
        public string CODIGO_BARRAS { get; set; }
        public string Mensagem { get; set; }
        public string NomeCliente => ATENDIMENTOS.Count > 0 ? ATENDIMENTOS.First().ATENDIMENTO.CLIENTE.NOME : string.Empty;
        public string DocumentoCliente => ATENDIMENTOS.Count > 0 ? ATENDIMENTOS.First().ATENDIMENTO.CLIENTE.DOCUMENTO : string.Empty;
        public List<Atend> ATENDIMENTOS { get; set; }
        public bool St_processar { get; set; } = false;
        public bool St_integrado { get; set; } = false;
    }

    public class NFe
    {
        public string CHAVE_ACESSO { get; set; }
        public string XML { get; set; }
        public string PROTOCOLO { get; set; }
        public string PROTOCOLO_DATA { get; set; }
    }

    public class RegistroNFe
    {
        public string CODIGO { get; set; }
        public string SERIE { get; set; }
        public string NUMERO { get; set; }
        public string SITUACAO { get; set; }
        public DateTime DATA_EMISSAO { get; set; }
        public NFe NFE { get; set; }
        public string Cliente
        {
            get
            {
                if (NFE != null)
                    if (!string.IsNullOrWhiteSpace(NFE.XML))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(NFE.XML);
                        return doc.GetElementsByTagName("dest")[0]["xNome"].InnerText;
                    }
                    else return string.Empty;
                else return string.Empty;
            }
        }
        public bool St_processar { get; set; } = false;
        public bool St_integrado { get; set; } = false;
    }

    public class Registros
    {
        public int TOTAL_REGISTROS { get; set; }
        public List<Boleto> REGISTROS { get; set; }
    }

    public class RegistrosNFe
    {
        public int TOTAL_REGISTROS { get; set; }
        public List<RegistroNFe> REGISTROS { get; set; }
    }
}
