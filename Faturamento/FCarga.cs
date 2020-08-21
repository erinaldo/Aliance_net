using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;

namespace Faturamento
{
    public partial class TFCarga : Form
    {
        private CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega rcarga;
        public CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega rCarga
        {
            get
            {
                if (bsCarga.Current != null)
                    return bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega;
                else
                    return null;
            }
            set
            { rcarga = value; }
        }
        public CamadaDados.Faturamento.Entrega.TRegistro_ItensCarga rItensCarga
        { get; set; }

        public TFCarga()
        {
            InitializeComponent();
        }

        private void InserirItens()
        {
            using (TFItensCarga fItensCarga = new TFItensCarga())
            {
                if (fItensCarga.ShowDialog() == DialogResult.OK)
                    if (fItensCarga.lItensRomaneio != null)
                    {
                        fItensCarga.lItensRomaneio.ForEach(p =>
                            (bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).lItens.Add(
                            new CamadaDados.Faturamento.Entrega.TRegistro_ItensCarga()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Id_romaneio = p.Id_romaneio,
                                Id_itemromaneio = p.Id_itemromaneio,
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Sigla_unidade = p.Sigla_unidade,
                                Quantidade = p.Qtd_entregar,
                                Ds_endereco = p.Ds_endereco,
                                Numero = p.Numero,
                                Bairro = p.Bairro,
                                Cidade = p.Cidade
                            }));
                        bsCarga.ResetCurrentItem();
                    }
            }
        }

        private void ExcluirItens()
        {
            if(bsCargaItens.Current != null)
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).lItensDel.Add(
                        bsCargaItens.Current as CamadaDados.Faturamento.Entrega.TRegistro_ItensCarga);
                    bsCargaItens.RemoveCurrent();
                }
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(Dt_carga.Text) || Dt_carga.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatório informar Data!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsCarga.Current as CamadaDados.Faturamento.Entrega.TRegistro_CargaEntrega).lItens.Count == 0)
                this.InserirItens();
            this.DialogResult = DialogResult.OK;
        }

        private void TFCarga_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (this.rcarga != null)
                bsCarga.DataSource = new CamadaDados.Faturamento.Entrega.TList_CargaEntrega() { this.rcarga };
            else
                bsCarga.AddNew();
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                              "isnull(a.st_motorista, 'N')|=|'S';" +
                               "isnull(a.st_ativomot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_motorista, nm_motorista },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            nm_motorista.Enabled = string.IsNullOrEmpty(cd_motorista.Text);
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                              "a.cd_clifor|Codigo|80";
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_motorista, nm_motorista },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
            nm_motorista.Enabled = string.IsNullOrEmpty(cd_motorista.Text);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCarga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItens();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItens();
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItens();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItens();
        }
    }
}
