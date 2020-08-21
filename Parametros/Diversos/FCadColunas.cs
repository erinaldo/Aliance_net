using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using Utils;

namespace Parametros.Diversos
{
    public partial class FCadColunas : Form
    {
        private CamadaDados.Diversos.TList_Colunasbd cColun { get; set; }

        public CamadaDados.Diversos.TList_Colunasbd rColun
        {
            get
            {
                return cColun;

            }
            set
            {
                cColun = value;
            }
        }
        private CamadaDados.Diversos.TList_Colunas cColunas { get; set; } = new TList_Colunas();
        public CamadaDados.Diversos.TList_Colunas rColunas
        {
            get
            {
                return bsColunas.List as TList_Colunas;
            }
            set { cColunas = value; }
        } 

        public FCadColunas()
        {
            InitializeComponent();
        }

        private void FCadColunas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            TList_Colunas colunas = new TList_Colunas();

            if (cColun != null)
            {
                cColun.ForEach(p =>
                {
                    TRegistro_Colunas col = new TRegistro_Colunas();
                    col.nm_tabela = p.nome_tabela;
                    col.nm_coluna = p.nome_coluna;

                    object id = new TCD_Colunas().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nm_tabela",
                                vOperador = "like",
                                vVL_Busca = "'"+p.nome_tabela+"'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nm_coluna",
                                vOperador = "like",
                                vVL_Busca = "'"+p.nome_coluna+"'"
                            }
                        }, "a.id_coluna");


                    if (id != null)
                    {
                        col.id_coluna = Convert.ToDecimal(id.ToString());
                        object ds = new TCD_Colunas().BuscarEscalar(
                            new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_coluna",
                                vOperador = "=",
                                vVL_Busca = col.id_coluna.ToString()
                            }
                            }, "a.ds_coluna");

                        if (ds != null)
                            col.ds_coluna = ds.ToString();
                    }

                        colunas.Add(col);
                });
                bsColunas.DataSource = colunas;
                bsColunas.ResetCurrentItem();
            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            

            this.DialogResult = DialogResult.OK;

        }

        private void panelDados1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja Cancelar?","Mensagem",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void FCadColunas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                this.DialogResult = DialogResult.OK;
            }else if (e.KeyCode.Equals(Keys.F6))
            {
                bb_cancelar_Click(this, new EventArgs());
            }
        }
    }
}
