using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Commoditties
{
    public partial class TFLanEmbalagem : Form
    {
        public TFLanEmbalagem()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            nr_contrato.Clear();
            cd_empresa.Clear();
            cd_clifor.Clear();
        }

        private void afterBusca()
        {
            bsContrato.DataSource = CamadaNegocio.Graos.TCN_CadContrato.BuscarContrato("'E'",
                                                                                       nr_contrato.Text,
                                                                                       cd_empresa.Text,
                                                                                       cd_clifor.Text,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       "'A'",
                                                                                       string.Empty,
                                                                                       null);
            bsContrato_PositionChanged(this, new EventArgs());
        }

        private void EmprestarEmbalagem()
        {
            if (bsContrato.Current != null)
            {
                if (!string.IsNullOrEmpty((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_produtoembalagem))
                    using (TFEmbalagem fEmbalagem = new TFEmbalagem())
                    {
                        fEmbalagem.Tp_mov = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Tp_movimento.Trim().ToUpper().Equals("E") ? "S" : "E";
                        fEmbalagem.Cd_empresa = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_empresa;
                        fEmbalagem.Nm_empresa = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nm_empresa;
                        fEmbalagem.Cd_produto = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_produtoembalagem;
                        fEmbalagem.Ds_produto = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Ds_produtoembalagem;
                        fEmbalagem.Sigla_unidade = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Sigla_undembalagem;
                        fEmbalagem.Cd_local = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_localembalagem;
                        fEmbalagem.Ds_local = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Ds_localembalagem;
                        if (fEmbalagem.ShowDialog() == DialogResult.OK)
                            if (fEmbalagem.rEstoque != null)
                            {
                                fEmbalagem.rEstoque.Tp_lancto = "N";
                                CamadaNegocio.Graos.TCN_Contrato_X_EstoqueEmbalagem.EmprestarEmbalagem(bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato,
                                                                                                       fEmbalagem.rEstoque,
                                                                                                       null);
                                MessageBox.Show("Registro Gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimparFiltros();
                                nr_contrato.Text = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contratostr;
                                this.afterBusca();
                            }
                    }
                else
                    MessageBox.Show("Não existe produto embalagem configurado para o contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Obrigatorio selecionar contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DevolverEmbalagem()
        {
            if (bsContrato.Current != null)
            {
                if (!string.IsNullOrEmpty((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_produtoembalagem))
                    using (TFEmbalagem fEmbalagem = new TFEmbalagem())
                    {
                        fEmbalagem.Tp_mov = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Tp_movimento.Trim().ToUpper().Equals("E") ? "E" : "S";
                        fEmbalagem.Cd_empresa = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_empresa;
                        fEmbalagem.Nm_empresa = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nm_empresa;
                        fEmbalagem.Cd_produto = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_produtoembalagem;
                        fEmbalagem.Ds_produto = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Ds_produtoembalagem;
                        fEmbalagem.Sigla_unidade = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Sigla_undembalagem;
                        fEmbalagem.Cd_local = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Cd_localembalagem;
                        fEmbalagem.Ds_local = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Ds_localembalagem;
                        if (fEmbalagem.ShowDialog() == DialogResult.OK)
                            if (fEmbalagem.rEstoque != null)
                            {
                                fEmbalagem.rEstoque.Tp_lancto = "N";
                                CamadaNegocio.Graos.TCN_Contrato_X_EstoqueEmbalagem.DevolverEmbalagem(bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato,
                                                                                                       fEmbalagem.rEstoque,
                                                                                                       null);
                                MessageBox.Show("Registro Gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimparFiltros();
                                nr_contrato.Text = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contratostr;
                                this.afterBusca();
                            }
                    }
                else
                    MessageBox.Show("Não existe produto embalagem configurado para o contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Obrigatorio selecionar contrato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirLancamento()
        {
            if (bsEstoqueEmbalagem.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro de estoque Nº " + (bsEstoqueEmbalagem.Current as CamadaDados.Estoque.TRegistro_LanEstoque).Id_lanctoestoque.ToString() + "?",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    CamadaNegocio.Estoque.TCN_LanEstoque.DeletarEstoque(bsEstoqueEmbalagem.Current as CamadaDados.Estoque.TRegistro_LanEstoque, null);
                    MessageBox.Show("Lançamento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimparFiltros();
                    nr_contrato.Text = (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contratostr;
                    this.afterBusca();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lançamento de embalagem para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLanEmbalagem_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gContrato);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault5);
            pFiltro.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pFiltro.set_FormatZero();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';isnull(a.st_registro, 'A')|<>|'C'"
                , new Componentes.EditDefault[] { cd_clifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bsContrato_PositionChanged(object sender, EventArgs e)
        {
            if(bsContrato.Current != null)
                if ((bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contrato != null)
                {
                    //Buscar estoque embalagem
                    (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).lEstoqueEmbalagem =
                        CamadaNegocio.Graos.TCN_Contrato_X_EstoqueEmbalagem.BuscarEstoque(
                                                                                          (bsContrato.Current as CamadaDados.Graos.TRegistro_CadContrato).Nr_contrato.Value.ToString(),
                                                                                          null);
                    bsContrato.ResetCurrentItem();
                }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Emprestar_Click(object sender, EventArgs e)
        {
            this.EmprestarEmbalagem();
        }

        private void BB_Devolver_Click(object sender, EventArgs e)
        {
            this.DevolverEmbalagem();
        }

        private void TFLanEmbalagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.EmprestarEmbalagem();
            else if (e.KeyCode.Equals(Keys.F10))
                this.DevolverEmbalagem();
            else if (e.KeyCode.Equals(Keys.F11))
                this.ExcluirLancamento();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.ExcluirLancamento();
        }

        private void TFLanEmbalagem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gContrato);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault5);
        }
    }
}
