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
    public partial class TFItensCarga : Form
    {
        public List<CamadaDados.Faturamento.Entrega.TRegistro_ItensRomaneio> lItensRomaneio
        {
            get
            {
                if (bsItensRomaneio.Count > 0)
                    return (bsItensRomaneio.List as CamadaDados.Faturamento.Entrega.TList_ItensRomaneio).FindAll(p => p.St_processar && p.Qtd_entregar > decimal.Zero);
                else return null;
            }
        }
        public TFItensCarga()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            this.DialogResult = DialogResult.OK;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[2];
            //Entrega ativa
            filtro[0].vNM_Campo = "isnull(c.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            //Saldo Entregar
            filtro[1].vNM_Campo = "a.quantidade - a.qtd_programada - a.qtd_entregue";
            filtro[1].vOperador = ">";
            filtro[1].vVL_Busca = "0";
            if (!string.IsNullOrEmpty(entrega.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_romaneio";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = entrega.Text;
            }
            if (!string.IsNullOrEmpty(id_prevenda.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_prevenda.Text;
            }
            if (!string.IsNullOrEmpty(nr_pedido.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_pedido.Text;
            }
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
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
                    (rbEntregaRomaneio.Checked ? "c.DT_Romaneio" : "c.DT_PrevEntrega") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (rbEntregaRomaneio.Checked ? "c.DT_Romaneio" : "c.DT_PrevEntrega") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(ds_endereco.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.ds_endereco";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + ds_endereco.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(bairro.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.bairro";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + bairro.Text.Trim() + "%'";
            }

            bsItensRomaneio.DataSource = new CamadaDados.Faturamento.Entrega.TCD_ItensRomaneio().Select(filtro, 0, string.Empty);
        }

        private void TFItensCarga_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensRomaneio);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItensRomaneio.Count > 0)
            {
                (bsItensRomaneio.List as CamadaDados.Faturamento.Entrega.TList_ItensRomaneio).ForEach(p =>
                    {
                        p.St_processar = cbTodos.Checked;
                        if (p.St_processar)
                            p.Qtd_entregar = p.SaldoEntregar;
                        else
                            p.Qtd_entregar = decimal.Zero;
                    });
                bsItensRomaneio.ResetBindings(true);
            }
        }

        private void gCargaItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsItensRomaneio.Current != null))
            {
                try
                {
                    if ((bsItensRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_ItensRomaneio).St_processar != true)
                    {
                        //Informar Quantidade
                        using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                        {
                            fQtde.Ds_label = "QTD.Entrega";
                            fQtde.Casas_decimais = 2;
                            fQtde.Vl_default = (bsItensRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_ItensRomaneio).SaldoEntregar;
                            fQtde.Vl_saldo = (bsItensRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_ItensRomaneio).SaldoEntregar;
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                (bsItensRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_ItensRomaneio).St_processar = true;
                                (bsItensRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_ItensRomaneio).Qtd_entregar = fQtde.Quantidade;
                            }
                            bsItensRomaneio.ResetCurrentItem();

                        }
                    }
                    else
                    {
                        (bsItensRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_ItensRomaneio).St_processar = false;
                        (bsItensRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_ItensRomaneio).Qtd_entregar = decimal.Zero;
                        bsItensRomaneio.ResetCurrentItem();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFItensCarga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void TFItensCarga_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensRomaneio);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "||(a.cd_produto = '" + cd_produto.Text.Trim() + "') or " +
                             "(exists(select 1 from tb_est_codbarra x " +
                             "         where x.cd_produto = a.cd_produto " +
                             "         and x.cd_codbarra = '" + cd_produto.Text.Trim() + "'))";
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { cd_produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }
    }
}
