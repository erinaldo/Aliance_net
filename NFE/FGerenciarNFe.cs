using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace srvNFE
{
    public partial class TFGerenciarNFe : Form
    {
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfe
        { get; set; }

        private decimal tot;
        private bool Altera_Relatorio;

        public TFGerenciarNFe()
        {
            InitializeComponent();
        }

        private void ConsultarLote()
        {
            lblStatus.Text = "Consulta Status Lote 1..10";
            System.Threading.Thread.Sleep(1000);
            tot = 1;
            //Consultar status lote NFe
            do
            {
                try
                {
                    if (rNfe != null)
                    {
                        srvNFE.NFERecepcao.TRetRecepcao2.ConsultaNFERecepcao2(rNfe.rCfgNfe);
                        this.ImprimirDanfe();
                    }
                    break;
                }
                catch
                { lblStatus.Text = "Consulta Status Lote " + (++tot).ToString() + "..10"; }
            } while (tot <= 10);
            if (tot > 10)
            {
                lblStatus.Text = "Lote não processado.";
                this.Close();
            }
            else
                this.Close();
        }

        private void ImprimirDanfe()
        {
            //Verificar status NFe
            object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rNfe.Cd_empresa.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_lanctofiscal",
                                                    vOperador = "=",
                                                    vVL_Busca = rNfe.Nr_lanctofiscal.ToString()
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_FAT_LoteNFE x " +
                                                                "where x.id_lote = a.id_lote " +
                                                                "and x.st_registro = 'P' " +
                                                                "and x.status = '104')"
                                                }
                                            }, "a.status");
            if (obj != null)
                if (obj.ToString().Trim().Equals("100"))
                    try
                    {
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                            Rel.Altera_Relatorio = Altera_Relatorio;

                            BindingSource BinDados = new BindingSource();
                            if (rNfe != null)
                            {
                                //Buscar registro nfe x nota fiscal
                                CamadaDados.Faturamento.NFE.TList_LanLoteNFE_X_NotaFiscal lLoteNfe =
                                new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().Select(
                                        new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rNfe.Cd_empresa.Trim() + "'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.nr_lanctofiscal",
                                                            vOperador = "=",
                                                            vVL_Busca = rNfe.Nr_lanctofiscalstr
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.status",
                                                            vOperador = "=",
                                                            vVL_Busca = "'100'"
                                                        }
                                                    }, 1, string.Empty);
                                if (lLoteNfe.Count > 0)
                                {
                                    rNfe.Dt_processamento = lLoteNfe[0].Dt_processamento;
                                    rNfe.Nr_protocolo = lLoteNfe[0].Nr_protocolo.HasValue ? lLoteNfe[0].Nr_protocolo.Value.ToString() : string.Empty;
                                }
                                Rel.Parametros_Relatorio.Add("VL_IPI", rNfe.ItensNota.Sum(v=> v.Vl_ipi));
                                Rel.Parametros_Relatorio.Add("VL_ICMS", rNfe.ItensNota.Sum(v=> v.Vl_icms + v.Vl_FCP));
                                Rel.Parametros_Relatorio.Add("VL_BASEICMS", rNfe.ItensNota.Sum(v=> v.Vl_basecalcICMS));
                                Rel.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_basecalcSTICMS));
                                Rel.Parametros_Relatorio.Add("VL_ICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_ICMSST + v.Vl_FCPST));

                                //Buscar conf impressao da nota fiscal
                                obj = new CamadaDados.Faturamento.Cadastros.TCD_CFGImpNF().BuscarEscalar(
                                                new Utils.TpBusca[]
                                                            {
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + rNfe.Cd_empresa.Trim() + "'"
                                                                },
                                                                new Utils.TpBusca()
                                                                {
                                                                    vNM_Campo = "a.nr_serie",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + rNfe.Nr_serie.Trim() + "'"
                                                                }
                                                            }, "a.QT_ItensNota");
                                if (obj != null)
                                    if (rNfe.ItensNota.Count < Convert.ToDecimal(obj.ToString()))
                                        while (rNfe.ItensNota.Count < Convert.ToDecimal(obj.ToString()))
                                            rNfe.ItensNota.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item());
                            }
                            BinDados.DataSource = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento() { rNfe };
                            Rel.DTS_Relatorio = BinDados;
                            //Buscar financeiro da DANFE
                            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'L'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                                        "inner join tb_fat_notafiscal_x_duplicata y " +
                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                        "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                                        "where isnull(x.st_registro, 'A') <> 'C' " +
                                                                        "and x.cd_empresa = a.cd_empresa " +
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and y.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                                        "and y.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal.ToString() + ")"
                                                        }
                                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);

                            if (lParc.Count == 0)
                            {
                                //Verificar se a nota foi vinculada de um cupom e buscar o Financeiro
                                lParc =
                                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                    new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'L'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                                        "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                        "and x.nr_lancto = y.nr_lancto " +
                                                                        "inner join TB_PDV_Cupom_X_VendaRapida k " +
                                                                        "on y.cd_empresa = k.cd_empresa " +
                                                                        "and y.id_cupom = k.id_vendarapida " +
                                                                        "inner join TB_FAT_ECFVinculadoNF z " +
                                                                        "on k.cd_empresa = z.cd_empresa " +
                                                                        "and k.id_cupom = z.id_cupom " +
                                                                        "where isnull(x.st_registro, 'A') <> 'C' " +
                                                                        "and x.cd_empresa = a.cd_empresa " +
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and z.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                                        "and z.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                                        }
                                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                                if (lParc.Count == 0)
                                {
                                    //Verificar se Nota foi gerada de uma venda rapida e buscar o Financeiro
                                    lParc =
                                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'L'",
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                                "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                "and x.nr_lancto = y.nr_lancto " +
                                                                "inner join TB_PDV_Pedido_X_VendaRapida k " +
                                                                "on k.cd_empresa = y.cd_empresa " +
                                                                "and k.id_vendarapida = y.id_cupom " +
                                                                "inner join TB_FAT_NotaFiscal z " +
                                                                "on z.cd_empresa = k.cd_empresa " +
                                                                "and z.nr_pedido = k.nr_pedido " +
                                                                "where isnull(x.st_registro, 'A') <> 'C' " +
                                                                "and x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lancto = a.nr_lancto " +
                                                                "and z.cd_empresa = '" + rNfe.Cd_empresa.Trim() + "' " +
                                                                "and z.nr_lanctofiscal = " + rNfe.Nr_lanctofiscal + ")"
                                                }
                                           }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                                }
                            }
                            if (lParc.Count > 0)
                                for (int i = 0; i < lParc.Count; i++)
                                {
                                    if (i < 12)
                                    {
                                        Rel.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                                        Rel.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].cVl_atual);
                                    }
                                    else
                                        break;
                                }
                            Rel.Nome_Relatorio = "TFLanFaturamento_Danfe";
                            Rel.NM_Classe = "TFLanConsultaNFe";
                            Rel.Modulo = "FAT";
                            Rel.Ident = "TFLanFaturamento_Danfe";
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = rNfe.Cd_clifor;
                            fImp.pMensagem = "DANFE Nº" + rNfe.Nr_notafiscal.ToString();
                            fImp.St_danfe = true;
                            //Verificar se existe logo configurada para a empresa
                            object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                            new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + rNfe.Cd_empresa.Trim() + "'"
                                                            }
                                                        }, "a.logoEmpresa");
                            if (log != null)
                                Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
                            if (Altera_Relatorio)
                            {
                                Rel.Gera_Relatorio(string.Empty,
                                                   fImp.pSt_imprimir,
                                                   fImp.pSt_visualizar,
                                                   fImp.pSt_enviaremail,
                                                   fImp.pSt_exportPdf,
                                                   fImp.Path_exportPdf,
                                                   fImp.pDestinatarios,
                                                   null,
                                                   "DANFE",
                                                   fImp.pDs_mensagem);
                                Altera_Relatorio = false;
                            }
                            else if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            {
                                List<string> Anexo = null;
                                if (fImp.St_receberXmlNfe)
                                {
                                    string path_anexo = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlString("PATH_ANEXO_EMAIL", null);
                                    if (!string.IsNullOrEmpty(path_anexo))
                                    {
                                        if (!System.IO.Directory.Exists(path_anexo))
                                            System.IO.Directory.CreateDirectory(path_anexo);
                                        if (!path_anexo.EndsWith("\\"))
                                            path_anexo += System.IO.Path.DirectorySeparatorChar.ToString();

                                        //Limpar diretorio path arquivo
                                        string[] arq = System.IO.Directory.GetFiles(path_anexo.Trim(), "*.xml");
                                        try
                                        {
                                            srvNFE.GerarArq.TGerarArq2.GerarArqXmlPeriodo(path_anexo,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          rNfe.Cd_empresa,
                                                                                          rNfe.Nr_notafiscal.ToString(),
                                                                                          rNfe.rCfgNfe);
                                        }
                                        catch { }
                                        //Ler arquivo gerado
                                        Anexo = new List<string>();
                                        Anexo.Add(path_anexo + rNfe.Chave_acesso_nfe.Trim() + "-nfe.xml");
                                    }
                                }
                                Rel.Gera_Relatorio(string.Empty,
                                                   fImp.pSt_imprimir,
                                                   fImp.pSt_visualizar,
                                                   fImp.pSt_enviaremail,
                                                   fImp.pSt_exportPdf,
                                                   fImp.Path_exportPdf,
                                                   fImp.pDestinatarios,
                                                   Anexo,
                                                   "DANFE",
                                                   fImp.pDs_mensagem);
                            }
                        }
                    }
                    catch { }
                else
                    MessageBox.Show("Lote Processado com Sucesso.\r\nNota Fiscal não foi aceita pela receita.\r\n" +
                    "Verifique o erro na tela de controle de NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Erro ao processar Lote NFe.\r\n" +
                    "Verifique o erro na tela de controle de NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFGerenciarNFe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void TFGerenciarNFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.P))
                Altera_Relatorio = true;
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            tempo.Enabled = false;
            bool st_loteproc = false;
            try
            {
                if (string.IsNullOrEmpty(rNfe.rCfgNfe.Nr_certificado_nfe))
                    throw new Exception("Não existe configuração para envio de NF-e para a empresa " + rNfe.rCfgNfe.Cd_empresa.Trim() + ".");
                //Enviar NFe
                st_loteproc = srvNFE.EnviaArq.TEnviarArq2.EnviarLoteNfe2(0, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNfe }, rNfe.rCfgNfe);
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Erro enviar NFe: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (st_loteproc)
            {
                this.ImprimirDanfe();
                this.Close();
            }
            else
                try
                {
                    this.ConsultarLote();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
