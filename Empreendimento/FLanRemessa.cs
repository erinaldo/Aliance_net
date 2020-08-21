using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Empreendimento;
using CamadaNegocio.Empreendimento;
using CamadaNegocio.Diversos;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using FormRelPadrao;
using Componentes;
using FormBusca;

namespace Empreendimento
{
    public partial class TFLanRemessa : Form
    {
        private bool Altera_Relatorio = false;
        public string vClifor { get; set; }
        public string vEmpresa { get; set; }
        public string vNr_Versao { get; set; }
        public string vId_Orcamento { get; set; }
        public string vdt_ini { get; set; }
        public string vdt_fin { get; set; }
        public string vId_vendedor { get; set; }


        public TFLanRemessa()
        {
            InitializeComponent();
        }
        private void afterBusca()
        {
            bsOrcamento.DataSource = TCN_Orcamento.Buscar(cd_empresa.Text,
                                                          id_orcamento.Text,
                                                          nr_versao.Text,
                                                          cd_clifor.Text,
                                                          string.Empty,
                                                          //rbIni.Checked ? "I" : rbFin.Checked ? "F" :
                                                          string.Empty,
                                                          dt_ini.Text,
                                                          dt_fin.Text,
                                                          "= 'E'",
                                                          //st_projeto.Checked ? "= 'T'" : st_finalizado.Checked ? "= 'F'" : st_aprovadorep.Checked ? "= 'R' OR isnull(a.st_registro, 'A') = 'P' " : "= 'A' OR ISNULL(a.st_registro,'A') = 'N' ",
                                                          null);
            bsOrcamento_PositionChanged(this, new EventArgs());
            bsOrcamento.ResetCurrentItem();
        }
        private void FLanRemessa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
         //   pFiltro.set_FormatZero();
            cd_clifor.Text = vClifor;
            cd_empresa.Text = vEmpresa;
            cd_vendedor.Text = vId_vendedor;
            id_orcamento.Text = vId_Orcamento;
            nr_versao.Text = vNr_Versao;
            dt_ini.Text = vdt_ini;
            dt_fin.Text = vdt_fin;
            afterBusca();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void panelDados1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bbOrcamento_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                //Buscar Projetos
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto =
                    TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          string.Empty,
                                          string.Empty,
                                          null);
                bsOrcamento.ResetCurrentItem();

                //if (!(string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).nr_lanctofiscal)))
                //{
                //    bsNotaFiscal.DataSource =
                //                new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                //                    new TpBusca[]
                //                { 
                //                    new TpBusca()
                //                    {
                //                        vNM_Campo = string.Empty,
                //                        vOperador = "exists",
                //                        vVL_Busca = "(select 1 from tb_fat_pedido x "+
                //                                    "where x.Nr_Pedido = a.nr_pedido "+
                //                                    "and x.nr_pedido = "+(bsOrcamento.Current as TRegistro_Orcamento).nr_lanctofiscal.ToString()+")"
                //                    }
                //                }, 0, string.Empty);
                //    bsNotaFiscal.ResetCurrentItem();

                //}

