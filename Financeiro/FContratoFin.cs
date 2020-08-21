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
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro
{
    public partial class TFContratoFin : Form
    {
        private CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin rcontrato;
        public CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin rContrato
        {
            get
            {
                if (bsContratoFin.Current != null)
                    return bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin;
                else
                    return null;
            }
            set { rcontrato = value; }
        }
        private decimal qtd_parc
        { get; set; }

        public TFContratoFin()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (vl_contrato.Value == decimal.Zero)
            {
                MessageBox.Show("Obrigatório informar valor do contrato!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (bsParcelas.Count == 0)
            {
                MessageBox.Show("Não existe parcelas no Contrato!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Nr_lancto == null)
            {
                try
                {
                    if (string.IsNullOrEmpty(cd_historico.Text))
                    {
                        MessageBox.Show("Obrigatório informar Historico para Gerar Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(tp_duplicata.Text))
                    {
                        MessageBox.Show("Obrigatório informar tipo de duplicata para Gerar Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(tp_docto.Text))
                    {
                        MessageBox.Show("Obrigatório informar tipo de documento para Gerar Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TRegistro_LanDuplicata rDup = new TRegistro_LanDuplicata();
                    rDup.Cd_empresa = cd_empresa.Text;
                    rDup.Cd_historico = cd_historico.Text;
                    rDup.Tp_doctostring = tp_docto.Text;
                    rDup.Tp_duplicata = tp_duplicata.Text;
                    rDup.Cd_clifor = CD_Clifor.Text;
                    rDup.Cd_endereco = CD_Endereco.Text;
                    rDup.Cd_juro = cd_juro.Text;
                    //Buscar Moeda Padrao
                    TList_Moeda tabela = CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Cd_empresa, null);
                    if (tabela != null)
                        if (tabela.Count > 0)
                        {
                            rDup.Cd_moeda = tabela[0].Cd_moeda;
                            rDup.Ds_moeda = tabela[0].Ds_moeda_singular;
                            rDup.Sigla_moeda = tabela[0].Sigla;
                        }
                    rDup.Cd_condpgto = cd_condpgto.Text;
                    rDup.Nr_docto = NR_ContratoOrigem.Text;
                    rDup.Vl_documento = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lParc.Sum(p => p.Vl_parcProvisao);
                    rDup.Vl_documento_padrao = vl_contrato.Value;
                    rDup.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                    rDup.Qt_parcelas = bsParcelas.Count;
                    decimal cd_parcela = 1;
                    (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lParc.ForEach(v =>
                        rDup.Parcelas.Add(new TRegistro_LanParcela()
                        {
                            Cd_parcela = cd_parcela++,
                            Dt_vencto = v.Dt_venctoProvisao,
                            Vl_parcela = v.Vl_parcProvisao,
                            Vl_parcela_padrao = v.Vl_parcProvisao
                        }));
                    (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup.Add(rDup);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void AjustarDadosFin()
        {
            if (bsContratoFin.Current != null)
            {
                int parcela = 1;
                (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lParcDel =
                     (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lParc;
                (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Vl_Contrato = vl_contrato.Value;
                (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).QTD_parcelas = qtd_parc;
                (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).QTD_diasdesdobro = QTD_DiasDesdobro.Value;
                (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lParc = CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.Calcula_Parcelas(bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin);
                (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lParc.ForEach(p => p.Id_parcela = parcela++);
                bsContratoFin.ResetCurrentItem();

                //Habilitar Campos
                dt_venctoParc.Enabled = bsParcelas.Count > 0;
                VL_Parcela.Enabled = bsParcelas.Count > 0;
            }
        }

        private void Busca_Endereco_Clifor()
        {
            //Busca Endereço 
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Cd_clifor + "'"
                        }
                    }, 0, string.Empty);

            //Limpar Endereço
            CD_Endereco.Text = string.Empty;
            DS_Endereco.Text = string.Empty;
            if (List_Endereco.Count == 1)
            {
                CD_Endereco.Text = List_Endereco[0].Cd_endereco.Trim();
                DS_Endereco.Text = List_Endereco[0].Ds_endereco.Trim();
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFContratoFin_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gParcelas);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rcontrato != null)
            {
                bsContratoFin.DataSource = new CamadaDados.Financeiro.Contrato.TList_ContratoFin() { rcontrato };
                if (qtd_parc == 0)
                    qtd_parc = bsParcelas.Count;
            }
            else
                bsContratoFin.AddNew();


            if (bsParcelas.Count == 0 && string.IsNullOrEmpty(cd_condpgto.Text))
            {
                //Buscar Configuração Contrato Financeiro
                CamadaDados.Financeiro.Cadastros.TList_CFGContratoFin lCfg =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CFGContratoFin.Buscar((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                if (lCfg.Count > 0)
                {
                    tp_docto.Text = lCfg[0].Tp_doctostr;
                    ds_tpdocto.Text = lCfg[0].Ds_tpdocto;
                    tp_duplicata.Text = lCfg[0].Tp_duplicata;
                    ds_tpduplicata.Text = lCfg[0].Ds_tpduplicata;
                    tp_mov.Text = "P";
                    cd_historico.Text = lCfg[0].Cd_historico;
                    ds_historico.Text = lCfg[0].Ds_historico;
                }
            }
            //Verificar se parcelas estao processadas
            if ((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Nr_lancto != null)
            {
                if ((bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup.Count == 1)
                {
                    ds_condpagto.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Ds_condpgto;
                    tp_duplicata.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Tp_duplicata;
                    ds_tpduplicata.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Ds_tpduplicata;
                    tp_docto.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Tp_doctostring;
                    ds_tpdocto.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Ds_tpdocto;
                    tp_juro.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Tp_juro;
                    cd_juro.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Cd_juro;
                    ds_juro.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Ds_juro;
                    cd_historico.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Cd_historico;
                    ds_historico.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Ds_historico;
                    tp_mov.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].Tp_mov;
                    st_comentrada.Text = (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).lDup[0].St_comentrada;
                }
                //Desabilitar Campos
                Duplicata.Enabled = false;
                vl_contrato.Enabled = false;
                QTD_DiasDesdobro.Enabled = false;
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                CD_Clifor.Enabled = false;
                BB_Clifor.Enabled = false;
                CD_Endereco.Enabled = false;
                BB_Endereco.Enabled = false;
                bb_cadclifor.Enabled = false;
            }
        }

        private void TFContratoFin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gParcelas);
        }

        private void TFContratoFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void vl_contrato_Leave(object sender, EventArgs e)
        {
            this.AjustarDadosFin();
        }

        private void QTD_DiasDesdobro_Leave(object sender, EventArgs e)
        {
            this.AjustarDadosFin();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                         , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                         , new CamadaDados.Diversos.TCD_CadEmpresa(),
                         "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                         "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                         "(exists(select 1 from tb_div_usuario_x_grupos y " +
                         "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.Busca_Endereco_Clifor();
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            this.Busca_Endereco_Clifor();
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                                , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;a.UF|Estado|150;a.fone|Telefone|80"
                                                            , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text + "'");
        }

        private void VL_Parcela_Leave(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                (bsParcelas.Current as CamadaDados.Financeiro.Contrato.TRegistro_ParcelaContrato).Vl_parcProvisao = VL_Parcela.Value;
                CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.RecalculaParc(bsParcelas.List as CamadaDados.Financeiro.Contrato.TList_ParcelaContrato,
                                                                                (bsContratoFin.Current as CamadaDados.Financeiro.Contrato.TRegistro_ContratoFin).Vl_Contrato,
                                                                                bsParcelas.Position);
                bsParcelas.ResetBindings(true);
            }
        }

        private void VL_Parcela_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                VL_Parcela_Leave(this, new EventArgs());
        }

        private void dt_venctoParc_Leave(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                (bsParcelas.Current as CamadaDados.Financeiro.Contrato.TRegistro_ParcelaContrato).Dt_venctoProvisaostr = dt_venctoParc.Text;
                CamadaNegocio.Financeiro.Contrato.TCN_ContratoFin.RecalcDiaVencto(bsParcelas.List as CamadaDados.Financeiro.Contrato.TList_ParcelaContrato,
                                                                                  QTD_DiasDesdobro.Value,
                                                                                  bsParcelas.Position);
                bsParcelas.ResetBindings(true);
   
            }
        }

        private void dt_venctoParc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                dt_venctoParc_Leave(this, new EventArgs());
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                        NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                        CD_Endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        DS_Endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.TP_Duplicata|=|'" + tp_duplicata.Text + "'";
             UtilPesquisa.EDIT_LeaveTpDuplicata(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_mov });
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vParamFixo = string.Empty;
            DataRowView linha = UtilPesquisa.BTN_BuscaTpDuplicata(new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_mov }, vParamFixo);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vColunas = "TP_Docto|=|'" + tp_docto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPDocto|Tipo Documento|350;" +
                              "TP_Docto|TP. Docto|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), "");
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CondPgto|=|'" + cd_condpgto.Text + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[]{cd_condpgto,
                                    ds_condpagto, st_comentrada, cd_juro, ds_juro,
                                    tp_juro},
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());

            if (linha != null)
            {
                QTD_DiasDesdobro.Value = Convert.ToDecimal(linha["QT_DiasDesdobro"].ToString());
                qtd_parc = Convert.ToDecimal(linha["QT_Parcelas"].ToString());
                this.AjustarDadosFin();
            }

        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_CondPgto|Condição Pagamento|350;" +
                             "a.CD_CondPgto|Cód. CondPgto|100;" +
                             "d.CD_Juro|Cód. Juro|100;" +
                             "d.DS_Juro|Descrição Juro|350";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpagto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), "");
            cd_condpgto_Leave(this, e);
        }

        private void cd_juro_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_Juro|=|'" + cd_juro.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_juro, ds_juro, tp_juro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadJuro());
        }

        private void bb_juro_Click(object sender, EventArgs e)
        {
            string coluna = "DS_Juro|Descrição Juro|200;CD_Juro|Cd. Juro|80;TP_Juro|Tipo Juro|80";
            UtilPesquisa.BTN_BUSCA(coluna, new Componentes.EditDefault[] { cd_juro, ds_juro, tp_juro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadJuro(), "");
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico.Text + "';" +
                              "a.TP_Mov|=|'" + tp_mov.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                                    new TCD_CadHistorico());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100;" +
                              "a.TP_Mov|Natureza|100;" +
                              "a.cd_Historico_Quitacao|Cd. Quitação|80;" +
                              "e.DS_Historico|Historico Quitação|200";
            string vParamFixo = "a.TP_Mov|=|'" + tp_mov.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                                        new TCD_CadHistorico(), vParamFixo);
        }
    }
}
