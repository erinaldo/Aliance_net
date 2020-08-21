using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFTrocarContrato : Form
    {
        public string pNr_contrato_dest
        { get { return nr_contrato_dest.Text; } }
        public List<CamadaDados.Balanca.TRegistro_LanPesagemGraos> lPesagem
        {
            get
            {
                if (bsPesagem.Count > 0)
                    return (bsPesagem.List as CamadaDados.Balanca.TList_RegLanPesagemGraos).FindAll(p => p.St_processarTicketRef);
                else return null;
            }
        }

        private string Cd_tabeladesc_dest{get;set;}

        public TFTrocarContrato()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_contrato_dest.Text))
            {
                MessageBox.Show("Obrigatorio informar contrato destino.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_contrato_dest.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[4];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            //Contrato destino
            filtro[1].vNM_Campo = "a.cd_tabeladesconto";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + Cd_tabeladesc_dest.Trim() + "'";
            //Status do Ticket
            filtro[2].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[2].vOperador = "in";
            filtro[2].vVL_Busca = "('A', 'F')";
            //Nao ter sido aplicado
            filtro[3].vNM_Campo = string.Empty;
            filtro[3].vOperador = "not exists";
            filtro[3].vVL_Busca = "(select 1 from tb_bal_aplicacao_pedido x " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.id_ticket = a.id_ticket " +
                                  "and x.tp_pesagem = a.tp_pesagem)";
            if (!string.IsNullOrEmpty(nr_contrato_orig.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_contrato_orig.Text;
            }
            if (!string.IsNullOrEmpty(CD_Contratante.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contratante";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Contratante.Text.Trim() + "'";
            }
            if(string.IsNullOrEmpty(CD_Contratante.Text) &&
                (!string.IsNullOrEmpty(nm_contratante.Text)))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NM_Contratante";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + nm_contratante.Text.Trim() + "%'";
            }
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_bruto)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_bruto)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
            }
            bsPesagem.DataSource = new CamadaDados.Balanca.TCD_LanPesagemGraos().Select(filtro, string.Empty, string.Empty, 0, string.Empty);
        }

        private void FTrocarContrato_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_contrato_dest_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { nr_contrato_dest }, "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'");
            if(linha != null)
                Cd_tabeladesc_dest = linha["cd_tabeladesconto"].ToString();
            else Cd_tabeladesc_dest = string.Empty;
        }

        private void nr_contrato_dest_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE("a.nr_contrato|=|" + nr_contrato_dest.Text + ";" +
                                              "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                              new Componentes.EditDefault[] { nr_contrato_dest },
                                              new CamadaDados.Graos.TCD_CadContrato());
            if(linha != null)
                Cd_tabeladesc_dest = linha["cd_tabeladesconto"].ToString();
            else Cd_tabeladesc_dest = string.Empty;
        }

        private void bb_contrato_orig_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { nr_contrato_orig }, "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'");
        }

        private void nr_contrato_orig_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.nr_contrato|=|" + nr_contrato_orig.Text + ";" +
                                              "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                              new Componentes.EditDefault[] { nr_contrato_orig },
                                              new CamadaDados.Graos.TCD_CadContrato());
        }

        private void bb_contratante_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Contratante }, string.Empty);
            nm_contratante.Enabled = string.IsNullOrEmpty(CD_Contratante.Text);
        }

        private void CD_Contratante_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Contratante.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Contratante }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            nm_contratante.Enabled = string.IsNullOrEmpty(CD_Contratante.Text);
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsPesagem.Count > 0)
            {
                (bsPesagem.List as CamadaDados.Balanca.TList_RegLanPesagemGraos).ForEach(p => p.St_processarTicketRef = cbTodos.Checked);
                bsPesagem.ResetBindings(true);
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFTrocarContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gPesagem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsPesagem.Current as CamadaDados.Balanca.TRegistro_LanPesagemGraos).St_processarTicketRef =
                    !(bsPesagem.Current as CamadaDados.Balanca.TRegistro_LanPesagemGraos).St_processarTicketRef;
                bsPesagem.ResetCurrentItem();
            }
        }
    }
}
