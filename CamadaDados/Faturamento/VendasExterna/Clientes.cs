using System;
using System.Collections.Generic;

namespace CamadaDados.Faturamento.VendasExterna
{
    public class Email
    {
        public string EMAIL { get; set; }
    }
    public class Responsavel
    {
        //public int CODIGO { get; set; }
        public string NOME { get; set; } = string.Empty;
    }
    public class Pais
    {
        public string NOME { get; set; }
    }
    public class Estado
    {
        public string SIGLA { get; set; }
    }
    public class Cidade
    {
        public string NOME { get; set; }
        public string CODIGO_IBGE { get; set; }
    }
    public class Endereco
    {
        //public int CODIGO { get; set; }
        public string TIPO { get; set; }
        public string PRINCIPAL { get; set; }
        public string CEP { get; set; }
        public string ENDERECO { get; set; }
        public string NUMERO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string BAIRRO { get; set; }
        public Pais PAIS { get; set; }
        public Estado ESTADO { get; set; }
        public Cidade CIDADE { get; set; }

    }
    public class Clientes
    {
        public string NOME { get; set; }
        //public string APELIDO { get; set; }
        public string TIPO_PESSOA { get; set; }
        public string SITUACAO { get; set; }
        //public string RESTRICAO { get; set; }
        public string DOCUMENTO { get; set; }
        public string EXCLUIDO { get; set; }
        public Responsavel RESPONSAVEL { get; set; } = new Responsavel();
        public List<Endereco> ENDERECOS { get; set; } = new List<Endereco>();
    }
}
