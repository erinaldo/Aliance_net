using FormBusca;
using System;
using System.Data;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFListRegraEspecial : Form
    {
        public TFListRegraEspecial()
        {
            InitializeComponent();
        }
        

        private void TFListRegraEspecial_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void tvRegras_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
                if (e.Node.Tag.ToString().Trim().ToUpper() != "N")
                    bsUsuario.DataSource = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.Buscar(string.Empty, string.Empty, e.Node.Text.Trim().ToUpper(), null);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bbAddLogin_Click(object sender, EventArgs e)
        {
            if(tvRegras.SelectedNode != null)
                if(!tvRegras.SelectedNode.Tag.ToString().Trim().ToUpper().Equals("N"))
                {
                    //Buscar Login
                    string vColunas = "a.login|Login|100;" +
                              "a.nome_usuario|Nome Usuario|200";
                    string vParam = "a.Tp_Registro|=|'U';" +
                                    "|not exists|(select 1 from tb_div_usuario_x_regraespecial x " +
                                    "where x.login = a.login and x.ds_regra = '" + tvRegras.SelectedNode.Text.Trim().ToUpper() + "')";
                    DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Diversos.TCD_CadUsuario(), vParam);
                    if (linha != null)
                        try
                        {
                            CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.Gravar(
                                new CamadaDados.Diversos.TRegistro_Usuario_RegraEspecial
                                {
                                    Login = linha["login"].ToString(),
                                    Ds_regra = tvRegras.SelectedNode.Text.Trim().ToUpper()
                                }, null);
                            MessageBox.Show("Login adicionado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsUsuario.DataSource = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.Buscar(string.Empty, string.Empty, tvRegras.SelectedNode.Text, null);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else MessageBox.Show("Obrigatório selecionar login para adicionar regra.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void bbDelLogin_Click(object sender, EventArgs e)
        {
            if(bsUsuario.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.Excluir(bsUsuario.Current as CamadaDados.Diversos.TRegistro_Usuario_RegraEspecial, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsUsuario.DataSource = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.Buscar(string.Empty, string.Empty, tvRegras.SelectedNode.Text, null);
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

      
    }
}
