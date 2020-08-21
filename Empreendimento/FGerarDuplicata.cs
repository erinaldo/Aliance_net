using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Empreendimento;
using CamadaNegocio.Empreendimento;
using Utils;

namespace Empreendimento
{
    public partial class FGerarDuplicata : Form
    {
        private CamadaDados.Empreendimento.TRegistro_Despesas rdespesa;
        public CamadaDados.Empreendimento.TRegistro_Despesas rDespesa
        {
            get
            {
                if (bsDespesa.Current != null)
                    return bsDespesa.Current as CamadaDados.Empreendimento.TRegistro_Despesas;
                else return null;
            }
            set { rdespesa = value; }
        }
        public decimal vVl_Doc { get; set; }
        public FGerarDuplicata()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            

        }


        private void FGerarDuplicata_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            panelDados1.set_FormatZero();
            bsExecDespesa.AddNew();
            if (rdespesa != null)
            {
                bsDespesa.DataSource = new CamadaDados.Empreendimento.TList_Despesas() { rdespesa };
            }
            else
                bsDespesa.AddNew();
            (bsExecDespesa.Current as TRegistro_ExecDespesas).vl_executado = rdespesa.Vl_subtotal;

        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
       
        }

        private void panelDados1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (bsExecDespesa.Current != null)
            {
                using (Financeiro.TFLanDuplicata dp = new Financeiro.TFLanDuplicata())
                {
                    dp.vVl_documento = (bsExecDespesa.Current as TRegistro_ExecDespesas).vl_executado;
                    dp.vCd_empresa = (bsExecDespesa.Current as TRegistro_ExecDespesas).Cd_empresa;
                    //Buscar Moeda Padrao
                    CamadaDados.Financeiro.Cadastros.TList_Moeda tabela =
                        CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao((bsExecDespesa.Current as TRegistro_ExecDespesas).Cd_empresa, null);
                    if (tabela != null)
                        if (tabela.Count > 0)
                        {
                            dp.vCd_moeda = tabela[0].Cd_moeda;
                            dp.vDs_moeda = tabela[0].Ds_moeda_singular;
                            dp.vSigla_moeda = tabela[0].Sigla;
                            dp.vCd_moeda_padrao = tabela[0].Cd_moeda;
                            dp.vDs_moeda_padrao = tabela[0].Ds_moeda_singular;
                            dp.vSigla_moeda_padrao = tabela[0].Sigla;
                        }
                    
                    dp.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                    if (dp.ShowDialog() == DialogResult.OK)
                    {
                        CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                        rDup = dp.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                        (bsExecDespesa.Current as TRegistro_ExecDespesas).rDuplicata = rDup;
                        (bsExecDespesa.Current as TRegistro_ExecDespesas).nr_lancto = Convert.ToDecimal(dp.nr_lancto);
                        (bsExecDespesa.Current as TRegistro_ExecDespesas).Id_orcamento = rdespesa.Id_orcamento;
                        (bsExecDespesa.Current as TRegistro_ExecDespesas).Cd_empresa = rdespesa.Cd_empresa;
                        (bsExecDespesa.Current as TRegistro_ExecDespesas).Nr_versao = rdespesa.Nr_versao;
                        (bsExecDespesa.Current as TRegistro_ExecDespesas).id_despesa = Convert.ToDecimal(rdespesa.Id_despesa);

                        TCN_ExecDespesas.Gravar(bsExecDespesa.Current as TRegistro_ExecDespesas, null);
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Duplicata gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                    }

                }


            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
