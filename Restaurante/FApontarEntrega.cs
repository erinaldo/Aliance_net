using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante;

namespace Restaurante
{
    public partial class TFApontarEntrega : Form
    {
        public string cd_entregador { get; set; } = string.Empty;
        public string ds_entregador { get; set; } = string.Empty;
        private CamadaDados.Restaurante.Cadastro.TList_CFG lcfg = new CamadaDados.Restaurante.Cadastro.TList_CFG();
        private TRegistro_PreVenda cPrevenda = new TRegistro_PreVenda();
        public TRegistro_PreVenda rPreVenda
        {
            get
            {
                return bsPreVenda.Current as TRegistro_PreVenda;
            }
            set
            {
                cPrevenda = value;
            }
        }

        public TFApontarEntrega()
        {
            InitializeComponent();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            try
            {
                if (lcfg[0].id_cargo != null)
                {
                    string vparam = "a.st_motorista|=|'S';" +
                            "a.id_cargo|=|'" + lcfg[0].id_cargo + "'";
                    FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, vparam);
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível obter listagem de entregador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            try
            {
                FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';a.id_cargo|=|'" + lcfg[0].id_cargo + "'" + "a.st_motorista|=|'S'",
                    new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            }
            catch
            {
                MessageBox.Show("Não foi possível obter listagem de entregador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void FApontarEntrega_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (cPrevenda != null)
                bsPreVenda.Add(cPrevenda);
            lcfg = CamadaNegocio.Restaurante.Cadastro.TCN_CFG.Buscar(string.Empty, null);
            if (lcfg.Count.Equals(0)) { MessageBox.Show("Não existe CFG. Restaurante cadastrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            cd_entregador = cd_clifor.Text;
            ds_entregador = nm_clifor.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FApontarEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                bb_inutilizar_Click(this, new EventArgs());
            }
            else if (e.KeyCode.Equals(Keys.F6) || e.KeyCode.Equals(Keys.Escape))
            {
                bb_cancelar_Click(this, new EventArgs());
            }
        }
    }
}
