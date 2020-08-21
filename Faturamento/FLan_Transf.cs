using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque;

namespace Faturamento
{
    public partial class TFLan_Transf : Form
    {
        public decimal qtd_transf = 0;
        public string vCd_empresa = string.Empty;
        public string vNm_empresa = string.Empty;
        public string vCd_produto = string.Empty;
        public string vDs_produto = string.Empty;
        public string vSigla_unidade = string.Empty;

        public TFLan_Transf()
        {
            InitializeComponent();
        }

        private decimal BuscarSaldoLocal(string Cd_empresa, string Cd_produto, string Cd_local)
        {
            return TCN_LanEstoque.Busca_Saldo_Local(Cd_empresa, Cd_produto, Cd_local);
        }

        private bool existirTransf()
        {
            for (int i = 0; i < bsTransfEstoque.Count; i++)
                if (((bsTransfEstoque[i] as CamadaDados.Estoque.TRegistro_LanTransfLocal_X_Estoque).Cd_empresa.Trim().Equals(cd_emp.Text.Trim())) &&
                   ((bsTransfEstoque[i] as CamadaDados.Estoque.TRegistro_LanTransfLocal_X_Estoque).Cd_produto.Trim().Equals(cd_produto.Text.Trim())) &&
                   ((bsTransfEstoque[i] as CamadaDados.Estoque.TRegistro_LanTransfLocal_X_Estoque).Cd_localorigem.Trim().Equals(CD_Local_Orig.Text.Trim())) &&
                   ((bsTransfEstoque[i] as CamadaDados.Estoque.TRegistro_LanTransfLocal_X_Estoque).Cd_localdestino.Trim().Equals(CD_Local_Dest.Text.Trim())))
                    return true;
            return false;
        }

        private decimal Totalizar()
        {
            decimal total = 0;
            for (int i = 0; i < bsTransfEstoque.Count; i++)
                total += (bsTransfEstoque[i] as CamadaDados.Estoque.TRegistro_LanTransfLocal_X_Estoque).Quantidade;
            return total;
        }

        private void TFLan_Transf_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsTransf.AddNew();
            total_quantidade.Value = qtd_transf;
            cd_emp.Text = vCd_empresa;
            nm_empresa.Text = vNm_empresa;
            cd_produto.Text = vCd_produto;
            ds_produto.Text = vDs_produto;
            sg_origem.Text = vSigla_unidade;
            sg_destino.Text = vSigla_unidade;
            sg_quantidade.Text = vSigla_unidade;
        }

