using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using CamadaDados.Restaurante;
using CamadaNegocio.Restaurante;
namespace Restaurante
{
    public partial class FTrocaMesa : Form
    {
        TList_CFG lcfg = new TList_CFG();
        TList_Local local_mesa = new TList_Local();

        public decimal? id_mesa;
        public decimal? id_local;
        public string Nr_mesa = string.Empty;
        public string id_cartao = string.Empty;
        public bool seleciona_mesa = false;

        public FTrocaMesa()
        {
            InitializeComponent();
        }

        public void fecharFrame()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void carregarmesas()
        {
            //Buscar mesas pré-cadastradas
            local_mesa = TCN_Local.Buscar(string.Empty, string.Empty, string.Empty, null);

            local_mesa.ForEach(pi =>
            {
                //Buscar mesas de cada local
                pi.lMesa = TCN_Mesa.Buscar(string.Empty, string.Empty, string.Empty, null);
            });

            mesas_tab.TabPages.Clear();
            local_mesa.ForEach(pi =>
            {
                TabPage tab = new TabPage();
                tab.Text = pi.Ds_Local;
                tab.Name = pi.Id_Local.ToString();
                FlowLayoutPanel flow = new FlowLayoutPanel();
                flow.Dock = DockStyle.Fill;

                if (pi.lMesa.Count > 0)
                {
                    Componentes.ListPanel[] lPanel = new Componentes.ListPanel[pi.lMesa.Count];
                    flow.Controls.Clear();
                    for (int i = 0; pi.lMesa.Count > i; i++)
                    {
                        if (pi.Id_Local.Equals(pi.lMesa[i].Id_Local))
                        {
                            lPanel[i] = new Componentes.ListPanel();
                            flow.Controls.Add(lPanel[i]);
                            lPanel[i].Location = new Point(3, 3);
                            lPanel[i].Name = pi.lMesa[i].Id_Local.ToString() + "-" + pi.lMesa[i].Id_Mesa.ToString();
                            lPanel[i].NM_Campo = "";
                            lPanel[i].Size = new Size(25, 15);
                            lPanel[i].TabIndex = 0;
                            lPanel[i].NM_Campo = pi.lMesa[i].Nr_Mesa;
                            if (pi.lMesa[i].id_cartao == decimal.Zero)
                                lPanel[i].BackColor = Color.GreenYellow;
                            else
                                lPanel[i].BackColor = Color.Red;
                            lPanel[i].Tag = pi.lMesa[i].id_cartao;

                            lPanel[i].BorderStyle = BorderStyle.FixedSingle;
                            lPanel[i].Click += new EventHandler(Mesa_Click);
                        }
                    }
                }
                tab.Controls.Add(flow);
                mesas_tab.TabPages.Add(tab);
            });
        }

        private void Mesa_Click(object sender, EventArgs e)
        {
            string[] a = ((Componentes.ListPanel)sender).Name.Split('-');
            decimal local = Convert.ToDecimal(a[0]);
            decimal mesa = Convert.ToDecimal(a[1]);
            Nr_mesa = ((Componentes.ListPanel)sender).NM_Campo;

            object nome = new TCD_Local().BuscarEscalar(new Utils.TpBusca[]
            {
                new Utils.TpBusca()
                {
                    vNM_Campo = "a.id_local",
                    vOperador = "=",
                    vVL_Busca = a[0]
                }
            }, "ds_local");

            if (Convert.ToDecimal(((Componentes.ListPanel)sender).Tag.ToString()) == decimal.Zero)
            {
                string me = string.Empty;

                if (seleciona_mesa)
                    me = "Deseja alterar para a mesa \n ";
                else
                    me = "Mesa selecionada: " + ((Componentes.ListPanel)sender).NM_Campo;

                id_local = local;
                id_mesa = mesa;
                DialogResult = DialogResult.OK;
            }
            else
            {
                id_local = local;
                id_mesa = mesa;
                id_cartao = ((Componentes.ListPanel)sender).Tag.ToString();
                DialogResult = DialogResult.Abort;
            }
        }

        private void FTrocaMesa_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.FixedHeight, true);
            lcfg = TCN_CFG.Buscar(string.Empty, null);
            if (lcfg.Count.Equals(0)) { MessageBox.Show("Erro: Não existe configuração de restaurante.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            carregarmesas();
            if (!string.IsNullOrEmpty(id_cartao))
                nr_mesa.Text = new CamadaDados.Restaurante.TCD_Cartao().BuscarEscalar(new Utils.TpBusca[] { new Utils.TpBusca() { vNM_Campo = "a.id_cartao", vOperador = "=", vVL_Busca = id_cartao}, new Utils.TpBusca() { vNM_Campo = "a.st_registro", vOperador = "=", vVL_Busca = "'A'"} }, "c.nr_mesa").ToString();
            ActiveControl = nr_mesa;
            nr_mesa.Select();
            nr_mesa.Focus();
        }

        private void FTrocaMesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape) || e.KeyCode.Equals(Keys.F6))
                fecharFrame();
        }

        private void nr_mesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (string.IsNullOrEmpty(nr_mesa.Text.Trim()))
                    return;

                DataTable rMesa = new TCD_Mesa().Buscar(new Utils.TpBusca[] { new Utils.TpBusca() { vNM_Campo = "a.nr_mesa", vOperador = "=", vVL_Busca = nr_mesa.Text.Trim() } }, 1);
                if (rMesa != null && rMesa.Rows.Count > 0)
                {
                    Mesa_Click(new Componentes.ListPanel() { Name = rMesa.Rows[0].ItemArray[1].ToString() + "-" + rMesa.Rows[0].ItemArray[2].ToString(), Tag = 0, NM_Campo = rMesa.Rows[0].ItemArray[4].ToString() }, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Mesa não localizada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            fecharFrame();
        }
    }
}
