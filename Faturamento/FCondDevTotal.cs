using System;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFCondDevTotal : Form
    {
        private CamadaDados.Faturamento.PDV.TRegistro_Condicional _condicional;
        public CamadaDados.Faturamento.PDV.TRegistro_Condicional Condicional { get { return _condicional; } }
        public TFCondDevTotal()
        {
            InitializeComponent();
        }

        private void TFCondDevTotal_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
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

        private void bbCancela_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bbConfirma_Click(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(id_condicional.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar numero condicional.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_condicional.Focus();
                return;
            }
            try
            {
                //Buscar condicional
                CamadaDados.Faturamento.PDV.TList_Condicional lCond = 
                    CamadaNegocio.Faturamento.PDV.TCN_Condicional.Buscar(cbEmpresa.SelectedValue.ToString(),
                                                                         id_condicional.Text,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         "'A'",
                                                                         false,
                                                                         false,
                                                                         false,
                                                                         null);
                if (lCond.Count > 0)
                {
                    _condicional = lCond[0];
                    _condicional.lItens = CamadaNegocio.Faturamento.PDV.TCN_ItensCondicional.Buscar(_condicional.Cd_empresa, _condicional.Id_condicionalstr, null);
                    if (_condicional.lItens.Exists(p => p.Qtd_devolvida > decimal.Zero))
                    {
                        MessageBox.Show("Não é permitido fazer devolução total de um condicional com devolução parcial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DialogResult = DialogResult.OK;
                }
                else MessageBox.Show("Condicional não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
