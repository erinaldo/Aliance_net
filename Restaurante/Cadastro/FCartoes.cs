using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Restaurante;
using CamadaNegocio.Restaurante;

namespace Restaurante.Cadastro
{
    public partial class FCartoes : Form
    {
        public FCartoes()
        {
            InitializeComponent();
        }

        private void afterbusca()
        {
            bsCartao.DataSource = TCN_Cartao.Buscar(cd_empresa.Text, string.Empty, nr_cartao.Text, cd_clifor.Text,  string.Empty, string.Empty,string.Empty, string.Empty, string.Empty, null);
            bsCartao.ResetCurrentItem();
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            afterbusca();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.rClifor != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            cd_clifor.Text = fClifor.rClifor.Cd_clifor;
                            nm_clifor.Text = fClifor.rClifor.Nm_clifor;
                            object t = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(new TpBusca[]{
                                                                                    new TpBusca(){
                                                                                        vNM_Campo = "a.cd_clifor",
                                                                                        vOperador= "=",
                                                                                        vVL_Busca = cd_clifor.Text
                                                                                    }}, "a.cd_endereco");


                            
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            
        }

        private void FCartoes_Load(object sender, EventArgs e)
        {
            pFiltros.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            using(Cadastro.FCadCartao cartao = new Cadastro.FCadCartao())
            {
                if(cartao.ShowDialog() == DialogResult.OK)
                {
                    TCN_Cartao.Gravar(cartao.rCartao, null);
                    MessageBox.Show("Cartao gravado com sucesso!", "mensagem", MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                    nr_cartao.Text = cartao.rCartao.nr_cartao;
                    afterbusca();
                }
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            if (bsCartao.Current != null)
            using (Cadastro.FCadCartao cartao = new Cadastro.FCadCartao())
            {
                cartao.rCartao = (bsCartao.Current as TRegistro_Cartao);
                if (cartao.ShowDialog() == DialogResult.OK)
                {
                    TCN_Cartao.Gravar(cartao.rCartao, null);
                    MessageBox.Show("Cartao gravado com sucesso!", "mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    nr_cartao.Text = cartao.rCartao.nr_cartao;
                    afterbusca();
                }
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja excluir cartao?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                TCN_Cartao.Excluir(bsCartao.Current as TRegistro_Cartao, null);
                MessageBox.Show("Excluido com sucesso!", "mensagem",MessageBoxButtons.OK);
                afterbusca();
            }



        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }
    }
}
