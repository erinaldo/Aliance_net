using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Utils;

namespace CamadaDados.Financeiro.Bloqueto
{
    #region Enumerações
    public enum TTipoInscricao { tiPessoaFisica, tiPessoaJuridica, tiOutro }

    public enum TEspecieDocumento
    {
        edAluguel,
        edApoliceSeguro,
        edCheque,
        edContrato,
        edContribuicaoConfederativa,
        edCosseguros,
        edDividaAtivaEstado,
        edDividaAtivaMunicipio,
        edDividaAtivaUniao,
        edDuplicataMercantil,
        edDuplicataMercantialIndicacao,
        edDuplicataRural,
        edDuplicataServico,
        edDuplicataServicoIndicacao,
        edFatura,
        edLetraCambio,
        edMensalidadeEscolar,
        edNotaCreditoComercial,
        edNotaCreditoExportacao,
        edNotaCreditoIndustrial,
        edNotaCreditoRural,
        edNotaDebito,
        edNotaPromissoria,
        edNotaPromissoriaRural,
        edNotaSeguro,
        edOutros,
        edParcelaConsorcio,
        edRecibo,
        edTriplicataMercantil,
        edTriplicataServico,
        edWarrant
    }

    public enum TAceiteDocumento { adSim, adNao }

    public enum TLayoutArquivo { laCNAB240, laCNAB400, laOutro }

    public enum TTipoMovimento { tmRemessa, tmRetorno, tmOutro }
    #endregion

    public class blCobCodBarr
    {
        private Image GetImage()
        {
            Color CorBarra = Color.Black;
            Color CorEspaco = Color.White;
            int LarguraBarraFina = 1;
            int LarguraBarraGrossa = 3;
            int AlturaBarra = 50;
            int LarguraBarra = 0;
            Pen caneta = new Pen(Color.White);
            int Col;
            int Lar;

            string CodigoAuxiliar = Define2de5();
            for (int x = 0; x < CodigoAuxiliar.Length; x++)
            {
                switch (CodigoAuxiliar[x])
                {
                    case '0':
                        LarguraBarra += LarguraBarraFina;
                        break;
                    case '1':
                        LarguraBarra += LarguraBarraGrossa;
                        break;
                };
            };

            Bitmap Result = new Bitmap(LarguraBarra, AlturaBarra);
            Graphics g = Graphics.FromImage(Result);
            g.Clear(Color.White);
            Col = 0;
            if (CodigoAuxiliar != "Erro")
            {
                for (int x = 0; x < CodigoAuxiliar.Length; x++)
                {
                    //{Desenha barra}
                    if ((x % 2) > 0)  //se for impar                    
                        caneta.Color = CorEspaco;
                    else
                        caneta.Color = CorBarra;
                    if (CodigoAuxiliar[x] == '0')
                    {
                        for (Lar = 0; Lar < LarguraBarraFina; Lar++)
                        {

                            g.DrawLine(caneta,
                                 new Point { X = Col, Y = 0 },
                                 new Point { X = Col, Y = AlturaBarra });
                            Col += 1;
                        }
                    }
                    else
                    {
                        for (Lar = 0; Lar < LarguraBarraGrossa; Lar++)
                        {
                            g.DrawLine(caneta,
                                 new Point { X = Col, Y = 0 },
                                 new Point { X = Col, Y = AlturaBarra });
                            Col += 1;
                        }
                    }
                }
            }
            else
                Result = null;

            return Result;
        }
        private string Define2de5()
        {
            //{Traduz dígitos do código de barras para valores de 0 e 1, formando um código do tipo Intercalado 2 de 5}
            string CodigoAuxiliar;
            string Start;
            string Stop;
            string[] T2de5 = new string[10];
            string Codifi = "";
            string Result = "";

            Result = "Erro";

            Start = "0000";
            Stop = "100";
            T2de5[0] = "00110";
            T2de5[1] = "10001";
            T2de5[2] = "01001";
            T2de5[3] = "11000";
            T2de5[4] = "00101";
            T2de5[5] = "10100";
            T2de5[6] = "01100";
            T2de5[7] = "00011";
            T2de5[8] = "10010";
            T2de5[9] = "01010";

            //{ Digitos }
            for (int i = 0; i < _Codigo.Trim().Length; i++)
            {
                if (char.IsDigit(_Codigo.Trim()[i]))
                    Codifi += T2de5[Convert.ToInt16(_Codigo.Trim()[i].ToString())];
                else
                    return "";
            }

            //{Se houver um número ímpar de dígitos no Código, acrescentar um ZERO no início}

            if ((_Codigo.Length % 2) > 0) //he impar
                Codifi = T2de5[0] + Codifi;

            //{Intercalar números - O primeiro com o segundo, o terceiro com o quarto, etc...}            
            CodigoAuxiliar = "";
            for (int i = 0; i <= (Codifi.Trim().Length - 9); i += 10)
            {
                CodigoAuxiliar += Codifi[i].ToString() +
                                  Codifi[i + 5].ToString() +
                                  Codifi[i + 1].ToString() +
                                  Codifi[i + 6].ToString() +
                                  Codifi[i + 2].ToString() +
                                  Codifi[i + 7].ToString() +
                                  Codifi[i + 3].ToString() +
                                  Codifi[i + 8].ToString() +
                                  Codifi[i + 4].ToString() +
                                  Codifi[i + 9].ToString();
            }

            //{ Acrescentar caracteres Start e Stop }
            Result = Start + CodigoAuxiliar + Stop;
            return Result;
        }
        private string GetLinhaDigitavel()
        {
            string p1, p2, p3, p4, p5, p6, Campo1, Campo2, Campo3, Campo4,
                Campo5 = string.Empty;

            /*       
             Campo 1 - composto pelo código do banco, código da moeda, as cinco primeiras posições
             do campo livre e DV (modulo10) desse campo       
            */
            p1 = _Codigo.Trim().Substring(0, 4);
            p2 = _Codigo.Trim().Substring(19, 5);
            p3 = Estruturas.Mod10(p1 + p2).ToString().Trim();
            p4 = p1 + p2 + p3;
            p5 = p4.Trim().Substring(0, 5);
            p6 = p4.Trim().Substring(5, 5);
            Campo1 = p5 + '.' + p6;

            /*
                Campo 2 - composto pelas posiçoes 6 a 15 do campo livre
                e DV (modulo10) deste campo
            */
            p1 = _Codigo.Trim().Substring(24, 10);
            p2 = Utils.Estruturas.Mod10(p1).ToString();
            p3 = p1 + p2;
            p4 = p3.Trim().Substring(0, 5);
            p5 = p3.Trim().Substring(5, 6);
            Campo2 = p4 + '.' + p5;

            /*
                Campo 3 - composto pelas posicoes 16 a 25 do campo livre
                e DV (modulo10) deste campo
            */
            p1 = _Codigo.Trim().Substring(34, 10);
            p2 = Utils.Estruturas.Mod10(p1).ToString();
            p3 = p1 + p2;
            p4 = p3.Trim().Substring(0, 5);
            p5 = p3.Trim().Substring(5, 6);
            Campo3 = p4 + '.' + p5;

            //
            //   Campo 4 - digito verificador do codigo de barras
            // 

            Campo4 = _Codigo.Trim().Substring(4, 1);

            //
            //   Campo 5 - composto pelo valor nominal do documento, sem indicacao
            //   de zeros a esquerda e sem edicao (sem ponto e virgula). Quando se
            //   tratar de valor zerado, a representacao deve ser 000 (tres zeros).
            //

            Campo5 = _Codigo.Trim().Substring(5, 4) + _Codigo.Trim().Substring(9, 10);

            return Campo1 + " " + Campo2 + " " + Campo3 + " " + Campo4 + " " + Campo5;
        }
        private string _Codigo;
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public string LinhaDigitavel
        {
            get { return GetLinhaDigitavel(); }
        }
        public Image Imagem
        {
            get { return GetImage(); }
        }
    }

    public class blEndereco
    {
        public string Rua
        { get; set; }
        public string Numero
        { get; set; }
        public string Complemento
        { get; set; }
        public string Bairro
        { get; set; }
        public string Cidade
        { get; set; }
        public string EMail
        { get; set; }
        public string Estado
        { get; set; }
        public string CEP
        { get; set; }

        public blEndereco()
        {
            Bairro = string.Empty;
            CEP = string.Empty;
            Cidade = string.Empty;
            Complemento = string.Empty;
            EMail = string.Empty;
            Estado = string.Empty;
            Numero = string.Empty;
            Rua = string.Empty;
        }
        public void Assign(blEndereco AEndereco)
        {
            Rua = AEndereco.Rua;
            Numero = AEndereco.Numero;
            Complemento = AEndereco.Complemento;
            Bairro = AEndereco.Bairro;
            Cidade = AEndereco.Cidade;
            EMail = AEndereco.EMail;
            Estado = AEndereco.Estado;
            CEP = AEndereco.CEP;
        }
    }

    public class blBanco
    {
        public string Codigo
        {
            get;
            set;
        } = string.Empty;
        private void SetCodigo(string ACodigoBanco)
        {
            ACodigoBanco = ACodigoBanco.Trim().PadLeft(3, '0');
            if (ACodigoBanco == "000")
                Codigo = string.Empty;
            else if (ACodigoBanco != Codigo)
                Codigo = ACodigoBanco;
        }
        private string GetDigito() //{Retorna o dígito do código do banco}
        {
            if (string.IsNullOrEmpty(Codigo))
                return string.Empty;
            else if (Codigo.Trim().Equals(string.Empty))
                return string.Empty;
            else if (Codigo.Trim().Equals("748"))
                return "X";
            else
                return Utils.Estruturas.Mod11(Codigo, 9, false, 0).ToString();

        }
        private string GetNome() //{Retorna o nome do banco}
        {
            Codigo = Codigo.Trim().PadLeft(3, '0');
            if (Codigo != "000")
            {
                string nmClasse = "blBanco" + Codigo;
                try
                {
                    Type _tp = Type.GetType(nmClasse);
                    MemberInfo[] _info = _tp.FindMembers(MemberTypes.Method,
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Static |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly, Type.FilterName, "GetNomeBanco");

                    MethodInfo _metodo = _tp.GetMethod("GetNomeBanco");
                    object obj = new object();
                    _metodo.Invoke(obj, null);

                    return (string)obj;
                }
                catch
                {
                    return "";
                }
            }
            else
            {
                throw new Exception("Codigo do banco nao informado!");
            }
        }
        public void Assign(blBanco ABanco)
        {
            Codigo = ABanco.Codigo;
        }
        public string Digito
        {
            get { return GetDigito(); }
        }
        public string Nome
        {
            get { return GetNome(); }
        }
    }

