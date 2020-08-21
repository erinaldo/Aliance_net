using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using CamadaDados.Diversos;

namespace LeituraSerial
{
    public class TLeituraSerial
    {
        public static string TrataDados(string Pacote, TRegistro_CadProtocolo Protocolo)
        {
            if (Protocolo.Char_eol_str != ' ')
                if (Pacote.Contains(Protocolo.Char_eol_str.ToString()))
                    Pacote = Pacote.Substring(0, Pacote.IndexOf(Protocolo.Char_eol_str) - 1);
            if (Pacote.Length >= Protocolo.Size_word)
                return Pacote.Substring(Protocolo.Pos_ini, Protocolo.Size_word);
            else
                return Pacote;
        }
    }
}
