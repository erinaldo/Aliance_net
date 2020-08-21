using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Servicos;
using FormBusca;
using Utils;

namespace Servicos
{
    public partial class TFItensFaturar : Form
    {
        public bool St_servico
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public List<TRegistro_LanServicosPecas> lItemOS
        {
            get
            {
                if (BS_ItensOS.Count > 0)
                    return (BS_ItensOS.DataSource as TList_LanServicosPecas).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public TFItensFaturar()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_clifor.Text))
            {
                MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_clifor.Focus();
                return;
            }
            TpBusca[] filtro = new TpBusca[4];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'";
            //Clifor
            filtro[1].vNM_Campo = "os.cd_clifor";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            //Filtrar Tipo de Produto
            filtro[2].vNM_Campo = "a.st_servico";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = St_servico.Equals(true) ? "'S'" : "'N'";
            //Nao ter sido vinculado a NF Ativa
            filtro[3].vNM_Campo = string.Empty;
            filtro[3].vOperador = string.Empty;
            filtro[3].vVL_Busca = "isnull(a.quantidade, 0) -  isnull((select sum(isnull(k.quantidade, 0)) " +
                                  "from tb_fat_notafiscal_item k " +
                                  "left outer join TB_FAT_Notafiscal w " +
                                  "on k.cd_empresa = w.cd_empresa " +
                                  "and k.nr_lanctofiscal = w.nr_lanctofiscal " +
                                  "inner join TB_OSE_Servico_X_PedidoItem x " +
                                  "on x.nr_pedido = k.nr_pedido " +
                                  "and x.cd_produto = k.cd_produto " +
                                  "and x.id_pedidoitem = k.id_pedidoitem " +
                                  "inner join TB_FAT_Pedido_Itens y " +
				                  "on x.NR_Pedido = y.Nr_Pedido " +
				                  "and x.id_pedidoitem = y.id_pedidoitem " +
				                  "where x.id_os = a.id_os " +
				                  "and x.cd_produto = a.cd_produto " +
                                  "and ISNULL(y.ST_Registro, 'A') <> 'C' " +
                                  "and ISNULL(w.ST_Registro, 'A') <> 'C' " +
                                  "and x.cd_empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "'), 0) > 0";
            if (dt_abertura.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), os.dt_abertura)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_abertura.Text).ToString("yyyyMMdd")) + "'";
            }
            if (dt_final.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), os.dt_abertura)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_final.Text).ToString("yyyyMMdd")) + "'";
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_produto.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(TP_Ordem.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "os.TP_Ordem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + TP_Ordem.Text.Trim() + "'";
            }
            BS_ItensOS.DataSource = new TCD_LanServicosPecas().Select(filtro, 0, string.Empty, string.Empty);
            tot_OS.Value = (BS_ItensOS.DataSource as TList_LanServicosPecas).Sum(p => p.Vl_SubTotalLiq);
            //Trazer Clifor
            pCd_clifor = cd_clifor.Text;
        }

        private void afterGrava()
        {
            if (BS_ItensOS.Count.Equals(0))
            {
                MessageBox.Show("Não existe Itens para faturar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!(BS_ItensOS.DataSource as TList_LanServicosPecas).Exists(p => p.St_processar))
            {
                MessageBox.Show("Nenhum item foi adicionado para faturar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFItensFaturar_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gItens);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            cd_clifor.Text = pCd_clifor;
            //Preencer combobox empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "EXISTS",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"

                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            if ((cbEmpresa.DataSource as CamadaDados.Diversos.TList_CadEmpresa).Count > 0)
            {
                if (!string.IsNullOrEmpty(pCd_empresa))
                    cbEmpresa.SelectedValue = pCd_empresa;
                else cbEmpresa.SelectedIndex = 0;
            }
            if (!string.IsNullOrEmpty(cd_clifor.Text) && cbEmpresa.SelectedValue != null)
                afterBusca();
        }

        private void TFItensFaturar_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItens);
        }

        private void TFItensFaturar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (BS_ItensOS.Count > 0)
            {
                (BS_ItensOS.DataSource as TList_LanServicosPecas).ForEach(p => p.St_processar = cbProcessar.Checked);
                tot_OSAgrupar.Value = (BS_ItensOS.DataSource as TList_LanServicosPecas).Where(p => p.St_processar).Sum(p => ((p.Qtd_faturar > decimal.Zero ? p.Qtd_faturar : p.Quantidade) * p.Vl_unitario) - p.Vl_desconto + p.Vl_acrescimo);
                BS_ItensOS.ResetBindings(true);
            }
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (BS_ItensOS.Current as TRegistro_LanServicosPecas).St_processar =
                    !(BS_ItensOS.Current as TRegistro_LanServicosPecas).St_processar;
                if ((BS_ItensOS.Current as TRegistro_LanServicosPecas).St_processar)
                    using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                    {
                        fQtd.Text = "Quantidade";
                        fQtd.Vl_default = (BS_ItensOS.Current as TRegistro_LanServicosPecas).SaldoFaturar;
                        if (fQtd.ShowDialog() == DialogResult.OK)
                            if (fQtd.Quantidade > decimal.Zero)
                            {
                                if (fQtd.Quantidade <= (BS_ItensOS.Current as TRegistro_LanServicosPecas).SaldoFaturar)
                                    (BS_ItensOS.Current as TRegistro_LanServicosPecas).Qtd_faturar =
                                        fQtd.Quantidade;
                                else
                                {
                                    MessageBox.Show("Quantidade informada é maior que o Saldo á faturar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    (BS_ItensOS.Current as TRegistro_LanServicosPecas).St_processar = false;
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar Quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (BS_ItensOS.Current as TRegistro_LanServicosPecas).St_processar = false;
                                return;
                            }
                        else
                        {
                            (BS_ItensOS.Current as TRegistro_LanServicosPecas).St_processar = false;
                            (BS_ItensOS.Current as TRegistro_LanServicosPecas).Qtd_faturar = decimal.Zero;
                        }
                    }
                else
                    (BS_ItensOS.Current as TRegistro_LanServicosPecas).Qtd_faturar = decimal.Zero;
                BS_ItensOS.ResetCurrentItem();
                tot_OSAgrupar.Value = (BS_ItensOS.DataSource as TList_LanServicosPecas).Where(p => p.St_processar).Sum(p => ((p.Qtd_faturar > decimal.Zero ? p.Qtd_faturar : p.Quantidade) * p.Vl_unitario) - p.Vl_desconto + p.Vl_acrescimo);
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }
                
        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { cd_clifor },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void TP_Ordem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_ordem|=|" + TP_Ordem.Text + ";" +
                           "|exists|(select 1 from tb_ose_paramos x " +
                           "           where x.tp_ordem = a.tp_ordem)";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { TP_Ordem },
                                            new CamadaDados.Servicos.Cadastros.TCD_TpOrdem());
        }

        private void bb_tpordem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipoordem|Tipo Ordem|200;" +
                              "a.tp_ordem|TP. Ordem|80;" +
                              "b.cd_tabelapreco|Cd. Tabela|80;" +
                              "c.ds_tabelapreco|Tabela Preço|200";
            string vParam = "|exists|(select 1 from tb_ose_paramos x " +
                            "           where x.tp_ordem = a.tp_ordem)";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Ordem },
                                            new CamadaDados.Servicos.Cadastros.TCD_TpOrdem(), vParam);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim(),
                                           new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }
    }
}
