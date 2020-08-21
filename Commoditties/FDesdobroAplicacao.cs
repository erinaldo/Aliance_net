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
    public partial class TFDesdobroAplicacao : Form
    {
        public string Nr_contrato
        { get; set; }

        public TFDesdobroAplicacao()
        {
            InitializeComponent();
            this.Nr_contrato = string.Empty;
        }

        private void afterGrava()
        {
            if (bsItensContrato.Count > 0)
            {
                try
                {
                    CamadaNegocio.Graos.TCN_CadContratoxPedidoItem.GravarDesdobroContratoXPedidoItem(
                        bsItensContrato.DataSource as CamadaDados.Graos.TList_CadContratoxPedidoItem, null);
                    MessageBox.Show("Desdobros gravados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Não existe itens contrato para gravar desdobro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirDesdobro()
        {
            if (bsItensContrato.Current != null)
            {
                //Verificar se o tipo de pedido do item permite transferencia e se e deposito
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.ST_PermiteTransf, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.ST_Deposito, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_pedido x " +
                                                    "where x.cfg_pedido = a.cfg_pedido " +
                                                    "and x.nr_pediddo = " + (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).Nr_pedidostr + ")"
                                    }
                                }, "a.cfg_pedido");
                if (obj != null)
                {
                    MessageBox.Show("Necessario configurar tipo de pedido " + obj.ToString() + " para permitir transferencia e/ou ser do tipo DEPOSITO.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFDesdobro fDesdobro = new TFDesdobro())
                {
                    fDesdobro.Text = "NOVO DESDOBRO";
                    fDesdobro.pCd_produto = (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).Cd_produto;
                    if(fDesdobro.ShowDialog() == DialogResult.OK)
                        if (fDesdobro.rDesd != null)
                        {
                            if ((bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).lDesdEspecial.Exists(p =>
                                p.Id_tpdesdobrostr.Trim().Equals(fDesdobro.rDesd.Id_tpdesdobrostr.Trim()) &&
                                p.Nr_pedidodest.Value.Equals(fDesdobro.rDesd.Nr_pedidodest.Value) &&
                                p.Cd_produtodest.Trim().Equals(fDesdobro.rDesd.Cd_produtodest.Trim()) &&
                                p.Id_pedidoitemdest.Value.Equals(fDesdobro.rDesd.Id_pedidoitemdest.Value)))
                            {
                                (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).lDesdEspecial.Find(p =>
                                p.Id_tpdesdobrostr.Trim().Equals(fDesdobro.rDesd.Id_tpdesdobrostr.Trim()) &&
                                p.Nr_pedidodest.Value.Equals(fDesdobro.rDesd.Nr_pedidodest.Value) &&
                                p.Cd_produtodest.Trim().Equals(fDesdobro.rDesd.Cd_produtodest.Trim()) &&
                                p.Id_pedidoitemdest.Value.Equals(fDesdobro.rDesd.Id_pedidoitemdest.Value)).Pc_desdobro = fDesdobro.rDesd.Pc_desdobro;
                                (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).lDesdEspecial.Find(p =>
                                p.Id_tpdesdobrostr.Trim().Equals(fDesdobro.rDesd.Id_tpdesdobrostr.Trim()) &&
                                p.Nr_pedidodest.Value.Equals(fDesdobro.rDesd.Nr_pedidodest.Value) &&
                                p.Cd_produtodest.Trim().Equals(fDesdobro.rDesd.Cd_produtodest.Trim()) &&
                                p.Id_pedidoitemdest.Value.Equals(fDesdobro.rDesd.Id_pedidoitemdest.Value)).Peso_desdobro = fDesdobro.rDesd.Peso_desdobro;
                            }
                            else
                                (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).lDesdEspecial.Add(fDesdobro.rDesd);
                            bsItensContrato.ResetCurrentItem();
                        }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item do contrato para inserir desdobro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AlterarDesdobro()
        {
            if (bsDesdobroEspecial.Current != null)
            {
                using (TFDesdobro fDesdobro = new TFDesdobro())
                {
                    fDesdobro.Text = "ALTERANDO DESDOBRO";
                    fDesdobro.pCd_produto = (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).Cd_produto;
                    CamadaDados.Graos.TRegistro_ContratoItem_X_DesdEspecial Copia = (bsDesdobroEspecial.Current as CamadaDados.Graos.TRegistro_ContratoItem_X_DesdEspecial).Copy();
                    fDesdobro.rDesd = Copia;
                    if(fDesdobro.ShowDialog() == DialogResult.OK)
                        if (fDesdobro.rDesd != null)
                        {
                            (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).lDesdEspecial[bsItensContrato.Position] = Copia;
                            bsItensContrato.ResetCurrentItem();
                        }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar desdobro para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirDesdobro()
        {
            if (bsDesdobroEspecial.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).lDesdEspecialDel.Add(
                        bsDesdobroEspecial.Current as CamadaDados.Graos.TRegistro_ContratoItem_X_DesdEspecial);
                    bsDesdobroEspecial.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar desdobro para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFDesdobroAplicacao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                //Buscar Itens Contrato
                bsItensContrato.DataSource = CamadaNegocio.Graos.TCN_CadContratoxPedidoItem.Buscar(Nr_contrato, 
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   0,
                                                                                                   null);
                bsItensContrato_PositionChanged(this, new EventArgs());
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            this.ExcluirDesdobro();
        }

        private void bb_alterar_Click(object sender, EventArgs e)
        {
            this.AlterarDesdobro();
        }

        private void bb_inserir_Click(object sender, EventArgs e)
        {
            this.InserirDesdobro();
        }

        private void TFDesdobroAplicacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirDesdobro();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarDesdobro();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirDesdobro();
        }

        private void bsItensContrato_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensContrato.Current != null)
                if ((bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).lDesdEspecial.Count < 1)
                {
                    (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).lDesdEspecial =
                        CamadaNegocio.Graos.TCN_ContratoItem_X_DesdEspecial.Buscar(
                        (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).Nr_contratostr,
                        (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).Nr_pedidostr,
                        (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).Cd_produto,
                        (bsItensContrato.Current as CamadaDados.Graos.TRegistro_CadContratoxPedidoItem).Id_pedidoitemstr,
                        null);
                    bsItensContrato.ResetCurrentItem();
                }
        }

        private void TFDesdobroAplicacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}
