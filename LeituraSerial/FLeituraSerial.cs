using System;
using System.Windows.Forms;
using Utils;
using System.Runtime.InteropServices;

namespace LeituraSerial
{
    public partial class TFLeituraSerial : Form
    {
        [DllImport("peso32.dll", EntryPoint = "ConfiguraRs")]
        public static extern int ConfiguraRs(string Config);
        [DllImport("peso32.dll", EntryPoint = "LePeso")]
        public static extern int LePeso([MarshalAs(UnmanagedType.VBByRefStr)]ref string Peso);

        string RxString { get; set; }

        public CamadaDados.Diversos.TRegistro_CadProtocolo rProtocolo
        { get; set; }

        public decimal Ps_capturado
        {
            get
            {
                return pesocapturado.Value;
            }
        }

        public TFLeituraSerial()
        {
            InitializeComponent();
        }

        private void TratarDadosRecebidos(object sender, EventArgs e)
        {
            string pacote = string.Empty;
            if(rProtocolo.Tam_pacote == 0 ? true : RxString.Trim().Length.Equals(rProtocolo.Tam_pacote))
            {
                strCompleta.Text = RxString.Trim();
                tamanhoString.Text = RxString.Trim().Length.ToString();
                pacote = RxString.Trim();
                RxString = string.Empty;
                if (rProtocolo.Char_eol_str != ' ')
                {
                    string[] aux = pacote.Split(new char[] { rProtocolo.Char_eol_str });
                    if (aux.Length > 0)
                        pacote = aux[0];
                }
                vl_capturado.Text = pacote.Trim().Substring(rProtocolo.Pos_ini, rProtocolo.Size_word);
                if (!string.IsNullOrEmpty(vl_capturado.Text.SoNumero()))
                    pesocapturado.Value = Convert.ToDecimal(vl_capturado.Text.SoNumero());
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Captura_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFLeituraSerial_Load(object sender, EventArgs e)
        {
            if (rProtocolo != null)
            {
                if (rProtocolo.St_utilizardllbool)
                {
                    if (Estruturas.BaixarDll(rProtocolo.Nm_dll.Contains(".dll") ? rProtocolo.Nm_dll : rProtocolo.Nm_dll.Trim() + ".dll"))
                    {
                        int ret = ConfiguraRs(rProtocolo.Ds_porta.Trim() + ":" +
                                                rProtocolo.Baudrate.ToString() + "," +
                                                "n," +
                                                rProtocolo.Databits.ToString() + "," +
                                                rProtocolo.Stopbits.ToString());
                        if (ret.Equals(1))
                        {
                            tmpPeso.Start();
                            st_detalhes.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Erro configurar protocolo componente, verifique o cadastro protocolo e tente novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.Cancel;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dll do modulo balança não disponivel para download.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    //Porta de comunicacao
                    serial.PortName = rProtocolo.Ds_porta;
                    //Velocidade de Leitura
                    serial.BaudRate = rProtocolo.Baudrate;
                    //Bit de Dados
                    serial.DataBits = rProtocolo.Databits;
                    serial.DiscardNull = rProtocolo.St_discartarnullbool;
                    serial.DtrEnable = rProtocolo.Dtrenabledbool;
                    serial.Handshake = rProtocolo.Handshake.Trim().Equals("1") ? System.IO.Ports.Handshake.RequestToSend :
                        rProtocolo.Handshake.Trim().Equals("2") ? System.IO.Ports.Handshake.RequestToSendXOnXOff :
                        rProtocolo.Handshake.Trim().Equals("3") ? System.IO.Ports.Handshake.XOnXOff : System.IO.Ports.Handshake.None;
                    //Paridade
                    serial.Parity = rProtocolo.Parity.Trim().Equals("1") ? System.IO.Ports.Parity.Mark :
                        rProtocolo.Parity.Trim().Equals("2") ? System.IO.Ports.Parity.Even :
                        rProtocolo.Parity.Trim().Equals("3") ? System.IO.Ports.Parity.Odd :
                        rProtocolo.Parity.Trim().Equals("4") ? System.IO.Ports.Parity.Space : System.IO.Ports.Parity.None;
                    serial.ReceivedBytesThreshold = rProtocolo.ReceivedBytes.Equals(0) ? 1 : rProtocolo.ReceivedBytes;
                    serial.ReadBufferSize = rProtocolo.Tam_bufferread.Equals(0) ? 4096 : rProtocolo.Tam_bufferread;
                    //Bit de Parada
                    serial.StopBits = rProtocolo.Stopbits.Trim().ToUpper().Equals("1") ?
                        System.IO.Ports.StopBits.One : rProtocolo.Stopbits.Trim().ToUpper().Equals("1.5") ?
                        System.IO.Ports.StopBits.OnePointFive : rProtocolo.Stopbits.Trim().ToUpper().Equals("2") ?
                        System.IO.Ports.StopBits.Two : System.IO.Ports.StopBits.None;
                    serial.ReadTimeout = 2000;
                    serial.WriteTimeout = 2000;
                    try
                    {
                        serial.Open();
                        serial.WriteLine("ENQ"); 
                        string a = serial.ReadExisting();
                    }
                    catch
                    {
                        MessageBox.Show("Erro de leitura na porta serial. Tente novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.Cancel;
                    }
                }
            }
            else
            {
                MessageBox.Show("Obrigatorio informar protocolo para capturar peso balança.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxString += serial.ReadExisting();
            Invoke(new EventHandler(TratarDadosRecebidos));
        }

        private void TFLeituraSerial_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(serial.IsOpen)
                serial.Close();
            tmpPeso.Stop();
        }

        private void st_detalhes_CheckedChanged(object sender, EventArgs e)
        {
            if (st_detalhes.Checked)
                Height = 265;
            else
                Height = 130;
        }

        private void TFLeituraSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void tmpPeso_Tick(object sender, EventArgs e)
        {
            tmpPeso.Stop();
            try
            {
                string peso = new string(' ', 30);
                if (Estruturas.BaixarDll(rProtocolo.Nm_dll.Contains(".dll") ? rProtocolo.Nm_dll : rProtocolo.Nm_dll.Trim() + ".dll"))
                {
                    int ret = LePeso(ref peso);

                    if (ret.Equals(1))
                        pesocapturado.Value = decimal.Parse(peso.Substring(0, 7));
                    else if (peso.Trim().ToUpper().Equals("ERRO 1"))
                    {
                        MessageBox.Show("Não foi possivel abrir a porta serial " + rProtocolo.Ds_porta.Trim() + " especificada.\r\n" +
                                        "Ela esta sendo usada por outro aplicativo ou não existe no computador.", "Mensagem", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        DialogResult = DialogResult.Cancel;
                    }
                    else if (peso.Trim().ToUpper().Equals("ERRO 2"))
                    {
                        MessageBox.Show("Não foi possivel montar a estrutura de configuração da serial.\r\n" +
                                        "Verifique o cadastro do protocolo e tente novamente.", "Mensagem",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.Cancel;
                    }
                    else if (peso.Trim().ToUpper().Equals("ERRO 3"))
                    {
                        MessageBox.Show("Não foi possivel configurar a serial.\r\n" +
                                        "Verifique o cadastro do protocolo e tente novamente.", "Mensagem",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    MessageBox.Show("Dll do modulo balança não disponivel para download.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Cancel;
                }
            }
            catch { }
            finally
            { tmpPeso.Start(); }
        }
    }
}
