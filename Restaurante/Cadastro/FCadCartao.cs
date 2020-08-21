using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Utils;
using System.Windows.Forms;
using CamadaDados.Restaurante;
using CamadaNegocio.Restaurante;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;

namespace Restaurante.Cadastro
{
    public partial class FCadCartao : Form
    {
        public string vCd_Empresa { get; set; } = string.Empty;
        public string vDs_Empresa { get; set; } = string.Empty;

        private TList_CFG lcfg { get; set; } = new TList_CFG();
        private TRegistro_Cartao cCartao { get; set; } = new TRegistro_Cartao();
        public TRegistro_Cartao rCartao
        {
            get
            {
                return bsCartao.Current as TRegistro_Cartao;
            }
            set
            {
                cCartao = value;
            }
        }

        public FCadCartao()
        {
            InitializeComponent();
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

        private void FCadCartao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;


            if (cCartao != null)
                bsCartao.Add(cCartao);
            else
                bsCartao.AddNew();

            lcfg = TCN_CFG.Buscar(string.Empty, null);
            if (lcfg.Count > 0)
            {
                if (lcfg[0].Tp_cartao.Equals("0"))
                {
                    cartaorot.Visible = true;
                    this.Height = 197;
                    ini.Value = lcfg[0].nr_cartaorotini;
                    fim.Value = lcfg[0].nr_cartaorotfin;
                }
                else
                    this.Width = 141;
            }

            (bsCartao.Current as TRegistro_Cartao).St_registro = "F";
            
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (panelDados1.validarCampoObrigatorio())
            {
                if (lcfg[0].Tp_cartao.Equals("0"))
                {
                    if (ini.Value > nr_cartao.Value)
                    {
                        MessageBox.Show("Número do cartão é menor que a faixa inicial do cartão: " + ini.Value + " - " + fim.Value, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    if (fim.Value < nr_cartao.Value)
                    {
                        MessageBox.Show("Número do cartão é menor que a faixa final do cartão: " + ini.Value + " - " + fim.Value, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                (bsCartao.Current as TRegistro_Cartao).Cd_empresa = lcfg[0].cd_empresa;
                (bsCartao.Current as TRegistro_Cartao).nr_card = nr_cartao.Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja cancelar?","mensagem",MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void barraMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
           
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
          
        }

        private void nr_cartao_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cd_empresa_Leave_1(object sender, EventArgs e)
        {

        }

        private void FCadCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bb_inutilizar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
        }
    }
}
