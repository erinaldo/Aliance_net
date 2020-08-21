using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Locacao;
using FormBusca;
using System;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFReceberFin : Form
    {
        public TRegistro_Retirada rRetirada => bsRetirada.Current as TRegistro_Retirada ?? null;
        public TFReceberFin()
        {
            InitializeComponent();
        }

        private void BuscarAbastecidas()
        {
            if (cbEmpresa.SelectedItem != null && 
                dt_retirada.Text.IsDateTime())
            {
                TpBusca[] filtro = new TpBusca[2];
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "'";
                filtro[1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Abast)))";
                filtro[1].vOperador = "<=";
                filtro[1].vVL_Busca = "'" + DateTime.Parse(dt_retirada.Text).ToString("yyyyMMdd") + "'";
                if (dtUltimaRetirada.Text.IsDateTime())
                    Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), a.DT_Abast)))",
                        "'" + DateTime.Parse(dtUltimaRetirada.Text).ToString("yyyyMMdd") + "'", ">");
                TList_AbastItens lAbast = new TCD_AbastItens().Select(filtro, 0, string.Empty);
                if(lAbast.Count > 0)
                {
                    vlAbast.Text = lAbast.Sum(x => x.Vl_subtotal).ToString("C");
                    bsAbastItens.DataSource = lAbast;
                }
                else
                {
                    bsAbastItens.Clear();
                    vlAbast.Clear();
                }
                
                filtro = new TpBusca[2];
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "'";
                filtro[1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Medicao)))";
                filtro[1].vOperador = "<=";
                filtro[1].vVL_Busca = "'" + DateTime.Parse(dt_retirada.Text).ToString("yyyyMMdd") + "'";
                if (dtUltimaRetirada.IsDateTime())
                    Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), a.DT_Medicao)))",
                        "'" + DateTime.Parse(dtUltimaRetirada.Text).ToString("yyyyMMdd") + "'", ">");
                TList_MedicaoProdutoItens lMedicao = new TCD_MedicaoProdutoItens().Select(filtro, 0, string.Empty);
                if(lMedicao.Count > 0)
                {
                    vlMedicao.Text = lMedicao.Sum(x => x.Vl_subtotal).ToString("C");
                    bsMedicao.DataSource = lMedicao;
                }
                else
                {
                    vlMedicao.Clear();
                    bsMedicao.Clear();
                }
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void TFReceberFin_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsRetirada.AddNew();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
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
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFReceberFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }


        private void cd_funcionario_Click(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_funcionario.Text.Trim() + "';" +
                            "isnull(a.st_funcionarios, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_funcionario, nm_funcionario },
                                                                new TCD_CadClifor());

        }

        private void bb_funcionario_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Responsável|200;" +
                              "a.cd_clifor|Codigo|80";
            string vParam = "isnull(a.st_funcionarios, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_funcionario, nm_funcionario },
                                                                new TCD_CadClifor(), vParam);
        }

        private void CD_ContaGer_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_ContaGer|=|'" + CD_ContaGer.Text.Trim() + "';" +
                              "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                              "where k.CD_ContaGer = a.CD_ContaGer " +
                              "and k.cd_Empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "' );" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                              "a.st_contaCF|=|1;" +
                              "ISNULL(a.ST_ContaCompensacao,'N')|=|'N';" +
                              "a.st_contacartao|<>|0";

            UtilPesquisa.EDIT_LEAVE(vColunas,
              new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
              new TCD_CadContaGer());
        }

        private void BB_ContaGer_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaGer|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
            string vParamFixo = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                                "where k.CD_ContaGer = a.CD_ContaGer " +
                                "and k.cd_Empresa = '" + cbEmpresa.SelectedValue.ToString().Trim() + "' );" +
                                "a.st_contaCF|=|1;" +
                                "ISNULL(a.ST_ContaCompensacao,'N')|=|'N';" +
                                "a.st_contacartao|<>|0";
            UtilPesquisa.BTN_BUSCA(vColunas,
                new Componentes.EditDefault[] { CD_ContaGer, DS_ContaGer },
                new TCD_CadContaGer(), vParamFixo);
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedItem != null)
            {
                //Buscar Ultima retirada
                object obj = new TCD_Retirada().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "'" }
                                            }, "a.dt_retirada", string.Empty, "a.dt_retirada desc", null);
                try
                {
                    dtUltimaRetirada.Text = DateTime.Parse(obj.ToString()).ToString("dd/MM/yyyy");
                }catch { dtUltimaRetirada.Text = string.Empty; }
                BuscarAbastecidas();
            }
        }

        private void dt_retirada_Leave(object sender, EventArgs e)
        {
            BuscarAbastecidas();
            if (dt_retirada.Text.IsDateTime() && dtUltimaRetirada.Text.IsDateTime())
                if (DateTime.Parse(dt_retirada.Text) <= DateTime.Parse(dtUltimaRetirada.Text))
                {
                    MessageBox.Show("Data retirada deve ser maior que data ultima retirada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_retirada.Clear();
                    dt_retirada.Focus();
                }
        }

        private void Valor_Leave(object sender, EventArgs e)
        {
            if (Valor.Value > decimal.Zero)
                if (Valor.Value > (bsRetirada.Current as TRegistro_Retirada).Vl_abastecidas + (bsRetirada.Current as TRegistro_Retirada).Vl_medidas)
                {
                    lblMensagem.Text = "Sobras " + (Valor.Value - (bsRetirada.Current as TRegistro_Retirada).Vl_abastecidas + (bsRetirada.Current as TRegistro_Retirada).Vl_medidas).ToString("C");
                    lblMensagem.ForeColor = System.Drawing.Color.Blue;
                }
                else if (Valor.Value < (bsRetirada.Current as TRegistro_Retirada).Vl_abastecidas + (bsRetirada.Current as TRegistro_Retirada).Vl_medidas)
                {
                    lblMensagem.Text = "Falta " + Math.Abs(Valor.Value - (bsRetirada.Current as TRegistro_Retirada).Vl_abastecidas + (bsRetirada.Current as TRegistro_Retirada).Vl_medidas).ToString("C");
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                }
                else
                    lblMensagem.Text = string.Empty;
            else lblMensagem.Text = string.Empty;
        }
    }
}
