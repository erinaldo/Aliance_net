using System.Collections.Generic;

namespace CamadaDados.Faturamento.VendasExterna
{
    public class Categoria
    {
        //public string TIPO { get; set; }
        public string NOME { get; set; }
    }
    public class Fabricante
    {
        public string NOME { get; set; }
    }
    public class Unidade
    {
        public string SIGLA { get; set; }
    }
    public class Estoque
    {
        public string UNIDADE { get; set; }
        public string LOCALIZACAO { get; set; }
        public decimal QUANTIDADE_MINIMA { get; set; }
        public decimal QUANTIDADE_ATUAL { get; set; }
        public decimal QUANTIDADE_RESERVA { get; set; }
    }
    public class InformacoesAd
    {
        public string ACESSO_RAPIDO { get; set; } = null;
        public string ALTURA { get; set; } = null;
        public string LARGURA { get; set; } = null;
        public string COMPRIMENTO { get; set; } = null;
        public string PESO { get; set; } = null;
    }
    public class Preco
    {
        public string UNIDADE { get; set; }
        public decimal MARGEM_CUSTO_REAL { get; set; } = decimal.Zero;
        public decimal? PRECO_CUSTO { get; set; } = null;
        public decimal? PRECO_CUSTO_ANTERIOR { get; set; } = null;
        public decimal? PRECO_CUSTO_REAL { get; set; } = null;
        public decimal? PRECO_MEDIO { get; set; } = null;
        public decimal PRECO_VENDA { get; set; }
        public decimal? PRECO_VENDA_ANTERIOR { get; set; } = null;
        public decimal? DESCONTO_MAXIMO { get; set; } = null;
    }
    public class Secao_Localizacao
    {
        public string UNIDADE { get; set; } = "1";
        public string LOCALIZACAO { get; set; } = "1";
    }
    public class Texto
    {
        public string DESCRICAO { get; set; } = null;
        public string OBSERVACAO { get; set; } = null;
    }
    public class Tributarios
    {
        public string UNIDADE { get; set; }
        public string ICMS_SIMPLES_NACIONAL { get; set; }
        public string IPI_CST_ENTRADA { get; set; } = null;
        public string IPI_CST_SAIDA { get; set; } = null;
        public decimal IPI_ALIQUOTA { get; set; }
        public decimal IPI_VALOR_UNIDADE { get; set; }
        public string IPI_CLASSE_ENQUADRAMENTO { get; set; } = null;
        public string PIS_CST { get; set; } = null;
        public decimal PIS_ALIQUOTA { get; set; }
        public string PIS_NATUREZA_RECEITA { get; set; } = null;
        public string COFINS_CST { get; set; } = null;
        public decimal COFINS_ALIQUOTA { get; set; }
        public string COFINS_NATUREZA_RECEITA { get; set; } = null;
        public string CONTRIBUICAO_SOCIAL_APURADA { get; set; } = null;
        public string TOTAL_TRIBUTOS_TIPO { get; set; }
        public string TOTAL_TRIBUTOS_VALOR { get; set; } = null;
        public decimal TOTAL_TRIBUTOS_PERCENTUAL { get; set; }
    }
    public class Tributario_ICMS
    {
        public string UNIDADE { get; set; }
        public string CST { get; set; }
        public decimal ALIQUOTA_ORIGEM { get; set; }
        public decimal ALIQUOTA_DESTINO { get; set; }
        public decimal MVA { get; set; }
        public string MVA_AJUSTAR { get; set; }
        public decimal ALIQUOTA_REDUCAO { get; set; }
        public decimal ALIQUOTA_REDUCAO_ST { get; set; }
        public decimal INTERESTADUAL_ALIQUOTA_FCP { get; set; }
        public decimal INTERESTADUAL_ALIQUOTA_DESTINO { get; set; }
        public Estado ESTADO { get; set; }
    }
    public class Produtos
    {
        public string CODIGO_BARRAS { get; set; }
        public string NOME { get; set; }
        public string FABRICACAO_PROPRIA { get; set; }
        public string DISPONIBILIDADE { get; set; }
        public string ORIGEM { get; set; }
        public string NCM { get; set; }
        public string CEST { get; set; } = null;
        public Categoria CATEGORIA { get; set; }
        public Fabricante FABRICANTE { get; set; }
        public Unidade UNIDADE_MEDIDA_VENDA { get; set; }
        public List<Estoque> ESTOQUES { get; set; } = new List<Estoque>();
        public InformacoesAd INFORMACOES_ADICIONAIS { get; set; } = new InformacoesAd();
        public List<Preco> PRECOS { get; set; } = new List<Preco>();
        public Secao_Localizacao SECAO_LOCALIZACAO { get; set; } = new Secao_Localizacao();
        public Texto TEXTOS { get; set; } = new Texto();
        public Tributarios TRIBUTARIOS { get; set; }
        public List<Tributario_ICMS> TRIBUTARIOS_ICMS { get; set; } = new List<Tributario_ICMS>();
    }
}
