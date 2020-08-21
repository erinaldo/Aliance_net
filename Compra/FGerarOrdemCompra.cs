using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;

namespace Compra
{
    public partial class TFGerarOrdemCompra : Form
    {
        public TFGerarOrdemCompra()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsRequisicao.DataSource = CamadaNegocio.Compra.Lancamento.TCN_Requisicao.Buscar(id_requisicao.Text,
                                                                                            cd_empresa.Text,
                                                                                            cd_produto.Text,
                                                                                            cd_clifor_requisitante.Text,
                                                                                            string.Empty,
                                                                                            DT_Inic.Text,
                                                                                            DT_Final.Text,
                                                                                            "'AP'",
                                                                                            false,
                                                                                            false,
                                                                                            false,
                                                                                            "'E'",
                                                                                            false,
                                                                                            null);
        }

        private void afterGrava()
        {
            if (bsRequisicao.Count > 0)
            {
                if (MessageBox.Show("Confirma processamento das requisições selecionadas?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        List<CamadaDados.Compra.Lancamento.TRegistro_Requisicao> lReqProc = (bsRequisicao.DataSource as CamadaDados.Compra.Lancamento.TList_Requisicao).FindAll(p=> p.St_integrar);
                        CamadaNegocio.Compra.Lancamento.TCN_Requisicao.ProcessarOrdemCompra(lReqProc, null);
                        MessageBox.Show("Requisições processadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TFGerarOrdemCompra_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gRequisicao);
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            this.afterBusca();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa }
                          , new TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new TCD_CadEmpresa());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vCond = "a.cd_produto|=|'" + cd_produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(string.Empty, new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_clifor_requisitante_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_cmp_usuariocompra x " +
                            "where x.cd_clifor_cmp = a.cd_clifor " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor_requisitante }, vParam);
        }

        private void cd_clifor_requisitante_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_clifor_requisitante.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C';" +
                            "|exists|(select 1 from tb_cmp_usuariocompra x " +
                            "where x.cd_clifor_cmp = a.cd_clifor " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_clifor_requisitante },
                                    new TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsRequisicao_PositionChanged(object sender, EventArgs e)
        {
            if (bsRequisicao.Current != null)
                if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao != null)
                {
                    //Buscar lista de negociacao
                    if((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lReqneg.Count < 1)
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lReqneg =
                            CamadaNegocio.Compra.Lancamento.TCN_Requisicao_X_Negociacao.Buscar(
                            (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.Value.ToString(),
                            string.Empty,
                            0, string.Empty, null);
                    //Buscar lista de cotacao
                    if ((bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes.Count < 1)
                        (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).lCotacoes =
                            CamadaNegocio.Compra.Lancamento.TCN_Cotacao.Buscar(string.Empty,
                                                                               string.Empty,
                                                                               (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Cd_empresa,
                                                                               (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).Id_requisicao.Value.ToString(),
                                                                               0,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               null);

                    bsRequisicao.ResetCurrentItem();
                }
        }

        private void gRequisicao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
                (bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_integrar =
                    !(bsRequisicao.Current as CamadaDados.Compra.Lancamento.TRegistro_Requisicao).St_integrar;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFGerarOrdemCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void TFGerarOrdemCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gRequisicao);
        }
    }
}
