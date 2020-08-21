using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Utils;

namespace Proc_Commoditties
{
    public partial class TFBalancaProc : Form
    {
        private decimal _peso;
        private string RxString;

        public decimal Peso
        {
            get { return _peso; }
        }
        public CamadaDados.Diversos.TRegistro_CadProtocolo rProtocolo
        { get; set; } = new CamadaDados.Diversos.TRegistro_CadProtocolo();

        public TFBalancaProc()
        {
            InitializeComponent();
        }

        private void TratarDadosRecebidos(object sender, EventArgs e)
        {
            string pacote = string.Empty;
            decimal pac = 0;

            if (RxString.Trim().Length >= rProtocolo.Tam_pacote)
            {
                try
                {
                    tempo.Stop();
                    pacote = RxString.Trim().SoNumero();

                    if (RxString.Contains('.') || RxString.Contains(','))
                        pac = Convert.ToDecimal(pacote.Substring(0, rProtocolo.Tam_pacote - 1));
                    else
                        pac = Convert.ToDecimal(pacote.Substring(0, rProtocolo.Tam_pacote));

                    RxString = string.Empty;

                    _peso = pac / 1000;
                    lblPeso.Text = _peso.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "Kg";
                    BB_Capturar.Enabled = true;
                    BB_Capturar.Select();
                }
                catch { }
                finally
                { tempo.Start(); }
            }
        }

        private void FBalancaProc_Load(object sender, EventArgs e)
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

            serial.ReadTimeout = 500;
            serial.WriteTimeout = 500;

            try
            {
                serial.Open();

                if (serial.IsOpen)
                {
                    tempo.Enabled = true;
                    tempo.Start();
                }
                else
                {
                    MessageBox.Show("Erro abrir porta " + rProtocolo.Ds_porta.Trim() + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Cancel;
                    tempo.Stop();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a porta " + rProtocolo.Ds_porta.Trim() + ". Descrição do erro: " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
                tempo.Stop();

            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
        private void BB_Capturar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxString += serial.ReadExisting();
            Invoke(new EventHandler(TratarDadosRecebidos));
        }

        private void BB_Cancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Enter) && BB_Cancelar.Focused)
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Enter) && BB_Capturar.Focused)
                DialogResult = DialogResult.OK;
        }

        private void BB_Capturar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.Escape))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Enter) && BB_Cancelar.Focused)
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Enter) && BB_Capturar.Focused)
                DialogResult = DialogResult.OK;
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            tempo.Stop();
            try
            {
                if(string.IsNullOrEmpty(rProtocolo.Char_eol.ToString()) ||
                    rProtocolo.Char_eol.ToString().Equals("0"))
                {
                    char inicio = (char)5;
                    serial.Write(inicio.ToString());
                }
                else serial.Write(rProtocolo.Char_eol_str.ToString());
                Thread.Sleep(500);
            }
            catch { }
            finally { tempo.Start(); }
        }

        private void TFBalancaProc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.DtrEnable = false;
                serial.RtsEnable = false;
                serial.DiscardInBuffer();
                serial.DiscardOutBuffer();
                serial.Close();
                serial.Dispose();
            }
            tempo.Stop();
        }
    }
}
