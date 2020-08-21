using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFDevolverCond : Form
    {
        public List<CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional> lItens
        {
            get
            {
                if (bsItens.Count > 0)
                    return (bsItens.List as CamadaDados.Faturamento.PDV.TList_ItensCondicional).FindAll(p => p.Qtd_devolver > decimal.Zero);
                else
                    return null;
            }
        }

        public string Cd_empresa
        { get; set; }
        public string Id_condicional
        { get; set; }
        public string Cd_clifor
        { get { return cd_clifor.Text; } }
        public bool St_faturar
        { get; set; }
        public string Tp_movimento
        { get; set; }

        public TFDevolverCond()
        {
            InitializeComponent();
            this.Tp_movimento = string.Empty;
        }

        private void afterGrava()
        {
            if ((!string.IsNullOrEmpty(id_condicional.Text)) && string.IsNullOrEmpty(cd_clifor.Text))
            {
                object obj = new CamadaDados.Faturamento.PDV.TCD_Condicional().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_condicional",
                                        vOperador = "=",
                                        vVL_Busca = id_condicional.Text
                                    }
                                }, "a.cd_clifor");
                cd_clifor.Text = obj != null ? obj.ToString() : string.Empty;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[5];
            //Condicional ativo
            filtro[0].vNM_Campo = "isnull(cond.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            //Item Ativo
            filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[1].vOperador = "<>";
            filtro[1].vVL_Busca = "'C'";
            //Saldo Devolver
            filtro[2].vNM_Campo = "(a.Quantidade - a.Qtd_devolvida)";
            filtro[2].vOperador = ">";
            filtro[2].vVL_Busca = "0";
            //Tipo movimento
            filtro[3].vNM_Campo = "cond.tp_movimento";
            filtro[3].vOperador = "=";
            filtro[3].vVL_Busca = "'" + (rbEntrada.Checked ? "E" : "S") + "'";
            //Empresa
            filtro[4].vNM_Campo = "a.cd_empresa";
            filtro[4].vOperador = "=";
            filtro[4].vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'";
            //Clifor
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "cond.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            }
            //Condicional
            if (!string.IsNullOrEmpty(id_condicional.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_condicional";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_condicional.Text;
            }
            //Produto
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_produto.Text.Trim() + "'";
            }
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (rbCondicional.Checked ? "cond.dt_condicional" : "cond.dt_prevdevolucao") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (rbCondicional.Checked ? "cond.dt_condicional" : "cond.dt_prevdevolucao") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
            }

            bsItens.DataSource = new CamadaDados.Faturamento.PDV.TCD_ItensCondicional().Select(filtro, 0, string.Empty);
            if (!(bsItens.Count > 0))
                MessageBox.Show("Não existe itens válidos para esta busca.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFDevolverCond_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            if (cbEmpresa.Items.Count > 0)
                if (!string.IsNullOrEmpty(Cd_empresa))
                    cbEmpresa.SelectedValue = Cd_empresa;
                else cbEmpresa.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(this.Tp_movimento))
                if (this.Tp_movimento.Trim().ToUpper().Equals("E"))
                    rbEntrada.Checked = true;
                else if (this.Tp_movimento.Trim().ToUpper().Equals("S"))
                    rbSaida.Checked = true;
            rgMovimento.Enabled = string.IsNullOrEmpty(this.Tp_movimento);
            id_condicional.Text = Id_condicional;
            cd_clifor.Text = Cd_clifor;
            cd_clifor.Enabled = string.IsNullOrEmpty(Cd_clifor);
            bb_clifor.Enabled = cd_clifor.Enabled;
            if ((cbEmpresa.SelectedItem != null) &&
                (!string.IsNullOrEmpty(id_condicional.Text)))
            {
                id_condicional.Text = Id_condicional;
                this.afterBusca();
            }
            qtd_faturar.Enabled = St_faturar && rbSaida.Checked;

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

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsItens.MoveNext();
            qtd_devolver.Focus();
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            bsItens.MovePrevious();
            qtd_devolver.Focus();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void qtd_devolver_Leave(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (qtd_devolver.Value > (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Saldo_devolver)
                {
                    qtd_devolver.Value = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Saldo_devolver;
                    bsItens.ResetCurrentItem();
                }
                if (qtd_faturar.Value > qtd_devolver.Value)
                {
                    qtd_faturar.Value = qtd_devolver.Value;
                    bsItens.ResetCurrentItem();
                }
            }
            if (!qtd_faturar.Focus())
                bb_avancar.Focus();
        }

        private void qtd_faturar_Leave(object sender, EventArgs e)
        {
            if (qtd_faturar.Value > qtd_devolver.Value)
            {
                qtd_faturar.Value = qtd_devolver.Value;
                bsItens.ResetCurrentItem();
            }
            bb_avancar.Focus();
        }

        private void qtd_faturar_KeyDown(object sender, KeyEventArgs e)
        {
            this.TFDevolverCond_KeyDown(sender, e);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDevolverCond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F12) &&
                    cbEmpresa.SelectedItem != null)
                this.BuscarProduto();
        }

        private void rbSaida_CheckedChanged(object sender, EventArgs e)
        {
            qtd_faturar.Enabled = St_faturar && rbSaida.Checked;
            this.afterBusca();
        }
        
        private void BuscarProduto()
        {
            if (string.IsNullOrEmpty(cd_prod.Text))
                FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                     cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                     string.Empty,
                                                     string.Empty,
                                                     new Componentes.EditDefault[] { cd_prod, cd_produto },
                                                     null);
            else
                FormBusca.UtilPesquisa.BuscarProduto(cd_prod.Text,
                                                     cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                     string.Empty,
                                                     string.Empty,
                                                     new Componentes.EditDefault[] { cd_prod, cd_produto },
                                                     null);
            for (int i = 0; i < bsItens.Count; i++)
            {
                if ((bsItens.List[i] as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Cd_produto.Equals(cd_prod.Text))
                {
                    bsItens.Position = i;
                    return;
                }
            }
            qtd_devolver.Focus();
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Cd_produto))
                    cd_prod.Text = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Cd_produto;
            }
            else
            {
                pValores.LimparRegistro();
            }
        }

        private void cd_prod_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_prod.Text) && string.IsNullOrEmpty(cd_produto.Text))
                cd_produto.Text = cd_prod.Text;
        }

        private void qtd_devolver_ValueChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                new  Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" +(bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Cd_produto.Trim() + "'"
                                }
                                }, "a.id_caracteristicaH");
                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                    using (Proc_Commoditties.TFGradeProduto fGrade = new Proc_Commoditties.TFGradeProduto())
                    {
                        fGrade.pId_caracteristica = obj.ToString();
                        fGrade.pCd_empresa = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Cd_empresa;
                        fGrade.pCd_produto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Cd_produto;
                        fGrade.pDs_produto = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Ds_produto;
                        fGrade.pQuantidade = (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Quantidade;
                        fGrade.pTp_movimento = "E";
                        if (fGrade.ShowDialog() == DialogResult.OK)
                        {
                            fGrade.lGrade.ForEach(p => (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).lGrade.Add(p));
                            qtd_devolver.Value = fGrade.lGrade.Sum(p => p.Vl_mov);
                            //   Quantidade.Enabled = false;
                            //if (vl_unitario.Enabled)
                            //    vl_unitario.Focus();
                            //else if (pc_desconto.Enabled)
                            //    pc_desconto.Focus();
                            //else pc_acrescimo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar grade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsItens.RemoveCurrent();
                        }
                    }
                //AddCarrinho();
                //LoginDesconto = string.Empty;
            }
        }

        private void cd_prod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                this.BuscarProduto();
        }
    }
}
