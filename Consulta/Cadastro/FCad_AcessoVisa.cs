using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Consulta.Cadastro
{
    public partial class TFCad_AcessoVisa : Form
    {
        public TFCad_AcessoVisa()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (bsVisaoBI.Current != null)
            {
                string vColunas = "Login|Log.|100";
                string vParam = "|exists|(select 1 from tb_div_usuario x " +
                            "          where x.Login = a.Login )";

                DataRowView data = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null,
                                        new CamadaDados.Diversos.TCD_CadUsuario(), vParam);
                bsAcessoVisao.AddNew();
                (bsAcessoVisao.Current as CamadaDados.Consulta.Cadastro.TRegistro_AcessoVisao).Login = data.Row.ItemArray[0].ToString();
                (bsAcessoVisao.Current as CamadaDados.Consulta.Cadastro.TRegistro_AcessoVisao).id_Visao = (bsVisaoBI.Current as CamadaDados.Consulta.Cadastro.TRegistro_VisaoBI).id_Visao;
                CamadaNegocio.Consulta.Cadastro.TCN_Cad_AcessoVisao.Grava((bsAcessoVisao.Current as CamadaDados.Consulta.Cadastro.TRegistro_AcessoVisao));

                MessageBox.Show("Salvo com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bsVisaoBI_PositionChanged(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Selecione uma visão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void FCad_AcessoVisa_Load(object sender, EventArgs e)
        {

        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            bsVisaoBI.DataSource = CamadaNegocio.Consulta.Cadastro.TCN_Cad_VisaoBI.Busca(
                                                                                             decimal.Zero,
                                                                                             string.Empty
                                                                                             );
            bsVisaoBI.ResetCurrentItem();
        }

        private void bsVisaoBI_PositionChanged(object sender, EventArgs e)
        {
            if (bsVisaoBI.Current != null)
            {
                bsAcessoVisao.DataSource = CamadaNegocio.Consulta.Cadastro.TCN_Cad_AcessoVisao.Busca(
                                                                                                 (bsVisaoBI.Current as CamadaDados.Consulta.Cadastro.TRegistro_VisaoBI).id_Visao,
                                                                                                 string.Empty
                                                                                                 );
                bsAcessoVisao.ResetCurrentItem();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            if (bsAcessoVisao.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro?\r\n" +
                                   "Deseja excluir este acesso.",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Consulta.Cadastro.TCN_Cad_AcessoVisao.Deleta((bsAcessoVisao.Current as CamadaDados.Consulta.Cadastro.TRegistro_AcessoVisao));
                        bsVisaoBI_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar login para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void afterbusca()
        {
            BB_Buscar_Click(this, new EventArgs());
        }
        private void bbInserirEtapa_Click(object sender, EventArgs e)
        {
            using(Consulta.Cadastro.FCadVisaoBI visaobi = new FCadVisaoBI()){
                visaobi.ShowDialog();
                if (visaobi.DialogResult == DialogResult.OK)
                {
                    bsVisaoBI.AddNew();
                    //bsVisaoBI.Current = visaobi.rVisao;
                    CamadaNegocio.Consulta.Cadastro.TCN_Cad_VisaoBI.Grava(visaobi.rVisao);
                    MessageBox.Show("Salvo com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterbusca();
                }

            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



