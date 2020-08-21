using System;
using System.Linq;
using Utils;

namespace NFCe
{
    public class TGerarQRCode
    {
        /*
        public static string GerarQRCode(CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe)
        {
            if (rNFCe.St_contingencia)
            {
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                rNFCe.Chave_acesso = NFCe.GerarXML.TGerarXML.MontarChaveAcessoNfe(rNFCe, true).Trim();
                hs.Add("@P_CHAVE", rNFCe.Chave_acesso);
                hs.Add("@P_EMPRESA", rNFCe.Cd_empresa);
                hs.Add("@P_ID_NFCE", rNFCe.Id_nfcestr);
                new CamadaDados.TDataQuery().executarSql("update tb_pdv_nfce set chave_acesso = @P_CHAVE, dt_alt = getdate() " +
                                                          "where cd_empresa = @P_EMPRESA and id_nfce = @P_ID_NFCE", hs);
            }
            string dest = string.Empty;
            if(rNFCe.rCliente == null ? false : !string.IsNullOrEmpty((rNFCe.rCliente.Nr_cgc + rNFCe.rCliente.Nr_cpf).SoNumero()))
            {
                if (rNFCe.rCliente.Tp_pessoa.Trim().ToUpper().Equals("F") && !string.IsNullOrEmpty(rNFCe.rCliente.Nr_cpf.SoNumero()))
                    dest = rNFCe.rCliente.Nr_cpf.SoNumero();
                else if (rNFCe.rCliente.Tp_pessoa.Trim().ToUpper().Equals("J") && !string.IsNullOrEmpty(rNFCe.rCliente.Nr_cgc.SoNumero()))
                    dest = rNFCe.rCliente.Nr_cgc.SoNumero();
            }
            else if (!string.IsNullOrEmpty(rNFCe.Nr_cgc_cpf.SoNumero()) &&
                     (rNFCe.Nr_cgc_cpf.SoNumero().Length.Equals(14) ||
                      rNFCe.Nr_cgc_cpf.SoNumero().Length.Equals(11)))
                dest = rNFCe.Nr_cgc_cpf.SoNumero();
            string str = "chNFe=" + GerarXML.TGerarXML.MontarChaveAcessoNfe(rNFCe, true).Trim() + "&" +
                          "nVersao=100&" +
                          "tpAmb=" + rNFCe.rCfgNFCe.Tp_ambiente_nfce.Trim() + "&" +
                          (string.IsNullOrEmpty(dest) ? string.Empty : "cDest=" + dest.Trim() + "&") +
                          "dhEmi=" + rNFCe.Dt_emissao.Value.ToString("yyyy-MM-ddTHH:mm:sszzz").ConvertHexaDecimal().ToLower() + "&" +
                          "vNF=" + Convert.ToDecimal(string.Format("{0:N2}", rNFCe.Vl_cupom)).ToString(new System.Globalization.CultureInfo("en-US", true)) + "&" +
                          "vICMS=" + Convert.ToDecimal(string.Format("{0:N2}", rNFCe.lItem.Sum(v => v.Vl_icms))).ToString(new System.Globalization.CultureInfo("en-US", true)) + "&" +
                          "digVal=" + rNFCe.Digval.ConvertHexaDecimal().ToLower() + "&" +
                          "cIdToken=" + rNFCe.rCfgNFCe.Id_tokencsc.Trim() + rNFCe.rCfgNFCe.Nr_csc.Trim();
            string strQRCode = rNFCe.rCfgNFCe.Url_nfce.Trim() +
                               "chNFe=" + GerarXML.TGerarXML.MontarChaveAcessoNfe(rNFCe, true).Trim() + "&" +
                               "nVersao=100&" +
                               "tpAmb=" + rNFCe.rCfgNFCe.Tp_ambiente_nfce.Trim() + "&" +
                               (string.IsNullOrEmpty(dest) ? string.Empty : "cDest=" + dest.Trim() + "&") +
                               "dhEmi=" + rNFCe.Dt_emissao.Value.ToString("yyyy-MM-ddTHH:mm:sszzz").ConvertHexaDecimal().ToLower() + "&" +
                               "vNF=" + Convert.ToDecimal(string.Format("{0:N2}", rNFCe.Vl_cupom)).ToString(new System.Globalization.CultureInfo("en-US", true)) + "&" +
                               "vICMS=" + Convert.ToDecimal(string.Format("{0:N2}", rNFCe.lItem.Sum(v => v.Vl_icms))).ToString(new System.Globalization.CultureInfo("en-US", true)) + "&" +
                               "digVal=" + rNFCe.Digval.ConvertHexaDecimal().ToLower() + "&" +
                               "cIdToken=" + rNFCe.rCfgNFCe.Id_tokencsc.Trim() + "&" +
                               "cHashQRCode=" + Utils.Estruturas.SHA1(str).ToLower().Trim();
            //Gerar Imagem QR Code
            Gma.QrCodeNet.Encoding.QrCode code = new Gma.QrCodeNet.Encoding.QrCode();
            Gma.QrCodeNet.Encoding.QrEncoder encoder = new Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M);
            code = encoder.Encode(strQRCode);
            Gma.QrCodeNet.Encoding.Windows.Render.GraphicsRenderer gRender =
                new Gma.QrCodeNet.Encoding.Windows.Render.GraphicsRenderer(new Gma.QrCodeNet.Encoding.Windows.Render.FixedModuleSize(4, Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Zero),
                                                                           System.Drawing.Brushes.Black, System.Drawing.Brushes.White);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            gRender.WriteToStream(code.Matrix, System.Drawing.Imaging.ImageFormat.Jpeg, ms);
            rNFCe.QR_Code = System.Drawing.Image.FromStream(ms);
            return strQRCode;
        }
        */
        public static string GerarQRCode2(CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe)
        {
            string strQRCode = string.Empty;
            if (rNFCe.St_contingencia)
            {
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                rNFCe.Chave_acesso = NFCe.GerarXML.TGerarXML.MontarChaveAcessoNfe(rNFCe, true).Trim();
                hs.Add("@P_CHAVE", rNFCe.Chave_acesso);
                hs.Add("@P_EMPRESA", rNFCe.Cd_empresa);
                hs.Add("@P_ID_NFCE", rNFCe.Id_nfcestr);
                new CamadaDados.TDataQuery().executarSql("update tb_pdv_nfce set chave_acesso = @P_CHAVE, dt_alt = getdate() " +
                                                          "where cd_empresa = @P_EMPRESA and id_nfce = @P_ID_NFCE", hs);
                string str = GerarXML.TGerarXML.MontarChaveAcessoNfe(rNFCe, true).Trim() + "|" +
                             "2|" +
                             rNFCe.rCfgNFCe.Tp_ambiente_nfce.Trim() + "|" +
                             rNFCe.Dt_emissao.Value.ToString("dd/MM/yyyy").Substring(0, 2) + "|" +
                             Convert.ToDecimal(string.Format("{0:N2}", rNFCe.Vl_cupom)).ToString(new System.Globalization.CultureInfo("en-US", true)) + "|" +
                             rNFCe.Digval.ConvertHexaDecimal() + "|" +
                             int.Parse(rNFCe.rCfgNFCe.Id_tokencsc) + rNFCe.rCfgNFCe.Nr_csc.Trim();
                strQRCode = rNFCe.rCfgNFCe.Url_nfce.Trim() + "?p=" +
                            GerarXML.TGerarXML.MontarChaveAcessoNfe(rNFCe, true).Trim() + "|" +
                             "2|" +
                             rNFCe.rCfgNFCe.Tp_ambiente_nfce.Trim() + "|" +
                             rNFCe.Dt_emissao.Value.ToString("dd/MM/yyyy").Substring(0, 2) + "|" +
                             Convert.ToDecimal(string.Format("{0:N2}", rNFCe.Vl_cupom)).ToString(new System.Globalization.CultureInfo("en-US", true)) + "|" +
                             rNFCe.Digval.ConvertHexaDecimal() + "|" +
                             int.Parse(rNFCe.rCfgNFCe.Id_tokencsc) + "|" +
                            Estruturas.SHA1(str).Trim();
            }
            else
            {
                string str = GerarXML.TGerarXML.MontarChaveAcessoNfe(rNFCe, true).Trim() + "|" +
                            "2|" +
                            rNFCe.rCfgNFCe.Tp_ambiente_nfce.Trim() + "|" +
                            int.Parse(rNFCe.rCfgNFCe.Id_tokencsc) + rNFCe.rCfgNFCe.Nr_csc.Trim();
                strQRCode = rNFCe.rCfgNFCe.Url_nfce.Trim() + "?p=" +
                            GerarXML.TGerarXML.MontarChaveAcessoNfe(rNFCe, true).Trim() + "|" +
                            "2|" + //Versão do QRCode
                            rNFCe.rCfgNFCe.Tp_ambiente_nfce.Trim() + "|" +
                            int.Parse(rNFCe.rCfgNFCe.Id_tokencsc) + "|" +
                            Estruturas.SHA1(str).Trim();
            }
            //Gerar Imagem QR Code
            Gma.QrCodeNet.Encoding.QrCode code = new Gma.QrCodeNet.Encoding.QrCode();
            Gma.QrCodeNet.Encoding.QrEncoder encoder = new Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M);
            code = encoder.Encode(strQRCode);
            Gma.QrCodeNet.Encoding.Windows.Render.GraphicsRenderer gRender =
                new Gma.QrCodeNet.Encoding.Windows.Render.GraphicsRenderer(new Gma.QrCodeNet.Encoding.Windows.Render.FixedModuleSize(4, Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Zero),
                                                                           System.Drawing.Brushes.Black, System.Drawing.Brushes.White);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            gRender.WriteToStream(code.Matrix, System.Drawing.Imaging.ImageFormat.Jpeg, ms);
            rNFCe.QR_Code = System.Drawing.Image.FromStream(ms);
            return strQRCode;
        }
    }
}
