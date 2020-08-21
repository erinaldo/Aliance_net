using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;
using FormBusca;
using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Diversos;

namespace Financeiro
{
    public partial class TFLan_ReciboAvulso : Form
    {
        private bool Altera_Relatorio = false;

        public TFLan_ReciboAvulso()
        {
            InitializeComponent();
            panelDados1.set_FormatZero();

        }

        public string tp_movimento = "";
        public string end_empresa = "";

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            buscaEnd(cd_clifor.Text);

        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            imprimirRecibo();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_clifor|=| '" + cd_clifor.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new TCD_CadClifor());
            buscaEnd(cd_clifor.Text);
        }

        private void buscaEnd(string cd_clifor)
        {
            if (!string.IsNullOrEmpty(cd_clifor))
            {
                TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_clifor, 
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
                                                                              0,
                                                                              null);
                cd_end.Text = lEnd[0].Cd_endereco;
                endereco.Text = lEnd[0].Ds_endereco;
                Cep.Text = lEnd[0].Cep;
                Fone_Contato.Text = lEnd[0].Fone;
                cidade.Text = lEnd[0].rCidade.Ds_cidade;
            }
            else
            {
                cd_end.Clear();
                endereco.Clear();
                Cep.Clear();
                Fone_Contato.Clear();
                cidade.Clear();
            }

        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void afterNovo()
        {
            nr_Dup.Clear();
            cd_clifor.Clear();
            dt_liquid.Clear();
            cd_empresa.Clear();
            nm_Empresa.Clear();
            vl_recibo.Value = 0;
            nm_clifor.Clear();
            cd_end.Clear();
            endereco.Clear();
            Cep.Clear();
            cidade.Clear();
            Fone_Contato.Clear();
            nr_Dup.Focus();
        }

        private void imprimirRecibo()
        {
            if ((cd_clifor.Text.Trim() != string.Empty) && (cd_empresa.Text.Trim() != string.Empty))
            {
                FormRelPadrao.TCN_LayoutRecibo.Imprime_Recibo(Altera_Relatorio, 
                                                              cd_clifor.Text,
                                                              nm_clifor.Text, 
                                                              nr_Dup.Text, 
                                                              cd_empresa.Text, 
                                                              nm_Empresa.Text, 
                                                              cd_end.Text, 
                                                              end_empresa,
                                                              nr_Dup.Text,
                                                              cd_parcela.Text, 
                                                              vl_recibo.Value, 
                                                              Convert.ToDateTime(dt_liquid.Text), 
                                                              tp_Mov.NM_Valor,
                                                              Observacao.Text);
            }
        }

        private void TFLan_ReciboAvulso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F8))
                imprimirRecibo();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Selecione o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_Empresa|Nome Empresa|300;a.cd_Empresa|Código Empresa|90";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_Empresa }, new TCD_CadEmpresa(), null);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=| '" + cd_empresa.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_Empresa }, new TCD_CadEmpresa());
            TList_CadEmpresa lEnd =
                    CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(cd_empresa.Text, "", "", null);
            end_empresa = lEnd[0].Ds_endereco.ToString();
        }

        private void TFLan_ReciboAvulso_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            nr_Dup.Focus();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
