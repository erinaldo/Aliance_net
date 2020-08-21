using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;
using Utils;

namespace Parametros.Diversos
{
    public partial class FExlNcm : Form
    {
        public FExlNcm()
        {
            InitializeComponent();
        }
        private bool sincronizando = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if(!sincronizando)
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.ShowDialog();
                editDefault1.Text = file.FileName;

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(editDefault1.Text))
            {
                if(!sincronizando)
                try
                {
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@"" + editDefault1.Text + "", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Excel._Worksheet xlWorksheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    Excel.Range xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    CamadaDados.Fiscal.TList_CadNCM lNcm = new CamadaDados.Fiscal.TList_CadNCM();

                    Excel.Application oXL = new Excel.Application();
                    Excel.Workbook oWB;
                    // oXL.Visible = true;
                    oWB = oXL.Workbooks.Open(editDefault1.Text, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, null, null);
                    Excel.Worksheet activeSheet = (Excel.Worksheet)oWB.ActiveSheet;
                    // string cellA1 = (string)activeSheet.get_Range("A1", Missing.Value).Text;

                    progressBar1.Maximum = rowCount;
                    sincronizando = true;


                    int ii = 1;
                        if (chCabeca.Checked)
                            ii = 2;
                    for (int i = ii; i <= rowCount; i++)
                    {
                        progressBar1.Value = i;
                        CamadaDados.Fiscal.TRegistro_CadNCM reg = new CamadaDados.Fiscal.TRegistro_CadNCM();
                        reg.Ds_NCM = ((string)activeSheet.get_Range("D" + i, Missing.Value).Value).ToUpper();
                        reg.NCM = ((Double)activeSheet.get_Range("A" + i, Missing.Value).Value).ToString();
                        reg.Dt_DT_IniVigencia = ((DateTime)activeSheet.get_Range("I" + i, Missing.Value).Value);
                        reg.Dt_DT_FimVigencia = ((DateTime)activeSheet.get_Range("J" + i, Missing.Value).Value);

                            string E = ((string)activeSheet.get_Range("E" + i, Missing.Value).Value);
                        E = E.Replace('.', ',');
                        string F = ((string)activeSheet.get_Range("F" + i, Missing.Value).Value);
                        F = F.Replace('.', ',');
                        string G = ((string)activeSheet.get_Range("G" + i, Missing.Value).Value);
                        G = G.Replace('.', ',');
                        string H = ((string)activeSheet.get_Range("H" + i, Missing.Value).Value);
                        H = H.Replace('.', ',');


                        reg.PC_Aliquota = (Convert.ToDecimal(E) + Convert.ToDecimal(F) + Convert.ToDecimal(G) + Convert.ToDecimal(H));

                        // reg.Tipo = (string)activeSheet.get_Range("C"+ i, Missing.Value).Text;


                        lNcm.Add(reg);
                    }
                    oWB.Close();
                    progressBar2.Maximum = rowCount;
                    int j = 0;
                    lNcm.ForEach(p =>
                    {
                        progressBar2.Value = j++;
                        CamadaNegocio.Fiscal.TCN_CadNCM.GravarNCM(p);
                    });

                        MessageBox.Show("Todos registros foram sincronizados!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                }catch(Exception ex)
                {
                        MessageBox.Show("Erro ao importar NCM: "+ex, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                finally
                {
                    sincronizando = false;
                }
            }
        }

        private void FExlNcm_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            if (sincronizando)
            {
                MessageBox.Show("Aguarter terminar de sincronizar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            this.Close();
        }

        private void FExlNcm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                button1_Click(this, new EventArgs());
        }
    }
}
