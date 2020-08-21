using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Utils;

namespace PostoCombustivel
{
    public class TVWTech
    {
        #region Chamadas Externas
        //Abrir porta serial
        [DllImport("ControlTech32.dll", EntryPoint = "InicializaCom")]
        private static extern int InicializaCom(int PortaCom, string Host_IP, int PortaIP);
        //Fechar porta serial
        [DllImport("ControlTech32.dll", EntryPoint = "FinalizaCom")]
        private static extern int FinalizaCom();
        //Status porta COM
        [DllImport("ControlTech32.dll", EntryPoint = "StatusCom")]
        private static extern int StatusCom();
        //Alterar Preco Bico
        [DllImport("ControlTech32.dll", EntryPoint = "AlteraPreco")]
        private static extern int AlteraPreco(int nBico, string sPreco);
        //Alterar Relogio Concentrador
        [DllImport("ControlTech32.dll", EntryPoint = "SetRelogio")]
        private static extern int SetRelogio(string DataHora);
        //Ler Encerrante Bico
        [DllImport("ControlTech32.dll", CharSet=CharSet.Ansi, SetLastError=true, EntryPoint = "GetEncerrantes")]
        private static extern int GetEncerrantes(int nBico, [MarshalAs(UnmanagedType.VBByRefStr)] ref string DadosEncerrantes);
        //Ler Abastecimentos OnLine
        [DllImport("ControlTech32.dll", CharSet=CharSet.Ansi, SetLastError=true)]
        private static extern int GetDisplay(int nBico, [MarshalAs(UnmanagedType.VBByRefStr)] ref string DadosDisplay);
        //Apagar Abastecimento
        [DllImport("ControlTech32.dll", EntryPoint = "ApagaAbastecimento")]
        private static extern int ApagaAbastecimento(int nIdAbast);
        //Ler Abastecimento Memoria
        [DllImport("ControlTech32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int GetAbastecimento([MarshalAs(UnmanagedType.VBByRefStr)] ref string Abastecimento);
        //Ler Status Pista
        [DllImport("ControlTech32.dll", CharSet=CharSet.Ansi, SetLastError=true)]
        private static extern int GetStatusPista(int nBicoInicial, int nBicoFinal, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Status);
        #endregion

        #region Metodos de Classe
        public static int AbrirPorta(int PortaCom, string Host_IP, int PortaIP)
        {
            if (Estruturas.BaixarDll("ControlTech32.dll"))
            {
                int ret = InicializaCom(PortaCom, Host_IP, PortaIP);
                return ret;
            }
            else return 255;//Erro
        }

        public static int FecharPorta()
        {
            if (Estruturas.BaixarDll("ControlTech32.dll"))
                return FinalizaCom();
            else return 255;//Erro
        }

        public static int StatusPorta()
        {
            if (Estruturas.BaixarDll("ControlTech32.dll"))
                return StatusCom();
            else return 255;//Erro
        }

        public static int LerStatusPista(int nBicoInicial, int nBicoFinal, ref string Status)
        {
            if (Estruturas.BaixarDll("ControlTech32.dll"))
            {
                Status = new string('\x20', 16);
                int ret = GetStatusPista(nBicoInicial, nBicoFinal, ref Status);
                return ret;
            }
            else return 255;//Erro
        }

        public static int LerAbastecimento(ref string Abastecimento)
        {
            if (Estruturas.BaixarDll("ControlTech32.dll"))
            {
                Abastecimento = new string('\x20', 91);
                int ret = GetAbastecimento(ref Abastecimento);
                return ret;
            }
            else return 255;//Erro
        }

        public static int ApagaAbastecimentoMemoria(int nIdAbast)
        {
            if (Estruturas.BaixarDll("ControlTech32.dll"))
                return ApagaAbastecimento(nIdAbast);
            else return 255;//Erro
        }

        public static int LerAbastecimentosOnLine(int nBico, ref string DadosDisplay)
        {
            if (Estruturas.BaixarDll("ControlTech32.dll"))
            {
                DadosDisplay = new string('\x20', 20);
                return GetDisplay(nBico, ref DadosDisplay);
            }
            else return 255;//Erro
        }

        public static int LerEncerrantes(int nBico, ref string DadosEncerrante)
        {
            if (Estruturas.BaixarDll("ControlTech32.dll"))
            {
                int ret = GetEncerrantes(nBico, ref DadosEncerrante);
                return ret;
            }
            else return 255;//Erro
        }

        public static int AlterarPreco(int nBico, string sPreco)
        {
            if (Estruturas.BaixarDll("ControlTech32.dll"))
                return AlteraPreco(nBico, sPreco);
            else return 255;//Erro
        }

        public static int AlterarDataHora(string DataHora)
        {
            if (Estruturas.BaixarDll("ControlTech32.dll"))
            {
                int ret = SetRelogio(DataHora);
                return ret;
            }
            else return 255;//Erro
        }
        #endregion
    }
}
