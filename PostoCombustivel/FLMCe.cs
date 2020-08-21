using System;
using System.Windows.Forms;
using Utils;

namespace PostoCombustivel
{
    public partial class TFLMCe : Form
    {
        private CamadaDados.PostoCombustivel.TRegistro_LMC rlmc;
        public CamadaDados.PostoCombustivel.TRegistro_LMC rLMC
        {
            get
            {
                if (rlmc == null && cbEmpresa.SelectedItem != null)
                {
                    rlmc = new CamadaDados.PostoCombustivel.TRegistro_LMC();
                    rlmc.Cd_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                    rlmc.Nm_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa;
                    rlmc.Cnpj_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).rClifor.Nr_cgc;
                    rlmc.IE_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).rEndereco.Insc_estadual;
                    rlmc.Dt_emissao = DateTime.Parse(dt_emissao.Text);
                }
                (bsMovLMC.List as CamadaDados.PostoCombustivel.TList_MovLMC).ForEach(p => rlmc.lMov.Add(p));
                return rlmc;
            }
        }

        public string pCd_empresa
        { get; set; }
        public string pDt_emissao
        { get; set; }

        public TFLMCe()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_emissao.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data emissão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_emissao.Focus();
                return;
            }
            if (bsMovLMC.Count.Equals(0))
            {
                MessageBox.Show("Não existe movimento para gerar LMC-e", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void CalcularLMC()
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_emissao.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data emissão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_emissao.Focus();
                return;
            }
            CamadaDados.PostoCombustivel.TList_LMC lLmc = CamadaNegocio.PostoCombustivel.TCN_LMC.Buscar(cbEmpresa.SelectedValue.ToString(), 
                                                                                                        string.Empty, 
                                                                                                        string.Empty, 
                                                                                                        dt_emissao.Text, 
                                                                                                        dt_emissao.Text, 
                                                                                                        string.Empty, 
                                                                                                        null);
            if (lLmc.Count > 0)
                if (MessageBox.Show("Já existe LMC-e gerado para o periodo informado.Deseja retificar o mesmo?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    return;
                else rlmc = lLmc[0];
            CamadaDados.PostoCombustivel.TList_MovLMC lMov = new CamadaDados.PostoCombustivel.TCD_LMC().SelectLMC(cbEmpresa.SelectedValue.ToString(), DateTime.Parse(dt_emissao.Text));
            lMov.RemoveAll(p => p.Volumeabertura.Equals(decimal.Zero) && p.Volumefechamento.Equals(decimal.Zero));
            lMov.ForEach(p =>
                {
                    if (rlmc != null)
                    {
                        //Verificar se produto ja existe no LMC
                        object obj = new CamadaDados.PostoCombustivel.TCD_MovLMC().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rlmc.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_lmc",
                                                vOperador = "=",
                                                vVL_Busca = rlmc.Id_lmcstr
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_produto",
                                                vOperador = "=",
                                                vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                            }
                                        }, "a.id_movto");
                        if (obj != null)
                        {
                            p.Cd_empresa = rlmc.Cd_empresa;
                            p.Id_lmc = rlmc.Id_lmc;
                            p.Id_movto = decimal.Parse(obj.ToString());
                        }
                    }
                    p.lVend = new CamadaDados.PostoCombustivel.TCD_MovVend().SelectMovVend(cbEmpresa.SelectedValue.ToString(), p.Cd_produto, DateTime.Parse(dt_emissao.Text));
                    if (p.Id_movto.HasValue)
                        p.lVend.ForEach(v =>
                            {
                                v.Cd_empresa = p.Cd_empresa;
                                v.Id_lmc = p.Id_lmc;
                                v.Id_movto = p.Id_movto;
                            });
                    p.lRec = new CamadaDados.PostoCombustivel.TCD_MovRec().SelectRec(cbEmpresa.SelectedValue.ToString(), p.Cd_produto, DateTime.Parse(dt_emissao.Text));
                    if (p.Id_movto.HasValue)
                        p.lRec.ForEach(v =>
                            {
                                v.Cd_empresa = p.Cd_empresa;
                                v.Id_lmc = p.Id_lmc;
                                v.Id_movto = p.Id_movto;
                            });
                });
            bsMovLMC.DataSource = lMov;
        }

        private void TFLMCe_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pLMC.set_FormatZero();
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
            cbEmpresa.SelectedValue = pCd_empresa;
            dt_emissao.Text = pDt_emissao;
            if (cbEmpresa.SelectedItem != null &&
                !string.IsNullOrEmpty(dt_emissao.Text.SoNumero()))
                CalcularLMC();
        }
        
        private void bb_buscar_Click(object sender, EventArgs e)
        {
            CalcularLMC();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFLMCe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                CalcularLMC();
        }
    }
}