    public class blContaBancaria
    {
        public blBanco Banco
        {
            get;
            set;
        }
        public string CodigoAgencia
        {
            get;
            set;
        }
        public string DigitoAgencia
        {
            get;
            set;
        }
        public string NumeroConta
        {
            get;
            set;
        }
        public string DigitoConta
        {
            get;
            set;
        }
        public string NomeCliente
        {
            get;
            set;
        }

        public blContaBancaria()
        {
            Banco = new blBanco();
            CodigoAgencia = string.Empty;
            DigitoAgencia = string.Empty;
            NumeroConta = string.Empty;
            DigitoConta = string.Empty;
            NomeCliente = string.Empty;
        }
        public void Assign(blContaBancaria AContaBancaria)
        {
            Banco.Assign(AContaBancaria.Banco);
            CodigoAgencia = AContaBancaria.CodigoAgencia;
            DigitoAgencia = AContaBancaria.DigitoAgencia;
            NumeroConta = AContaBancaria.NumeroConta;
            DigitoConta = AContaBancaria.DigitoConta;
            NomeCliente = AContaBancaria.NomeCliente;
        }
    }

    public class blPessoa
    {
        public TTipoInscricao TipoInscricao
        { get; set; }
        public string NumeroCPFCNPJ
        { get; set; }
        public string Nome
        { get; set; }
        public blEndereco Endereco
        { get; set; }
        public blContaBancaria ContaBancaria
        { get; set; }

        public void Assign(blPessoa APessoa)
        {
            TipoInscricao = APessoa.TipoInscricao;
            NumeroCPFCNPJ = APessoa.NumeroCPFCNPJ;
            Nome = APessoa.Nome;
            Endereco.Assign(APessoa.Endereco);
            ContaBancaria.Assign(APessoa.ContaBancaria);
        }
        public blPessoa()
        {
            TipoInscricao = TTipoInscricao.tiOutro;
            NumeroCPFCNPJ = string.Empty;
            Nome = string.Empty;
            Endereco = new blEndereco();
            ContaBancaria = new blContaBancaria();
        }
    }

    public class blCedente : blPessoa
    {
        public string CodigoCedente
        { get; set; }
        public string DigitoCodigoCedente
        { get; set; }
        public string Postocedente
        { get; set; }

        public void Assign(blCedente ACedente)
        {
            base.Assign(ACedente);
            CodigoCedente = ACedente.CodigoCedente;
            DigitoCodigoCedente = ACedente.DigitoCodigoCedente;
            Postocedente = ACedente.Postocedente;
        }
        public blCedente()
        {
            CodigoCedente = string.Empty;
            DigitoCodigoCedente = string.Empty;
            Postocedente = string.Empty;
        }
    }

    #region Classe Titulo
    public class TList_Bloqueto : List<TBloqueto>, IComparer<TBloqueto>
    {
        #region IComparer<TBloqueto> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_Bloqueto()
        { }

        public TList_Bloqueto(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TBloqueto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TBloqueto x, TBloqueto y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }

    public class TBloqueto
    {
        public string Nosso_numero
        { get; set; }
        public string Digito_nossonumero
        { get; set; }
        public string Aceite_SN
        { get; set; }
        public string Ano
        { get; set; }
        public string Instrucoes
        { get; set; }
        public string Cd_banco
        { get; set; }
        public string Digito_banco
        { get; set; }
        public byte[] Logo_banco
        { get; set; }
        public string LinhaDigitavel
        { get; set; }
        public string Local_pagamento
        { get; set; }
        public string Numerodocumento
        { get; set; }
        public string Carteira
        { get; set; }
        public string Modalidade
        { get; set; }
        public string Tp_cobranca
        { get; set; }
        public decimal Vl_nominal
        { get; set; }
        public decimal Vl_documento
        { get; set; }
        public decimal Vl_multacalc
        { get; set; }
        public decimal Vl_jurocalc
        { get; set; }
        public decimal Vl_atual
        { get { return Vl_documento + Vl_multacalc + Vl_jurocalc; } }
        public string Nm_sacado
        { get; set; }
        public string Cpf_Cnpj_sacado
        { get; set; }
        public string DS_Endereco_Sacado
        { get; set; }
        public string Numero_Sacado
        { get; set; }
        public string Complemento_Sacado
        { get; set; }
        public string Bairro_Sacado
        { get; set; }
        public string Cidade_Sacado
        { get; set; }
        public string Uf_Sacado
        { get; set; }
        public string Cep_Sacado
        { get; set; }
        public string Nm_Cedente
        { get; set; }
        public string Agencia
        { get; set; }
        public string Codigocedente
        { get; set; }
        public string Digitocedente
        { get; set; }
        public string Posto_cedente
        { get; set; }
        public byte[] imagem
        { get; set; }
        public DateTime Dt_vencimento
        { get; set; }
        public DateTime Dt_documento
        { get; set; }
        public string Especiedocumento
        { get; set; }
        public string Tp_layoutbloqueto
        { get; set; }
        public decimal Qt_atualizatitulo
        { get; set; }

        public TBloqueto()
        {
            Nosso_numero = string.Empty;
            Aceite_SN = string.Empty;
            Ano = string.Empty;
            Instrucoes = string.Empty;
            Cd_banco = string.Empty;
            Digito_banco = string.Empty;
            LinhaDigitavel = string.Empty;
            Local_pagamento = string.Empty;
            Numerodocumento = string.Empty;
            Carteira = string.Empty;
            Modalidade = string.Empty;
            Tp_cobranca = string.Empty;
            Codigocedente = string.Empty;
            Vl_nominal = decimal.Zero;
            Vl_documento = decimal.Zero;
            Vl_multacalc = decimal.Zero;
            Vl_jurocalc = decimal.Zero;
            Nm_sacado = string.Empty;
            Cpf_Cnpj_sacado = string.Empty;
            DS_Endereco_Sacado = string.Empty;
            Numero_Sacado = string.Empty;
            Complemento_Sacado = string.Empty;
            Bairro_Sacado = string.Empty;
            Cidade_Sacado = string.Empty;
            Uf_Sacado = string.Empty;
            Cep_Sacado = string.Empty;
            Nm_Cedente = string.Empty;
            Agencia = string.Empty;
            Codigocedente = string.Empty;
            imagem = null;
            Dt_vencimento = new DateTime();
            Dt_documento = new DateTime();
            Especiedocumento = string.Empty;
            Logo_banco = null;
            Tp_layoutbloqueto = string.Empty;
            Qt_atualizatitulo = decimal.Zero;
        }
    }

    public class blListaTitulo : List<blTitulo>, IComparer<blTitulo>
    {
        #region IComparer<blTitulo> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public blListaTitulo()
        { }

