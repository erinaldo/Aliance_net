using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Componentes
{
    public partial class CheckedListBoxDefault : CheckedListBox
    {
        private DataTable vTabela;
        private string vDisplayColuna;
        private string vValueColuna;
        private string vNM_Campo;
        private string vNM_Alias;
        private bool vST_Gravar;
        private bool vST_Checked;
     //   private string vVl_Busca;

        public DataTable Tabela { get { return vTabela; } set { setVTabela(value); } }
        public string Display { get { if (vDisplayColuna == null)return ""; else return vDisplayColuna; } set { setVDisplay(value); } }
        public string Value { get { if (vValueColuna == null)return ""; else return vValueColuna; } set { vValueColuna = value; } }
        public string NM_Campo { get { if (vNM_Campo == null)return ""; else return vNM_Campo; } set { vNM_Campo = value; } }
        public string NM_Alias { get { if (vNM_Alias == null)return ""; else return vNM_Alias; } set { vNM_Alias = value; } }
        public string Vl_Busca { get {  return getVl_Busca(); } }
        public bool ST_Gravar { get { return vST_Gravar; } set { vST_Gravar = value; } }
        public bool ST_Checked { get { return vST_Checked; } set { vST_Checked = value; } }


        private int IndexOf(string valor)
        {
            for (int i = 0; i < vTabela.Rows.Count; i++)
                if (vTabela.Rows[i][Display].ToString().Trim().ToUpper().Equals(valor.Trim().ToUpper()))
                    return i;
            return -1;
        }

        private void preencherItens()
        {
            if ((vTabela != null) && (vDisplayColuna.Trim() != ""))
            {
                this.Items.Clear();
                for (int i = 0; i < vTabela.Rows.Count; i++)
                    this.Items.Add(vTabela.Rows[i][vDisplayColuna].ToString(), vST_Checked);
            }
        }

        private void setVTabela(DataTable value)
        {
            vTabela = value;
            preencherItens();
        }

        private string getVl_Busca()
        {
            string retorno = "";
            if (vValueColuna.Trim() != "")
            {
                string vVirgula = "";
                for (int i = 0; i < this.CheckedItems.Count; i++)
                {
                    int vindex = IndexOf(this.CheckedItems[i].ToString());
                    if (vindex >= 0)
                    {
                        retorno += vVirgula + "'" + vTabela.Rows[vindex][Value].ToString().Trim() + "'";
                        vVirgula = ",";
                    }
                }
            }
            return retorno;
        }

        private void setVDisplay(string value)
        {
            vDisplayColuna = value;
            preencherItens();
        }

        public CheckedListBoxDefault()
        {
            InitializeComponent();
            this.CheckOnClick = true;
            this.HorizontalScrollbar = true;
        }

        public CheckedListBoxDefault(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.CheckOnClick = true;
            this.HorizontalScrollbar = true;
        }
    }
}
