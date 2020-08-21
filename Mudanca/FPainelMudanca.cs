using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace Mudanca
{
    public partial class TFPainelMudanca : Form
    {
        private int month
        { get; set; }
        private int daysMonth
        { get; set; }
        private CamadaDados.Mudanca.TList_LanMudanca lMudanca
        { get; set; }
        private ListBox[] lista = new ListBox[6];
        private ToolTip toolTip
        { get; set; }
        private CamadaDados.Mudanca.Cadastros.TList_CFGMudanca lCfg
        { get; set; }
        public TFPainelMudanca()
        {
            InitializeComponent();
            for (int i = 2013; i < 2050; i++)
                cbxAno.Items.Add(i);
        }

        private void LimparLabel()
        {
            lb1.Items.Clear();
            lb2.Items.Clear();
            lb3.Items.Clear();
            lb4.Items.Clear();
            lb5.Items.Clear();
            lb6.Items.Clear();
            lb7.Items.Clear();
            lb8.Items.Clear();
            lb9.Items.Clear();
            lb10.Items.Clear();
            lb11.Items.Clear();
            lb12.Items.Clear();
            lb13.Items.Clear();
            lb14.Items.Clear();
            lb15.Items.Clear();
            lb16.Items.Clear();
            lb17.Items.Clear();
            lb18.Items.Clear();
            lb19.Items.Clear();
            lb20.Items.Clear();
            lb21.Items.Clear();
            lb22.Items.Clear();
            lb23.Items.Clear();
            lb24.Items.Clear();
            lb25.Items.Clear();
            lb26.Items.Clear();
            lb27.Items.Clear();
            lb28.Items.Clear();
            lb29.Items.Clear();
            lb30.Items.Clear();
            lb31.Items.Clear();
            lb32.Items.Clear();
            lb33.Items.Clear();
            lb34.Items.Clear();
            lb35.Items.Clear();
            lb36.Items.Clear();
            lb37.Items.Clear();
        }

        private void ListBoxSelect(ListBox sender)
        {
            try
            {
                if (((ListBox)sender).Name.Equals("0") ||
                    ((ListBox)sender).Name.Equals("lb1") ||
                    ((ListBox)sender).Name.Equals("lb2") ||
                    ((ListBox)sender).Name.Equals("lb3") ||
                    ((ListBox)sender).Name.Equals("lb4") ||
                    ((ListBox)sender).Name.Equals("lb5") ||
                    ((ListBox)sender).Name.Equals("lb6") ||
                    ((ListBox)sender).Name.Equals("lb7"))
                {
                    lb7.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb6.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb5.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb4.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb3.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb2.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb1.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lista[0].SelectedIndex = ((ListBox)sender).SelectedIndex;
                }
                else if (((ListBox)sender).Name.Equals("1") ||
                    ((ListBox)sender).Name.Equals("lb8") ||
                    ((ListBox)sender).Name.Equals("lb9") ||
                    ((ListBox)sender).Name.Equals("lb10") ||
                    ((ListBox)sender).Name.Equals("lb11") ||
                    ((ListBox)sender).Name.Equals("lb12") ||
                    ((ListBox)sender).Name.Equals("lb13") ||
                    ((ListBox)sender).Name.Equals("lb14"))
                {
                    lb8.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb9.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb10.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb11.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb12.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb13.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb14.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lista[1].SelectedIndex = ((ListBox)sender).SelectedIndex;
                }
                else if (((ListBox)sender).Name.Equals("2") ||
                    ((ListBox)sender).Name.Equals("lb15") ||
                    ((ListBox)sender).Name.Equals("lb16") ||
                    ((ListBox)sender).Name.Equals("lb17") ||
                    ((ListBox)sender).Name.Equals("lb18") ||
                    ((ListBox)sender).Name.Equals("lb19") ||
                    ((ListBox)sender).Name.Equals("lb20") ||
                    ((ListBox)sender).Name.Equals("lb21"))
                {
                    lb15.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb16.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb17.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb18.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb19.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb20.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb21.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lista[2].SelectedIndex = ((ListBox)sender).SelectedIndex;
                }
                else if (((ListBox)sender).Name.Equals("3") ||
                    ((ListBox)sender).Name.Equals("lb22") ||
                    ((ListBox)sender).Name.Equals("lb23") ||
                    ((ListBox)sender).Name.Equals("lb24") ||
                    ((ListBox)sender).Name.Equals("lb25") ||
                    ((ListBox)sender).Name.Equals("lb26") ||
                    ((ListBox)sender).Name.Equals("lb27") ||
                    ((ListBox)sender).Name.Equals("lb28"))
                {
                    lb22.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb23.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb24.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb25.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb26.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb27.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb28.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lista[3].SelectedIndex = ((ListBox)sender).SelectedIndex;
                }
                else if (((ListBox)sender).Name.Equals("4") ||
                    ((ListBox)sender).Name.Equals("lb29") ||
                    ((ListBox)sender).Name.Equals("lb30") ||
                    ((ListBox)sender).Name.Equals("lb31") ||
                    ((ListBox)sender).Name.Equals("lb32") ||
                    ((ListBox)sender).Name.Equals("lb33") ||
                    ((ListBox)sender).Name.Equals("lb34") ||
                    ((ListBox)sender).Name.Equals("lb35"))
                {
                    lb29.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb30.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb31.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb32.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb33.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb34.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb35.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lista[4].SelectedIndex = ((ListBox)sender).SelectedIndex;
                }
                else if (((ListBox)sender).Name.Equals("5") ||
                    ((ListBox)sender).Name.Equals("lb36") ||
                    ((ListBox)sender).Name.Equals("lb37"))
                {
                    lb36.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lb37.SelectedIndex = ((ListBox)sender).SelectedIndex;
                    lista[5].SelectedIndex = ((ListBox)sender).SelectedIndex;
                }
            }
            catch { }
        }

        private ListBox NextDay(string lbl)
        {
            ListBox retorno = new ListBox();
            if (lbl.Equals("lb0"))
                return lb1;
            else if (lbl.Equals("lb1"))
                return lb2;
            else if (lbl.Equals("lb2"))
                return lb3;
            else if (lbl.Equals("lb3"))
                return lb4;
            else if (lbl.Equals("lb4"))
                return lb5;
            else if (lbl.Equals("lb5"))
                return lb6;
            else if (lbl.Equals("lb6"))
                return lb7;
            else if (lbl.Equals("lb7"))
                return lb8;
            else if (lbl.Equals("lb8"))
                return lb9;
            else if (lbl.Equals("lb9"))
                return lb10;
            else if (lbl.Equals("lb10"))
                return lb11;
            else if (lbl.Equals("lb11"))
                return lb12;
            else if (lbl.Equals("lb12"))
                return lb13;
            else if (lbl.Equals("lb13"))
                return lb14;
            else if (lbl.Equals("lb14"))
                return lb15;
            else if (lbl.Equals("lb15"))
                return lb16;
            else if (lbl.Equals("lb16"))
                return lb17;
            else if (lbl.Equals("lb17"))
                return lb18;
            else if (lbl.Equals("lb18"))
                return lb19;
            else if (lbl.Equals("lb19"))
                return lb20;
            else if (lbl.Equals("lb20"))
                return lb21;
            else if (lbl.Equals("lb21"))
                return lb22;
            else if (lbl.Equals("lb22"))
                return lb23;
            else if (lbl.Equals("lb23"))
                return lb24;
            else if (lbl.Equals("lb24"))
                return lb25;
            else if (lbl.Equals("lb25"))
                return lb26;
            else if (lbl.Equals("lb26"))
                return lb27;
            else if (lbl.Equals("lb27"))
                return lb28;
            else if (lbl.Equals("lb28"))
                return lb29;
            else if (lbl.Equals("lb29"))
                return lb30;
            else if (lbl.Equals("lb30"))
                return lb31;
            else if (lbl.Equals("lb31"))
                return lb32;
            else if (lbl.Equals("lb32"))
                return lb33;
            else if (lbl.Equals("lb33"))
                return lb34;
            else if (lbl.Equals("lb34"))
                return lb35;
            else if (lbl.Equals("lb35"))
                return lb36;
            else if (lbl.Equals("lb36"))
                return lb37;
            else return retorno;
        }

        private void PreencherMes(string day)
        {
            //int i = 1;
            if (day.Trim().ToUpper().Equals("SUNDAY"))
            {
                //lb1.Text = i.ToString();
                this.PositionWeek(-1);
            }
            else if (day.ToUpper().Equals("MONDAY"))
            {
                //lb2.Text = i.ToString();
                this.PositionWeek(0);
            }
            else if (day.Trim().ToUpper().Equals("TUESDAY"))
            {
                //lb3.Text = i.ToString();
                this.PositionWeek(1);
            }
            else if (day.Trim().ToUpper().Equals("WEDNESDAY"))
            {
                //lb4.Text = i.ToString();
                this.PositionWeek(2);
            }
            else if (day.Trim().ToUpper().Equals("THURSDAY"))
            {
                //lb5.Text = i.ToString();
                this.PositionWeek(3);
            }
            else if (day.Trim().ToUpper().Equals("FRIDAY"))
            {
                //lb6.Text = i.ToString();
                this.PositionWeek(4);
            }
            else if (day.Trim().ToUpper().Equals("SATURDAY"))
            {
                //lb7.Text = i.ToString();
                this.PositionWeek(5);
            }            
        }

        private void PositionWeek(int y)
        {
            //Criar Lista Veiculo
            List<string> veiculo = new List<string>();
            //Preencher Lista Veiculo
            for (int i = 0; lista[0].Items.Count > i; i++)
                veiculo.Add(lista[0].Items[i].ToString());
            for (int x = 1; daysMonth + 1 > x; x++)
            {
                y++;
                string lista = string.Empty;
                string b = (x < 10 ? "0" : string.Empty) + x.ToString() + "/" + (month < 10 ? "0" : string.Empty) + month.ToString() + "/" + cbxAno.SelectedItem.ToString();

                //Criar Array de Mudanca
                string[] mudanca = new string[veiculo.Count];
                for (int i = 0; veiculo.Count > i; i++)
                    mudanca[i] = string.Empty;
                //Formar Lista de Viagens do dia
                 lMudanca.Where(p => DateTime.Parse(b) >= p.Dt_viagem && 
                                     DateTime.Parse(b) <= p.Dt_entrega).ToList().ForEach(p =>
                {
                        if (string.IsNullOrEmpty(mudanca[0]))
                            mudanca[0]= (x.ToString());
                        if (veiculo.Exists(h=> h.Equals(p.placa)))
                        {
                           int position = veiculo.FindIndex(h=> h.Equals(p.placa));
                           if (DateTime.Parse(b) == p.Dt_viagem)
                                mudanca[position] += (" I-" + (p.Nm_clifor.Split(new char[] { ' ' })[0] + "/" + p.DS_Cidade_Orig.Trim() + "/" +  p.DS_Cidade_Dest.Trim()));
                           else if (DateTime.Parse(b) == p.Dt_entrega)
                               mudanca[position] += (" E-" + (p.Nm_clifor.Split(new char[] { ' ' })[0] + "/" + p.DS_Cidade_Orig.Trim() + "/" + p.DS_Cidade_Dest.Trim()));
                           else
                               mudanca[position] += (" V-" + (p.Nm_clifor.Split(new char[] { ' ' })[0] + "/" + p.DS_Cidade_Orig.Trim() + "/" + p.DS_Cidade_Dest.Trim()));
                        }                          
                });
                //Preencher Calendario 
                //Se existir mudancas preencher com as viagens
                if (mudanca.ToList().Exists(z=> !string.IsNullOrEmpty(z)))
                    foreach (string a in mudanca)
                    {
                        this.NextDay("lb" + y.ToString()).Items.AddRange(new object[] 
                            {
                                lista = a
                            });
                    }
                else// senao preencher somente o dia
                    this.NextDay("lb" + y.ToString()).Items.AddRange(new object[] 
                            {
                                x.ToString(),
                                string.Empty,
                                string.Empty,
                                string.Empty,
                                string.Empty,
                                string.Empty,
                            });
            }
        }

        private void PreencherMudanca(DateTime date)
        {
            //Calcular ultimo dia do mes
            DateTime d = date.AddMonths(1);
            d = d.AddDays(-1);
           lMudanca =
                new CamadaDados.Mudanca.TCD_LanMudanca().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.dt_viagem",
                        vOperador = ">=",
                        vVL_Busca = "'" + date.ToString("yyyyMMdd") + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.dt_viagem",
                        vOperador = "<=",
                        vVL_Busca = "'" + d.ToString("yyyyMMdd 23:59:59") + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, '1')",
                        vOperador = "<>",
                        vVL_Busca = "'3'"
                    },
                }, 0, string.Empty);
        }

        private void TFPainelMudanca_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar CFG Mudanca
            lCfg =
                CamadaNegocio.Mudanca.Cadastros.TCN_CFGMudanca.buscar(string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty, 
                                                                      string.Empty,
                                                                      null);
            //Image imagem = null;
            //byte[] img = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlImagem("IMAGEM_RELATORIO", lCfg[0].Cd_empresa, null);
            //if (img != null)
            //{
            //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //    ms.Write(img, 0, img.Length);
            //    imagem = Image.FromStream(ms);
            //    pLogo.BackgroundImage = imagem;
            //}
            tcPainel.TabPages.Remove(tpMes);
            cbxAno.SelectedItem = DateTime.Now.Year;
            for (int i = 0; lista.Count() > i; i++)
                lista[i] = new ListBox();
            //Buscar Veiculos
            CamadaDados.Frota.Cadastros.TList_CadVeiculo lVeic =
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'I'" 
                        }
                    }, 0, string.Empty);
            if (lVeic.Count > 0)
                lVeic.ForEach(p =>
                {
                    this.NewListBox(p.placa,
                                   new EventArgs());
                });
        }

        private void bb_mes_Click(object sender, EventArgs e)
        {
            month = 0;
            if (((Button)sender).Text.ToUpper().Equals("JANEIRO"))
                month = 01;
            else if (((Button)sender).Text.ToUpper().Equals("FEVEREIRO"))
                month = 02;
            else if (((Button)sender).Text.ToUpper().Equals("MARÇO"))
                month = 03;
            else if (((Button)sender).Text.ToUpper().Equals("ABRIL"))
                month = 04;
            else if (((Button)sender).Text.ToUpper().Equals("MAIO"))
                month = 05;
            else if (((Button)sender).Text.ToUpper().Equals("JUNHO"))
                month = 06;
            else if (((Button)sender).Text.ToUpper().Equals("JULHO"))
                month = 07;
            else if (((Button)sender).Text.ToUpper().Equals("AGOSTO"))
                month = 08;
            else if (((Button)sender).Text.ToUpper().Equals("SETEMBRO"))
                month = 09;
            else if (((Button)sender).Text.ToUpper().Equals("OUTUBRO"))
                month = 10;
            else if (((Button)sender).Text.ToUpper().Equals("NOVEMBRO"))
                month = 11;
            else if (((Button)sender).Text.ToUpper().Equals("DEZEMBRO"))
                month = 12;

            // obtém a quantidade de dias MÊS e ANO selecionados
            System.Globalization.Calendar c = new System.Globalization.GregorianCalendar();
            daysMonth = c.GetDaysInMonth(int.Parse(cbxAno.SelectedItem.ToString()), month);
            //Verificar dia da semana em que se incia o MÊS selecionado
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.SelectedItem.ToString());
            string day = date.DayOfWeek.ToString();
            //Chamar Mes
            tcPainel.TabPages.Remove(tpAno);
            tcPainel.TabPages.Add(tpMes);
            //Preencher Mudança
            this.PreencherMudanca(date);
            //Preencher mes
            this.LimparLabel();
            this.PreencherMes(day);
            //Layout Mes
            tpMes.Text = ((Button)sender).Text + "/" + cbxAno.SelectedItem.ToString() + " - " + lCfg[0].Nm_empresa + 
                "            LEGENDA: I - INICIO VIAGEM[PRETO]|           V - EM VIAGEM[AZUL]|           E - ENTREGA[VERDE]|             [Pressione ESC para Sair].";
            tpMes.Font = new Font("Arial", 15, FontStyle.Bold);
            tpMes.ForeColor = Color.Blue;
            //Redimensionar se mes nao ocupar todos os ListBox
            if (lb29.Items.Count.Equals(0) &&
                lb30.Items.Count.Equals(0) &&
                lb31.Items.Count.Equals(0) &&
                lb32.Items.Count.Equals(0) &&
                lb33.Items.Count.Equals(0) &&
                lb34.Items.Count.Equals(0) &&
                lb35.Items.Count.Equals(0))
                tlpMes.RowStyles[5] = new RowStyle(SizeType.Absolute, 0);
            else
                tlpMes.RowStyles[5] = new RowStyle(SizeType.Percent, 16.67067F);
            //Redimensionar se mes nao ocupar todos os ListBox
            if (lb36.Items.Count.Equals(0) &&
                lb37.Items.Count.Equals(0))
                tlpMes.RowStyles[6] = new RowStyle(SizeType.Absolute, 0);
            else
                tlpMes.RowStyles[6] = new RowStyle(SizeType.Percent, 16.67067F);

        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            //Chamar Mes
            tcPainel.TabPages.Remove(tpMes);
            tcPainel.TabPages.Add(tpAno);
        }

        private void dia_Click(object sender, EventArgs e)
        {

        }

        private void TFPainelMudanca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void lb_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Brush cor = e.Index == 0 ? Brushes.Blue : Brushes.Black;
                Font fonte = e.Index == 0 ? new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))) : e.Font;

                Brush cColeta = Brushes.Black;
                Brush cViagem = Brushes.Blue;
                Brush cEntrega = Brushes.Green;
                Brush cEntregaColeta = Brushes.Gold;

                e.DrawBackground();
                if (((ListBox)sender).Items[e.Index].ToString().Contains(" I-"))
                    e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), fonte, cColeta, e.Bounds.Left, e.Bounds.Top);
                else if (((ListBox)sender).Items[e.Index].ToString().Contains(" E-"))
                    e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), fonte, cEntrega, e.Bounds.Left, e.Bounds.Top);
                else if (((ListBox)sender).Items[e.Index].ToString().Contains(" I-") &&
                         ((ListBox)sender).Items[e.Index].ToString().Contains(" E-"))
                    e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), fonte, cEntregaColeta, e.Bounds.Left, e.Bounds.Top);
                else
                    e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), fonte, cViagem, e.Bounds.Left, e.Bounds.Top);
                e.DrawFocusRectangle();
            }
            catch { }
        }

        private void NewListBox(object texto, 
                               EventArgs e)
        {
            for (int i = 0; lista.Count() > i; i++)
            {
                this.tlpMes.Controls.Add(((ListBox)lista[i]), 0, i + 1);
                ((ListBox)lista[i]).FormattingEnabled = true;
                ((ListBox)lista[i]).Name = i.ToString();
                ((ListBox)lista[i]).IntegralHeight = false;
                ((ListBox)lista[i]).Size = new Size(104, 65);
                ((ListBox)lista[i]).Dock = DockStyle.Fill;
                ((ListBox)lista[i]).Font = new Font("Arial", 10.869F, FontStyle.Bold);
                ((ListBox)lista[i]).ItemHeight = 17;
                if (((ListBox)lista[i]).Items.Count.Equals(0))
                    ((ListBox)lista[i]).Items.AddRange(new object[] { string.Empty });
                ((ListBox)lista[i]).Items.AddRange(new object[] { texto.ToString() });
                ((ListBox)lista[i]).Click += new System.EventHandler(this.lb_Click);
            }
        }

        private void lb_Click(object sender, EventArgs e)
        {
            try
            {
                toolTip = new ToolTip(); 
                toolTip.Show(((ListBox)sender).SelectedItem.ToString(), this, ((ListBox)sender).Location.X, ((ListBox)sender).Location.Y, 6000);
                this.ListBoxSelect(((ListBox)sender));
            }
            catch { }
        }
    }
}
