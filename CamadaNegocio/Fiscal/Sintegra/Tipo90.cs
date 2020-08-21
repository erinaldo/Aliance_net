using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaNegocio.Fiscal.Sintegra
{
    public class Tipo90
    {
        public string Tipo
        {
            get
            {
                return "90";
            }
        }
        public string Cnpj
        { get; set; }
        private string insc_estadual;
        public string Insc_estadual
        {
            get
            {
                if (insc_estadual.Trim().ToUpper() != "ISENTO")
                    return insc_estadual.Trim().SoNumero();
                else
                    return insc_estadual;
            }
            set
            {
                insc_estadual = value;
            }
        }
        public int Count50
        { get; set; }
        public int Count51
        { get; set; }
        public int Count53
        { get; set; }
        public int Count54
        { get; set; }
        public int Count60M
        { get; set; }
        public int Count60A
        { get; set; }
        public int Count60D
        { get; set; }
        public int Count60I
        { get; set; }
        public int Count60R
        { get; set; }
        public int Count70
        { get; set; }
        public int Count71
        { get; set; }
        public int Count74
        { get; set; }
        public int Count75
        { get; set; }
        public decimal Total_geral
        { get; set; }
        public decimal Numero_registro
        { get; set; }

        public Tipo90()
        {
            this.Cnpj = string.Empty;
            this.insc_estadual = string.Empty;
            this.Count50 = 0;
            this.Count51 = 0;
            this.Count53 = 0;
            this.Count54 = 0;
            this.Count60M = 0;
            this.Count60A = 0;
            this.Count60D = 0;
            this.Count60I = 0;
            this.Count60R = 0;
            this.Count70 = 0;
            this.Count71 = 0;
            this.Count74 = 0;
            this.Count75 = 0;
            this.Total_geral = 3;//Registro 10, 11 e 90 que sao obrigatorios
            this.Numero_registro = 1;
        }

        public Linha CriarRegistroTipo90()
        {
            //Tipo registro
            Linha ln = this.Tipo.Trim();
            //Cnpj do informante
            ln += this.Cnpj.Trim().SoNumero().FormatStringEsquerda(14, '0');
            //Inscricao estadual do informante
            ln += this.Insc_estadual.Trim().FormatStringDireita(14, ' ');
            if (this.Count50 > 0)
            {
                ln += "50";
                ln += string.Format("{0:N0}", this.Count50).SoNumero().FormatStringEsquerda(8, '0');
                this.Total_geral += this.Count50;
            }
            if (this.Count51 > 0)
            {
                ln += "51";
                ln += string.Format("{0:N0}", this.Count51).SoNumero().FormatStringEsquerda(8, '0');
                this.Total_geral += this.Count51;
            }
            if (this.Count53 > 0)
            {
                ln += "53";
                ln += string.Format("{0:N0}", this.Count53).SoNumero().FormatStringEsquerda(8, '0');
                this.Total_geral += this.Count53;
            }
            if (this.Count54 > 0)
            {
                ln += "54";
                ln += string.Format("{0:N0}", this.Count54).SoNumero().FormatStringEsquerda(8, '0');
                this.Total_geral += this.Count54;
            }
            if (this.Count60M > 0)
            {
                ln += "60";
                ln += string.Format("{0:N0}", this.Count60M + this.Count60A + this.Count60D + this.Count60I + this.Count60R).SoNumero().FormatStringEsquerda(8, '0');
                this.Total_geral += this.Count60M + this.Count60A + this.Count60D + this.Count60I + this.Count60R;
            }
            if (this.Count70 > 0)
            {
                ln += "70";
                ln += string.Format("{0:N0}", this.Count70).SoNumero().FormatStringEsquerda(8, '0');
                this.Total_geral += this.Count70;
            }
            if (this.Count71 > 0)
            {
                ln += "71";
                ln += string.Format("{0:N0}", this.Count71).SoNumero().FormatStringEsquerda(8, '0');
                this.Total_geral += this.Count71;
            }
            if (this.Count74 > 0)
            {
                ln += "74";
                ln += string.Format("{0:N0}", this.Count74).SoNumero().FormatStringEsquerda(8, '0');
                this.Total_geral += this.Count74;
            }
            if (this.Count75 > 0)
            {
                ln += "75";
                ln += string.Format("{0:N0}", this.Count75).SoNumero().FormatStringEsquerda(8, '0');
                this.Total_geral += this.Count75;
            }
            //Total geral
            ln += "99" + string.Format("{0:N0}", this.Total_geral).SoNumero().FormatStringEsquerda(8, '0');
            ln += " ".FormatStringDireita(125 - ln.ToString().Length, ' ');
            //Numero registro tipo 90
            ln += string.Format("{0:N0}", this.Numero_registro).SoNumero().FormatStringEsquerda(1, '0');
            ln += "\r\n";

            return ln;
        }
    }

    public class TCN_Tipo90
    {
        public static string MontarRegistro90(string Cd_empresa,
                                              int Count50,
                                              int Count51,
                                              int Count53,
                                              int Count54,
                                              int Count60M,
                                              int Count60A,
                                              int Count60D,
                                              int Count60I,
                                              int Count60R,
                                              int Count70,
                                              int Count71,
                                              int Count74,
                                              int Count75)
        {
            CamadaDados.Fiscal.Sintegra.Tipo10_11 emp =
                new CamadaDados.Fiscal.Sintegra.TCD_Tipo10_11().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                            }
                        }, 0, string.Empty);
            if (emp != null)
            {
                Tipo90 tp_90 = new Tipo90();
                tp_90.Cnpj = emp.Cnpj;
                tp_90.Insc_estadual = emp.Insc_estadual;
                tp_90.Count50 = Count50;
                tp_90.Count51 = Count51;
                tp_90.Count53 = Count53;
                tp_90.Count54 = Count54;
                tp_90.Count60M = Count60M;
                tp_90.Count60A = Count60A;
                tp_90.Count60D = Count60D;
                tp_90.Count60I = Count60I;
                tp_90.Count60R = Count60R;
                tp_90.Count70 = Count70;
                tp_90.Count71 = Count71;
                tp_90.Count74 = Count74;
                tp_90.Count75 = Count75;
                return tp_90.CriarRegistroTipo90().ToString();
            }
            else
                throw new Exception("Não existe dados da empresa " + Cd_empresa.Trim() + " para montar registro 90");
        }
    }
}
