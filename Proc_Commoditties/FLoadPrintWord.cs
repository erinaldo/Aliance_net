using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class FLoadPrintWord : Form
    {
        public FLoadPrintWord()
        {
            InitializeComponent();
        }

        private void FLoadPrintWord_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }
    }

    public class ThreadLoadWordPrint
    {
        public FLoadPrintWord TelaEspera = new FLoadPrintWord();
        public bool alive = true;
        public bool msg_nova = true;
        public List<string> arrayTarefas = new List<string>();
        public int tarefaCurrent = 0;

        public ThreadLoadWordPrint(string titulo)
        {
            TelaEspera.labelMSG.Text = titulo;
            TelaEspera.Show();
        }

        public void Msg(string msg)
        {
            this.tarefaCurrent = arrayTarefas.Count;
            arrayTarefas.Add(msg);
            
            //TelaEspera.textBoxTarefa.Text += arrayTarefas[tarefaCurrent] + Environment.NewLine;
            
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
                if (_openForm is FLoadPrintWord)
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
