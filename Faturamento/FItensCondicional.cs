using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFItensCondicional : Form
    {
        public List<CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional> lItens
        {
            get
            {
                if (bsItens.Count > 0)
                    return (bsItens.List as CamadaDados.Faturamento.PDV.TList_ItensCondicional).FindAll(p => p.St_processar);
                else return null;
            }
        }
        public string Cd_clifor
        { get { return cd_clifor.Text; } }
        public bool St_nfdev
        { get; set; }

        public TFItensCondicional()
        {
            InitializeComponent();
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
            if (pFiltro.validarCampoObrigatorio())
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
                //Saldo Faturar Normal/Devolver
                filtro[2].vNM_Campo = this.St_nfdev ? "(Qtd_devolvida - Qtd_nfdev)" : "(Quantidade - Qtd_nfcond)";
                filtro[2].vOperador = ">";
                filtro[2].vVL_Busca = "0";
                //Tipo movimento
                filtro[3].vNM_Campo = "cond.tp_movimento";
                filtro[3].vOperador = "=";
                filtro[3].vVL_Busca = "'S'";
                //Empresa
                filtro[4].vNM_Campo = "a.cd_empresa";
                filtro[4].vOperador = "=";
                filtro[4].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";

                //Clifor
                if (!string.IsNullOrEmpty(cd_clifor.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "cond.cd_clifor";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
                }
                if (!string.IsNullOrEmpty(id_condicional.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_condicional";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_condicional.Text;
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

        }

        private void TFItensCondicional_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            Saldo_nfcomp.Visible = !this.St_nfdev;
            Saldo_nfdev.Visible = this.St_nfdev;
            Qtd_faturar.Visible = !this.St_nfdev;
            cQtdDevolver.Visible = this.St_nfdev;
            lblQuantidade.Text = this.St_nfdev ? "Qtd. Devolver" : "Qtd. Faturar";
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
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

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsItens.MoveNext();
            qtd_fat.Focus();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsItens.List as CamadaDados.Faturamento.PDV.TList_ItensCondicional).ForEach(p => 
                    {
                        p.St_processar = cbTodos.Checked;
                        if (this.St_nfdev)
                            p.Qtd_devolver = cbTodos.Checked ? p.Saldo_nfdev : decimal.Zero;
                        else p.Qtd_faturar = cbTodos.Checked ? p.Saldo_nfcond : decimal.Zero;
                    });
                bsItens.ResetBindings(true);
                qtd_devolver.Value = this.St_nfdev ? (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Saldo_nfdev :
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Saldo_nfcond;
                qtd_fat.Value = this.St_nfdev ? (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Qtd_devolver :
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Qtd_faturar;
            }
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).St_processar =
                    !(bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).St_processar;
                if (this.St_nfdev)
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Qtd_devolver =
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).St_processar ?
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Saldo_nfdev : decimal.Zero;
                else
                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Qtd_faturar =
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).St_processar ?
                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Saldo_nfcond : decimal.Zero;
                bsItens.ResetCurrentItem();
                qtd_devolver.Value = this.St_nfdev ? (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Saldo_nfdev :
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Saldo_nfcond;
                qtd_fat.Value = this.St_nfdev ? (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Qtd_devolver :
                                        (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Qtd_faturar;
            }
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            qtd_devolver.Value = this.St_nfdev ? (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Saldo_nfdev :
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Saldo_nfcond;
            qtd_fat.Value = this.St_nfdev ? (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Qtd_devolver : 
                                    (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Qtd_faturar;
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            bsItens.MovePrevious();
            qtd_fat.Focus();
        }

        private void qtd_fat_Leave(object sender, EventArgs e)
        {
            if (qtd_fat.Value > qtd_devolver.Value)
                qtd_fat.Value = qtd_devolver.Value;
            if (!(bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).St_processar)
                (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).St_processar = true;
            (bsItens.Current as CamadaDados.Faturamento.PDV.TRegistro_ItensCondicional).Qtd_faturar = qtd_fat.Value;
            bsItens.ResetCurrentItem();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFItensCondicional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }
    }
}
