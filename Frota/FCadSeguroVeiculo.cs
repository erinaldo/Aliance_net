using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFCadSeguroVeiculo : Form
    {
        private CamadaDados.Frota.Cadastros.TRegistro_CadSeguroVeiculo rseguro;
        public CamadaDados.Frota.Cadastros.TRegistro_CadSeguroVeiculo rSeguro
        {
            get
            {
                if (bsSeguros.Count > 0)
                    return bsSeguros.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroVeiculo;
                else
                    return null;
            }
            set
            { rseguro = value; }
        }
        public TFCadSeguroVeiculo()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDadosSeguro.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void inserirPremio()
        {
            if(bsSeguros.Current != null)
                using (TFCadPremioSeguro fPremio = new TFCadPremioSeguro())
                {
                    if(fPremio.ShowDialog() == DialogResult.OK)
                        if (fPremio.rPremio != null)
                        {  
                            (bsSeguros.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroVeiculo).lPremios.Add(fPremio.rPremio);
                             bsSeguros.ResetCurrentItem();    
                        }
                      
                }
        }

        private void AlterarPremio()
        {
            if (bsPremios.Current != null)
                using (TFCadPremioSeguro fPremio = new TFCadPremioSeguro())
                {
                    string ds_premio = (bsPremios.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroPremios).Ds_premio;
                    string vl_premio = (bsPremios.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroPremios).Vl_premio.ToString();

                    fPremio.rPremio = bsPremios.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroPremios;
                    if (fPremio.ShowDialog() != DialogResult.OK)
                    {
                        (bsPremios.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroPremios).Ds_premio = ds_premio;
                        (bsPremios.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroPremios).Vl_premio = Convert.ToDecimal(vl_premio);
                        bsPremios.ResetCurrentItem();
                    }
                }
        }

        private void excluirPremio()
        {
            if(bsPremios.Current != null)
                if (MessageBox.Show("Confirma exclusão do premio selecionado?", "Mensagem", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsSeguros.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroVeiculo).lPremiosDel.Add(
                        bsPremios.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroPremios);
                    bsPremios.RemoveCurrent();
                }
        }

        private void TFCadSeguroVeiculo_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDadosSeguro.set_FormatZero();
            if (rseguro != null)
            {
                bsSeguros.DataSource = new CamadaDados.Frota.Cadastros.TList_CadSeguroVeiculo() { rseguro };
                id_veiculo.Enabled = false;
                bb_veiculo.Enabled = false;
            }
            else
                bsSeguros.AddNew();
        }

        private void cd_seguradora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_seguradora.Text.Trim() + "';" +
                               "isnull(a.st_registro, 'N')|=|'S';" +
                                "isnull(a.st_ativo, 'N')|=|'S'"; 
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_seguradora, nm_seguradora },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_seguradora_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Seguradora|200;" +
                              "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_seguradora, nm_seguradora },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               string.Empty);
        }

        private void cd_corretora_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_corretora.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'N')|=|'S';" +
                            "isnull(a.st_ativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_corretora, nm_corretora },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_corretora_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Corretora|200;" +
                              "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_corretora, nm_corretora},
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                                            string.Empty);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFCadSeguroVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.inserirPremio();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarPremio();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.excluirPremio();
        }

        private void btn_InserirSeguros_Item_Click(object sender, EventArgs e)
        {
            this.inserirPremio();
        }

        private void BB_Alterar_Premios_Click(object sender, EventArgs e)
        {
            this.AlterarPremio();
        }

        private void btn_DeletaSeguros_Item_Click(object sender, EventArgs e)
        {
            this.excluirPremio();
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }
    }
}
