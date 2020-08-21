using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Contabil.Cadastros
{
    public partial class TFPlanoReferencial : Form
    {
        public TFPlanoReferencial()
        {
            InitializeComponent();
        }

        private void TFPlanoReferencial_Load(object sender, EventArgs e)
        {
            bsPlanoReferencia.DataSource = CamadaNegocio.Contabil.Cadastro.TCN_PlanoReferencial.Buscar(string.Empty, string.Empty, null);
        }

        private void bbImportar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "Plano Referencial|*.txt";
                op.Title = "Selecionar Plano Contas Referencial";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.File.Exists(op.FileName))
                    {
                        CamadaDados.Contabil.Cadastro.TList_PlanoReferencial lPlano = new CamadaDados.Contabil.Cadastro.TList_PlanoReferencial();
                        System.IO.StreamReader reader = new System.IO.StreamReader(op.FileName, Encoding.UTF7);
                        string linha = string.Empty;
                        while ((linha = reader.ReadLine()) != null)
                        {
                            if (!string.IsNullOrEmpty(linha))
                                if (Char.IsNumber(linha, 0))
                                {
                                    string[] v = linha.Split(new char[] { '|' });
                                    DateTime? dt_ini = null;
                                    if (v[2].Trim().Length.Equals(8))
                                        dt_ini = new DateTime(int.Parse(v[2].Substring(4, 4)), int.Parse(v[2].Substring(2, 2)), int.Parse(v[2].Substring(0, 2)));
                                    DateTime? dt_fin = null;
                                    if (v[3].Trim().Length.Equals(8))
                                        dt_fin = new DateTime(int.Parse(v[3].Substring(4, 4)), int.Parse(v[3].Substring(2, 2)), int.Parse(v[3].Substring(0, 2)));
                                    lPlano.Add(new CamadaDados.Contabil.Cadastro.TRegistro_PlanoReferencial()
                                    {
                                        Cd_referencia = v[0],
                                        Nome = v[1].RemoverCaracteres().ToUpper(),
                                        Dt_ini = dt_ini,
                                        Dt_fin = dt_fin,
                                        Tp_conta = v[5],
                                        Cd_referenciapai = v[6],
                                        Nivel = decimal.Parse(v[7]),
                                        Natureza = string.IsNullOrEmpty(v[8].SoNumero()) ? string.Empty : decimal.Parse(v[8]).ToString()
                                    });
                                }
                        }
                        try
                        {
                            CamadaNegocio.Contabil.Cadastro.TCN_PlanoReferencial.Gravar(lPlano, null);
                            MessageBox.Show("Plano Referencial importado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsPlanoReferencia.DataSource = lPlano;
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (FCad_PlanoReferencia plano = new FCad_PlanoReferencia())
            {
                if (plano.ShowDialog() == DialogResult.OK)
                {

                    CamadaNegocio.Contabil.Cadastro.TCN_PlanoReferencial.Gravar(plano.rPlano, null);
                    MessageBox.Show("Plano Referencial gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsPlanoReferencia.Add(plano.rPlano);

                }
            }
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(bsPlanoReferencia.Current != null)

            using (FCad_PlanoReferencia plano = new FCad_PlanoReferencia())
            {
                plano.rPlano = (bsPlanoReferencia.Current as CamadaDados.Contabil.Cadastro.TRegistro_PlanoReferencial);
                if (plano.ShowDialog() == DialogResult.OK)
                {

                    CamadaNegocio.Contabil.Cadastro.TCN_PlanoReferencial.Gravar(plano.rPlano, null);
                    MessageBox.Show("Plano Referencial gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        bsPlanoReferencia.DataSource = CamadaNegocio.Contabil.Cadastro.TCN_PlanoReferencial.Buscar(string.Empty, string.Empty, null);
                        //     bsPlanoReferencia.Add(plano.rPlano);
                    }


            }
        }
    }
}
