using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utils
{
    public partial class FTelaEspera : Form
    {
        public FTelaEspera()
        {
            InitializeComponent();
        }

        private void TelaEspera_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }
    }

    public class ThreadEspera
    {
        public FTelaEspera TelaEspera = new FTelaEspera();
        public bool alive = true;
        public bool msg_nova = true;
        public List<string> arrayTarefas = new List<string>();
        public int tarefaCurrent = 0;

        public ThreadEspera(string titulo)
        {
            TelaEspera.labelMSG.Text = titulo;
            TelaEspera.Show();
        }

        public void Msg(string msg)
        {
            this.tarefaCurrent = arrayTarefas.Count;
            arrayTarefas.Add(msg);
            
            TelaEspera.textBoxTarefa.Text += arrayTarefas[tarefaCurrent] + Environment.NewLine;
            
            TelaEspera.Refresh();
        }

        public void Fechar()
        {
            TelaEspera.Dispose();
            this.alive = false;
        }

        public void AbreForm()
        {
            bool _found = false;

            foreach (Form _openForm in Application.OpenForms)
            {
                if (_openForm is FTelaEspera)
                {
                    _openForm.Focus();
                    _found = true;
                }
            }

            if (!_found)
            {
                TelaEspera.ShowDialog();
            }

            msg_nova = false;
        }
    }
}