        public blListaTitulo(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(blTitulo value,
                                        string Propriedade)
        {
            PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(blTitulo x, blTitulo y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }

    public class blTitulo
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_sacado
        { get; set; }
        public decimal? Nr_lancto
        { get; set; }
        public decimal? Cd_parcela
        { get; set; }
        public decimal? Id_cobranca
        { get; set; }
        public decimal? Id_config { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        //Campo utilizado para impressao no boleto quando correspondente
        public string Nome_banco
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Cd_banco
        {
            get
            {
                return Cedente.ContaBancaria.Banco.Codigo;
            }
        }
        public string Digito_Banco
        {
            get
            {
                return Cedente.ContaBancaria.Banco.Digito;
            }
        }
        public byte[] Logo_banco
        { get; set; }
        public Image imgLogo
        {
            get
            {
                if (Logo_banco != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(Logo_banco, 0, Logo_banco.Length);
                        return Image.FromStream(ms);
                    }
                }
                else return null;
            }
        }
        public string Ano
        { get; set; }
        public string Status_remessa
        { get; set; }
        public string Ds_motivo
        { get; set; }
        public blCedente Cedente
        { get; set; }
        public string Nm_cedente
        {
            get
            {
                return Cedente.Nome;
            }
        }
        public string codigocedente
        { get { return Cedente.CodigoCedente; } }
        public blPessoa Sacado
        { get; set; }
        public blPessoa Avalista
        { get; set; }
        public blEndereco EndAvalista
        { get; set; }
        public string Nm_sacado
        {
            get
            {
                return Sacado.Nome;
            }
            set { }
        }
        public string cpf_cnpj_sacado
        {
            get
            {
                return Sacado.NumeroCPFCNPJ;
            }
        }
        public string Ds_endereco_sacado
        {
            get
            {
                return Sacado.Endereco.Rua;
            }
        }
        public string Numero_sacado
        {
            get
            {
                return Sacado.Endereco.Numero;
            }
        }
        public string Complemento_sacado
        {
            get
            {
                return Sacado.Endereco.Complemento;
            }
        }
        public string Bairro_sacado
        {
            get
            {
                return Sacado.Endereco.Bairro;
            }
        }
        public string Cidade_sacado
        {
            get
            {
                return Sacado.Endereco.Cidade;
            }
        }
        public string Uf_sacado
        {
            get
            {
                return Sacado.Endereco.Estado;
            }
        }
        public string Cep_sacado
        {
            get
            {
                return Sacado.Endereco.CEP;
            }
        }
        public string Local_pagamento
        { get; set; }
        public string Nosso_numero
        { get; set; }
        public string NumeroDocumento { get; set; }
        public string Carteira
        { get; set; }
        public string Modalidade
        { get; set; }
        public string Tp_cobranca
        { get; set; }
        private TAceiteDocumento aceite_documento;
        public TAceiteDocumento Aceite_documento
        {
            get { return aceite_documento; }
            set { aceite_documento = value; }
        }
        public string Aceite_SN
        {
            get
            {
                if (aceite_documento == TAceiteDocumento.adNao)
                    return "N";
                else if (aceite_documento == TAceiteDocumento.adSim)
                    return "S";
                else
                    return string.Empty;
            }
        }
        private TEspecieDocumento especie_documento;
        public TEspecieDocumento Especie_documento
        {
            get { return especie_documento; }
            set { especie_documento = value; }
        }
        private DateTime? dt_documento;
        public DateTime? Dt_documento
        {
            get { return dt_documento; }
            set
            {
                dt_documento = value;
                dt_documentostring = (value.HasValue ? value.ToString() : string.Empty);
            }
        }
        private string dt_documentostring;
        public string Dt_documentostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_documentostring).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                dt_documentostring = value;
                try
                {
                    dt_documento = Convert.ToDateTime(value);
                }
                catch
                { dt_documento = null; }
            }
        }
        private DateTime? dt_vencimento;
        public DateTime? Dt_vencimento
        {
            get { return dt_vencimento; }
            set
            {
                dt_vencimento = value;
                dt_vencimentostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_vencimentostring;
        public string Dt_vencimentostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_vencimentostring).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                dt_vencimentostring = value;
                try
                {
                    dt_vencimento = Convert.ToDateTime(value);
                }
                catch
                { dt_vencimento = null; }
            }
        }
        private DateTime? dt_ocorrencia;
        public DateTime? Dt_ocorrencia
        {
            get { return dt_ocorrencia; }
            set
            {
                dt_ocorrencia = value;
            }
        }
        private DateTime? dt_credito;
        public DateTime? Dt_credito
        {
            get { return dt_credito; }
            set
            {
                dt_credito = value;
                dt_creditostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_creditostring;
        public string Dt_creditostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_creditostring).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                dt_creditostring = value;
                try
                {
                    dt_credito = Convert.ToDateTime(value);
                }
                catch
                { dt_credito = null; }
            }
        }
        private DateTime? dt_creditotaxa;
        public DateTime? Dt_creditotaxa
        {
            get { return dt_creditotaxa; }
            set
            {
                dt_creditotaxa = value;
                dt_creditotaxastr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_creditotaxastr;
        public string Dt_creditotaxastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_creditotaxastr).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                dt_creditotaxastr = value;
                try
                {
                    dt_creditotaxa = Convert.ToDateTime(value);
                }
                catch
                { dt_creditotaxa = null; }
            }
        }
        private DateTime? dt_protesto;
        public DateTime? Dt_protesto
        {
            get { return dt_protesto; }
            set
            {
                dt_protesto = value;
                dt_protestostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_protestostring;
        public string Dt_protestostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_protestostring).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                dt_protestostring = value;
                try
                {
                    dt_protesto = Convert.ToDateTime(value);
                }
                catch
                { dt_protesto = null; }
            }
        }
        private DateTime? dt_baixa;
        public DateTime? Dt_baixa
        {
            get { return dt_baixa; }
            set
            {
                dt_baixa = value;
                dt_baixastring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_baixastring;
        public string Dt_baixastring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_baixastring).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                dt_baixastring = value;
                try
                {
                    dt_baixa = Convert.ToDateTime(value);
                }
                catch
                { dt_baixa = null; }
            }
        }
        private DateTime? dt_emissaobloqueto;
        public DateTime? Dt_emissaobloqueto
        {
            get { return dt_emissaobloqueto; }
            set
            {
                dt_emissaobloqueto = value;
                dt_emissaobloquetostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_emissaobloquetostring;
        public string Dt_emissaobloquetostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_emissaobloquetostring).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                dt_emissaobloquetostring = value;
                try
                {
                    dt_emissaobloqueto = Convert.ToDateTime(value);
                }
                catch
                { dt_emissaobloqueto = null; }
            }
        }
        public decimal Vl_nominal
        { get; set; }
        public decimal Vl_documento
        { get; set; }
        public decimal Vl_recebido { get; set; } = decimal.Zero;
        public decimal Vl_multacalc
        { get; set; }
        public decimal Vl_jurocalc
        { get; set; }
        public decimal Vl_atual
        { get { return Vl_documento + Vl_multacalc + Vl_jurocalc; } }
        public decimal Vl_despesa_cobranca
        { get; set; }
        public decimal Vl_abatimento
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_morajuros
        { get; set; }
        public decimal Vl_iof
        { get; set; }
        public decimal Vl_outras_despesas
        { get; set; }
        public decimal vl_outros_creditos
        { get; set; }
        public string Instrucoes
        { get; set; }
        public blCobCodBarr CodigoBarras
        {
            get
            {
                return GerarCodigoBarras();
            }
        }
        public Image ImagemBarra
        {
            get
            {
                return CodigoBarras.Imagem;
            }
        }
        public string LinhaDigitavel
        {
            get
            {
                return CodigoBarras.LinhaDigitavel;
            }
        }
        public string Sg_moeda_padrao
        { get; set; }
        public string Digito_nossonumero
        {
            get
            {
                return CalcularDigitoNossoNumero();
            }
        }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status_registro = "ABERTO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status_registro = "COMPENSADO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status_registro = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("D"))
                    status_registro = "DESCONTADO";
            }
        }
        private string status_registro;
        public string Status_registro
        {
            get { return status_registro; }
            set
            {
                status_registro = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("COMPENSADO"))
                    st_registro = "P";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("DESCONTADO"))
                    st_registro = "D";
            }
        }
        public decimal Pc_jurodia
        { get; set; }
        public string Tp_jurodia
        { get; set; }
        public decimal Pc_desconto
        { get; set; }
        public string Tp_desconto
        { get; set; }
        public decimal Nr_diasdesconto
        { get; set; }
        public decimal Pc_multa
        { get; set; }
        public string Tp_multa
        { get; set; }
        public decimal Nr_diasmulta
        { get; set; }
        public int EspecieDocumento { get { return RetornarCodigoEspecieDocumento(); } }
        public string EspecieDocumentostr
        {
            get
            {
                switch (EspecieDocumento)
                {
                    case 20: return "AP";   //{AP  APÓLICE DE SEGURO}
                    case 1: return "CH";   //{CH  CHEQUE}
                    case 2: return "DM";   //{DM  DUPLICATA MERCANTIL}
                    case 3: return "DMI";   //{DMI DUPLICATA MERCANTIL P/ INDICAÇÃO}
                    case 6: return "DR";   //{DR  DUPLICATA RURAL}
                    case 4: return "DS";   //{DS  DUPLICATA DE SERVIÇO}
                    case 5: return "DSI";   //{DSI DUPLICATA DE SERVIÇO P/ INDICAÇÃO}
                    case 18: return "FAT";   //{FAT FATURA}
                    case 7: return "LC";   //{LC  LETRA DE CÂMBIO}
                    case 21: return "ME";   //{ME  MENSALIDADE ESCOLAR}
                    case 8: return "NCC";   //{NCC NOTA DE CRÉDITO COMERCIAL}
                    case 9: return "NCE";   //{NCE NOTA DE CRÉDITO A EXPORTAÇÃO}
                    case 10: return "NCI";   //{NCI NOTA DE CRÉDITO INDUSTRIAL}
                    case 11: return "NCR";   //{NCR NOTA DE CRÉDITO RURAL}
                    case 19: return "ND";   //{ND  NOTA DE DÉBITO}
                    case 12: return "NP";   //{NP  NOTA PROMISSÓRIA}
                    case 14: return "NPR";   //{NPR NOTA PROMISSÓRIA RURAL}
                    case 16: return "NS";   //{NS  NOTA DE SEGURO}
                    case 22: return "PC";   //{PC  PARCELA DE CONSORCIO}
                    case 17: return "RC";   // {RC  RECIBO}
                    case 15: return "TS";   //{TS  TRIPLICATA DE SERVIÇO}
                    default: return string.Empty;
                }
            }
        }
        public string Digito_NossoNumero { get { return CalcularDigitoNossoNumero(); } }
        public bool St_descontar
        { get; set; }
        public string Cd_bancocorrespondente
        { get; set; }
        public string Digito_bancocorrespondente
        { get { return Estruturas.Mod11(Cd_bancocorrespondente, 9, false, 0).ToString(); } }
        public string Ds_bancocorrespondente
        { get; set; }
        public string Conveniocobranca
        { get; set; }
        public string Nr_agenciacorrespondente
        { get; set; }
        public string Nr_contacorrespondente
        { get; set; }
        public string Carteiracorrespondente
        { get; set; }
        public bool St_protestarauto
        { get; set; }
        public decimal Nr_diasprotestar
        { get; set; }
        public string Cd_ocorrencia
        { get; set; }
        public string Ds_ocorrencia
        { get; set; }
        public string Ds_motivoocorrencia
        { get; set; }
        public string Ds_observacao
        { get; set; }
        private string st_protestado;
        public string St_protestado
        {
            get { return st_protestado; }
            set
            {
                st_protestado = value;
                st_protestadobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_protestadobool;
        public bool St_protestadobool
        {
            get { return st_protestadobool; }
            set
            {
                st_protestadobool = value;
                st_protestado = value ? "S" : "N";
            }
        }
        public string DS_Instrucoes
        { get; set; }
        public string Tp_layoutbloqueto
        { get; set; }
        public decimal Qt_atualizatitulo
        { get; set; }
        public string Cd_integracao { get; set; }
        private string st_baixadointegracao;
        public string St_baixadointegracao
        {
            get { return st_baixadointegracao; }
            set
            {
                st_baixadointegracao = value;
                st_baixadointegracaobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_baixadointegracaobool;
        public bool St_baixadointegracaobool
        {
            get { return st_baixadointegracaobool; }
            set
            {
                st_baixadointegracaobool = value;
                st_baixadointegracao = value ? "S" : "N";
            }
        }
        public bool St_processar { get; set; }

        public string Email { get; set; }
        public List<string> Anexos { get; set; }


        public blTitulo()
        {
            Nome_banco = string.Empty;
            aceite_documento = TAceiteDocumento.adNao;
            Carteira = string.Empty;
            Modalidade = string.Empty;
            Ano = string.Empty;
            Tp_cobranca = string.Empty;
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            Cd_portador = string.Empty;
            Cd_empresa = string.Empty;
            Cd_sacado = string.Empty;
            Cd_parcela = null;
            Cedente = new blCedente();
            dt_baixa = null;
            dt_baixastring = string.Empty;
            dt_credito = null;
            dt_creditostring = string.Empty;
            dt_creditotaxa = null;
            dt_creditotaxastr = string.Empty;
            dt_documento = null;
            dt_documentostring = string.Empty;
            dt_emissaobloqueto = null;
            dt_emissaobloquetostring = string.Empty;
            dt_ocorrencia = null;
            dt_protesto = null;
            dt_protestostring = string.Empty;
            dt_vencimento = null;
            dt_vencimentostring = string.Empty;
            especie_documento = TEspecieDocumento.edFatura;
            Id_cobranca = null;
            Id_config = null;
            Instrucoes = string.Empty;
            DS_Instrucoes = string.Empty;
            Local_pagamento = string.Empty;
            Nosso_numero = string.Empty;
            Nr_lancto = null;
            NumeroDocumento = string.Empty;
            Sacado = new blPessoa();
            st_registro = "A";
            status_registro = "ABERTO";
            Vl_abatimento = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_despesa_cobranca = decimal.Zero;
            Vl_nominal = decimal.Zero;
            Vl_documento = decimal.Zero;
            Vl_multacalc = decimal.Zero;
            Vl_jurocalc = decimal.Zero;
            Vl_iof = decimal.Zero;
            Vl_morajuros = decimal.Zero;
            Vl_outras_despesas = decimal.Zero;
            vl_outros_creditos = decimal.Zero;
            Logo_banco = null;
            Pc_jurodia = decimal.Zero;
            Tp_jurodia = string.Empty;
            Pc_desconto = decimal.Zero;
            Tp_desconto = string.Empty;
            Nr_diasdesconto = decimal.Zero;
            Pc_multa = decimal.Zero;
            Tp_multa = string.Empty;
            Nr_diasmulta = decimal.Zero;
            St_descontar = false;

            Cd_bancocorrespondente = string.Empty;
            Ds_bancocorrespondente = string.Empty;
            Conveniocobranca = string.Empty;
            Nr_agenciacorrespondente = string.Empty;
            Nr_contacorrespondente = string.Empty;
            Carteiracorrespondente = string.Empty;
            St_protestarauto = false;
            Nr_diasprotestar = decimal.Zero;
            Avalista = new blPessoa();
            EndAvalista = new blEndereco();
            Status_remessa = string.Empty;
            Ds_motivo = string.Empty;
            Cd_ocorrencia = string.Empty;
            Ds_ocorrencia = string.Empty;
            Ds_motivoocorrencia = string.Empty;
            Ds_observacao = string.Empty;
            st_protestado = "N";
            st_protestadobool = false;
            Qt_atualizatitulo = decimal.Zero;
            St_processar = false;
        }

        //Retornar vetor de byte da imagem
        public byte[] getImagem()
        {
            if (CodigoBarras.Imagem != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    CodigoBarras.Imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            else
                return null;
        }
        //Preencher objeto boleto para ser impresso
        public TBloqueto PreencherBloqueto()
        {
            TBloqueto bloqueto = new TBloqueto();
            bloqueto.Aceite_SN = Aceite_SN;
            bloqueto.Ano = Ano;
            bloqueto.Bairro_Sacado = Bairro_sacado;
            bloqueto.Carteira = Carteira;
            bloqueto.Modalidade = Modalidade;
            bloqueto.Tp_cobranca = Tp_cobranca;
            bloqueto.Cd_banco = Cd_banco;
            bloqueto.Cep_Sacado = Cep_sacado;
            bloqueto.Cidade_Sacado = Cidade_sacado;
            bloqueto.Complemento_Sacado = Complemento_sacado;
            bloqueto.Cpf_Cnpj_sacado = cpf_cnpj_sacado;
            bloqueto.Digito_banco = Digito_Banco;
            bloqueto.DS_Endereco_Sacado = Ds_endereco_sacado;
            bloqueto.Instrucoes = Instrucoes;
            bloqueto.LinhaDigitavel = LinhaDigitavel;
            bloqueto.Local_pagamento = Local_pagamento;
            bloqueto.Nm_Cedente = Nm_cedente;
            bloqueto.Nm_sacado = Nm_sacado;
            bloqueto.Nosso_numero = Nosso_numero;
            bloqueto.Digito_nossonumero = Digito_nossonumero;
            bloqueto.Numero_Sacado = Numero_sacado;
            bloqueto.Numerodocumento = NumeroDocumento;
            bloqueto.Uf_Sacado = Uf_sacado;
            bloqueto.Vl_nominal = Vl_nominal;
            bloqueto.Vl_documento = Vl_documento;
            bloqueto.Vl_multacalc = Vl_multacalc;
            bloqueto.Vl_jurocalc = Vl_jurocalc;
            bloqueto.Agencia = Cedente.ContaBancaria.CodigoAgencia;
            if (Cedente.ContaBancaria.Banco.Codigo.Trim().Equals("237"))
                bloqueto.Agencia = bloqueto.Agencia.Trim() + "-" + Utils.Estruturas.Mod11(bloqueto.Agencia.Trim(), 9, false, 0).ToString().Trim();
            bloqueto.Codigocedente = Cedente.CodigoCedente;
            bloqueto.Digitocedente = Cedente.DigitoCodigoCedente;
            bloqueto.Posto_cedente = Cedente.Postocedente;
            bloqueto.imagem = getImagem();
            bloqueto.Dt_vencimento = dt_vencimento.Value;
            bloqueto.Dt_documento = dt_emissaobloqueto.Value;
            bloqueto.Especiedocumento = RetornarCodigoEspecieDocumento().ToString();
            bloqueto.Logo_banco = Logo_banco;
            bloqueto.Tp_layoutbloqueto = Tp_layoutbloqueto;
            bloqueto.Qt_atualizatitulo = Qt_atualizatitulo;
            return bloqueto;
        }
        //Calcula o digito do nosso numero, conforme criterios definidos por cada banco
        private string CalcularDigitoNossoNumero()
        {
            string nm_classe = "CamadaDados.Financeiro.Bloqueto.blBanco" + Cedente.ContaBancaria.Banco.Codigo.Trim().PadLeft(3, '0');
            Type t = Type.GetType(nm_classe);
            object obj = t.Assembly.CreateInstance(nm_classe);
            MethodInfo m = t.GetMethod("CalcularDigitoNossoNumero");
            return m.Invoke(obj, new object[] { this }).ToString();
        }
        //Retorna um objeto do Codigo de Barras contendo linha digitavel e imagem do codigo de barras
        //baseado nos dados do titulo
        private blCobCodBarr GerarCodigoBarras()
        {
            #region Primeira parte do codigo de barras
            //Codigo moeda
            const string scd_moeda = "9";
            //Codigo do banco
            string scd_banco = Estruturas.StrTam(string.IsNullOrEmpty(Cd_bancocorrespondente) ? Cedente.ContaBancaria.Banco.Codigo.Trim() : Cd_bancocorrespondente, "0", false, 3);
            //Fator de vencimento
            string sfator_vencimento = Estruturas.StrTam(Estruturas.CalcFatorVencto(Convert.ToDateTime(Dt_vencimento)).ToString().Trim(), "0", false, 4);
            //Valor do documento
            string svl_documento = Vl_atual.ToString("N2", new System.Globalization.CultureInfo("pt-BR")).SoNumero().FormatStringEsquerda(10, '0');
            #endregion

            //Segunda parte do codigo de barras
            string nm_classe = string.Empty;
            if (string.IsNullOrEmpty(Cd_bancocorrespondente) ?
                Cedente.ContaBancaria.Banco.Codigo.Trim().Length.Equals(4) :
                Cd_bancocorrespondente.Trim().Length.Equals(4))
                nm_classe = "CamadaDados.Financeiro.Bloqueto.blBanco" + (string.IsNullOrEmpty(Cd_bancocorrespondente) ?
                    Cedente.ContaBancaria.Banco.Codigo.Trim().Remove(0, 1) : Cd_bancocorrespondente.Trim().Remove(0, 1));
            else
                nm_classe = "CamadaDados.Financeiro.Bloqueto.blBanco" + (string.IsNullOrEmpty(Cd_bancocorrespondente) ?
                    Cedente.ContaBancaria.Banco.Codigo.Trim() : Cd_bancocorrespondente.Trim());
            Type t = Type.GetType(nm_classe);
            object obj = t.Assembly.CreateInstance(nm_classe);
            MethodInfo m = t.GetMethod("GetCampoLivreCodigoBarra");
            string scampo_livre = m.Invoke(obj, new object[] { this }).ToString();

            //Calcula o digito e completa o codigo de barras
            string scodigo_barras = string.Empty;
            if (scd_banco.Trim().Equals("756") && string.IsNullOrEmpty(Cd_bancocorrespondente))//Sicoob e nao tiver banco correspondente
                scodigo_barras = scd_banco.Trim() +
                                 scd_moeda.Trim() +
                                 sfator_vencimento.Trim() +
                                 svl_documento.Trim() +
                                 Carteira.Trim() +//Codigo da carteira
                                 Cedente.ContaBancaria.CodigoAgencia.Trim() +
                                 scampo_livre;
            else if (scd_banco.Trim().Equals("001") &&
                Cedente.CodigoCedente.Trim().Length.Equals(7) &&
                string.IsNullOrEmpty(Cd_bancocorrespondente))
                scodigo_barras = scd_banco.Trim() +
                                 scd_moeda.Trim() +
                                 sfator_vencimento.Trim() +
                                 svl_documento.Trim() +
                                 "000000" +
                                 scampo_livre.Trim();
            else
                scodigo_barras = scd_banco.Trim() +
                                 scd_moeda.Trim() +
                                 sfator_vencimento.Trim() +
                                 svl_documento.Trim() +
                                 scampo_livre;
            string sdigito_codigo_barras = Estruturas.Mod11(scodigo_barras, 9, false, 0).ToString().Trim();
            if (sdigito_codigo_barras.Trim().Equals("0"))
                sdigito_codigo_barras = "1";
            return new blCobCodBarr() { Codigo = scodigo_barras.Substring(0, 4) + sdigito_codigo_barras + scodigo_barras.Substring(4, scodigo_barras.Length - 4) };
        }
        public string CalcularNossoNumero(string vCd_banco,
                                          decimal vNossoNumero,
                                          string ConvenioCobranca,
                                          string pCodigoCendente,
                                          string pCarteira)
        {
            string nm_classe = string.Empty;
            if (vCd_banco.Trim().Length.Equals(4))
                nm_classe = "CamadaDados.Financeiro.Bloqueto.blBanco" + vCd_banco.Trim().Remove(0, 1);
            else
                nm_classe = "CamadaDados.Financeiro.Bloqueto.blBanco" + vCd_banco.Trim().PadLeft(3, '0');
            Type t = Type.GetType(nm_classe);
            object obj = t.Assembly.CreateInstance(nm_classe);
            MethodInfo m = t.GetMethod("CalcularNossoNumero");
            if (vCd_banco.Trim().Equals("001"))
                return m.Invoke(obj, new object[] { vNossoNumero, ConvenioCobranca, pCodigoCendente }).ToString();
            else if (vCd_banco.Trim().Equals("104"))
                return m.Invoke(obj, new object[] { pCarteira, vNossoNumero }).ToString();
            else if (vCd_banco.Trim().Equals("085"))
                return m.Invoke(obj, new object[] { vNossoNumero, ConvenioCobranca, pCodigoCendente }).ToString();
            else return m.Invoke(obj, new object[] { vNossoNumero }).ToString();
        }
        public int RetornarCodigoEspecieDocumento()
        {
            int retorno = 99;
            switch (especie_documento)
            {
                case TEspecieDocumento.edApoliceSeguro: retorno = 20; break;   //{AP  APÓLICE DE SEGURO}
                case TEspecieDocumento.edCheque: retorno = 1; break;   //{CH  CHEQUE}
                case TEspecieDocumento.edDuplicataMercantil: retorno = 2; break;   //{DM  DUPLICATA MERCANTIL}
                case TEspecieDocumento.edDuplicataMercantialIndicacao: retorno = 3; break;   //{DMI DUPLICATA MERCANTIL P/ INDICAÇÃO}
                case TEspecieDocumento.edDuplicataRural: retorno = 6; break;   //{DR  DUPLICATA RURAL}
                case TEspecieDocumento.edDuplicataServico: retorno = 4; break;   //{DS  DUPLICATA DE SERVIÇO}
                case TEspecieDocumento.edDuplicataServicoIndicacao: retorno = 5; break;   //{DSI DUPLICATA DE SERVIÇO P/ INDICAÇÃO}
                case TEspecieDocumento.edFatura: retorno = 18; break;   //{FAT FATURA}
                case TEspecieDocumento.edLetraCambio: retorno = 7; break;   //{LC  LETRA DE CÂMBIO}
                case TEspecieDocumento.edMensalidadeEscolar: retorno = 21; break;   //{ME  MENSALIDADE ESCOLAR}
                case TEspecieDocumento.edNotaCreditoComercial: retorno = 8; break;   //{NCC NOTA DE CRÉDITO COMERCIAL}
                case TEspecieDocumento.edNotaCreditoExportacao: retorno = 9; break;   //{NCE NOTA DE CRÉDITO A EXPORTAÇÃO}
                case TEspecieDocumento.edNotaCreditoIndustrial: retorno = 10; break;   //{NCI NOTA DE CRÉDITO INDUSTRIAL}
                case TEspecieDocumento.edNotaCreditoRural: retorno = 11; break;   //{NCR NOTA DE CRÉDITO RURAL}
                case TEspecieDocumento.edNotaDebito: retorno = 19; break;   //{ND  NOTA DE DÉBITO}
                case TEspecieDocumento.edNotaPromissoria: retorno = 12; break;   //{NP  NOTA PROMISSÓRIA}
                case TEspecieDocumento.edNotaPromissoriaRural: retorno = 14; break;   //{NPR NOTA PROMISSÓRIA RURAL}
                case TEspecieDocumento.edNotaSeguro: retorno = 16; break;   //{NS  NOTA DE SEGURO}
                case TEspecieDocumento.edParcelaConsorcio: retorno = 22; break;   //{PC  PARCELA DE CONSORCIO}
                case TEspecieDocumento.edRecibo: retorno = 17; break;   // {RC  RECIBO}
                case TEspecieDocumento.edTriplicataMercantil: retorno = 14; break;   //{TM  TRIPLICATA MERCANTIL}
                case TEspecieDocumento.edTriplicataServico: retorno = 15; break;   //{TS  TRIPLICATA DE SERVIÇO}
            }
            return retorno;
        }
        public static TEspecieDocumento RetornarEspecieDocumento(int vCd_especiedoc)
        {
            TEspecieDocumento retorno = TEspecieDocumento.edOutros;
            switch (vCd_especiedoc)
            {
                case 20: retorno = TEspecieDocumento.edApoliceSeguro; break;   //{AP  APÓLICE DE SEGURO}
                case 1: retorno = TEspecieDocumento.edCheque; break;   //{CH  CHEQUE}
                case 2: retorno = TEspecieDocumento.edDuplicataMercantil; break;   //{DM  DUPLICATA MERCANTIL}
                case 3: retorno = TEspecieDocumento.edDuplicataMercantialIndicacao; break;   //{DMI DUPLICATA MERCANTIL P/ INDICAÇÃO}
                case 6: retorno = TEspecieDocumento.edDuplicataRural; break;   //{DR  DUPLICATA RURAL}
                case 4: retorno = TEspecieDocumento.edDuplicataServico; break;   //{DS  DUPLICATA DE SERVIÇO}
                case 5: retorno = TEspecieDocumento.edDuplicataServicoIndicacao; break;   //{DSI DUPLICATA DE SERVIÇO P/ INDICAÇÃO}
                case 18: retorno = TEspecieDocumento.edFatura; break;   //{FAT FATURA}
                case 7: retorno = TEspecieDocumento.edLetraCambio; break;   //{LC  LETRA DE CÂMBIO}
                case 21: retorno = TEspecieDocumento.edMensalidadeEscolar; break;   //{ME  MENSALIDADE ESCOLAR}
                case 8: retorno = TEspecieDocumento.edNotaCreditoComercial; break;   //{NCC NOTA DE CRÉDITO COMERCIAL}
                case 9: retorno = TEspecieDocumento.edNotaCreditoExportacao; break;   //{NCE NOTA DE CRÉDITO A EXPORTAÇÃO}
                case 10: retorno = TEspecieDocumento.edNotaCreditoIndustrial; break;   //{NCI NOTA DE CRÉDITO INDUSTRIAL}
                case 11: retorno = TEspecieDocumento.edNotaCreditoRural; break;   //{NCR NOTA DE CRÉDITO RURAL}
                case 19: retorno = TEspecieDocumento.edNotaDebito; break;   //{ND  NOTA DE DÉBITO}
                case 12: retorno = TEspecieDocumento.edNotaPromissoria; break;   //{NP  NOTA PROMISSÓRIA}
                case 13: retorno = TEspecieDocumento.edNotaPromissoriaRural; break;   //{NPR NOTA PROMISSÓRIA RURAL}
                case 16: retorno = TEspecieDocumento.edNotaSeguro; break;   //{NS  NOTA DE SEGURO}
                case 22: retorno = TEspecieDocumento.edParcelaConsorcio; break;   //{PC  PARCELA DE CONSORCIO}
                case 17: retorno = TEspecieDocumento.edRecibo; break;   // {RC  RECIBO}
                case 14: retorno = TEspecieDocumento.edTriplicataMercantil; break;   //{TM  TRIPLICATA MERCANTIL}
                case 15: retorno = TEspecieDocumento.edTriplicataServico; break;   //{TS  TRIPLICATA DE SERVIÇO}
            }
            return retorno;
        }
    }

    public class TCD_Titulo : TDataQuery
    {
        public TCD_Titulo()
        { }

        public TCD_Titulo(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.cd_empresa, a.nr_lancto, a.cd_parcela, a.id_cobranca, a.id_config, c.cd_clifor as cd_sacado, ");
                sql.AppendLine("f.cd_contager, d.ds_contager, d.cd_banco, e.ds_banco, d.nr_agencia, d.digitoagencia, isnull(a.st_registro, 'A') as st_registro, ");
                sql.AppendLine("d.nr_contacorrente, d.digitoconta, a.nossonumero, a.aceite_sn, a.especiedocumento, f.cd_portador, a.Cd_Integracao, ");
                sql.AppendLine("a.dt_ocorrencia, a.dt_credito, a.dt_creditotaxa, f.ano, a.vl_multacalc, a.vl_jurocalc, a.qt_atualizatitulo, a.ST_BaixadoIntegracao, ");
                sql.AppendLine("f.pc_jurodia, f.tp_jurodia, f.pc_desconto, f.tp_desconto, f.nr_diasdesconto, f.pc_multa, f.tp_multa, f.nr_diasmulta, a.st_protestado, ");
                sql.AppendLine("a.dt_protesto, a.dt_baixa, c.nr_docto, f.postocedente, f.ds_instrucoes as instrucoes, ");
                sql.AppendLine("a.vl_despesacobranca, a.vl_abatimento, a.vl_desconto, a.vl_morajuros, f.tp_cobranca, ");
                sql.AppendLine("a.vl_iof, a.vl_outrasdespesas, a.vl_outroscreditos, a.ds_instrucoes, f.logo_banco, f.TP_LayoutBloqueto, ");
                sql.AppendLine("a.dt_emissaobloqueto, f.codigocedente, f.digitocedente, f.ds_localpagamento, f.tp_carteira, f.modalidade, ");
                sql.AppendLine("f.postocedente, b.dt_vencto, c.dt_emissao, c.ds_observacao, ");
                sql.AppendLine("status_remessa = (select top 1 x.st_loteremessa ");
                sql.AppendLine("                    from tb_cob_loteremessa_x_titulo x ");
                sql.AppendLine("                    inner join tb_cob_loteremessa y ");
                sql.AppendLine("                    on x.id_lote = y.id_lote ");
                sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                    and x.nr_lancto = a.nr_lancto ");
                sql.AppendLine("                    and x.cd_parcela = a.cd_parcela ");
                sql.AppendLine("                    and x.id_cobranca = a.id_cobranca ");
                sql.AppendLine("                    and y.tp_instrucao = 'RT' ");//Registrar titulo
                sql.AppendLine("                    and isnull(y.st_registro, 'A') = 'P' ");//Processado
                sql.AppendLine("                    order by y.dt_lote desc), ");
                sql.AppendLine("ds_motivo = (select top 1 x.ds_motivo ");
                sql.AppendLine("                    from tb_cob_loteremessa_x_titulo x ");
                sql.AppendLine("                    inner join tb_cob_loteremessa y ");
                sql.AppendLine("                    on x.id_lote = y.id_lote ");
                sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                    and x.nr_lancto = a.nr_lancto ");
                sql.AppendLine("                    and x.cd_parcela = a.cd_parcela ");
                sql.AppendLine("                    and x.id_cobranca = a.id_cobranca ");
                sql.AppendLine("                    and y.tp_instrucao = 'RT' ");//Registrar titulo
                sql.AppendLine("                    and isnull(y.st_registro, 'A') = 'P' ");//Processado
                sql.AppendLine("                    order by y.dt_lote desc), ");
                //Dados correspondente
                sql.AppendLine("f.cd_bancocorrespondente, bd.ds_banco as ds_bancocorrespondente, f.st_protestoauto, f.nr_diasprotesto, ");
                sql.AppendLine("f.conveniocobranca, f.nr_agenciacorrespondente, f.nr_contacorrespondente, f.carteiracorrespondente, ");
                //Valor do documento
                sql.AppendLine("vl_documento = DBO.F_CALC_VL_DUP_MOEDAPADRAO(a.CD_Empresa, a.NR_Lancto, a.CD_Parcela, 'S', getDate(), ");
                sql.AppendLine("((isnull(b.vl_parcela_padrao, 0) - (select isNull(sum(isNull(x.vl_liquidacao_padrao, 0)),0) ");
                sql.AppendLine("                                   from tb_fin_liquidacao x ");
                sql.AppendLine("                                   where x.cd_empresa = b.cd_empresa ");
                sql.AppendLine("                                   and x.nr_lancto = b.nr_lancto ");
                sql.AppendLine("                                   and x.cd_parcela = b.cd_parcela ");
                sql.AppendLine("                                   and x.st_registro <> 'C' )))), b.vl_parcela as vl_nominal, ");
                //Valor Recebido
                sql.AppendLine("Vl_recebido = isnull((select sum(isnull(x.vl_liquidacao, 0) + isnull(x.vl_juroacrescimo, 0) - isnull(x.vl_descontobonus, 0)) ");
                sql.AppendLine("						from tb_fin_liquidacao x ");
                sql.AppendLine("						where isnull(x.st_registro, 'A') <> 'C' ");
                sql.AppendLine("						and x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("						and x.nr_lancto = a.nr_lancto ");
                sql.AppendLine("						and x.cd_parcela = a.cd_parcela), 0), ");
                //Dados do sacado
                sql.AppendLine("sacado.tp_pessoa as tp_pessoa_sacado, sacado.nm_clifor as nm_clifor_sacado, ");
                sql.AppendLine("case when sacado.tp_pessoa = 'J' then sacado.nr_cgc else sacado.nr_cpf end as nr_cgc_cpf_sacado, ");
                sql.AppendLine("endsacado.ds_endereco as ds_endsacado, endsacado.numero as numero_sacado, ");
                sql.AppendLine("endsacado.ds_complemento as ds_complemento_sacado, endsacado.bairro as bairro_sacado, ");
                sql.AppendLine("endsacado.ds_cidade as ds_cidade_sacado, endsacado.uf as uf_sacado, endsacado.cep as cep_sacado, ");
                //Dados do Avalista
                sql.AppendLine("avalista.tp_pessoa as tp_pessoa_avalista, avalista.nm_clifor as nm_clifor_avalista, ");
                sql.AppendLine("case when avalista.tp_pessoa = 'J' then avalista.nr_cgc else avalista.nr_cpf end as nr_cgc_cpf_avalista, ");
                sql.AppendLine("endavalista.ds_endereco as ds_endavalista, endavalista.numero as numero_avalista, ");
                sql.AppendLine("endavalista.ds_complemento as ds_complemento_avalista, endavalista.bairro as bairro_avalista, ");
                sql.AppendLine("endavalista.ds_cidade as ds_cidade_avalista, endavalista.uf as uf_avalista, endavalista.cep as cep_avalista, ");
                //Dados do Cedente
                sql.AppendLine("cedente.tp_pessoa as tp_pessoa_cedente, cedente.nm_clifor as nm_clifor_cedente, ");
                sql.AppendLine("case when cedente.tp_pessoa = 'J' then cedente.nr_cgc else cedente.nr_cpf end as nr_cgc_cpf_cedente, ");
                sql.AppendLine("endcedente.ds_endereco as ds_endereco_cedente, endcedente.numero as numero_cedente, ");
                sql.AppendLine("endcedente.ds_complemento as ds_complemento_cedente, endcedente.bairro as bairro_cedente, ");
                sql.AppendLine("endcedente.ds_cidade as ds_cidade_cedente, endcedente.uf as uf_cedente, endcedente.cep as cep_cedente ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");
            sql.AppendLine("from tb_cob_titulo a  ");
            //Parcela
            sql.AppendLine("inner join tb_fin_parcela b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = b.nr_lancto ");
            sql.AppendLine("and a.cd_parcela = b.cd_parcela ");
            //Duplicata
            sql.AppendLine("inner join tb_fin_duplicata c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = c.nr_lancto ");
            //Configuração Boleto
            sql.AppendLine("inner join tb_cob_cfgbanco f ");
            sql.AppendLine("on a.id_config = f.id_config ");
            //Dados Conta Gerencial
            sql.AppendLine("inner join tb_fin_contager d ");
            sql.AppendLine("on f.cd_contager = d.cd_contager ");
            //Dados Banco
            sql.AppendLine("inner join tb_fin_banco e ");
            sql.AppendLine("on d.cd_banco = e.cd_banco ");
            //Cliente Sacado
            sql.AppendLine("inner join vtb_fin_clifor sacado ");
            sql.AppendLine("on c.cd_clifor = sacado.cd_clifor ");
            //Endereco Sacado
            sql.AppendLine("inner join vtb_fin_endereco endsacado ");
            sql.AppendLine("on c.cd_clifor = endsacado.cd_clifor ");
            sql.AppendLine("and c.cd_endereco = endsacado.cd_endereco ");
            //Empresa Cedente
            sql.AppendLine("inner join tb_div_empresa empcedente ");
            sql.AppendLine("on f.cd_empresa = empcedente.cd_empresa ");
            //Cliente Cedente
            sql.AppendLine("inner join vtb_fin_clifor cedente ");
            sql.AppendLine("on empcedente.cd_clifor = cedente.cd_clifor ");
            //Enderco Cedente
            sql.AppendLine("inner join vtb_fin_endereco endcedente ");
            sql.AppendLine("on empcedente.cd_clifor = endcedente.cd_clifor ");
            sql.AppendLine("and empcedente.cd_endereco = endcedente.cd_endereco ");
            //Banco Correspondente
            sql.AppendLine("left outer join tb_fin_banco bd ");
            sql.AppendLine("on f.cd_bancocorrespondente = bd.cd_banco ");
            //Cliente Avalista
            sql.AppendLine("left outer join vtb_fin_clifor avalista ");
            sql.AppendLine("on c.cd_avalista = avalista.cd_clifor ");
            //Endereco Avalista
            sql.AppendLine("left outer join vtb_fin_endereco endavalista ");
            sql.AppendLine("on c.cd_avalista = endavalista.cd_clifor ");
            sql.AppendLine("and c.cd_endavalista = endavalista.cd_endereco ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public blListaTitulo Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            blListaTitulo lista = new blListaTitulo();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                blPessoa sacado = null;
                blEndereco endSacado = null;
                blPessoa avalista = null;
                blEndereco endAvalista = null;
                blCedente cedente = null;
                blEndereco endCedente = null;
                blContaBancaria dbCedente = null;
                blBanco banco = null;
                while (reader.Read())
                {
                    blTitulo reg = new blTitulo();
                    //Dados do titulo
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Sacado")))
                        reg.Cd_sacado = reader.GetString(reader.GetOrdinal("CD_Sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Cobranca"))))
                        reg.Id_cobranca = reader.GetDecimal(reader.GetOrdinal("ID_Cobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("ID_Config"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ContaGer"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGer")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NossoNumero"))))
                        reg.Nosso_numero = reader.GetString(reader.GetOrdinal("NossoNumero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Docto")))
                        reg.NumeroDocumento = reader.GetString(reader.GetOrdinal("NR_Docto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Aceite_SN"))))
                        reg.Aceite_documento = reader.GetString(reader.GetOrdinal("Aceite_SN")).Trim().ToUpper().Equals("S") ? TAceiteDocumento.adSim : TAceiteDocumento.adNao;
                    if (!reader.IsDBNull(reader.GetOrdinal("Ano")))
                        reg.Ano = reader.GetString(reader.GetOrdinal("ano"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("EspecieDocumento"))))
                        reg.Especie_documento = blTitulo.RetornarEspecieDocumento(Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("EspecieDocumento"))));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Vencto")))
                        reg.Dt_vencimento = reader.GetDateTime(reader.GetOrdinal("DT_Vencto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Ocorrencia"))))
                        reg.Dt_ocorrencia = reader.GetDateTime(reader.GetOrdinal("DT_Ocorrencia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Credito"))))
                        reg.Dt_credito = reader.GetDateTime(reader.GetOrdinal("DT_Credito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_CreditoTaxa")))
                        reg.Dt_creditotaxa = reader.GetDateTime(reader.GetOrdinal("DT_CreditoTaxa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Protesto"))))
                        reg.Dt_protesto = reader.GetDateTime(reader.GetOrdinal("DT_Protesto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Baixa"))))
                        reg.Dt_baixa = reader.GetDateTime(reader.GetOrdinal("DT_Baixa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_DespesaCobranca"))))
                        reg.Vl_despesa_cobranca = reader.GetDecimal(reader.GetOrdinal("Vl_DespesaCobranca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Abatimento"))))
                        reg.Vl_abatimento = reader.GetDecimal(reader.GetOrdinal("Vl_Abatimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Desconto"))))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_MoraJuros"))))
                        reg.Vl_morajuros = reader.GetDecimal(reader.GetOrdinal("Vl_MoraJuros"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_IOF"))))
                        reg.Vl_iof = reader.GetDecimal(reader.GetOrdinal("Vl_IOF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_OutrasDespesas"))))
                        reg.Vl_outras_despesas = reader.GetDecimal(reader.GetOrdinal("Vl_OutrasDespesas"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_OutrosCreditos"))))
                        reg.vl_outros_creditos = reader.GetDecimal(reader.GetOrdinal("Vl_OutrosCreditos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_nominal")))
                        reg.Vl_nominal = reader.GetDecimal(reader.GetOrdinal("vl_nominal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_documento")))
                        reg.Vl_documento = reader.GetDecimal(reader.GetOrdinal("vl_documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_recebido")))
                        reg.Vl_recebido = reader.GetDecimal(reader.GetOrdinal("Vl_recebido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_multacalc")))
                        reg.Vl_multacalc = reader.GetDecimal(reader.GetOrdinal("vl_multacalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_jurocalc")))
                        reg.Vl_jurocalc = reader.GetDecimal(reader.GetOrdinal("vl_jurocalc"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Instrucoes"))))
                        reg.Instrucoes = reader.GetString(reader.GetOrdinal("DS_Instrucoes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("instrucoes")))
                        reg.DS_Instrucoes = reader.GetString(reader.GetOrdinal("instrucoes"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_EmissaoBloqueto"))))
                        reg.Dt_emissaobloqueto = reader.GetDateTime(reader.GetOrdinal("DT_EmissaoBloqueto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Carteira"))))
                        reg.Carteira = reader.GetString(reader.GetOrdinal("TP_Carteira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("modalidade")))
                        reg.Modalidade = reader.GetString(reader.GetOrdinal("modalidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_LocalPagamento"))))
                        reg.Local_pagamento = reader.GetString(reader.GetOrdinal("DS_LocalPagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Logo_banco")))
                        reg.Logo_banco = (byte[])reader.GetValue(reader.GetOrdinal("Logo_banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_LayoutBloqueto")))
                        reg.Tp_layoutbloqueto = reader.GetString(reader.GetOrdinal("TP_LayoutBloqueto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_cobranca")))
                        reg.Tp_cobranca = reader.GetString(reader.GetOrdinal("tp_cobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_jurodia")))
                        reg.Pc_jurodia = reader.GetDecimal(reader.GetOrdinal("pc_jurodia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_jurodia")))
                        reg.Tp_jurodia = reader.GetString(reader.GetOrdinal("tp_jurodia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_desconto")))
                        reg.Pc_desconto = reader.GetDecimal(reader.GetOrdinal("pc_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_desconto")))
                        reg.Tp_desconto = reader.GetString(reader.GetOrdinal("tp_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_diasdesconto")))
                        reg.Nr_diasdesconto = reader.GetDecimal(reader.GetOrdinal("nr_diasdesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_multa")))
                        reg.Pc_multa = reader.GetDecimal(reader.GetOrdinal("pc_multa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_multa")))
                        reg.Tp_multa = reader.GetString(reader.GetOrdinal("tp_multa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_diasmulta")))
                        reg.Nr_diasmulta = reader.GetDecimal(reader.GetOrdinal("nr_diasmulta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_bancocorrespondente")))
                        reg.Cd_bancocorrespondente = reader.GetString(reader.GetOrdinal("cd_bancocorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_bancocorrespondente")))
                        reg.Ds_bancocorrespondente = reader.GetString(reader.GetOrdinal("ds_bancocorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ConvenioCobranca")))
                        reg.Conveniocobranca = reader.GetString(reader.GetOrdinal("conveniocobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_agenciacorrespondente")))
                        reg.Nr_agenciacorrespondente = reader.GetString(reader.GetOrdinal("nr_agenciacorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contacorrespondente")))
                        reg.Nr_contacorrespondente = reader.GetString(reader.GetOrdinal("nr_contacorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("carteiracorrespondente")))
                        reg.Carteiracorrespondente = reader.GetString(reader.GetOrdinal("carteiracorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_banco")))
                        reg.Nome_banco = reader.GetString(reader.GetOrdinal("ds_banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_protestoauto")))
                        reg.St_protestarauto = reader.GetString(reader.GetOrdinal("st_protestoauto")).ToString().Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_diasprotesto")))
                        reg.Nr_diasprotestar = reader.GetDecimal(reader.GetOrdinal("nr_diasprotesto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("status_remessa")))
                        reg.Status_remessa = reader.GetString(reader.GetOrdinal("status_remessa")).Trim().ToUpper().Equals("A") ? "ACEITO" :
                            reader.GetString(reader.GetOrdinal("status_remessa")).Trim().ToUpper().Equals("R") ? "REJEITADO" : string.Empty;
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_motivo")))
                        reg.Ds_motivo = reader.GetString(reader.GetOrdinal("ds_motivo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_protestado")))
                        reg.St_protestado = reader.GetString(reader.GetOrdinal("st_protestado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_atualizatitulo")))
                        reg.Qt_atualizatitulo = reader.GetDecimal(reader.GetOrdinal("qt_atualizatitulo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Integracao")))
                        reg.Cd_integracao = reader.GetString(reader.GetOrdinal("Cd_Integracao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_BaixadoIntegracao")))
                        reg.St_baixadointegracao = reader.GetString(reader.GetOrdinal("ST_BaixadoIntegracao"));
                    //Dados do sacado
                    sacado = new blPessoa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_pessoa_sacado"))))
                        sacado.TipoInscricao = reader.GetString(reader.GetOrdinal("tp_pessoa_sacado")).Trim().ToUpper().Equals("J") ? TTipoInscricao.tiPessoaJuridica :
                            reader.GetString(reader.GetOrdinal("tp_pessoa_sacado")).Trim().ToUpper().Equals("F") ? TTipoInscricao.tiPessoaFisica :
                            TTipoInscricao.tiOutro;
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_clifor_sacado"))))
                        sacado.Nome = reader.GetString(reader.GetOrdinal("nm_clifor_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf_sacado"))))
                        sacado.NumeroCPFCNPJ = reader.GetString(reader.GetOrdinal("nr_cgc_cpf_sacado"));
                    //Endereco do Sacado
                    endSacado = new blEndereco();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endsacado")))
                        endSacado.Rua = reader.GetString(reader.GetOrdinal("ds_endsacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("numero_sacado"))))
                        endSacado.Numero = reader.GetString(reader.GetOrdinal("numero_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_complemento_sacado"))))
                        endSacado.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("bairro_sacado"))))
                        endSacado.Bairro = reader.GetString(reader.GetOrdinal("bairro_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_cidade_sacado"))))
                        endSacado.Cidade = reader.GetString(reader.GetOrdinal("ds_cidade_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("uf_sacado"))))
                        endSacado.Estado = reader.GetString(reader.GetOrdinal("uf_sacado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cep_sacado"))))
                        endSacado.CEP = reader.GetString(reader.GetOrdinal("cep_sacado"));
                    sacado.Endereco = endSacado;
                    reg.Sacado = sacado;
                    //Dados Avalista
                    avalista = new blPessoa();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa_avalista")))
                        avalista.TipoInscricao = reader.GetString(reader.GetOrdinal("tp_pessoa_avalista")).Trim().ToUpper().Equals("J") ? TTipoInscricao.tiPessoaJuridica :
                            reader.GetString(reader.GetOrdinal("tp_pessoa_avalista")).Trim().ToUpper().Equals("F") ? TTipoInscricao.tiPessoaFisica : TTipoInscricao.tiOutro;
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor_avalista")))
                        avalista.Nome = reader.GetString(reader.GetOrdinal("nm_clifor_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf_avalista")))
                        avalista.NumeroCPFCNPJ = reader.GetString(reader.GetOrdinal("nr_cgc_cpf_avalista"));
                    reg.Avalista = avalista;
                    //Endereco Avalista
                    endAvalista = new blEndereco();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endavalista")))
                        endAvalista.Rua = reader.GetString(reader.GetOrdinal("ds_endavalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero_avalista")))
                        endAvalista.Numero = reader.GetString(reader.GetOrdinal("numero_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento_avalista")))
                        endAvalista.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro_avalista")))
                        endAvalista.Bairro = reader.GetString(reader.GetOrdinal("bairro_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade_avalista")))
                        endAvalista.Cidade = reader.GetString(reader.GetOrdinal("ds_cidade_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_avalista")))
                        endAvalista.Estado = reader.GetString(reader.GetOrdinal("uf_avalista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep_avalista")))
                        endAvalista.CEP = reader.GetString(reader.GetOrdinal("cep_avalista"));
                    reg.EndAvalista = endAvalista;
                    //Dados do Cedente
                    cedente = new blCedente();
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_pessoa_cedente"))))
                        cedente.TipoInscricao = reader.GetString(reader.GetOrdinal("tp_pessoa_cedente")).Trim().ToUpper().Equals("J") ? TTipoInscricao.tiPessoaJuridica :
                            reader.GetString(reader.GetOrdinal("tp_pessoa_cedente")).Trim().ToUpper().Equals("F") ? TTipoInscricao.tiPessoaFisica : TTipoInscricao.tiOutro;
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_clifor_cedente"))))
                        cedente.Nome = reader.GetString(reader.GetOrdinal("nm_clifor_cedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf_cedente"))))
                        cedente.NumeroCPFCNPJ = reader.GetString(reader.GetOrdinal("nr_cgc_cpf_cedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CodigoCedente")))
                        cedente.CodigoCedente = reader.GetString(reader.GetOrdinal("CodigoCedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigitoCedente")))
                        cedente.DigitoCodigoCedente = reader.GetString(reader.GetOrdinal("DigitoCedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("postocedente")))
                        cedente.Postocedente = reader.GetString(reader.GetOrdinal("postocedente"));
                    //Endereco do Cedente
                    endCedente = new blEndereco();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_endereco_cedente"))))
                        endCedente.Rua = reader.GetString(reader.GetOrdinal("ds_endereco_cedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("numero_cedente"))))
                        endCedente.Numero = reader.GetString(reader.GetOrdinal("numero_cedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_complemento_cedente"))))
                        endCedente.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento_cedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("bairro_cedente"))))
                        endCedente.Bairro = reader.GetString(reader.GetOrdinal("bairro_cedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_cidade_cedente"))))
                        endCedente.Cidade = reader.GetString(reader.GetOrdinal("ds_cidade_cedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_cedente")))
                        endCedente.Estado = reader.GetString(reader.GetOrdinal("uf_cedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep_cedente")))
                        endCedente.CEP = reader.GetString(reader.GetOrdinal("cep_cedente"));
                    cedente.Endereco = endCedente;
                    //Dados Bancarios Cedente
                    dbCedente = new blContaBancaria();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Agencia")))
                        dbCedente.CodigoAgencia = reader.GetString(reader.GetOrdinal("NR_Agencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigitoAgencia")))
                        dbCedente.DigitoAgencia = reader.GetString(reader.GetOrdinal("DigitoAgencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_ContaCorrente")))
                        dbCedente.NumeroConta = reader.GetString(reader.GetOrdinal("NR_ContaCorrente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigitoConta")))
                        dbCedente.DigitoConta = reader.GetString(reader.GetOrdinal("DigitoConta"));
                    //Dados do Banco
                    banco = new blBanco();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        banco.Codigo = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    dbCedente.Banco = banco;
                    cedente.ContaBancaria = dbCedente;
                    reg.Cedente = cedente;

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(blTitulo val)
        {
            Hashtable hs = new Hashtable(30);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_COBRANCA", val.Id_cobranca);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_NOSSONUMERO", val.Nosso_numero);
            hs.Add("@P_ACEITE_SN", val.Aceite_documento == TAceiteDocumento.adSim ? "S" : "N");
            hs.Add("@P_ESPECIEDOCUMENTO", val.RetornarCodigoEspecieDocumento());
            hs.Add("@P_DT_OCORRENCIA", val.Dt_ocorrencia);
            hs.Add("@P_DT_CREDITO", val.Dt_credito);
            hs.Add("@P_DT_CREDITOTAXA", val.Dt_creditotaxa);
            hs.Add("@P_DT_PROTESTO", val.Dt_protesto);
            hs.Add("@P_DT_BAIXA", val.Dt_baixa);
            hs.Add("@P_VL_DESPESACOBRANCA", val.Vl_despesa_cobranca);
            hs.Add("@P_VL_ABATIMENTO", val.Vl_abatimento);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);
            hs.Add("@P_VL_MORAJUROS", val.Vl_morajuros);
            hs.Add("@P_VL_IOF", val.Vl_iof);
            hs.Add("@P_VL_OUTRASDESPESAS", val.Vl_outras_despesas);
            hs.Add("@P_VL_OUTROSCREDITOS", val.vl_outros_creditos);
            hs.Add("@P_DS_INSTRUCOES", val.Instrucoes);
            hs.Add("@P_DT_EMISSAOBLOQUETO", val.Dt_emissaobloqueto);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_TP_COBRANCA", val.Tp_cobranca);
            hs.Add("@P_ST_PROTESTADO", val.St_protestado);
            hs.Add("@P_VL_MULTACALC", val.Vl_multacalc);
            hs.Add("@P_VL_JUROCALC", val.Vl_jurocalc);
            hs.Add("@P_QT_ATUALIZATITULO", val.Qt_atualizatitulo);
            hs.Add("@P_CD_INTEGRACAO", val.Cd_integracao);
            hs.Add("@P_ST_BAIXADOINTEGRACAO", val.St_baixadointegracao);

            return executarProc("IA_COB_TITULO", hs);
        }

        public string Excluir(blTitulo val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_COBRANCA", val.Id_cobranca);

            return executarProc("EXCLUI_COB_TITULO", hs);
        }
    }
    #endregion

    public class blCobranca
    {
        public string NomeArquivo
        {
            get;
            set;
        }
        public decimal SequencialArq
        { get; set; }
        public DateTime DataArquivo
        { get; set; }
        public TLayoutArquivo LayoutArquivo
        {
            get;
            set;
        }
        public TTipoMovimento TipoMovimento
        {
            get;
            set;
        }
        public string Cd_bancocorrespondente { get; set; } = string.Empty;
        public decimal Cd_instrucao
        { get; set; }
        public blListaTitulo Titulos
        {
            get;
            set;
        }
        public blCobranca()
        {
            NomeArquivo = string.Empty;
            SequencialArq = decimal.Zero;
            DataArquivo = DateTime.Now;
            LayoutArquivo = TLayoutArquivo.laOutro;
            TipoMovimento = TTipoMovimento.tmOutro;
            Cd_instrucao = 1;
            Titulos = new blListaTitulo();
        }
        public static decimal TratarInstrucaoRemessa(string banco, string instrucao)
        {
            if (banco.Trim().PadLeft(3, '0').Length != 3)
                throw new Exception("Código do banco deve possuir 3 caracteres!");
            string nm_classe = "CamadaDados.Financeiro.Bloqueto.blBanco" + banco.Trim().PadLeft(3, '0');
            Type t = Type.GetType(nm_classe);
            object obj = t.Assembly.CreateInstance(nm_classe);
            MethodInfo m = t.GetMethod("TratarInstrucaoRemessa");
            return decimal.Parse(m.Invoke(obj, new object[] { instrucao }).ToString());
        }
        public bool GerarRemessa(string vCd_banco,
                                 string Path_remessa)
        {
            if (Titulos.Count > 0)
            {
                if (Titulos.Exists(p => string.IsNullOrEmpty(p.Sacado.Endereco.CEP.SoNumero())))
                    throw new Exception("Não é permitido gerar REMESSA para BOLETO com sacado sem CEP.");
                if ((TipoMovimento != TTipoMovimento.tmRemessa))
                    TipoMovimento = TTipoMovimento.tmRemessa;

                if (!string.IsNullOrEmpty(vCd_banco))
                {
                    string nm_classe = "CamadaDados.Financeiro.Bloqueto.blBanco" + vCd_banco.Trim();
                    try
                    {
                        Type t = Type.GetType(nm_classe);
                        object obj = t.Assembly.CreateInstance(nm_classe);
                        MethodInfo m = t.GetMethod("GerarRemessa");
                        m.Invoke(obj, new object[] { this, Path_remessa });
                        return true;
                    }
                    catch (Exception ex)
                    { throw new Exception("Erro gerar arquivo remessa: " + ex.Message); }
                }
                else
                    throw new Exception("Codigo do banco nao informado!");
            }
            else
                throw new Exception("Não há titulos para gerar Remessa!");
        }
        public blListaTitulo LerRetorno(string path_retorno,
                                        string vCd_banco,
                                        string vCd_bancocorrespondente,
                                        string[] files)
        {
            blCobranca cob = new blCobranca();
            cob.Cd_bancocorrespondente = vCd_bancocorrespondente;
            for (int i = 0; i < files.Length; i++)
            {
                if (path_retorno.Trim().Substring(path_retorno.Trim().Length - 1, 1) != Path.DirectorySeparatorChar.ToString())
                    path_retorno += Path.DirectorySeparatorChar.ToString();
                if (File.Exists(path_retorno.Trim() + files[i].Trim()))
                {
                    string[] linha = new string[0];
                    using (StreamReader sr = new StreamReader(path_retorno.Trim() + files[i].Trim()))
                    {
                        while (!sr.EndOfStream)
                        {
                            Array.Resize(ref linha, linha.Length + 1);
                            linha[linha.Length - 1] = sr.ReadLine();
                        }
                        sr.Close();
                    }
                    if (linha.Length < 3)
                        return null;
                    switch (linha[0].ToString().Length)
                    {
                        case 240:
                            {
                                cob.LayoutArquivo = TLayoutArquivo.laCNAB240;
                                break;
                            }
                        case 400:
                            {
                                cob.LayoutArquivo = TLayoutArquivo.laCNAB400;
                                break;
                            }
                        default:
                            {
                                cob.LayoutArquivo = TLayoutArquivo.laOutro;
                                throw new Exception(files[i].Trim() + " não é um arquivo de retorno de cobrança com layout CNAB240 ou CNAB400");
                            }
                    }
                    //Chamar procedimento para ler retorno de acordo com o banco
                    string nm_classe = "CamadaDados.Financeiro.Bloqueto.blBanco" + vCd_banco.Trim();
                    try
                    {
                        Type t = Type.GetType(nm_classe);
                        object obj = t.Assembly.CreateInstance(nm_classe);
                        MethodInfo m = t.GetMethod("LerRetorno");
                        m.Invoke(obj, new object[] { cob, linha });
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            return cob.Titulos;
        }
    }
}
