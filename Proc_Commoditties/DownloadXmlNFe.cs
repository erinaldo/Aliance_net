using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Utils;
using System.Text.RegularExpressions;
using System.Xml;
using CamadaNegocio.Estoque.Cadastros;

namespace Proc_Commoditties
{
    public class DownloadXmlNFe
    {
        private static string html = string.Empty;
        private static string chaveAcesso = string.Empty;
        private static CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item ItensNota
        { get; set; }
        private static CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item rNota
        { get; set; }

        public static string DownloadHtml(string chave)
        {
            html = string.Empty;
            ItensNota = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item();
            using (TFCaptcha fCaptcha = new TFCaptcha())
            {
                fCaptcha.chaveAcesso = chave;
                if (fCaptcha.ShowDialog() == DialogResult.OK)
                    html = fCaptcha.html;
            }
            if (!string.IsNullOrEmpty(html))
            {
                if (html.Contains(">NF-e INEXISTENTE na base nacional, favor consultar esta NF-e no site da SEFAZ de origem.<"))
                {
                    MessageBox.Show("NF-e INEXISTENTE na base nacional, favor consultar esta NF-e no site da SEFAZ de origem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                BuscarProdutos();
                GerarXml();
                if (System.IO.File.Exists("C:\\Aliance.Net\\Xml\\" + chaveAcesso.SoNumero().Trim() + ".xml"))
                    return "C:\\Aliance.Net\\Xml\\" + chaveAcesso.SoNumero().Trim() + ".xml";
                else
                    return string.Empty;
            }
            return string.Empty;
        }

        private static string CalcularDigitoChave(string vChave)
        {
            return Utils.Estruturas.Mod11(Regex.Replace(vChave, "[!@#$%&*()-/;:?,.\r\n]", string.Empty), 9, false, 0).ToString();
        }

        private static string MontarNf(string label)
        {
            string linha = string.Empty;
            System.IO.StringReader rd = new System.IO.StringReader(html);
            char[] START = { '<', };
            try
            {
                if (html.Contains(label))
                    while (linha != null)
                    {
                        linha = rd.ReadLine();
                        if (linha.Contains(label))
                        {
                            string[] n = linha.Split(START);
                            foreach (string s in n)
                            {
                                if (s.Contains("SPAN>"))
                                    return s.Remove(0, 5);
                            }
                        }
                    }
                return string.Empty;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim() + "\r\nNome da coluna:" + label, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return string.Empty;
        }

        private static string BuscarEmitente(string label)
        {
            string linha = string.Empty;
            System.IO.StringReader rd = new System.IO.StringReader(html);
            char[] START = { '<', };
            bool st_emit = true;
            try
            {
                while (linha != null)
                {
                    linha = rd.ReadLine();
                    if (linha != null)
                    {
                        st_emit = !linha.Contains(">Dados do Destinatário<");
                        if (st_emit)
                            if (linha.Contains(label))
                            {
                                string[] n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                        return s.Remove(0, 5);
                                }
                            }
                    }
                    else
                        return string.Empty;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim() + "\r\nNome da coluna:" + label, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return string.Empty;
        }

        private static string BuscarDestinatario(string label)
        {
            string linha = string.Empty;
            System.IO.StringReader rd = new System.IO.StringReader(html);
            char[] START = { '<', };
            bool st_dest = false;
            try
            {
                while (linha != null)
                {
                    linha = rd.ReadLine();
                    if (linha != null)
                    {
                        if (!st_dest)
                            st_dest = linha.Contains(">Dados do Destinatário<") || linha.Contains(">Dados do Remetente<");
                        if (st_dest)
                            if (linha.Contains(label))
                            {
                                string[] n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                        return s.Remove(0, 5);
                                }
                            }
                    }
                    else
                        return string.Empty;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim() + "\r\nNome da coluna:" + label, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return string.Empty;
        }

        private static string BuscarTransp(string label)
        {
            string linha = string.Empty;
            System.IO.StringReader rd = new System.IO.StringReader(html);
            char[] START = { '<', };
            bool st_transp = false;
            try
            {
                while (linha != null)
                {
                    linha = rd.ReadLine();
                    st_transp = linha.Contains(">Dados do Transporte<");
                    if (st_transp)
                        if (linha.Contains(label))
                        {
                            string[] n = linha.Split(START);
                            foreach (string s in n)
                            {
                                if (s.Contains("SPAN>"))
                                    return s.Remove(0, 5);
                            }
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return string.Empty;
        }

        private static void BuscarProdutos()
        {
            string linha = string.Empty;
            System.IO.StringReader rd = new System.IO.StringReader(html);
            char[] START = { '<', };
            try
            {
                while (linha != null)
                {
                    linha = rd.ReadLine();
                    if (linha != null)
                        if (linha.Contains("-numero><SPAN>"))
                        {
                            rNota =
                                new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item();
                            string[] n = linha.Split(START);
                            while (!linha.Contains("-descricao><SPAN>"))
                                linha = rd.ReadLine();
                            if (linha.Contains("-descricao><SPAN>"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Ds_produto = s.Remove(0, 5);
                                        break;
                                    }
                                };
                            }
                            while (!linha.Contains("-qtd><SPAN>"))
                                linha = rd.ReadLine();
                            if (linha.Contains("-qtd><SPAN>"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Quantidade = Convert.ToDecimal(string.IsNullOrEmpty(s.Remove(0,5)) ? "0" : s.Remove(0,5));
                                        break;
                                    }
                                };
                            }
                            while (!linha.Contains("-uc><SPAN>"))
                                linha = rd.ReadLine();
                            if (linha.Contains("-uc><SPAN>"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Sigla_unidade = s.Remove(0, 5);
                                        break;
                                    }
                                };
                            }
                            while (!linha.Contains("-vb><SPAN>"))
                                linha = rd.ReadLine();
                            if (linha.Contains("-vb><SPAN>"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Vl_subtotal = Convert.ToDecimal(string.IsNullOrEmpty(s.Remove(0,5)) ? "0" : s.Remove(0,5));
                                        break;
                                    }
                                };
                            }
                            while (!linha.Contains(">Código do Produto<"))
                                linha = rd.ReadLine();
                            if (linha.Contains(">Código do Produto<"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Cd_produto = s.Remove(0, 5);
                                        break;
                                    }
                                };
                            }
                            while (!linha.Contains(">Código NCM<"))
                                linha = rd.ReadLine();
                            if (linha.Contains(">Código NCM<"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Cd_ncm = s.Remove(0, 5);
                                        break;
                                    }
                                };
                            }
                            while (!linha.Contains(">Outras Despesas Acessórias<"))
                                linha = rd.ReadLine();
                            if (linha.Contains(">Outras Despesas Acessórias<"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Vl_outrasdesp = Convert.ToDecimal(string.IsNullOrEmpty(s.Remove(0,5)) ? "0" : s.Remove(0,5));
                                        break;
                                    }
                                };
                            }
                            while (!linha.Contains(">Valor do Desconto<"))
                                linha = rd.ReadLine();
                            if (linha.Contains(">Valor do Desconto<"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Vl_desconto = Convert.ToDecimal(string.IsNullOrEmpty(s.Remove(0,5)) ? "0" : s.Remove(0,5));
                                        break;
                                    }
                                };
                            }
                            while (!linha.Contains(">Valor Total do Frete<"))
                                linha = rd.ReadLine();
                            if (linha.Contains(">Valor Total do Frete<"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Vl_freteitem = Convert.ToDecimal(string.IsNullOrEmpty(s.Remove(0,5)) ? "0" : s.Remove(0,5));
                                        break;
                                    }
                                };
                            }
                            while (!linha.Contains(">Valor do Seguro<"))
                                linha = rd.ReadLine();
                            if (linha.Contains(">Valor do Seguro<"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Vl_seguro = Convert.ToDecimal(string.IsNullOrEmpty(s.Remove(0,5)) ? "0" : s.Remove(0,5));
                                        break;
                                    }
                                };
                            }
                            while (!linha.Contains(">Valor unitário de comercialização<"))
                                linha = rd.ReadLine();
                            if (linha.Contains(">Valor unitário de comercialização<"))
                            {
                                n = linha.Split(START);
                                foreach (string s in n)
                                {
                                    if (s.Contains("SPAN>"))
                                    {
                                        rNota.Vl_unitario = Convert.ToDecimal(string.IsNullOrEmpty(s.Remove(0,5)) ? "0" : s.Remove(0,5));
                                        break;
                                    }
                                };
                            }
                            ItensNota.Add(rNota);
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private static void GerarXml()
        {
            StringBuilder xml = new StringBuilder();
            #region NFe
            xml.Append("<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\">\n");

            chaveAcesso = MontarNf(">Chave de Acesso<");
            #region infNFe
            xml.Append("<infNFe Id=\"NFe" + chaveAcesso.SoNumero().Trim() + "\" versao=\"" + MontarNf(">Versão XML<").Trim() + "\">\n");

            #region ide
            xml.Append("<ide>\n");

            #region cUF
            xml.Append("<cUF>");
            xml.Append(chaveAcesso.Substring(0,2));
            xml.Append("</cUF>\n");
            #endregion

            #region natOp
            xml.Append("<natOp>");
            xml.Append(MontarNf(">Natureza da Operação<").Trim()); //Natureza da operação
            xml.Append("</natOp>\n");
            #endregion

            #region indPag
            xml.Append("<indPag>");
            xml.Append(MontarNf(">Forma de Pagamento<").Trim().Substring(0,1)); //Forma de Pagamento 
            //0 - a vista  
            //1 - a prazo  
            //2 - outros
            xml.Append("</indPag>\n");
            #endregion

            #region mod
            xml.Append("<mod>");
            xml.Append(MontarNf(">Modelo<").Trim().PadLeft(2, '0')); //Modelo documento fiscal 
            //utilizar codigo 55 para identificacao da NF-e
            //utilizar codigo 65 para identificacao da NFC-e
            xml.Append("</mod>\n");
            #endregion

            #region serie
            xml.Append("<serie>");
            xml.Append(MontarNf(">Série<").Trim()); //Série da nota fiscal
            //Informar 0 (zero) para serie unica
            xml.Append("</serie>\n");
            #endregion

            #region nNF
            xml.Append("<nNF>");
            xml.Append(MontarNf(">Número<").ToString().Trim()); //Numero do documento fiscal
            xml.Append("</nNF>\n");
            #endregion

            #region dEmi
            xml.Append("<dhEmi>");
            xml.Append(Convert.ToDateTime(MontarNf(">Data de Emissão<")).ToString("yyyy-MM-ddTHH:mm:sszzz")); //Data de emissão da nota fiscal
            xml.Append("</dhEmi>\n");
            #endregion

            #region dSaiEnt
            string dt_saient = MontarNf(">Data/Hora Saída/Entrada <");
            if (!string.IsNullOrEmpty(dt_saient))
            {
                xml.Append("<dhSaiEnt>");
                xml.Append(Convert.ToDateTime(dt_saient.Substring(0, 10)).ToString("yyyy-MM-ddTHH:mm:sszzz")); //Data de entrada/saida da nf-e
                xml.Append("</dhSaiEnt>\n");
            }
            #endregion

            #region tpNF
            xml.Append("<tpNF>");
            xml.Append(MontarNf(">Tipo da Operação<").Contains("0") ? "0" : "1"); //Tipo documento fiscal 
            //0 - entrada
            //1 - saida
            xml.Append("</tpNF>\n");
            #endregion

            //#region idDest
            //xml.Append("<idDest>");
            //xml.Append(p.rEmpresa.rEndereco.Cd_uf.Equals(p.rEndereco.Cd_uf) ? "1" : "2");
            ////1-Dentro estado 2-Fora estado 3-Exterior
            //xml.Append("</idDest>\n");
            //#endregion

            //#region cMunFG
            //xml.Append("<cMunFG>");
            //xml.Append(p.rEmpresa.rEndereco.Cd_cidade.Trim().PadLeft(7, '0')); //Codigo do municipio gerador do icms
            //xml.Append("</cMunFG>\n");
            //#endregion

            #region tpImp
            xml.Append("<tpImp>");
            xml.Append("1"); //Formato de impressão do DANFE 
            //1 - Retrato
            //2 - Paisagem
            xml.Append("</tpImp>\n");
            #endregion

            #region tpEmis
            xml.Append("<tpEmis>");
            xml.Append(MontarNf(">Tipo de Emissão<").Substring(0,1)); //Forma de emissão da NF-e
            //1-Normal, emissão normal com transmissão on-line da NF-e para a SEFAZ de origem
            //6-Contingencia SVC-AN
            //7-Contingencia SVC-RS
            xml.Append("</tpEmis>\n");
            #endregion

            #region cDV
            string digitochave = CalcularDigitoChave(chaveAcesso.SoNumero()).Trim();
            xml.Append("<cDV>");
            xml.Append(digitochave); //Digito verificador da chave de acesso da NF-e
            xml.Append("</cDV>\n");
            #endregion

            #region tpAmb
            xml.Append("<tpAmb>");
            xml.Append("1");
            //1-Produção 
            //2-homologação
            xml.Append("</tpAmb>\n");
            #endregion

            #region finNFe
            xml.Append("<finNFe>");
            xml.Append(MontarNf(">Finalidade<").Trim().Substring(0,1));
            //1 - Normal
            //2 - Complementar 
            //3 - Ajuste
            //4 - Devolucao/Retorno
            xml.Append("</finNFe>\n");
            #endregion

            #region indFinal
            xml.Append("<indFinal>");
            xml.Append(MontarNf(">Modelo<").Trim().Equals("55") ? "0" : "1");
            //0-nao 1-sim
            xml.Append("</indFinal>\n");
            #endregion

            #region indPres
            xml.Append("<indPres>");
            xml.Append("1");//Operacao presencial
            xml.Append("</indPres>\n");
            #endregion

            #region procEmi
            xml.Append("<procEmi>");
            xml.Append("0"); //Processo de emissão da NF-e
            //0-emissão de nf-e com aplicativo do contribuinte
            //1-emissão de nf-e avulsa pelo fisco
            //2-emissão de nf-e avulsa, pelo contribuinte com seu certificado digital atraves do site do fisco
            //3-emissão de nf-e pelo contribuinte com aplicativo fornecido pelo fisco
            xml.Append("</procEmi>\n");
            #endregion

            #region verProc
            xml.Append("<verProc>");
            xml.Append(MontarNf(">Versão do Processo<").Trim()); //Versão do processo de emissão da NF-e
            xml.Append("</verProc>\n");
            #endregion

            //Notas fiscais referenciadas
            //xml.Append(MontarTagNfsReferenciadas(p));
            xml.Append("</ide>\n");
            #endregion

            #region emit
            xml.Append("<emit>\n");

            #region CNPJ
            xml.Append("<CNPJ>");
            xml.Append(BuscarEmitente(">CNPJ<").SoNumero());
            xml.Append("</CNPJ>\n");
            #endregion

            #region xNome
            xml.Append("<xNome>");
            xml.Append(BuscarEmitente(">Nome / Razão Social<").RemoverCaracteres().Trim()); //Razão social ou nome do emitente
            xml.Append("</xNome>\n");
            #endregion

            #region xFant
            //if (!string.IsNullOrEmpty(p.rEmpresa.rClifor.Nm_fantasia))
            //{
            //    xml.Append("<xFant>");
            //    xml.Append(p.rEmpresa.rClifor.Nm_fantasia.RemoverCaracteres().Trim()); //Nome fantasia
            //    xml.Append("</xFant>\n");
            //}
            #endregion

            #region enderEmit
            xml.Append("<enderEmit>\n");

            #region xLgr
            xml.Append("<xLgr>");
            xml.Append(BuscarEmitente(">Endereço<").Split(new char[] { '&' })[0].RemoverCaracteres().TrimEnd(',').Trim());
            xml.Append("</xLgr>\n");
            #endregion

            #region nro
            //Verificar quantidades de virgula
            string numeroEmit = BuscarEmitente(">Endereço<");
            int totNumEmit = numeroEmit.Split(new char[] { ',' }).Length - 1;
            xml.Append("<nro>");
            xml.Append(totNumEmit.Equals(2) ?
                numeroEmit.Split(new char[] { ',' })[2].Split(new char[] { '&' })[1].Remove(0, 6).Trim() :
                totNumEmit.Equals(1) ?
                numeroEmit.Split(new char[] { ',' })[1].Split(new char[] { '&' })[1].Remove(0, 6).Trim() :
                string.Empty);
            xml.Append("</nro>\n");
            #endregion

            #region xCpl
            //if (!string.IsNullOrEmpty(p.rEmpresa.rEndereco.Ds_complemento))
            //{
            //    xml.Append("<xCpl>");
            //    xml.Append(p.rEmpresa.rEndereco.Ds_complemento.RemoverCaracteres().Trim());
            //    xml.Append("</xCpl>\n");
            //}
            #endregion

            #region xBairro
            xml.Append("<xBairro>");
            xml.Append(BuscarEmitente(">Bairro / Distrito<").RemoverCaracteres().Trim());
            xml.Append("</xBairro>\n");
            #endregion

            #region cMun
            xml.Append("<cMun>");
            xml.Append(BuscarEmitente(">Município<").Split(new char[] {'-'})[0].Trim());
            xml.Append("</cMun>\n");
            #endregion

            #region xMun
            xml.Append("<xMun>");
            xml.Append(BuscarEmitente(">Município<").Split(new char[] { '-' })[1].Trim());
            xml.Append("</xMun>\n");
            #endregion

            #region UF
            xml.Append("<UF>");
            xml.Append(BuscarEmitente(">UF<"));
            xml.Append("</UF>\n");
            #endregion

            #region CEP
            xml.Append("<CEP>");
            xml.Append(BuscarEmitente(">CEP<").SoNumero());
            xml.Append("</CEP>\n");
            #endregion

            #region cPais
            xml.Append("<cPais>");
            xml.Append(BuscarEmitente(">País<").Split(new char[] {'-'})[0].FormatStringEsquerda(4, '0')); //Codigo do pais, utilizar a tabela do BACEN
            //1058 - Brasil
            xml.Append("</cPais>\n");
            #endregion

            #region xPais
            xml.Append("<xPais>");
            xml.Append(BuscarEmitente(">País<").Split(new char[] { '-' })[1].Trim()); //Nome do pais
            xml.Append("</xPais>\n");
            #endregion

            #region fone
            string fone = BuscarEmitente(">Telefone<");
            if (!string.IsNullOrEmpty(fone.SoNumero()))
            {
                xml.Append("<fone>");
                xml.Append(fone.SoNumero());
                xml.Append("</fone>\n");
            }
            #endregion

            xml.Append("</enderEmit>\n");
            #endregion

            #region IE
            xml.Append("<IE>");
            xml.Append(Regex.Replace(BuscarEmitente(">Inscrição Estadual<").Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
            xml.Append("</IE>\n");
            #endregion

            #region IEST
            string iest = BuscarEmitente(">Inscrição Estadual do Substituto Tributário<");
            if ((!string.IsNullOrEmpty(Regex.Replace(iest.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty))))
            {
                xml.Append("<IEST>");
                xml.Append(Regex.Replace(iest.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                xml.Append("</IEST>");
            }
            #endregion

            #region IM
            string im = BuscarEmitente(">Inscrição Municipal<");
            if (!string.IsNullOrEmpty(Regex.Replace(im.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty)))
            {
                xml.Append("<IM>");
                xml.Append(Regex.Replace(im.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                xml.Append("</IM>\n");
            }
            #endregion

            #region CNAE
            string cnae = BuscarEmitente(">CNAE Fiscal<");
            if (!string.IsNullOrEmpty(Regex.Replace(cnae.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty)))
            {
                xml.Append("<CNAE>");
                xml.Append(Regex.Replace(cnae.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                xml.Append("</CNAE>\n");
            }
            #endregion

            #region CRT
            xml.Append("<CRT>");
            xml.Append(BuscarEmitente(">Código de Regime Tributário<").Trim().Substring(1,1));
            xml.Append("</CRT>\n");
            #endregion
            xml.Append("</emit>\n");
            #endregion

            #region dest
            xml.Append("<dest>\n");

            #region CNPJ/CPF
            string cnpj = BuscarDestinatario(">CNPJ<");
            if (!string.IsNullOrEmpty(cnpj))
            {
                xml.Append("<CNPJ>");
                xml.Append(cnpj.SoNumero());
                xml.Append("</CNPJ>\n");
            }
            else
            {
                xml.Append("<CPF>");
                xml.Append(Regex.Replace(BuscarDestinatario(">CPF<").Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty));
                xml.Append("</CPF>\n");
            }
            #endregion

            #region xNome
            xml.Append("<xNome>");
            xml.Append(BuscarDestinatario(">Nome / Razão Social<").RemoverCaracteres().Trim());
            xml.Append("</xNome>\n");
            #endregion

            #region enderDest
            xml.Append("<enderDest>\n");

            #region xLgr
            xml.Append("<xLgr>");
            xml.Append(BuscarDestinatario(">Endereço<").Split(new char[] { '&' })[0].RemoverCaracteres().TrimEnd(',').Trim());
            xml.Append("</xLgr>\n");
            #endregion

            #region nro
            //Verificar quantidades de virgula
            string numeroDest = BuscarDestinatario(">Endereço<");
            int totDest = numeroDest.Split(new char[] { ',' }).Length - 1;
            xml.Append("<nro>");
            xml.Append(totDest.Equals(2) ?
                numeroDest.Split(new char[] { ',' })[2].Split(new char[] { '&' })[1].Remove(0, 6).Trim() :
                totDest.Equals(1) ?
                numeroDest.Split(new char[] { ',' })[1].Split(new char[] { '&' })[1].Remove(0, 6).Trim() :
                string.Empty);
            xml.Append("</nro>\n");
            #endregion

            #region xCpl
            //if (!string.IsNullOrEmpty(p.rEndereco.Ds_complemento))
            //{
            //    xml.Append("<xCpl>");
            //    xml.Append(p.rEndereco.Ds_complemento.RemoverCaracteres().Trim());
            //    xml.Append("</xCpl>\n");
            //}
            #endregion

            #region xBairro
            xml.Append("<xBairro>");
            xml.Append(BuscarDestinatario(">Bairro / Distrito<").RemoverCaracteres().Trim());
            xml.Append("</xBairro>\n");
            #endregion

            #region cMun
            xml.Append("<cMun>");
            xml.Append(BuscarDestinatario(">Município<").Split(new char[] {'-'})[0].Trim()); // Codigo do municipio, utilizar tabela do IBGE
            xml.Append("</cMun>\n");
            #endregion

            #region xMun
            xml.Append("<xMun>");
            xml.Append(BuscarDestinatario(">Município<").Split(new char[] {'-'})[1].RemoverCaracteres().Trim());
            xml.Append("</xMun>\n");
            #endregion

            #region UF
            xml.Append("<UF>");
            xml.Append(BuscarDestinatario(">UF<").Trim());
            xml.Append("</UF>\n");
            #endregion

            #region CEP
            string cep = BuscarDestinatario(">CEP<");
            if (Regex.Replace(cep.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Trim() != string.Empty)
            {
                xml.Append("<CEP>");
                xml.Append(Regex.Replace(cep.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).PadLeft(8, '0'));
                xml.Append("</CEP>\n");
            }
            #endregion

            #region cPais
            xml.Append("<cPais>");
            xml.Append(BuscarDestinatario(">País<").Split(new char[] {'-'})[0].Trim()); //Utilizar tabela do  BACEN
            xml.Append("</cPais>\n");
            #endregion

            #region xPais
            xml.Append("<xPais>");
            xml.Append(BuscarDestinatario(">País<").Split(new char[] {'-'})[1].Trim());
            xml.Append("</xPais>\n");
            #endregion

            #region fone
            string foneDest = BuscarDestinatario(">Telefone<");
            if (Regex.Replace(foneDest.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty).Trim() != string.Empty)
            {
                xml.Append("<fone>");
                string fone_dest = Regex.Replace(foneDest.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty);
                if (fone_dest.Length > 10)
                    fone_dest = fone_dest.Remove(0, 1);
                fone_dest = Regex.Replace(fone_dest, "[' ']", string.Empty);
                xml.Append(fone_dest);
                xml.Append("</fone>\n");
            }
            #endregion

            xml.Append("</enderDest>\n");
            #endregion

            #region indIEDest
            string iedest = BuscarDestinatario(">Inscrição Estadual<");
            xml.Append("<indIEDest>");
            xml.Append(string.IsNullOrEmpty(iedest.SoNumero()) ? "2" : "1");
            xml.Append("</indIEDest>\n");
            #endregion

            #region IE
            if (!string.IsNullOrEmpty(iedest.SoNumero()))
            {
                xml.Append("<IE>");
                if (!string.IsNullOrEmpty(iedest))
                    xml.Append(iedest.SoNumero());
                 //Informar a IE quando o destinatario for contribuinte do ICMS.
                //Informar ISENTO quando o destinatario for contribuinte do ICMS,
                //mas não estiver obrigado à inscrição no cadastro de contribuintes do ICMS.
                //Não informar o conteudo da TAG se o destinatario não for contribuinte do ICMS
                xml.Append("</IE>\n");
            }
            #endregion

            #region email
            string emailDest = BuscarDestinatario(">E-mail<");
            if (!string.IsNullOrEmpty(emailDest))
            {
                xml.Append("<email>");
                xml.Append(emailDest.Trim());
                xml.Append("</email>\n");
            }
            #endregion

            xml.Append("</dest>\n");
            #endregion

            #region det - Grupo Detalhamento de Produtos e Serviços
            int tot_item = 1;
            decimal tot_imposto_aprox = decimal.Zero;
            ItensNota.ForEach(v =>
            {
                xml.Append("<det nItem=\"" + tot_item.ToString() + "\">\n");

                #region prod
                xml.Append("<prod>");

                #region cProd
                xml.Append("<cProd>");
                xml.Append(v.Cd_produto.RemoverCaracteres().Trim()); //Preencher com CFOP, caso se trate de itens não relacionados com mercadorias/produtos
                //e que o contribuinte não possua codificação própria.
                xml.Append("</cProd>\n");
                #endregion

                #region cEAN
                //xml.Append("<cEAN>");
                //xml.Append(""); //GTIN(Global Trade Item Number) do produto, antigo codigo EAN ou codigo de barras
                ////não informar o conteudo da tag caso o produto não possua este codigo
                //xml.Append("</cEAN>\n");
                #endregion

                #region xProd
                xml.Append("<xProd>");
                xml.Append(v.Ds_produto.Trim());
                xml.Append("</xProd>\n");
                #endregion

                #region NCM
                xml.Append("<NCM>");
                xml.Append(v.St_servico.Trim().ToUpper().Equals("S") ? "00" : v.Cd_ncm.Trim());
                xml.Append("</NCM>\n");
                #endregion

                #region CFOP
                xml.Append("<CFOP>");
                xml.Append(v.Cd_cfop.Trim().PadLeft(4, '0'));
                xml.Append("</CFOP>\n");
                #endregion

                #region uCom
                xml.Append("<uCom>");
                xml.Append(v.Sigla_unidade.Trim()); //Unidade de comercialização do produto
                xml.Append("</uCom>\n");
                #endregion

                #region qCom
                xml.Append("<qCom>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Quantidade de comercialização do produto
                xml.Append("</qCom>\n");
                #endregion

                #region vUnCom
                xml.Append("<vUnCom>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N10}", (v.Quantidade.Equals(decimal.Zero) ? decimal.Zero : v.Vl_subtotal / TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null)))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de comercialização do produto
                xml.Append("</vUnCom>\n");
                #endregion

                #region vProd
                xml.Append("<vProd>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_subtotal)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total bruto do produto e/ou serviços
                xml.Append("</vProd>\n");
                #endregion

                #region cEANTrib
                xml.Append("<cEANTrib>");
                xml.Append("12345678912345"); //GTIN(Global Trade Item Number) da unidade tributavel,
                //antigo codigo EAN ou codigo de barras
                xml.Append("</cEANTrib>\n");
                #endregion

                #region uTrib
                xml.Append("<uTrib>");
                xml.Append(v.Sigla_unidade.Trim());
                xml.Append("</uTrib>\n");
                #endregion

                #region qTrib
                xml.Append("<qTrib>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N4}", v.Quantidade)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Quantidade tributavel
                xml.Append("</qTrib>\n");
                #endregion

                #region vUnTrib
                xml.Append("<vUnTrib>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N10}", (v.Quantidade.Equals(decimal.Zero) ? decimal.Zero : v.Vl_subtotal / CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(v.Cd_unidEst, v.Cd_unidade, v.Quantidade, 3, null)))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                xml.Append("</vUnTrib>\n");
                #endregion

                #region vFrete
                if (v.Vl_freteitem > 0)
                {
                    xml.Append("<vFrete>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_freteitem)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                    xml.Append("</vFrete>\n");
                }
                #endregion

                #region vSeg
                if (v.Vl_seguro > decimal.Zero)
                {
                    xml.Append("<vSeg>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_seguro)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vSeg>\n");
                }
                #endregion

                #region vDesc
                if (v.Vl_desconto > 0)
                {
                    xml.Append("<vDesc>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_desconto)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor unitario de tributação
                    xml.Append("</vDesc>\n");
                }
                #endregion

                #region vOutro
                if ((v.Vl_outrasdesp + v.Vl_juro_fin) > decimal.Zero)
                {
                    xml.Append("<vOutro>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", v.Vl_outrasdesp + v.Vl_juro_fin)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vOutro>");
                }
                #endregion

                #region indTot
                xml.Append("<indTot>");
                xml.Append("1"); //Valor unitario de tributação
                xml.Append("</indTot>\n");
                #endregion

                //if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoCombustivel(v.Cd_produto) ||
                //    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoLubrificante(v.Cd_produto))
                //{
                //    #region Combustiveis e Lubrificantes
                //    xml.Append("<comb>");

                //    #region Codigo ANP
                //    xml.Append("<cProdANP>");
                //    xml.Append(v.Cd_anp.Trim());
                //    xml.Append("</cProdANP>\n");
                //    #endregion

                //    #region UF Consumidor
                //    xml.Append("<UFCons>");
                //    xml.Append(p.Uf_clifor.Trim());
                //    xml.Append("</UFCons>\n");
                //    #endregion

                //    xml.Append("</comb>\n");
                //    #endregion
                //}

                xml.Append("</prod>\n");
                #endregion

                #region infAdProd
                if (!string.IsNullOrEmpty(v.Observacao_item))
                {
                    string obsitem = Regex.Replace(v.Observacao_item.RemoverCaracteres().Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty);
                    xml.Append("<infAdProd>");
                    if (obsitem.Trim().Length <= 500)
                        xml.Append(obsitem.Trim()); //Informações adicionais do produto
                    else
                        xml.Append(obsitem.Trim().Substring(0, 500));
                    xml.Append("</infAdProd>\n");
                }
                #endregion

                tot_item++;

                xml.Append("</det>\n");
            });
            #endregion

            #region total
            xml.Append("<total>\n");

            #region ICMSTot
            xml.Append("<ICMSTot>\n");

            #region vBC
            xml.Append("<vBC>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Where(v => v.Cd_ST_ICMS.Trim() != "201" &&
                                                                                      v.Cd_ST_ICMS.Trim() != "202" &&
                                                                                      v.Cd_ST_ICMS.Trim() != "203" &&
                                                                                      v.Cd_ST_ICMS.Trim() != "500").Sum(z => z.Vl_basecalcICMS))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Base de calculo do ICMS
            xml.Append("</vBC>\n");
            #endregion

            #region vICMS
            xml.Append("<vICMS>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Where(v => v.Cd_ST_ICMS != "201" &&
                                                                                      v.Cd_ST_ICMS.Trim() != "202" &&
                                                                                      v.Cd_ST_ICMS.Trim() != "203" &&
                                                                                      v.Cd_ST_ICMS.Trim() != "500").Sum(z => z.Vl_icms))).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vICMS>\n");
            #endregion

            #region vICMSDeson
            xml.Append("<vICMSDeson>");
            xml.Append("0.00");
            xml.Append("</vICMSDeson>\n");

            #endregion

            #region vBCST
            xml.Append("<vBCST>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_basecalcSTICMS))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Base de calculo do ICMS ST
            xml.Append("</vBCST>\n");
            #endregion

            #region vST
            xml.Append("<vST>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_ICMSST))).ToString(new System.Globalization.CultureInfo("en-US", true)));
            xml.Append("</vST>\n");
            #endregion

            #region vProd
            xml.Append("<vProd>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", MontarNf(">Valor Total dos Produtos <"))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total dos produtos e serviços
            xml.Append("</vProd>\n");
            #endregion

            #region vFrete
            xml.Append("<vFrete>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", MontarNf(">Valor do Frete</")).ToString(new System.Globalization.CultureInfo("en-US", true))));
            xml.Append("</vFrete>\n");
            #endregion

            #region vSeg
            xml.Append("<vSeg>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", MontarNf(">Valor do Seguro</"))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valot total do seguro
            xml.Append("</vSeg>\n");
            #endregion

            #region vDesc
            xml.Append("<vDesc>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", MontarNf(">Valor Total dos Descontos<"))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total do desconto
            xml.Append("</vDesc>\n");
            #endregion

            #region vII
            xml.Append("<vII>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", decimal.Zero)).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total do II
            xml.Append("</vII>\n");
            #endregion

            #region vIPI
            xml.Append("<vIPI>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_ipi))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor total do IPI
            xml.Append("</vIPI>\n");
            #endregion

            #region vPIS
            xml.Append("<vPIS>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_basecalcPIS))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor PIS
            xml.Append("</vPIS>\n");
            #endregion

            #region vCOFINS
            xml.Append("<vCOFINS>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_basecalcCofins))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor do cofins
            xml.Append("</vCOFINS>\n");
            #endregion

            #region vOutro
            xml.Append("<vOutro>");
            xml.Append(Convert.ToDecimal(string.Format("{0:N2}", MontarNf(">Outras Despesas Acessórias</"))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Outras despesas acessorias
            xml.Append("</vOutro>\n");
            #endregion

            #region vNF
            xml.Append("<vNF>");
            xml.Append(MontarNf(">Valor&nbsp;Total&nbsp;da&nbsp;Nota&nbsp;Fiscal&nbsp;&nbsp;<")); //Valor total da NF-e
            xml.Append("</vNF>\n");
            #endregion

            if (tot_imposto_aprox > decimal.Zero)
            {
                xml.Append("<vTotTrib>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", tot_imposto_aprox)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                xml.Append("</vTotTrib>\n");
            }

            xml.Append("</ICMSTot>\n");
            #endregion

            if (ItensNota.Sum(v => v.Vl_iss) > 0)
            {
                #region ISSQNtot
                xml.Append("<ISSQNtot>\n");

                #region vServ
                //if (p.Vl_totalservicos > 0)
                //{
                //    xml.Append("<vServ>");
                //    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", p.Vl_totalservicos)).ToString(new System.Globalization.CultureInfo("en-US", true)));
                //    xml.Append("</vServ>\n");
                //}
                #endregion

                #region vBC
                xml.Append("<vBC>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", (ItensNota.Sum(v => v.Vl_basecalcISS)))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                xml.Append("</vBC>\n");
                #endregion

                #region vISS
                xml.Append("<vISS>");
                xml.Append(Convert.ToDecimal(string.Format("{0:N2}", (ItensNota.Sum(v => v.Vl_iss)))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                xml.Append("</vISS>\n");
                #endregion

                #region vPIS
                if (ItensNota.Where(v => v.St_servico.Trim().ToUpper().Equals("S")).Sum(v => v.Vl_pis) > 0)
                {
                    xml.Append("<vPIS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Where(v => v.St_servico.Trim().ToUpper().Equals("S")).Sum(v => v.Vl_pis))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vPIS>\n");
                }
                #endregion

                #region vCOFINS
                if (ItensNota.Where(v => v.St_servico.Trim().ToUpper().Equals("S")).Sum(v => v.Vl_cofins) > 0)
                {
                    xml.Append("<vCOFINS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Where(v => v.St_servico.Trim().ToUpper().Equals("S")).Sum(v => v.Vl_cofins))).ToString(new System.Globalization.CultureInfo("en-US", true)));
                    xml.Append("</vCOFINS>\n");
                }
                #endregion

                xml.Append("</ISSQNtot>\n");
                #endregion
            }

            if ((ItensNota.Sum(v => v.Vl_retidoPIS) > 0) ||
                (ItensNota.Sum(v => v.Vl_retidoCofins) > 0) ||
                (ItensNota.Sum(v => v.Vl_retidoCSLL) > 0) ||
                (ItensNota.Sum(v => v.Vl_retidoIRRF) > 0) ||
                (ItensNota.Sum(v => v.Vl_retidoINSS) > 0))
            {
                #region retTrib
                xml.Append("<retTrib>\n");

                if (ItensNota.Sum(v => v.Vl_retidoPIS) > 0)
                {
                    #region vRetPIS
                    xml.Append("<vRetPIS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_retidoPIS))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido PIS
                    xml.Append("</vRetPIS>\n");
                    #endregion
                }

                if (ItensNota.Sum(v => v.Vl_retidoCofins) > 0)
                {
                    #region vRetCOFINS
                    xml.Append("<vRetCOFINS>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_retidoCofins))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                    xml.Append("</vRetCOFINS>\n");
                    #endregion
                }

                if (ItensNota.Sum(v => v.Vl_retidoCSLL) > 0)
                {
                    #region vRetCSLL
                    xml.Append("<vRetCSLL>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_retidoCSLL))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                    xml.Append("</vRetCSLL>\n");
                    #endregion
                }

                if (ItensNota.Sum(v => v.Vl_basecalcIRRF) > 0)
                {
                    #region vBCIRRF
                    xml.Append("<vBCIRRF>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_basecalcIRRF))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                    xml.Append("</vBCIRRF>\n");
                    #endregion
                }

                if (ItensNota.Sum(v => v.Vl_retidoIRRF) > 0)
                {
                    #region vIRRF
                    xml.Append("<vIRRF>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_retidoIRRF))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                    xml.Append("</vIRRF>\n");
                    #endregion
                }

                if (ItensNota.Sum(v => v.Vl_basecalcINSS) > 0)
                {
                    #region vBCRetPrev
                    xml.Append("<vBCRetPrev>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_basecalcINSS))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                    xml.Append("</vBCRetPrev>\n");
                    #endregion
                }

                if (ItensNota.Sum(v => v.Vl_retidoINSS) > 0)
                {
                    #region vRetPrev
                    xml.Append("<vRetPrev>");
                    xml.Append(Convert.ToDecimal(string.Format("{0:N2}", ItensNota.Sum(v => v.Vl_retidoINSS))).ToString(new System.Globalization.CultureInfo("en-US", true))); //Valor retido cofins
                    xml.Append("</vRetPrev>\n");
                    #endregion
                }

                xml.Append("</retTrib>\n");
                #endregion
            }
            xml.Append("</total>\n");
            #endregion

            //#region transp
            //xml.Append("<transp>\n");

            //#region modFrete
            //xml.Append("<modFrete>");
            //string freteporConta = MontarNf(">Modalidade do Frete<");
            //xml.Append(freteporConta.Trim().Equals("1") ? "0" : freteporConta.Trim().Equals("2") ? "1" : "9"); //Modalidade do frete
            //xml.Append("</modFrete>\n");
            //#endregion
            //string razaosocialTransp = BuscarTransp(">Razão Social / Nome<");
            //if (!string.IsNullOrEmpty(razaosocialTransp))
            //{
            //    #region transporta
            //    xml.Append("<transporta>\n");

            //    string cnpjcpfTransp = BuscarTransp(">CNPJ<");
            //    if (!string.IsNullOrEmpty(cnpjcpfTransp))
            //        if (cnpjcpfTransp.SoNumero().Length.Equals(14))
            //        {
            //            #region CNPJ
            //            xml.Append("<CNPJ>");
            //            xml.Append(cnpjcpfTransp.SoNumero().FormatStringEsquerda(14, '0')); //Valor do ISSQN
            //            xml.Append("</CNPJ>\n");
            //            #endregion
            //        }
            //        else
            //        {
            //            #region CPF
            //            xml.Append("<CPF>");
            //            xml.Append(BuscarTransp(">CPF<").SoNumero().FormatStringEsquerda(11, '0')); //Valor do ISSQN
            //            xml.Append("</CPF>\n");
            //            #endregion
            //        }

            //    #region xNome
            //    xml.Append("<xNome>");
            //    xml.Append(razaosocialTransp.RemoverCaracteres().Trim()); //Valor do ISSQN
            //    xml.Append("</xNome>\n");
            //    #endregion

            //    string ieTransp = BuscarTransp(">Inscrição Estadual<");
            //    string ufTransp = BuscarTransp(">UF<");
            //    if ((!string.IsNullOrEmpty(ieTransp)) &&
            //        (!string.IsNullOrEmpty(ufTransp)))
            //    {
            //        #region IE
            //        xml.Append("<IE>");
            //        xml.Append(Regex.Replace(ieTransp.Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty)); //Valor do ISSQN
            //        xml.Append("</IE>\n");
            //        #endregion
            //    }

            //    string endTransp = BuscarTransp(">Endereço Completo<");
            //    if (!string.IsNullOrEmpty(endTransp))
            //    {
            //        #region xEnder
            //        xml.Append("<xEnder>");
            //        xml.Append(endTransp.RemoverCaracteres().Trim()); //Valor do ISSQN
            //        xml.Append("</xEnder>\n");
            //        #endregion
            //    }

            //    string cidadeTransp = BuscarTransp(">Município<");
            //    if (!string.IsNullOrEmpty(cidadeTransp))
            //    {
            //        #region xMun
            //        xml.Append("<xMun>");
            //        xml.Append(cidadeTransp.RemoverCaracteres().Trim()); //Valor do ISSQN
            //        xml.Append("</xMun>\n");
            //        #endregion
            //    }

            //    if (!string.IsNullOrEmpty(ufTransp))
            //    {
            //        #region UF
            //        xml.Append("<UF>");
            //        xml.Append(ufTransp.Trim()); //Valor do ISSQN
            //        xml.Append("</UF>\n");
            //        #endregion
            //    }

            //    xml.Append("</transporta>\n");
            //    #endregion
            //}

            ////if ((!string.IsNullOrEmpty(p.Placaveiculo)) &&
            ////    (!string.IsNullOrEmpty(p.Ufveiculo)))
            ////{
            ////    #region veicTransp
            ////    xml.Append("<veicTransp>\n");

            ////    #region placa
            ////    xml.Append("<placa>");
            ////    xml.Append(p.Placaveiculo.Trim());
            ////    xml.Append("</placa>\n");
            ////    #endregion

            ////    #region UF
            ////    xml.Append("<UF>");
            ////    xml.Append(p.Ufveiculo.Trim());
            ////    xml.Append("</UF>\n");
            ////    #endregion

            ////    xml.Append("</veicTransp>\n");
            ////    #endregion
            ////}

            //decimal qtdTransp = Convert.ToDecimal(BuscarTransp(">Quantidade<"));
            //if (qtdTransp > 0)
            //{
            //    #region vol
            //    xml.Append("<vol>\n");

            //    #region qVol
            //    xml.Append("<qVol>");
            //    xml.Append(Convert.ToDecimal(string.Format("{0:N0}", qtdTransp)).ToString(new System.Globalization.CultureInfo("en-US", true)));
            //    xml.Append("</qVol>\n");
            //    #endregion

            //    string especie = BuscarTransp(">Espécie<");
            //    if (!string.IsNullOrEmpty(especie))
            //    {
            //        #region esp
            //        xml.Append("<esp>");
            //        xml.Append(especie.Trim());
            //        xml.Append("</esp>\n");
            //        #endregion
            //    }

            //    string marca = BuscarTransp(">Marca dos Volumes<");
            //    if (!string.IsNullOrEmpty(marca))
            //    {
            //        #region marca
            //        xml.Append("<marca>");
            //        xml.Append(marca.Trim());
            //        xml.Append("</marca>\n");
            //        #endregion
            //    }

            //    string numeroVol = BuscarTransp(">Numeração<");
            //    if (!string.IsNullOrEmpty(numeroVol))
            //    {
            //        #region nVol
            //        xml.Append("<nVol>");
            //        xml.Append(numeroVol.Trim());
            //        xml.Append("</nVol>\n");
            //        #endregion
            //    }

            //    decimal pesoliq = Convert.ToDecimal(BuscarTransp(">Peso Líquido<"));
            //    if (pesoliq > 0)
            //    {
            //        #region pesoL
            //        xml.Append("<pesoL>");
            //        xml.Append(Convert.ToDecimal(string.Format("{0:N3}", pesoliq)).ToString(new System.Globalization.CultureInfo("en-US", true)));
            //        xml.Append("</pesoL>\n");
            //        #endregion
            //    }

            //    decimal pesoBruto = Convert.ToDecimal(BuscarTransp(">Peso Bruto<"));
            //    if (pesoBruto > 0)
            //    {
            //        #region pesoB
            //        xml.Append("<pesoB>");
            //        xml.Append(Convert.ToDecimal(string.Format("{0:N3}", pesoBruto)).ToString(new System.Globalization.CultureInfo("en-US", true)));
            //        xml.Append("</pesoB>\n");
            //        #endregion
            //    }

            //    xml.Append("</vol>\n");
            //    #endregion
            //}

            //xml.Append("</transp>\n");
            //#endregion

            //if ((!string.IsNullOrEmpty(p.Obsfiscal)) ||
            //    (!string.IsNullOrEmpty(p.Dadosadicionais)))
            //{
            //    #region infAdic
            //    xml.Append("<infAdic>");

            //    if (!string.IsNullOrEmpty(p.Obsfiscal))
            //    {
            //        #region infAdFisco
            //        string obsfiscal = Regex.Replace(p.Obsfiscal.RemoverCaracteres().Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty);
            //        xml.Append("<infAdFisco>");
            //        xml.Append(obsfiscal.Trim().Length > 2000 ? obsfiscal.Trim().Substring(0, 2000) : obsfiscal.Trim());
            //        xml.Append("</infAdFisco>");
            //        #endregion
            //    }

            //    if (!string.IsNullOrEmpty(p.Dadosadicionais))
            //    {
            //        #region infCpl
            //        string dadosadicionais = Regex.Replace(p.Dadosadicionais.RemoverCaracteres().Trim(), "[!@#$%&*()-/;:?,.\r\n]", string.Empty);
            //        xml.Append("<infCpl>");
            //        xml.Append(dadosadicionais.Trim().Length > 5000 ? dadosadicionais.Trim().Substring(0, 5000) : dadosadicionais.Trim());
            //        xml.Append("</infCpl>");
            //        #endregion
            //    }

            //    xml.Append("</infAdic>\n");
            //    #endregion
            //}

            xml.Append("</infNFe>\n");
            #endregion

            xml.Append("</NFe>\n");
            #endregion

            //Versao do xml
            XmlDocument doc = new XmlDocument();
            string xmlStr = string.Empty;
            xmlStr = xml.ToString();
            doc.LoadXml(xmlStr);
            string xmlLote = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
            xmlLote += "<nfeProc xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + doc.DocumentElement["infNFe"].Attributes["versao"].InnerText + "\">\n";
            xmlLote += xmlStr + "\n";
            xmlLote += "<protNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + doc.DocumentElement["infNFe"].Attributes["versao"].InnerText + "\">\n";
            xmlLote += "<infProt>\n";
            xmlLote += "<tpAmb>" + "1" + "</tpAmb>\n";
            xmlLote += "<verAplic>" + "3.10" + "</verAplic>\n";
            xmlLote += "<chNFe>" + chaveAcesso.SoNumero().Trim() + "</chNFe>\n";
            xmlLote += "</infProt>\n";
            xmlLote += "</protNFe>\n";
            xmlLote += "</nfeProc>";

            string folder = @"C:\Aliance.Net\Xml";
            Utils.SettingsUtils.Default.Path_XML_NFe_CTe = "C:\\Aliance.Net\\Xml";
            Utils.SettingsUtils.Default.Save();
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);
            if (System.IO.File.Exists("C:\\Aliance.Net\\Xml\\" + chaveAcesso.Trim() + ".xml"))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Aliance.Net\\Xml\\" + chaveAcesso.SoNumero().Trim() + ".xml");
                file.Write(xmlLote);
                file.Close();
            }
            else
                using (System.IO.FileStream fs = System.IO.File.Create("C:\\Aliance.Net\\Xml\\" + chaveAcesso.SoNumero().Trim() + ".xml"))
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs))
                    {
                        sw.Write(xmlLote);
                    }
                }
        }
    }
}
