using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class TFCartoesMesa : Form
    {
        public string pNr_Mesa { get; set; } = string.Empty;
        public string pId_local { get; set; } = string.Empty;
        public string pCd_Empresa { get; set; } = string.Empty;
        public string pNr_Cartao { get; set; } = string.Empty;
        public string pId_Cartao { get; set; } = string.Empty;


        public TFCartoesMesa()
        {
            InitializeComponent();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void carregarmesas()
        {
            CamadaDados.Restaurante.TList_Cartao cartao = new CamadaDados.Restaurante.TList_Cartao();
            cartao = new CamadaDados.Restaurante.TCD_Cartao().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = pCd_Empresa
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "c.nr_mesa",
                        vOperador = "=",
                        vVL_Busca = pNr_Mesa
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.id_local",
                        vOperador = "=",
                        vVL_Busca = pId_local
                    }, 
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.st_registro",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }, 0,string.Empty,string.Empty);

            //adiciona locais na tabcontrol de locais
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            Componentes.ListPanel[] lPanel = new Componentes.ListPanel[cartao.Count];
            flow.Controls.Clear();
            int i = 0;
            cartao.ForEach(pi =>
            {

                lPanel[i] = new Componentes.ListPanel();
                flow.Controls.Add(lPanel[i]);
                lPanel[i].Location = new System.Drawing.Point(3, 3);
                lPanel[i].Name = pi.nr_cartao.ToString();
                lPanel[i].Tag = pi.id_cartao.ToString();
                lPanel[i].NM_Campo = pi.nr_cartao.ToString();


                lPanel[i].Size = new System.Drawing.Size(25, 15);
                lPanel[i].TabIndex = 0; 
                lPanel[i].BackColor = Color.GreenYellow;  

                lPanel[i].BorderStyle = BorderStyle.FixedSingle;
                lPanel[i].Click += new EventHandler(this.Mesa_Click);
                 
                i++;


            });
            panelDados3.Controls.Add(flow);

        }
        private void Mesa_Click(object sender, EventArgs e)
        {
          //  carregarmesas();
            //((Componentes.PanelDados)sender).BackColor = Color.Blue;
            pId_Cartao = ((Componentes.ListPanel)sender).Tag.ToString();
            pNr_Cartao = ((Componentes.ListPanel)sender).Name.ToString();
            mesa_n.Text = ((Componentes.ListPanel)sender).Name.ToString();

        }

        private void FCartoesMesa_Load(object sender, EventArgs e)
        {
            carregarmesas();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(pNr_Cartao))
            this.DialogResult = DialogResult.OK;
        }
    }
}
