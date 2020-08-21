using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Faturamento.NotaFiscal;

namespace Servicos
{
    public partial class TFLan_Servico_x_Notas : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public bool St_gerarpedido
        {
            get { return st_gerarpedido.Checked; }
        }
        public string Tp_nota
        {
            get
            {
                if (rbNfPropria.Checked)
                    return "P";
                else
                    return "T";
            }
        }
        public CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed
        {
            get
            {
                if (st_gerarpedido.Checked)
                    return null;
                else if (BS_Itens.Current != null)
                {
                    TList_Pedido lPed = new TCD_Pedido().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_pedido",
                                                    vOperador = "=",
                                                    vVL_Busca = (BS_Itens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Nr_PedidoString
                                                }
                                            }, 1, string.Empty);
                    if (lPed.Count > 0)
                    {
                        lPed[0].Pedido_Itens.Add(BS_Itens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item);
                        lPed[0].Tp_pedido = "RM"; //Pedido de Remessa
                        return lPed[0];
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }

        public TFLan_Servico_x_Notas()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            TpBusca[] filtro = new TpBusca[3];
            filtro[0].vNM_Campo = "n.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + Cd_empresa.Trim() + "'";

            filtro[1].vNM_Campo = "n.tp_movimento";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + Tp_movimento.Trim() + "'";
            
            filtro[2].vNM_Campo = "isnull(n.st_pedido, 'A')";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'F'";
            if (nr_notafiscal.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_notafiscal x " +
                                                      "inner join tb_fat_notafiscal_item y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      "where y.nr_pedido = a.nr_pedido " +
                                                      "and x.nr_notafiscal = " + nr_notafiscal.Text + ")";

            }
            
            if (pCd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + pCd_produto.Trim() + "'";
            }
            if (pCd_clifor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "n.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + pCd_clifor.Trim() + "'";
            }
            BS_Itens.DataSource = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
        }

        private void afterGrava()
        {
            if ((BS_Itens.Current != null) && st_gerarpedido.Checked)
            {
                if (MessageBox.Show("Existe um pedido selecionado e o flag <GERAR PEDIDO REMESSA PARA TRANSPORTE> tambem esta marcado.\r\n" +
                                "Se continuar o sistema ira ignorar o pedido selecionado e gerar um novo pedido de remessa.\r\n\r\n" +
                                "Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    this.DialogResult = DialogResult.OK;
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        private void TFLan_Servico_x_Notas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFLan_Servico_x_Notas_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            pPedido.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pDadosNota.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            //Buscar pedidos
            this.afterBusca();
        }

        private void nr_notafiscal_Leave(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFLan_Servico_x_Notas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
