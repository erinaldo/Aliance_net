using System;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFViagem : Form
    {
        private CamadaDados.Financeiro.Viagem.TRegistro_Viagem rviagem;
        public CamadaDados.Financeiro.Viagem.TRegistro_Viagem rViagem
        {
            get
            {
                if (bsViagem.Current != null)
                    return bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem;
                else
                    return null;
            }
            set { rviagem = value; }
        }
        public TFViagem()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pViagem.validarCampoObrigatorio())
            {
                if((bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).Dt_ini >
                    (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).Dt_fin)
                {
                    MessageBox.Show("Data Inicial é maior que a final!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).lDespesas.ForEach(p => 
                {
                    if ((bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).Dt_ini >
                    p.Dt_despesa)
                    {
                        MessageBox.Show("Data Inicial é maior que uma despesa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                });

                DialogResult = DialogResult.OK;
            }
        }

        private void InserirDespesas()
        {
            using (TFDespesasViagem fDesp = new TFDespesasViagem())
            {
                if (fDesp.ShowDialog() == DialogResult.OK)
                    if (fDesp.rDespesas != null)
                    {
                        if (fDesp.rDespesas.Tp_pagamento.Trim().ToUpper().Equals("1"))
                        {
                            using (TFLanDuplicata fDup = new TFLanDuplicata())
                            {
                                fDup.vCd_empresa = (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).Cd_empresa;
                                fDup.vNm_empresa = (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).Nm_empresa;
                                fDup.vCd_clifor = fDesp.vCD_Clifor;
                                fDup.vNm_clifor = fDesp.rDespesas.Nm_fornecedor;
                                
                                //Buscar Endereço
                                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_clifor",
                                                vOperador = "=",
                                                vVL_Busca = "'" + fDesp.vCD_Clifor.Trim() + "'"
                                            }
                                        }, 1, string.Empty);
                                if (lEnd.Count > 0)
                                {
                                    fDup.vCd_endereco = lEnd[0].Cd_endereco;
                                    fDup.vDs_endereco = lEnd[0].Ds_endereco;
                                }
                                //fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                //fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                //fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                //fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                fDup.vTp_mov = "P";
                                //fDup.vCd_historico = lCfg[0].Cd_historico;
                                //fDup.vDs_historico = lCfg[0].Ds_historico;
                                fDup.vDt_emissao = fDesp.rDespesas.Dt_despesastr;
                                fDup.vVl_documento = fDesp.rDespesas.Vl_subtotal;
                                fDup.vNr_docto = fDesp.rDespesas.Nr_notafiscal;
                                fDup.vSt_finPed = true;
                                fDup.St_bloquearccusto = true;//Centro Resultado sera lancado pela despesa da viagem
                                if (fDup.ShowDialog() == DialogResult.OK)
                                    if (fDup.dsDuplicata.Count > 0)
                                        fDesp.rDespesas.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                    else
                                    {
                                        MessageBox.Show("Obrigatório gerar duplicata para incluir despesa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Obrigatório gerar duplicata para incluir despesa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                                 (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).Cd_empresa,
                                                                                 null).Trim().ToUpper().Equals("S"))
                        {
                            using (TFRateioCResultado fRateio = new TFRateioCResultado())
                            {
                                fRateio.vVl_Documento = fDesp.rDespesas.Vl_subtotal;
                                fRateio.Tp_mov = "P";
                                fRateio.Dt_movimento = fDesp.rDespesas.Dt_despesa;
                                fRateio.ShowDialog();
                                fDesp.rDespesas.lCCusto = fRateio.lCResultado;
                            }
                        }
                        (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).lDespesas.Add(fDesp.rDespesas);
                        bsViagem.ResetCurrentItem();
                    }
            }
        }

        private void ExcluirDespesas()
        {
            if (MessageBox.Show("Confirma a exclusão do item?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).lDespesasDel.Add(bsDespesas.Current as CamadaDados.Financeiro.Viagem.TRegistro_DespesasViagem);
                bsDespesas.RemoveCurrent();
                bsViagem.ResetCurrentItem();
            }
        }

        private void TFViagem_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pViagem.set_FormatZero();
            if (rviagem != null)
            {
                bsViagem.DataSource = new CamadaDados.Financeiro.Viagem.TList_Viagem() { rviagem };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
            }
            else
                bsViagem.AddNew();
        }

        private void ts_btn_InserirRota_Click(object sender, EventArgs e)
        {
            InserirDespesas();
        }

        private void ts_btn_DeletarRota_Click(object sender, EventArgs e)
        {
            ExcluirDespesas();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, Nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, Nm_empresa }, string.Empty);
        }

        private void Cd_funcionario_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + Cd_funcionario.Text.Trim() + "';" +
                               "ISNULL(a.st_funcionarios, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_funcionario, Nm_funcionario },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_funcionario_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                             "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_funcionario, Nm_funcionario },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               "ISNULL(a.st_funcionarios, 'N')|=|'S'");
        }

        private void TFViagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirDespesas();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirDespesas();
        }

        private void km_inicial_Leave(object sender, EventArgs e)
        {
            if (km_inicial.Value > 0 && km_prevfinal.Value > 0)
                if (km_inicial.Value > km_prevfinal.Value)
                {
                    MessageBox.Show("KM Inicial não pode ser maior que KM Final!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    km_inicial.Value = decimal.Zero;
                    km_inicial.Focus();
                    return;
                }
        }

        private void km_inicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                km_inicial_Leave(this, new EventArgs());
        }

        private void km_prevfinal_Leave(object sender, EventArgs e)
        {
            if (km_inicial.Value > 0 && km_prevfinal.Value > 0)
                if (km_inicial.Value > km_prevfinal.Value)
                {
                    MessageBox.Show("KM Final não pode ser menor que KM Inicial!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    km_prevfinal.Value = decimal.Zero;
                    km_prevfinal.Focus();
                    return;
                }
        }

        private void km_prevfinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                km_prevfinal_Leave(this, new EventArgs());
        }
    }
}