        private void BB_Local_Origem_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Local|Des. do Local de Origem|350;" +
                              "CD_Local|Cód. Local|100";
            string vParamFixo = "|EXISTS|(Select 1 From TB_EST_Empresa_X_LocalArm x Where x.CD_Local = a.CD_Local and x.CD_Empresa = '" + cd_emp.Text + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local_Orig, NM_Local_Origem },
                                    new TCD_CadLocalArm(), vParamFixo);
            Qtde_localOrigem.Value = BuscarSaldoLocal(cd_emp.Text, cd_produto.Text, CD_Local_Orig.Text);

        }

        private void CD_Local_Orig_Leave(object sender, EventArgs e)
        {
            if(CD_Local_Orig.Text.Trim() != string.Empty)
                if (CD_Local_Orig.Text.Trim() != CD_Local_Dest.Text.Trim())
                {
                    string vColunas = CD_Local_Orig.NM_CampoBusca + "|=|'" + CD_Local_Orig.Text + "'";
                        vColunas += ";|EXISTS|(Select 1 From TB_EST_Empresa_X_LocalArm x Where x.CD_Local = a.CD_Local and x.CD_Empresa = '" + cd_emp.Text + "')";
                    UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local_Orig, NM_Local_Origem },
                                            new TCD_CadLocalArm());
                    Qtde_localOrigem.Value = BuscarSaldoLocal(cd_emp.Text, cd_produto.Text, CD_Local_Orig.Text);
                }
                else
                {
                    MessageBox.Show("O Local De Destino Tem Que Ser Diferente do Local De Origem!");
                    CD_Local_Orig.Clear();
                    NM_Local_Origem.Clear();
                    CD_Local_Orig.Focus();
                }
        }

        private void BB_LocalDest_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Local|Des. do Local De Destino|350;" +
                              "CD_Local|Cód. Local|100";
            string vParamFixo = "|EXISTS|(Select 1 From TB_EST_Empresa_X_LocalArm x Where x.CD_Local = a.CD_Local and x.CD_Empresa = '" + cd_emp.Text + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local_Dest, NM_Local_Dest },
                                    new TCD_CadLocalArm(), vParamFixo);
            if(CD_Local_Dest.Text.Trim() != string.Empty)
                if (CD_Local_Dest.Text.Trim().Equals(CD_Local_Orig.Text.Trim()))
                {
                    MessageBox.Show("O Local de destino tem que ser diferente do local de origem.");
                    CD_Local_Dest.Clear();
                    NM_Local_Dest.Clear();
                    CD_Local_Dest.Focus();
                    return;
                }
            Qtde_localDestino.Value = BuscarSaldoLocal(cd_emp.Text, cd_produto.Text, CD_Local_Dest.Text);
        }

        private void CD_Local_Dest_Leave(object sender, EventArgs e)
        {
            if(CD_Local_Dest.Text.Trim() != string.Empty)
                if (CD_Local_Dest.Text.Trim() != CD_Local_Orig.Text.Trim())
                {
                    string vColunas = CD_Local_Dest.NM_CampoBusca + "|=|'" + CD_Local_Dest.Text.Trim() + "'";
                    vColunas += ";|EXISTS|(Select 1 From TB_EST_Empresa_X_LocalArm x Where x.CD_Local = a.CD_Local and x.CD_Empresa = '" + cd_emp.Text + "')";
                    UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local_Dest, NM_Local_Dest },
                                            new TCD_CadLocalArm());
                    Qtde_localDestino.Value = BuscarSaldoLocal(cd_emp.Text, cd_produto.Text, CD_Local_Dest.Text);
                }
                else
                {
                    MessageBox.Show("O local de destino tem que ser diferente do local de origem!");
                    CD_Local_Dest.Clear();
                    NM_Local_Dest.Clear();
                    CD_Local_Dest.Focus();
                }
        }

        private void QTD_CompDev_ValueChanged(object sender, EventArgs e)
        {
            saldo_quantidade.Value = total_quantidade.Value - QTD_CompDev.Value;
        }

        private void total_quantidade_ValueChanged(object sender, EventArgs e)
        {
            saldo_quantidade.Value = total_quantidade.Value - QTD_CompDev.Value;
        }

        private void bb_adicionar_Click(object sender, EventArgs e)
        {
            if (CD_Local_Orig.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar Local Origem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Local_Orig.Focus();
                return;
            }
            if (CD_Local_Dest.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatório informar Local Destino.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Local_Dest.Focus();
                return;
            }
            if (quantidade.Value < 1)
            {
                MessageBox.Show("Obrigatório informar quantidade transferir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Focus();
                return;
            }
            if (!existirTransf())
            {
                bsTransfEstoque.Add(new CamadaDados.Estoque.TRegistro_LanTransfLocal_X_Estoque()
                {
                    Cd_empresa = vCd_empresa,
                    Nm_empresa = vNm_empresa,
                    Cd_produto = vCd_produto,
                    Ds_produto = vDs_produto,
                    Sigla_unidade = vSigla_unidade,
                    Cd_localorigem = CD_Local_Orig.Text,
                    Cd_localdestino = CD_Local_Dest.Text,
                    Quantidade = quantidade.Value
                });
                //Totalizar quantidade transferida
                QTD_CompDev.Value = Totalizar();
                CD_Local_Orig.Clear();
                NM_Local_Origem.Clear();
                Qtde_localOrigem.Value = 0;
                CD_Local_Dest.Clear();
                NM_Local_Dest.Clear();
                Qtde_localDestino.Value = 0;
                quantidade.Value = 0;
            }
            else
                MessageBox.Show("Ja existe transferência para o local armazenagem origem " + CD_Local_Orig.Text.Trim() + " e local armazenagem destino " + CD_Local_Dest.Text.Trim() + ".",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            if (bsTransfEstoque.Current != null)
            {
                bsTransfEstoque.RemoveCurrent();
                QTD_CompDev.Value = Totalizar();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void quantidade_Leave(object sender, EventArgs e)
        {
            if (quantidade.Value > Qtde_localOrigem.Value)
            {
                MessageBox.Show("Quantidade não pode ser maior que o saldo do local de origem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Focus();
                return;
            }
            if (quantidade.Value > saldo_quantidade.Value)
            {
                MessageBox.Show("Quantidade não pode ser maior que o saldo restante para transferir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Focus();
                return;
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFLan_Transf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
        }

        private void TFLan_Transf_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saldo_quantidade.Value > 0)
            {
                MessageBox.Show("Obrigatorio transferir saldo total.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
    }
}
