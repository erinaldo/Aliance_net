using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFCorrigirDesdobroAplicar : Form
    {
        private bool St_alterar = false;

        public List<CamadaDados.Balanca.TRegistro_DesdobroAplicar> lDesd
        { get; set; }

        public TFCorrigirDesdobroAplicar()
        {
            InitializeComponent();
        }

        private void TFCorrigirDesdobroAplicar_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gDesdobro);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsDesdobro.DataSource = lDesd;
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            string vParam = "a.cd_modelo|=|'04'";//Nota Fiscal Produtor
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_SerieNF|Descrição Série|350;a.NR_Serie|Cód. Série|100",
                                                       new Componentes.EditDefault[] { nr_serie },
                                                       new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF(), vParam);
        }

        private void nr_serie_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_serie|=|'" + nr_serie.Text.Trim() + "';" +
                            "a.cd_modelo|=|'04'";//Nota Fiscal Produtor
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_serie },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF());
        }

        private void bb_alterar_Click(object sender, EventArgs e)
        {
            if (bsDesdobro.Current != null)
            {
                nr_serie.Enabled = true;
                bb_serie.Enabled = true;
                nr_notafiscal.Enabled = true;
                dt_emissao.Enabled = true;
                DT_SaiEnt.Enabled = true;
                qtd_nota.Enabled = true;
                vl_unitario.Enabled = true;
                vl_subtotal.Enabled = true;
                vl_basecalc.Enabled = true;
                vl_icms.Enabled = true;

                bb_alterar.Enabled = false;
                bb_gravar.Enabled = true;
                this.St_alterar = true;
            }
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            if (bsDesdobro.Current != null)
            {
                //Buscar registro desdobro clifor
                CamadaDados.Balanca.TList_RegLanPesagemClifor lClifor =
                CamadaNegocio.Balanca.TCN_LanPesagemClifor.Busca((bsDesdobro.Current as CamadaDados.Balanca.TRegistro_DesdobroAplicar).Cd_empresa,
                                                                 (bsDesdobro.Current as CamadaDados.Balanca.TRegistro_DesdobroAplicar).Id_ticket.ToString(),
                                                                 (bsDesdobro.Current as CamadaDados.Balanca.TRegistro_DesdobroAplicar).Tp_pesagem,
                                                                 (bsDesdobro.Current as CamadaDados.Balanca.TRegistro_DesdobroAplicar).Id_desdobro.ToString(),
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 false,
                                                                 1,
                                                                 string.Empty,
                                                                 null);
                if (lClifor.Count > 0)
                {
                    lClifor[0].Nr_serie = nr_serie.Text;
                    lClifor[0].Nr_notafiscal = nr_notafiscal.Text;
                    if (dt_emissao.Text.Trim() != "/  /")
                        lClifor[0].Dt_emissaostr = dt_emissao.Text;
                    if (DT_SaiEnt.Text.Trim() != "/  /")
                        lClifor[0].Dt_saientstr = DT_SaiEnt.Text;
                    try
                    {
                        CamadaNegocio.Balanca.TCN_LanPesagemClifor.GravarPesagemClifor(lClifor[0], null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                //Buscar registro Desdobro produto
                CamadaDados.Balanca.TList_RegLanPesagemProduto lProd =
                    CamadaNegocio.Balanca.TCN_LanPesagemProduto.Busca((bsDesdobro.Current as CamadaDados.Balanca.TRegistro_DesdobroAplicar).Cd_empresa,
                                                                      (bsDesdobro.Current as CamadaDados.Balanca.TRegistro_DesdobroAplicar).Id_ticket.ToString(),
                                                                      (bsDesdobro.Current as CamadaDados.Balanca.TRegistro_DesdobroAplicar).Tp_pesagem,
                                                                      string.Empty,
                                                                      (bsDesdobro.Current as CamadaDados.Balanca.TRegistro_DesdobroAplicar).Id_desdobro.ToString(),
                                                                      (bsDesdobro.Current as CamadaDados.Balanca.TRegistro_DesdobroAplicar).Id_item.ToString(),
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      1,
                                                                      string.Empty,
                                                                      null);
                if (lProd.Count > 0)
                {
                    lProd[0].Qtd_nota = qtd_nota.Value;
                    lProd[0].Vl_unitario = vl_unitario.Value;
                    lProd[0].Vl_subtotal = vl_subtotal.Value;
                    lProd[0].Vl_basecalc = vl_basecalc.Value;
                    lProd[0].Vl_icms = vl_icms.Value;
                    try
                    {
                        CamadaNegocio.Balanca.TCN_LanPesagemProduto.GravarPesagemProduto(lProd[0], null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                //Alterar status da tela
                nr_serie.Enabled = false;
                bb_serie.Enabled = false;
                nr_notafiscal.Enabled = false;
                dt_emissao.Enabled = false;
                DT_SaiEnt.Enabled = false;
                qtd_nota.Enabled = false;
                vl_unitario.Enabled = false;
                vl_subtotal.Enabled = false;
                vl_basecalc.Enabled = false;
                vl_icms.Enabled = false;

                bb_alterar.Enabled = true;
                bb_gravar.Enabled = false;
                this.St_alterar = false;
                //Move para o proximo registro
                bsDesdobro.MoveNext();
            }
        }

        private void TFCorrigirDesdobroAplicar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gDesdobro);
            if (this.St_alterar)
            {
                MessageBox.Show("Existe alterações pendentes para salvar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
    }
}
