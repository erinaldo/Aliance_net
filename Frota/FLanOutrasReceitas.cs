using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using CamadaDados.Frota.Cadastros;
using CamadaNegocio.Frota.Cadastros;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFLanOutrasReceitas : Form
    {
        public TFLanOutrasReceitas()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            id_receita.Text = string.Empty;
            cd_empresa.Text = string.Empty;
            id_veiculo.Text = string.Empty;
            cd_motorista.Text = string.Empty;
            dt_ini.Text = string.Empty;
            dt_fin.Text = string.Empty;
        }

        private void afterBusca()
        {
            bsReceitas.DataSource =
                CamadaNegocio.Frota.TCN_OutrasReceitas.Buscar(id_receita.Text,
                                                              cd_empresa.Text,
                                                              string.Empty,
                                                              id_veiculo.Text,
                                                              cd_motorista.Text,
                                                              string.Empty,
                                                              dt_ini.Text,
                                                              dt_fin.Text,
                                                              false,
                                                              null);
            bsReceitas.ResetCurrentItem();
        }

        private void afterNovo()
        {
            using(TFOutrasReceitas fReceita = new TFOutrasReceitas())
            {
                
                if (fReceita.ShowDialog() == DialogResult.OK)
                    if (fReceita.rReceita != null)
                        
                        try
                        {

                            if(fReceita.vl_docto != decimal.Zero)
                                //Lançar Duplicata
                                using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                                {
                                    fDup.vSt_ctrc = true;
                                    fDup.vCd_empresa = fReceita.rReceita.Cd_empresa;
                                    fDup.vNm_empresa = fReceita.rReceita.Nm_empresa;
                                    fDup.vCd_clifor = fReceita.rReceita.Cd_clifor;
                                    fDup.vNm_clifor = fReceita.rReceita.Nm_clifor;
                                    //Buscar endereco clifor
                                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fReceita.rReceita.Cd_clifor,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  1,
                                                                                                  null);
                                    if (lEnd.Count > 0)
                                    {
                                        fDup.vCd_endereco = lEnd[0].Cd_endereco;
                                        fDup.vDs_endereco = lEnd[0].Ds_endereco;
                                    }
                                    fDup.vTp_mov = "R";
                                    //Buscar TP.Duplicata
                                    CamadaDados.Financeiro.Cadastros.TList_CadTpDuplicata lTpDup =
                                       new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_mov",
                                                        vOperador = "=",
                                                        vVL_Busca = "'R'"
                                                    }
                                                }, 1, string.Empty);
                                    fDup.vTp_duplicata = lTpDup.Count > 0 ? lTpDup[0].Tp_duplicata : string.Empty;
                                    fDup.vDs_tpduplicata = lTpDup.Count > 0 ? lTpDup[0].Ds_tpduplicata : string.Empty;
                                    fDup.vDt_emissao = fReceita.rReceita.Dt_receitastr;
                                    fDup.vVl_documento = fReceita.vl_docto;
                                        fDup.vNr_docto = "RECEITA" + fReceita.rReceita.Dt_receitastr;
                                    if (fDup.ShowDialog() == DialogResult.OK)
                                        if (fDup.dsDuplicata.Count > 0)
                                            fReceita.rReceita.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                        else
                                        {
                                            MessageBox.Show("Obrigatório gravar Duplicata para lançar receita!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    else
                                    {
                                        MessageBox.Show("Obrigatório gravar Duplicata para lançar receita!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            CamadaNegocio.Frota.TCN_OutrasReceitas.Gravar(fReceita.rReceita, null);
                            MessageBox.Show("Receita gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparCampos();
                            id_receita.Text = fReceita.rReceita.Id_receitastr;
                            cd_empresa.Text = fReceita.rReceita.Cd_empresa;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsReceitas.Current != null)
                using (TFOutrasReceitas fReceita = new TFOutrasReceitas())
                {
                    fReceita.rReceita = bsReceitas.Current as CamadaDados.Frota.TRegistro_OutrasReceitas;
                    if (fReceita.ShowDialog() == DialogResult.OK)
                        if (fReceita.rReceita != null)
                            try
                            {
                                CamadaNegocio.Frota.TCN_OutrasReceitas.Gravar(fReceita.rReceita, null);
                                MessageBox.Show("Receita alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimparCampos();
                                id_receita.Text = fReceita.rReceita.Id_receitastr;
                                cd_empresa.Text = fReceita.rReceita.Cd_empresa;
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if (bsReceitas.Current != null)
                if (MessageBox.Show("Confirma a exclusão da receita?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.TCN_OutrasReceitas.Excluir(bsReceitas.Current as CamadaDados.Frota.TRegistro_OutrasReceitas, null);
                        MessageBox.Show("Receita excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparCampos();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFLanOutrasReceitas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFLanOutrasReceitas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterDevolver();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                  new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo  },
                                        new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo },
                                        new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|'" + cd_motorista.Text.Trim() + "';" +
                            "isnull(a.s t_motorista, 'N')|=|'S';" +
                            "isnull(a.ST_AtivoMot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LeaveClifor(vParam, new Componentes.EditDefault[] { cd_motorista },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.ST_AtivoMot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista }, vParam);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_devolver_Click(object sender, EventArgs e)
        {
            using(TFDevolucaoOutrasReceitas fdevolucao = new TFDevolucaoOutrasReceitas()){
                fdevolucao.preenche();
                fdevolucao.vl_adtoViagem = (bsReceitas.Current as CamadaDados.Frota.TRegistro_OutrasReceitas).Vl_adtoViagem;
                if (fdevolucao.ShowDialog() == DialogResult.OK)
                    if (fdevolucao.rLancaixa != null)
                    {
                       

                        CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(fdevolucao.rLancaixa,null);
                        TRegistro_DevOutrasReceitas rdevolucao = new CamadaDados.Frota.Cadastros.TRegistro_DevOutrasReceitas();

                        rdevolucao.cd_contager = fdevolucao.rLancaixa.Cd_ContaGer;
                        rdevolucao.Id_lanctoCaixa = fdevolucao.rLancaixa.Cd_LanctoCaixa;
                        rdevolucao.Id_receita = (bsReceitas.Current as CamadaDados.Frota.TRegistro_OutrasReceitas).Id_receita;
                                       
                        TCN_DevOutrasReceitas.Gravar(rdevolucao,null);

                    }


            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.afterDevolver();
        }

        private void afterDevolver()
        {
            if ((bsReceitas.Current as CamadaDados.Frota.TRegistro_OutrasReceitas).Sd_devadtoViagem != decimal.Zero)
                using (TFDevolucaoOutrasReceitas fdevolucao = new TFDevolucaoOutrasReceitas())
                {
                    fdevolucao.preenche();
                    fdevolucao.vl_adtoViagem = (bsReceitas.Current as CamadaDados.Frota.TRegistro_OutrasReceitas).Vl_adtoViagem;
                    if (fdevolucao.ShowDialog() == DialogResult.OK)
                        if (fdevolucao.rLancaixa != null)
                        {


                            CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(fdevolucao.rLancaixa, null);
                            TRegistro_DevOutrasReceitas rdevolucao = new CamadaDados.Frota.Cadastros.TRegistro_DevOutrasReceitas();

                            rdevolucao.cd_contager = fdevolucao.rLancaixa.Cd_ContaGer;
                            rdevolucao.Id_lanctoCaixa = fdevolucao.rLancaixa.Cd_LanctoCaixa;
                            rdevolucao.Id_receita = (bsReceitas.Current as CamadaDados.Frota.TRegistro_OutrasReceitas).Id_receita;

                            TCN_DevOutrasReceitas.Gravar(rdevolucao, null);

                        }


                }
            else
                MessageBox.Show("Não há saldo devedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);


            this.afterBusca();
        }
    }
}
