using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cartao;
using CamadaNegocio.Financeiro.Cartao;

namespace Financeiro
{
    public partial class FDescontarCartao : Form
    {
        public FDescontarCartao()
        {
            InitializeComponent();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }
        
        private void afterbusca()
        {

            bsLoteCartao.DataSource = TCN_LanLoteCartao.Buscar(cd_empresa.Text,
                id_lote.Text, string.Empty, string.Empty, string.Empty, 
                cbAberto.Checked ? "'A'" : cbProcessado.Checked ? "'P'" : "'A','P'"
                , null);
            bsLoteCartao_PositionChanged(this, new EventArgs());
            bsLoteCartao.ResetCurrentItem();

        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void bsLoteCartao_PositionChanged(object sender, EventArgs e)
        {
            if(bsLoteCartao.Current != null)
            {
                (bsLoteCartao.Current as TRegistro_LanLoteCartao).lCartao = TCN_FaturaDescontar.Buscar(
                    (bsLoteCartao.Current as TRegistro_LanLoteCartao).Cd_Empresa,
                    (bsLoteCartao.Current as TRegistro_LanLoteCartao).Id_Lote.ToString(),
                    string.Empty,
                    null);
            }
            bsLoteCartao.ResetCurrentItem();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            using (FLoteCartaoDescontar flote = new FLoteCartaoDescontar())
            {
                if(flote.ShowDialog() == DialogResult.OK)
                {
                    TCN_LanLoteCartao.Gravar(flote.rLoteCartao, null);
                    MessageBox.Show("Lote Gravado com sucesso!", "Mensagem.");
                    afterbusca();
                }


            }
        }

        private void FDescontarCartao_Load(object sender, EventArgs e)
        {

            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void FDescontarCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                BB_Novo_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F5))
                BB_Excluir_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F7))
                BB_Buscar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F9))
                BB_ProcessarLote_Click(this, new EventArgs());

        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            if (bsLoteCartao.Current != null)
                if ((bsLoteCartao.Current as TRegistro_LanLoteCartao).St_registro.Trim().ToUpper().Equals("A"))
                {
                    if (MessageBox.Show("Confirma exclusão do registro?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            TCN_LanLoteCartao.Excluir(bsLoteCartao.Current as TRegistro_LanLoteCartao, null);
                            afterbusca();
                            MessageBox.Show("Lote excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro excluir lote: " + ex.Message);
                        }
                    }
                }
                else
                    MessageBox.Show("Não é permitido excluir lote processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_ProcessarLote_Click(object sender, EventArgs e)
        {
            if (bsLoteCartao.Current != null)
            {
                using (TFProcessarLoteBloqueto processa = new TFProcessarLoteBloqueto())
                {
                    bsLoteCartao.ResetCurrentItem();
                    // preenche list fat
                    (bsLoteCartao.Current as TRegistro_LanLoteCartao).lCartao.ForEach(p =>
                    {
                        (bsLoteCartao.Current as TRegistro_LanLoteCartao).lFatCartao.Add(TCN_FaturaCartao.Buscar(p.Id_Fatura.ToString(), p.Cd_Empresa, string.Empty,
                            string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                            string.Empty, string.Empty, string.Empty, string.Empty, decimal.Zero, decimal.Zero, true, string.Empty, string.Empty, null)[0]);

                    });

                    processa.Id_lote = (bsLoteCartao.Current as TRegistro_LanLoteCartao).Id_Lote.ToString();
                    processa.Ds_lote = (bsLoteCartao.Current as TRegistro_LanLoteCartao).Ds_Lote;
                    processa.Dt_processamento = (bsLoteCartao.Current as TRegistro_LanLoteCartao).Dt_Processamento;
                    processa.Vl_totalbloqueto = (bsLoteCartao.Current as TRegistro_LanLoteCartao).lFatCartao.Sum(p => p.Vl_liquido);
                    if (processa.ShowDialog() == DialogResult.OK)
                    {
                        CamadaDados.Financeiro.Cadastros.TList_CFGFaturaCartao lCfg =
                      CamadaNegocio.Financeiro.Cadastros.TCN_CFGFaturaCartao.Buscar((bsLoteCartao.Current as TRegistro_LanLoteCartao).Cd_Empresa,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           string.Empty,
                                                           null);


                        //quitar faturas
                        (bsLoteCartao.Current as TRegistro_LanLoteCartao).lFatCartao.ForEach(p =>
                        {
                            TCN_FaturaCartao.QuitarFatura((bsLoteCartao.Current as TRegistro_LanLoteCartao).lFatCartao,
                                                                                                      Convert.ToDateTime(processa.Dt_processamento),
                                                                                                      p.Cd_contager,
                                                                                                      p.Cd_empresa,
                                                                                                      p.Tp_movimento,
                                                                                                      null);
                        });

                        string retorno = CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa()
                        {
                            Cd_ContaGer = (bsLoteCartao.Current as TRegistro_LanLoteCartao).Cd_ContaGer,
                            Cd_Empresa = (bsLoteCartao.Current as TRegistro_LanLoteCartao).Cd_Empresa,
                            Cd_Historico = lCfg[0].Cd_historico_taxa,
                            ComplHistorico = "TAXA DESCONTO CARTOES DO LOTE " + (bsLoteCartao.Current as TRegistro_LanLoteCartao).Id_Lote,
                            Dt_lancto = (bsLoteCartao.Current as TRegistro_LanLoteCartao).Dt_Processamento != null ?  (bsLoteCartao.Current as TRegistro_LanLoteCartao).Dt_Processamento: processa.Dt_processamento,
                            Nr_Docto = "LOTE" + (bsLoteCartao.Current as TRegistro_LanLoteCartao).Id_Lote,
                            St_Estorno = "N",
                            Vl_PAGAR = processa.Vl_taxa,
                            Vl_RECEBER = decimal.Zero
                        }, null);
                        (bsLoteCartao.Current as TRegistro_LanLoteCartao).Cd_LanctoCaixa = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_CD_LANCTOCAIXA")) ;
                        (bsLoteCartao.Current as TRegistro_LanLoteCartao).Dt_Processamento = (bsLoteCartao.Current as TRegistro_LanLoteCartao).Dt_Processamento != null ? (bsLoteCartao.Current as TRegistro_LanLoteCartao).Dt_Processamento : processa.Dt_processamento;
                        (bsLoteCartao.Current as TRegistro_LanLoteCartao).St_registro = "P";
                       TCN_LanLoteCartao.Gravar((bsLoteCartao.Current as TRegistro_LanLoteCartao), null);
                        MessageBox.Show("Quitação fatura realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    processa.Vl_totalbloqueto = decimal.Zero;
                    afterbusca();
                }
                //this.afterBusca();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Estornar_Click(object sender, EventArgs e)
        {

            if (bsLoteCartao.Current != null)
            {
                if (MessageBox.Show("Confirma estorno do processamento do lote?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsLoteCartao.Current as TRegistro_LanLoteCartao).lCartao.ForEach(p =>
                    {
                        if ((bsLoteCartao.Current as TRegistro_LanLoteCartao).lLanCaixa.Count < 1)
                            (bsLoteCartao.Current as TRegistro_LanLoteCartao).lLanCaixa = 
                            TCN_FaturaCartao_X_Caixa.BuscarCaixa(p.Id_Fatura.ToString(),
                            null);

                        if ((bsLoteCartao.Current as TRegistro_LanLoteCartao).lFatCartao_Caixa.Count < 1)
                            (bsLoteCartao.Current as TRegistro_LanLoteCartao).lFatCartao_Caixa =
                            TCN_FaturaCartao_X_Caixa.Buscar(p.Id_Fatura.ToString(),
                            (bsLoteCartao.Current as TRegistro_LanLoteCartao).Cd_ContaGer,
                            (bsLoteCartao.Current as TRegistro_LanLoteCartao).Cd_LanctoCaixa.ToString(),
                            null);

                        if ((bsLoteCartao.Current as TRegistro_LanLoteCartao).lFatCartao.Count < 1)
                            (bsLoteCartao.Current as TRegistro_LanLoteCartao).lFatCartao =
                            TCN_FaturaCartao.Buscar(p.Id_Fatura.ToString(),
                            (bsLoteCartao.Current as TRegistro_LanLoteCartao).Cd_Empresa,
                            string.Empty,string.Empty, string.Empty, string.Empty,string.Empty,string.Empty,string.Empty,
                            (bsLoteCartao.Current as TRegistro_LanLoteCartao).Cd_ContaGer.ToString(),
                            string.Empty,string.Empty,string.Empty,string.Empty,decimal.Zero,decimal.Zero, true, string.Empty,string.Empty,
                            null);
                    });
                    try
                    {
                        TCN_LanLoteCartao.EstornarLote((bsLoteCartao.Current as TRegistro_LanLoteCartao), null);
                        MessageBox.Show("Lote estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro estornar lote: " + ex.Message);
                    }
                }
            }
        }
    }
}
