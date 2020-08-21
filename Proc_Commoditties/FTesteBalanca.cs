using System;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Proc_Commoditties
{
    public partial class FTesteBalanca : Form
    {
        private decimal _peso;
        public decimal Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        public CamadaDados.Diversos.TRegistro_CadProtocolo rProt { get; set; }
            = new CamadaDados.Diversos.TRegistro_CadProtocolo();

        public FTesteBalanca()
        {
            InitializeComponent();
        }

        private void TratarDadosRecebidos(object sender, EventArgs e)
        {
            lblPeso.Text = _peso.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "Kg";
            button1.Enabled = true;
            button1.Focus();
        }

        private void FTesteBalanca_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            //Porta de comunicacao
            serial.PortName = rProt.Ds_porta;
            //Velocidade de Leitura
            serial.BaudRate = rProt.Baudrate;
            //Bit de Dados
            serial.DataBits = rProt.Databits;
            //Paridade
            serial.Parity = rProt.Parity.Trim().Equals("1") ? System.IO.Ports.Parity.Mark :
                rProt.Parity.Trim().Equals("2") ? System.IO.Ports.Parity.Even :
                rProt.Parity.Trim().Equals("3") ? System.IO.Ports.Parity.Odd :
                rProt.Parity.Trim().Equals("4") ? System.IO.Ports.Parity.Space : System.IO.Ports.Parity.None;
            //Bit de Parada
            serial.StopBits = rProt.Stopbits.Trim().ToUpper().Equals("1") ?
                System.IO.Ports.StopBits.One : rProt.Stopbits.Trim().ToUpper().Equals("1.5") ?
                System.IO.Ports.StopBits.OnePointFive : rProt.Stopbits.Trim().ToUpper().Equals("2") ?
                System.IO.Ports.StopBits.Two : System.IO.Ports.StopBits.None;
            serial.Open();
            if(serial.IsOpen)
                tempo.Start();
            else
            {
                MessageBox.Show("Erro abrir porta " + rProt.Ds_porta.Trim() + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string peso = serial.ReadExisting();
            if (!string.IsNullOrEmpty(peso))
            {
                var vetor = peso.ToArray();
                peso = string.Empty;
                foreach (char c in vetor)
                    if (char.IsNumber(c) || c.Equals('.'))
                        peso += c.ToString();
                if (!string.IsNullOrEmpty(peso))
                    try
                    {
                        _peso = decimal.Divide(decimal.Parse(peso), 1000);
                        Invoke(new EventHandler(TratarDadosRecebidos));
                    }
                    catch { }
            }
        }
        
        private void FTesteBalanca_FormClosing(object sender, FormClosingEventArgs e)
        {
            tempo.Stop();
            if (serial.IsOpen)
                serial.Close();
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            tempo.Stop();
            try
            {
                serial.Write(((char)5).ToString());
                System.Threading.Thread.Sleep(500);
            }
            catch { }
            finally{ tempo.Start(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
