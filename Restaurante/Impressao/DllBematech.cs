using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Impressao
{
    public class DllBematech
    {
        public static int IniciarPorta(string Porta)
        {
            if (Utils.TVersaoOS.Is64Bit())
                return PDV.TBemaMp2064.IniciarPorta(Porta);
            else return PDV.TBemaMp2032.IniciarPorta(Porta);
        }

        public static int Texto(string Texto)
        {
            if (Utils.TVersaoOS.Is64Bit())
                return PDV.TBemaMp2064.Texto(Texto);
            else return PDV.TBemaMp2032.Texto(Texto);
        }

        public static int Guilhotina()
        {
            if (Utils.TVersaoOS.Is64Bit())
                return PDV.TBemaMp2064.Guilhotina();
            else return PDV.TBemaMp2032.Guilhotina();
        }

        public static int FecharPorta()
        {
            if (Utils.TVersaoOS.Is64Bit())
                return PDV.TBemaMp2064.FechaPorta();
            else return PDV.TBemaMp2032.FechaPorta();
        }
    }
}