                if (bsProjeto.Current != null)
                    (bsProjeto.Current as TRegistro_OrcProjeto).lFicha =
                        TCN_FichaTec.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                              (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                              (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                              string.Empty,
                                              string.Empty,
                                        string.Empty,
                                              null);
                bsItens.ResetCurrentItem();
            }
            else
                MessageBox.Show("Selecione um Projeto!","Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void bbFatuProjeto_Click(object sender, EventArgs e)
        {
            if (bsProjeto.Current != null)
            {
                using (FItensRemessa itensRemessa = new FItensRemessa())
                {
                    itensRemessa.rOrcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                    itensRemessa.vNr_Versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                    itensRemessa.vCD_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                    itensRemessa.vID_Orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;

                    if (itensRemessa.ShowDialog() == DialogResult.OK)
                    {
                    }
                }
            }
            else
                MessageBox.Show("Selecione um projeto!", "Mensagem", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);


        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsProjeto_PositionChanged(object sender, EventArgs e)
        {
            if(bsProjeto.Current != null)
            (bsProjeto.Current as TRegistro_OrcProjeto).lFicha =
                TCN_FichaTec.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                      (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                      (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                      string.Empty,
                                      string.Empty,
                                        string.Empty,
                                      null);
            bsItens.ResetCurrentItem();
        }

        private void Imprime_Danfe()
        {
            FormRelPadrao.Relatorio Danfe = new FormRelPadrao.Relatorio();
            Danfe.Altera_Relatorio = Altera_Relatorio;
            //Buscar NFe
            TRegistro_LanFaturamento rNfe = TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                        null);
            //Buscar Itens NFe
            rNfe.ItensNota = TCN_LanFaturamento_Item.Busca(rNfe.Cd_empresa,
                                                           rNfe.Nr_lanctofiscalstr,
                                                           string.Empty,
                                                           null);
            Danfe.Parametros_Relatorio.Add("VL_IPI", rNfe.ItensNota.Sum(v=> v.Vl_ipi));
            Danfe.Parametros_Relatorio.Add("VL_ICMS", rNfe.ItensNota.Sum(v=> v.Vl_icms + v.Vl_FCP));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMS", rNfe.ItensNota.Sum(v=> v.Vl_basecalcICMS));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_basecalcSTICMS));
            Danfe.Parametros_Relatorio.Add("VL_ICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_ICMSST + v.Vl_FCPST));

            BindingSource Bin = new BindingSource();
            Bin.DataSource = new TList_RegLanFaturamento() { rNfe };
            Danfe.Nome_Relatorio = "TFLanFaturamento_Danfe";
            Danfe.NM_Classe = "TFLanConsultaNFe";
            Danfe.Modulo = "FAT";
            Danfe.Ident = "TFLanFaturamento_Danfe";
            Danfe.DTS_Relatorio = Bin;
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
                                                        "and y.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                        "and y.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                        }
                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            if (lParc.Count == 0)
            {
                //Verificar se Nota a nota foi vinculada de um cupom e buscar o Financeiro
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
                                                            "and z.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
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
                                                            "inner join TB_PDV_Pedido_X_VendaRapida k " +
                                                            "on k.cd_empresa = y.cd_empresa " +
                                                            "and k.id_vendarapida = y.id_cupom " +
                                                            "inner join TB_FAT_NotaFiscal z " +
                                                            "on z.cd_empresa = k.cd_empresa " +
                                                            "and z.nr_pedido = k.nr_pedido " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                            }
                                       }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                }
            }
            if (lParc.Count > 0)
            {
                for (int i = 0; i < lParc.Count; i++)
                {
                    if (i < 12)
                    {
                        Danfe.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                        Danfe.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                    }
                    else
                        break;
                }
            }
            //Verificar se existe logo configurada para a empresa
            object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                            new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.logoEmpresa");
            if (log != null)
                Danfe.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
            Danfe.Gera_Relatorio();
        }


        private void afterPrint()
        {
            if (bsNotaFiscal.Current != null)
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                {
                    //Verificar o status de retorno da NF-e
                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.Status",
                                            vOperador = "=",
                                            vVL_Busca = "'100'"
                                        }
                                    }, "1");
                    if (obj != null)
                    {
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                            fImp.pMensagem = "NF-e Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Imprime_Danfe();
                        }
                    }
                    else
                        MessageBox.Show("Permitido imprimir DANFE somente de NF-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal de terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                        fImp.pMensagem = "NOTA FISCAL Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                           null),
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pDestinatarios,
                                               "NOTA FISCAL Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                               fImp.pDs_mensagem);
                    }
                }
        }
        private void toolStripButton40_Click(object sender, EventArgs e)
        {
            afterPrint();
        }
        private void Imprime_NotaFiscal(TRegistro_LanFaturamento rNf,
                                        bool St_imprimir,
                                        bool St_visualizar,
                                        bool St_enviaremail,
                                        List<string> Destinatarios,
                                        string Titulo,
                                        string Mensagem)
        {
            LayoutNotaFiscal Relatorio = new LayoutNotaFiscal();
            Relatorio.Imprime_NF(rNf,
                                St_imprimir,
                                St_visualizar,
                                St_enviaremail,
                                Destinatarios,
                                Titulo,
                                Mensagem);
        }

        private void tsnotafiscal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
