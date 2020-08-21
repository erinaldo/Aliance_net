using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Frota
{
    public partial class TFLanAbastFrota : Form
    {
        private string LoginAbastecida;
        private CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg;
        public string Cd_tpveiculo
        { get; set; }

        public TFLanAbastFrota()
        {
            InitializeComponent();
            lCfg = new CamadaDados.Frota.Cadastros.TList_CfgFrota();
        }

        private bool ValidarKm(ref decimal Km_atual)
        {
            bool retorno = true;
            //Validar KM Atual
            if ((!string.IsNullOrEmpty(placa.Text)) &&
                (placa.Text.Trim() != "-") &&
                (km_atual.Value > decimal.Zero))
            {

                //Buscar ultimo KM Informado para a placa
                object obj = new CamadaDados.Frota.TCD_AbastVeiculo().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "replace(d.placa, '-', '')",
                                            vOperador = "=",
                                            vVL_Busca = "'" + placa.Text.Trim().Replace("-", "") + "'"
                                        }
                                    }, "isnull(a.km_atual, 0)", string.Empty, "a.dt_abastecimento desc", null);
                if (obj != null)
                {
                    Km_atual = decimal.Parse(obj.ToString());
                    if (Km_atual > km_atual.Value)
                        retorno = false;
                }
            }
            return retorno;
        }

        private void TFLanAbastFrota_Load(object sender, EventArgs e)
        {
            try
            {
                //Buscar lista empresa usuario
                empresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
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
                empresa.DisplayMember = "NM_Empresa";
                empresa.ValueMember = "CD_Empresa";
                empresa_SelectedIndexChanged(this, new EventArgs());
            }
            catch { }
        }

        private void placa_Leave(object sender, EventArgs e)
        {
            if ((empresa.SelectedValue != null) && (lCfg.Count > 0) && (placa.Text.Trim() != "-"))
            {
                using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
                {
                    fSessao.Mensagem = "Acesso Abastecimento Frota";
                    fSessao.Titulo = "FROTA";
                    if (fSessao.ShowDialog() == DialogResult.OK)
                    {
                        LoginAbastecida = fSessao.Usuario;
                        if (new CamadaDados.Diversos.TCD_CadUsuario().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_acesso x " +
                                                "where x.Id_Menu = 191300 "  +
                                                "and x.login = '" + LoginAbastecida.Trim() + "')"
                                }
                            }, "1") != null)
                        {

                            //Verificar placa cadastrada
                            if (new CamadaDados.Frota.Cadastros.TCD_CadVeiculo().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_frt_veiculo x " +
                                                    "where x.id_veiculo = a.id_veiculo " +
                                                    "and REPLACE(x.placa, '-', '') = '" + placa.Text.Replace("-", string.Empty).Trim() + "')"
                                    }
                                }, "1") != null)
                            {
                                //Verificar se o veiculo tem tracao
                                if (new CamadaDados.Diversos.TCD_CadTpVeiculo().BuscarEscalar(
                                    new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.tp_veiculo",
                                        vOperador = "=",
                                        vVL_Busca = "'T'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_frt_veiculo x " +
                                                    "where x.cd_tpveiculo = a.cd_tpveiculo " +
                                                    "and REPLACE(x.placa, '-', '') = '" + placa.Text.Replace("-", string.Empty).Trim() + "')"
                                    }
                                }, "1") != null)
                                {
                                    //Buscar requisicao abastecimento para a placa
                                    CamadaDados.Frota.TList_AbastVeiculo lAbast =
                                        CamadaNegocio.Frota.TCN_AbastVeiculo.Buscar(string.Empty,
                                                                                    empresa.SelectedValue.ToString(),
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    placa.Text,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    "'R'",
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    1,
                                                                                    null);
                                    if (lAbast.Count > 0)
                                    {
                                        bsAbastecimento.DataSource = lAbast;
                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Dt_abastecimento = CamadaDados.UtilData.Data_Servidor();
                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).LoginAbastecida = LoginAbastecida;
                                        bsAbastecimento.ResetCurrentItem();
                                        km_atual.Enabled = true;
                                        ds_observacao.Enabled = true;
                                        bb_abast.Enabled = true;
                                        placa.Enabled = false;
                                        empresa.Enabled = false;
                                        bb_gravar.Enabled = true;
                                        bb_cancelar.Enabled = true;
                                        km_atual.Focus();
                                    }
                                    else if (!lCfg[0].St_exigirrequisicaobool)
                                    {
                                        bsAbastecimento.AddNew();
                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa = empresa.SelectedValue.ToString();
                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_produto = lCfg[0].Cd_combustivel;
                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_produto = lCfg[0].Ds_combustivel;
                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_despesa = lCfg[0].Id_despesacombustivel;
                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_despesa = lCfg[0].Ds_despesacombustivel;
                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Dt_abastecimento = CamadaDados.UtilData.Data_Servidor();
                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).LoginAbastecida = LoginAbastecida;
                                        //Verificar se existe viagem programada ou executando para o veiculo
                                        CamadaDados.Frota.TList_Viagem lViagem =
                                            CamadaNegocio.Frota.TCN_Viagem.Buscar(string.Empty,
                                                                                  empresa.SelectedValue.ToString(),
                                                                                  string.Empty,
                                                                                  placa.Text,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  "'P', 'E'",
                                                                                  null);
                                        if (lViagem.Count > 0)
                                        {
                                            if (lViagem.Count.Equals(0))
                                            {
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_viagem = lViagem[0].Id_viagem;
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_viagem = lViagem[0].Ds_viagem;
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_veiculo = lViagem[0].Id_veiculo;
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_veiculo = lViagem[0].Ds_veiculo;
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa = lViagem[0].Cd_empresa;
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Nm_empresa = lViagem[0].Nm_empresa;
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Dt_abastecimento = CamadaDados.UtilData.Data_Servidor();
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).LoginAbastecida = LoginAbastecida;
                                                bsAbastecimento.ResetCurrentItem();
                                                km_atual.Enabled = true;
                                                ds_observacao.Enabled = true;
                                                bb_abast.Enabled = true;
                                                placa.Enabled = false;
                                                empresa.Enabled = false;
                                                bb_gravar.Enabled = true;
                                                bb_cancelar.Enabled = true;
                                                dt_requisicao.Focus();
                                            }
                                            else
                                                using (TFListViagem fViagem = new TFListViagem())
                                                {
                                                    fViagem.lViagem = lViagem;
                                                    if (fViagem.ShowDialog() == DialogResult.OK)
                                                    {
                                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_viagem = fViagem.rViagem.Id_viagem;
                                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_viagem = fViagem.rViagem.Ds_viagem;
                                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_veiculo = fViagem.rViagem.Id_veiculo;
                                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_veiculo = fViagem.rViagem.Ds_veiculo;
                                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa = fViagem.rViagem.Cd_empresa;
                                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Nm_empresa = fViagem.rViagem.Nm_empresa;
                                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Dt_abastecimento = CamadaDados.UtilData.Data_Servidor();
                                                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).LoginAbastecida = LoginAbastecida;
                                                        bsAbastecimento.ResetCurrentItem();
                                                        km_atual.Enabled = true;
                                                        ds_observacao.Enabled = true;
                                                        bb_abast.Enabled = true;
                                                        placa.Enabled = false;
                                                        empresa.Enabled = false;
                                                        bb_gravar.Enabled = true;
                                                        bb_cancelar.Enabled = true;
                                                        dt_requisicao.Focus();
                                                    }
                                                    else
                                                    {
                                                        //Buscar veiculo
                                                        CamadaDados.Frota.Cadastros.TList_CadVeiculo lVeic =
                                                            CamadaNegocio.Frota.Cadastros.TCN_CadVeiculo.Buscar(string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                placa.Text,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                "'A'",
                                                                                                                null);
                                                        if (lVeic.Count > 0)
                                                        {
                                                            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_veiculo = lVeic[0].Id_veiculo;
                                                            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_veiculo = lVeic[0].Ds_veiculo;
                                                            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).LoginAbastecida = LoginAbastecida;
                                                            bsAbastecimento.ResetCurrentItem();
                                                            km_atual.Enabled = true;
                                                            ds_observacao.Enabled = true;
                                                            bb_abast.Enabled = true;
                                                            placa.Enabled = false;
                                                            empresa.Enabled = false;
                                                            bb_gravar.Enabled = true;
                                                            bb_cancelar.Enabled = true;
                                                            dt_requisicao.Focus();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Não existe veiculo ativo para a placa " + placa.Text, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            placa.Clear();
                                                            placa.Focus();
                                                        }
                                                    }
                                                }
                                        }
                                        else
                                        {
                                            //Buscar veiculo
                                            CamadaDados.Frota.Cadastros.TList_CadVeiculo lVeic =
                                                CamadaNegocio.Frota.Cadastros.TCN_CadVeiculo.Buscar(string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    placa.Text,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    "'A'",
                                                                                                    null);
                                            if (lVeic.Count > 0)
                                            {
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_veiculo = lVeic[0].Id_veiculo;
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_veiculo = lVeic[0].Ds_veiculo;
                                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).LoginAbastecida = LoginAbastecida;
                                                bsAbastecimento.ResetCurrentItem();
                                                km_atual.Enabled = true;
                                                ds_observacao.Enabled = true;
                                                bb_abast.Enabled = true;
                                                placa.Enabled = false;
                                                empresa.Enabled = false;
                                                bb_gravar.Enabled = true;
                                                bb_cancelar.Enabled = true;
                                                dt_requisicao.Focus();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Não existe veiculo ativo para a placa " + placa.Text, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                placa.Clear();
                                                placa.Focus();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Empresa exige requisição para realizar abastecimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        placa.Clear();
                                        placa.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Veiculo informado não possui tração!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    placa.Clear();
                                    placa.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não existe Veículo cadastrado para esta placa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                placa.Clear();
                                placa.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario não tem acesso a tela de abastecimento Frota!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar login para iniciar abastecimento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        private void empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (empresa.SelectedValue != null)
            {
                lCfg = CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(empresa.SelectedValue.ToString(),
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         null);
                if (lCfg.Count > 0)
                {
                    if(!string.IsNullOrEmpty(lCfg[0].Cd_terminal) && (lCfg[0].Cd_terminal == Utils.Parametros.pubTerminal))
                    {
                        tmpAbastecimento.Enabled = false;
                        if ((!string.IsNullOrEmpty(lCfg[0].Tp_concentrador)) && (lCfg[0].Porta_comunicacao > decimal.Zero))
                        {
                            lblConcentrador.Text = lCfg[0].Tipo_concentrador;
                            tmpAbastecimento.Interval = lCfg[0].Tmp_abastecimento > decimal.Zero ? Convert.ToInt32(lCfg[0].Tmp_abastecimento) : 5000;
                            //Abrir porta comunicacao
                            if (PostoCombustivel.TAutomacao.AbrirPorta(lCfg[0].Tp_concentrador, Convert.ToInt32(lCfg[0].Porta_comunicacao)))
                            {
                                lblStatus.Text = "ONLINE";
                                lblStatus.ForeColor = Color.Blue;
                                tmpAbastecimento.Enabled = true;
                            }
                            else
                            {
                                lblStatus.Text = "OFFLINE";
                                lblStatus.ForeColor = Color.Red;
                            }
                        }
                        else
                            lblConcentrador.Text = "SEM AUTOMAÇÃO";
                    }
                    else
                        lblConcentrador.Text = "SEM TERMINAL";
                }
            }
        }

        private void bb_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmpAbastecimento_Tick(object sender, EventArgs e)
        {
            try
            {
                tmpAbastecimento.Enabled = false;
                //Ler status da porta COM
                int status = PostoCombustivel.TAutomacao.StatusPorta(lCfg[0].Tp_concentrador);
                if (status == 1)
                    if (!PostoCombustivel.TAutomacao.AbrirPorta(lCfg[0].Tp_concentrador, lCfg[0].Porta_comunicacao))
                        return;
                if (status == 255)
                {
                    PostoCombustivel.TAutomacao.FecharPorta(lCfg[0].Tp_concentrador);
                    return;
                }
                string abast = string.Empty;
                //Ler abastecimento memoria
                PostoCombustivel.TAutomacao.LerAbastecimentoAtual(lCfg[0].Tp_concentrador, false, ref abast);
                if (!string.IsNullOrEmpty(abast.Trim()))
                {
                    if (lCfg[0].Tp_concentrador.Trim().ToUpper().Equals("CT"))
                    {
                        abast = abast.Substring(abast.IndexOf('('));
                        volume_requisicao.Value = decimal.Divide(decimal.Parse(abast.SoNumero().Substring(6, 6)), lCfg[0].Vl_fatordivisao > decimal.Zero ? lCfg[0].Vl_fatordivisao : 1000);
                    }
                    else if (lCfg[0].Tp_concentrador.Trim().ToUpper().Equals("VW"))
                    {
                        if (abast.Trim().Substring(0, 1).Trim().ToUpper().Equals("O"))
                            if (abast.Trim().Substring(5, 1).Trim().Equals("a"))
                            {
                                //Gravar Abastecida
                                CamadaDados.Frota.TRegistro_Abastecidas rAbast = new CamadaDados.Frota.TRegistro_Abastecidas();
                                rAbast.Cd_empresa = empresa.SelectedValue.ToString();
                                rAbast.Volume = decimal.Divide(decimal.Parse(abast.Trim().Substring(30, 8)), lCfg[0].Vl_fatordivisao > decimal.Zero ? lCfg[0].Vl_fatordivisao : 1000);
                                //Data Abastecimento
                                DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
                                try
                                {
                                    rAbast.Dt_abastecida = new DateTime(2000 + Convert.ToInt32(abast.Trim().Substring(22, 2)),
                                                                        Convert.ToInt32(abast.Trim().Substring(20, 2)),
                                                                        Convert.ToInt32(abast.Trim().Substring(18, 2)),
                                                                        Convert.ToInt32(abast.Trim().Substring(12, 2)),
                                                                        Convert.ToInt32(abast.Trim().Substring(14, 2)),
                                                                        Convert.ToInt32(abast.Trim().Substring(16, 2)));
                                    if (Math.Abs(rAbast.Dt_abastecida.Value.Subtract(dt_atual).Hours) > 1)
                                        PostoCombustivel.TVWTech.AlterarDataHora(dt_atual.ToString());
                                }
                                catch
                                { rAbast.Dt_abastecida = CamadaDados.UtilData.Data_Servidor(); }
                                CamadaNegocio.Frota.TCN_Abastecidas.Gravar(rAbast, null);
                                if (bsAbastecimento.Current != null)
                                {
                                    volume_requisicao.Value = rAbast.Volume;
                                    (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).rAbast = rAbast;
                                }
                                //Apagar Abastecida
                                PostoCombustivel.TAutomacao.AvancarAbastecimento(lCfg[0].Tp_concentrador, Convert.ToInt32(abast.Trim().Substring(6, 4)));
                            }
                    }
                }
            }
            catch
            { }
            finally
            { tmpAbastecimento.Enabled = true; }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            empresa.Enabled = true;
            placa.Enabled = true;
            km_atual.Enabled = false;
            ds_observacao.Enabled = false;
            bb_gravar.Enabled = false;
            bb_cancelar.Enabled = false;
            bb_fechar.Enabled = true;
            bsAbastecimento.RemoveCurrent();
            placa.Clear();
            placa.Focus();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            if (bsAbastecimento.Current != null)
            {
                if ((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Volume.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio aguardar finalização do abastecimento para GRAVAR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lCfg[0].St_km_obrigatoriobool &&
                    km_atual.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar KM para GRAVAR abastecimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    km_atual.Focus();
                    return;
                }
                if (km_atual.Focused)
                {
                    decimal KM = decimal.Zero;
                    if (!this.ValidarKm(ref KM))
                    {
                        MessageBox.Show("KM Atual não pode ser menor ou igual ao ultimo KM informado para a placa (Ultimo KM: " + KM.ToString("N0", new System.Globalization.CultureInfo("pt-BR")) + ").",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        km_atual.Value = decimal.Zero;
                        km_atual.Focus();
                        return;
                    }
                }
                try
                {
                    (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_abastecimento = "P";
                    (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_captura = "A";
                    (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_registro = "A";
                    (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Vl_unitario = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa,
                                                                                                                                                                     (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_produto,
                                                                                                                                                                     null);                   
                    CamadaNegocio.Frota.TCN_AbastVeiculo.Gravar(bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo, null);
                    MessageBox.Show("Abastecimento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bb_cancelar_Click(this, new EventArgs());
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void km_atual_Leave(object sender, EventArgs e)
        {
            decimal KM = decimal.Zero;
            if (!this.ValidarKm(ref KM))
            {
                MessageBox.Show("KM Atual não pode ser menor ou igual ao ultimo KM informado para a placa (Ultimo KM: " + KM.ToString("N0", new System.Globalization.CultureInfo("pt-BR")) + ").",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                km_atual.Value = decimal.Zero;
                km_atual.Focus();
            }
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void bb_abast_Click(object sender, EventArgs e)
        {
            using (TFListaAbastecida fLista = new TFListaAbastecida())
            {
                fLista.Cd_empresa = empresa.SelectedValue.ToString();
                if(fLista.ShowDialog() == DialogResult.OK)
                    if (fLista.rAbast != null)
                    {
                        volume_requisicao.Value = fLista.rAbast.Volume;
                        dt_requisicao.Text = fLista.rAbast.Dt_abastecidastr;
                        (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).rAbast = fLista.rAbast;
                        km_atual.Focus();
                    }
            }
        }

        private void TFLanAbastFrota_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                tmpAbastecimento.Enabled = false;
                tmpAbastecimento.Dispose();
            }
            catch
            { }
        }
    }
}
