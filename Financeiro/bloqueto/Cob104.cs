using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Financeiro.bloqueto;

namespace Financeiro.bloqueto
{
    public class blBanco104
    {
        const string CodigBanco = "104";
        const string NomeBanco = "Caixa Econ. Federal";
         
        private bool GerarRemessaCNAB240( blCobranca ACobranca, StringBuilder Remessa)
        { 
            string ACedenteTipoInscricao;
            string ASacadoTipoInscricao;
            string Registro = "";
            int NumeroRegistro = 0;
            int NumeroLote = 1;

            
            /*
            if (ACobranca.Titulos.Count < 1)
                throw new Exception("Não há títulos para gerar remessa");
            
            //{ GERAR REGISTRO-HEADER DO ARQUIVO }
            switch ACobranca.Titulos[NumeroRegistro].

      case Titulos[NumeroRegistro].Cedente.TipoInscricao of
         tiPessoaFisica  : ACedenteTipoInscricao := '1';
         tiPessoaJuridica: ACedenteTipoInscricao := '2';
         tiOutro         : ACedenteTipoInscricao := '3';
      end;

      if Formatar(CodigoBanco,3,false,'0') <> Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.Banco.Codigo,3,false,'0') then
         Raise Exception.CreateFmt('O título (Nosso Número: %s) não pertence ao banco %s (%s)',[Titulos[NumeroRegistro].NossoNumero,CodigoBanco,NomeBanco]);

      Registro := Formatar(CodigoBanco,3,false,'0'); {1 a 3 - Código do banco}
      Registro := Registro + '0000'; {4 a 7 - Lote de serviço}
      Registro := Registro + '0'; {8 - Tipo de registro - Registro header de arquivo}
      Registro := Registro + Formatar('',9); {9 a 17 - Uso exclusivo FEBRABAN/CNAB}
      Registro := Registro + ACedenteTipoInscricao; {18 - Tipo de inscrição do cedente}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.NumeroCPFCGC,14,false,'0'); {19 a 32 - Número de inscrição do cedente}

      {CÓDIGO DO CONVÊNIO = AGÊNCIA + NÚMERO CONVÊNIO + DV}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia,4,false,'0'); {33 a 36 - Código da agência}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.CodigoCedente,11,false,'0'); {37 a 47 - Código do convênio no banco}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.DigitoCodigoCedente,1,false,'0'); {48 - Dígito do código do convênio no banco}

      Registro := Registro + Formatar('',4); {49 a 52 - Uso exclusivo CAIXA}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia,5,false,'0'); {53 a 57 - Código da agência do cedente}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoAgencia,1,false,'0'); {58 - Dígito do código da agência do cedente}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.NumeroConta,12,false,'0'); {59 a 70 - Código da conta corrente vinculada à cobrança / não é o número da conta corrente comum}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoConta,1,false,'0'); {71 - Dígito da conta corrente vinculada à cobrança}
      Registro := Registro + Modulo11(Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia,5,false,'0')+Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.NumeroConta,12,false,'0')); {72 - Dígito verificador da agência / conta do cedente}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.Nome,30,true,' '); {73 a 102 - Nome do cedente}
      Registro := Registro + Formatar('CAIXA ECONOMICA FEDERAL',30,true,' '); {103 a 132 - Nome do banco}
      Registro := Registro + Formatar('',10); {133 a 142 - Uso exclusivo FEBRABAN/CNAB}
      Registro := Registro + '1'; {143 - Código de Remessa (1) / Retorno (2)}
      Registro := Registro + FormatDateTime('ddmmyyyy',DataArquivo); {144 a 151 - Data do de geração do arquivo}
      Registro := Registro + FormatDateTime('hhmmss',DataArquivo);  {152 a 157 - Hora de geração do arquivo}
      Registro := Registro + Formatar(IntToStr(NumeroArquivo),6,false,'0'); {158 a 163 Número seqüencial do arquivo}
      Registro := Registro + '030'; {164 a 166 - Número da versão do layout do arquivo}
      Registro := Registro + Formatar('',5,false,'0'); {167 a 171 - Densidade de gravação do arquivo (BPI)}
      Registro := Registro + Formatar('',20); {172 a 191 - Uso reservado do banco}
      if TipoMovimento = tmRemessaTeste then
         Registro := Registro + Formatar('REMESSA-TESTE',20) {192 a 211 - Deverá conter a literal REMESSA-TESTE para fase de testes}
      else
         Registro := Registro + Formatar('',20); {192 a 211 - Deverá conter a literal REMESSA-TESTE para fase de testes}
      Registro := Registro + Formatar('',29); {212 a 240 - Uso exclusivo FEBRABAN/CNAB}

      Remessa.Add(Registro);
      Registro := '';

      {GERAR REGISTRO HEADER DO LOTE}
      Registro := Formatar(CodigoBanco,3,false,'0'); {1a 3 - Código do banco}
      Registro := Registro + Formatar(IntToStr(NumeroLote),4,false,'0'); {4 a 7 - Número do lote de serviço}
      Registro := Registro + '1'; {8 - Tipo do registro - Registro header de lote}
      Registro := Registro + 'R'; {9 - Tipo de operação: R (Remessa) ou T (Retorno)}
      Registro := Registro + '01'; {10 a 11 - Tipo de serviço: 01 (Cobrança)}
      Registro := Registro + '00'; {12 a 13 - Forma de lançamento: preencher com ZEROS no caso de cobrança}
      Registro := Registro + '020'; {14 a 16 - Número da versão do layout do lote}
      Registro := Registro + ' '; {17 - Uso exclusivo FEBRABAN/CNAB}
      Registro := Registro + ACedenteTipoInscricao; {18 - Tipo de inscrição do cedente}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.NumeroCPFCGC,15,false,'0'); {19 a 33 - Número de inscrição do cedente}

      {CÓDIGO DO CONVÊNIO = AGÊNCIA + NÚMERO CONVÊNIO + DV}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia,4,false,'0'); {34 a 37 - Código da agência}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.CodigoCedente,11,false,'0'); {38 a 48 - Código do convênio no banco}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.DigitoCodigoCedente,1,false,'0'); {49 - Dígito do código do convênio no banco}

      Registro := Registro + Formatar('',4); {50 a 53 - Uso exclusivo CAIXA}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia,5,false,'0'); {54 a 58 - Código da agência do cedente}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoAgencia,1,false,'0'); {59 - Dígito da agência do cedente}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.NumeroConta,12,false,'0'); {60 a 71 - Número da conta vinculada à cobrança / não é o número da conta corrente comum}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoConta,1,false,'0'); {72 - Dígito do código do cedente no banco}
      Registro := Registro + Modulo11(Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia,5,false,'0')+Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.NumeroConta,12,false,'0')); {73 - Dígito verificador da agência / conta}
      Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.Nome,30,true,' '); {74 a 103 - Nome do cedente}
      Registro := Registro + Formatar('',40); {104 a 143 - Mensagem 1 para todos os boletos do lote}
      Registro := Registro + Formatar('',40); {144 a 183 - Mensagem 2 para todos os boletos do lote}
      Registro := Registro + Formatar(IntToStr(NumeroArquivo),8,false,'0'); {184 a 191 - Número do arquivo}
      Registro := Registro + FormatDateTime('ddmmyyyy',DataArquivo); {192 a 199 - Data de geração do arquivo}
      Registro := Registro + FormatDateTime('ddmmyyyy',DataArquivo); {200 a 207 - Data do crédito - Informar a mesma data da gravação do arquivo}
      Registro := Registro + Formatar('',33); {208 a 240 - Uso exclusivo FEBRABAN/CNAB}

      Remessa.Add(Registro);
      Registro := '';

      { GERAR TODOS OS REGISTROS DETALHE DA REMESSA }
      while NumeroRegistro <= (Titulos.Count - 1) do
      begin

         if Formatar(CodigoBanco,3,false,'0') <> Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.Banco.Codigo,3,false,'0') then
            Raise Exception.CreateFmt('O título (Nosso Número: %s) não pertence ao banco %s (%s)',[Titulos[NumeroRegistro].NossoNumero,CodigoBanco,NomeBanco]);

         {SEGMENTO P}
         if Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.Banco.Codigo,3,false,'0') <> Formatar(CodigoBanco,3,false,'0') then
            Raise Exception.CreateFmt('Titulo não pertence ao banco %s - %s',[CodigoBanco,NomeBanco]);

         case Titulos[NumeroRegistro].Cedente.TipoInscricao of
            tiPessoaFisica  : ACedenteTipoInscricao := '1';
            tiPessoaJuridica: ACedenteTipoInscricao := '2';
            tiOutro         : ACedenteTipoInscricao := '9';
         end;

         Registro := Formatar(CodigoBanco,3,false,'0'); {1 a 3 - Código do banco}
         Registro := Registro + Formatar(IntToStr(NumeroLote),4,false,'0'); {4 a 7 - Número do lote}
         Registro := Registro + '3'; {8 - Tipo do registro: Registro detalhe}
         Registro := Registro + Formatar(IntToStr(2*NumeroRegistro+1),5,false,'0'); {9 a 13 - Número seqüencial do registro no lote - Cada título tem 2 registros (P e Q)}
         Registro := Registro + 'P'; {14 - Código do segmento do registro detalhe}
         Registro := Registro + ' '; {15 - Uso exclusivo FEBRABAN/CNAB: Branco}
         case Titulos[NumeroRegistro].TipoOcorrencia of {16 a 17 - Código de movimento}
            toRemessaRegistrar                 : Registro := Registro + '01';
            toRemessaBaixar                    : Registro := Registro + '02';
            toRemessaConcederAbatimento        : Registro := Registro + '04';
            toRemessaCancelarAbatimento        : Registro := Registro + '05';
            toRemessaConcederDesconto          : Registro := Registro + '07';
            toRemessaCancelarDesconto          : Registro := Registro + '08';
            toRemessaAlterarVencimento         : Registro := Registro + '06';
            toRemessaProtestar                 : Registro := Registro + '09';
            toRemessaCancelarInstrucaoProtesto : Registro := Registro + '10';
            toRemessaDispensarJuros            : Registro := Registro + '31';
            toRemessaAlterarNomeEnderecoSacado : Registro := Registro + '31';
         else
            Raise Exception.CreateFmt('Ocorrência inválida em remessa - Nosso número: %s / Seu número: %s',[Titulos[NumeroRegistro].NossoNumero,Titulos[NumeroRegistro].SeuNumero]);
         end; {case Titulos[NumeroRegistro].TipoOcorrencia}
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia,5,false,'0'); {18 a 22 - Agência mantenedora da conta}
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoAgencia,1,false,'0'); {23 - Dígito verificador da agência}
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.NumeroConta,12,false,'0'); {24 a 35 - Número da conta vinculada à cobrança / não é o número da conta corrente comum}
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.DigitoConta,1,false,'0'); {36 - Dígito da conta vinculada à cobrança}
         Registro := Registro + Modulo11(Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.CodigoAgencia,5,false,'0')+Formatar(Titulos[NumeroRegistro].Cedente.ContaBancaria.NumeroConta,12,false,'0')); {37 - Dígito verificador da agência / conta}
         Registro := Registro + Formatar('',9); {38 a 46 - Uso exclusivo CAIXA: Brancos}
         Registro := Registro + Formatar(Titulos[NumeroRegistro].NossoNumero,11,false,'0'); {47 a 57 - Nosso número - identificação do título no banco}
         Registro := Registro + '1'; {58 - Cobrança Simples}
         Registro := Registro + '1'; {59 - Forma de cadastramento do título no banco: com cadastramento}
         Registro := Registro + '2'; {60 - Tipo de documento: Escritural}
         case Titulos[NumeroRegistro].EmissaoBoleto of {61 a 62 - Quem emite e quem distribui o boleto?}
            ebBancoEmite      : Registro := Registro + '1' + '1';
            ebClienteEmite    : Registro := Registro + '2' + '2';
            ebBancoReemite    : Registro := Registro + '4' + '1';
            ebBancoNaoReemite : Registro := Registro + '5' + '2';
         else
            Raise Exception.CreateFmt('Identificação inválida de emissão de boleto em remessa - Nosso número: %s / Seu número: %s',[Titulos[NumeroRegistro].NossoNumero,Titulos[NumeroRegistro].SeuNumero]);
         end; {case Titulos[NumeroRegistro].EmissaoBoleto}
         Registro := Registro + Formatar(Titulos[NumeroRegistro].SeuNumero,11,false,'0'); {63 a 73 - Número que identifica o título na empresa}
         Registro := Registro + Formatar('',4); {74 a 77 - Uso exclusivo CAIXA: Brancos}
         Registro := Registro + FormatDateTime('ddmmyyyy',Titulos[NumeroRegistro].DataVencimento); {78 a 85 - Data de vencimento do título}
         Registro := Registro + FormatCurr('000000000000000',Titulos[NumeroRegistro].ValorDocumento * 100); {86 a 100 - Valor nominal do título}
         Registro := Registro + '00000'; {101 a 105 - Agência cobradora. Deixar zerado. A Caixa determinará automaticamente pelo CEP do sacado}
         Registro := Registro + '0'; {106 - Dígito da agência cobradora}
         case Titulos[NumeroRegistro].EspecieDocumento of {107 a 108 - Espécie do documento}
            edApoliceSeguro                : Registro := Registro + '20'; {AP  APÓLICE DE SEGURO}
            edCheque                       : Registro := Registro + '01'; {CH  CHEQUE}
            edDuplicataMercantil           : Registro := Registro + '02'; {DM  DUPLICATA MERCANTIL}
            edDuplicataMercantialIndicacao : Registro := Registro + '03'; {DMI DUPLICATA MERCANTIL P/ INDICAÇÃO}
            edDuplicataRural               : Registro := Registro + '06'; {DR  DUPLICATA RURAL}
            edDuplicataServico             : Registro := Registro + '04'; {DS  DUPLICATA DE SERVIÇO}
            edDuplicataServicoIndicacao    : Registro := Registro + '05'; {DSI DUPLICATA DE SERVIÇO P/ INDICAÇÃO}
            edFatura                       : Registro := Registro + '18'; {FAT FATURA}
            edLetraCambio                  : Registro := Registro + '07'; {LC  LETRA DE CÂMBIO}
            edMensalidadeEscolar           : Registro := Registro + '21'; {ME  MENSALIDADE ESCOLAR}
            edNotaCreditoComercial         : Registro := Registro + '08'; {NCC NOTA DE CRÉDITO COMERCIAL}
            edNotaCreditoExportacao        : Registro := Registro + '09'; {NCE NOTA DE CRÉDITO A EXPORTAÇÃO}
            edNotaCreditoIndustrial        : Registro := Registro + '10'; {NCI NOTA DE CRÉDITO INDUSTRIAL}
            edNotaCreditoRural             : Registro := Registro + '11'; {NCR NOTA DE CRÉDITO RURAL}
            edNotaDebito                   : Registro := Registro + '19'; {ND  NOTA DE DÉBITO}
            edNotaPromissoria              : Registro := Registro + '12'; {NP  NOTA PROMISSÓRIA}
            edNotaPromissoriaRural         : Registro := Registro + '13'; {NPR NOTA PROMISSÓRIA RURAL}
            edNotaSeguro                   : Registro := Registro + '16'; {NS  NOTA DE SEGURO}
            edParcelaConsorcio             : Registro := Registro + '22'; {PC  PARCELA DE CONSORCIO}
            edRecibo                       : Registro := Registro + '17'; {RC  RECIBO}
            edTriplicataMercantil          : Registro := Registro + '14'; {TM  TRIPLICATA MERCANTIL}
            edTriplicataServico            : Registro := Registro + '15' {TS  TRIPLICATA DE SERVIÇO}
         else
            Registro := Registro + '99'; {OUTROS}
         end; {case Titulos[NumeroRegistro].EspecieDocumento}
         case Titulos[NumeroRegistro].AceiteDocumento of {109 - Identificação de título Aceito / Não aceito}
            adSim : Registro := Registro + 'A';
            adNao : Registro := Registro + 'N';
         end; {case Titulos[NumeroRegistro].AceiteDocumento}
         Registro := Registro + FormatDateTime('ddmmyyyy',Titulos[NumeroRegistro].DataDocumento); {110 a 117 - Data da emissão do documento}
         if Titulos[NumeroRegistro].ValorMoraJuros > 0 then
         begin
            Registro := Registro + '1'; {118 - Código de juros de mora: Valor por dia}
            if Titulos[NumeroRegistro].DataMoraJuros <> null then
               Registro := Registro + FormatDateTime('ddmmyyyy',Titulos[NumeroRegistro].DataMoraJuros) {119 a 126 - Data a partir da qual serão cobrados juros}
            else
               Registro := Registro + Formatar('',8,false,'0'); {119 a 126 - Data a partir da qual serão cobrados juros}
            Registro := Registro + FormatCurr('000000000000000',Titulos[NumeroRegistro].ValorMoraJuros * 100); {127 a 141 - Valor de juros de mora por dia}
         end
         else
         begin
            Registro := Registro + '4'; {118 - Código de juros de mora: Acata cadastramento na CAIXA}
            Registro := Registro + Formatar('',8,false,'0'); {119 a 126 - Data a partir da qual serão cobrados juros}
            Registro := Registro + Formatar('',15,false,'0'); {127 a 141 - Valor de juros de mora por dia}
         end;
         if Titulos[NumeroRegistro].ValorDesconto > 0 then
         begin
            Registro := Registro + '1'; {142 - Código de desconto: Valor fixo até a data informada}
            if Titulos[NumeroRegistro].DataDesconto <> null then
               Registro := Registro + FormatDateTime('ddmmyyyy',Titulos[NumeroRegistro].DataDesconto) {143 a 150 - Data do desconto}
            else
               Registro := Registro + FormatDateTime('ddmmyyyy',Titulos[NumeroRegistro].DataVencimento); {143 a 150 - se não houver desconto, deve ser informada a mesma data do vencimento}
            Registro := Registro + FormatCurr('000000000000000',Titulos[NumeroRegistro].ValorDesconto * 100); {151 a 165 - Valor do desconto por dia}
         end
         else
         begin
            Registro := Registro + '0'; {142 - Código de desconto: Sem desconto}
            Registro := Registro + FormatDateTime('ddmmyyyy',Titulos[NumeroRegistro].DataVencimento); {143 a 150 - se não houver desconto, deve ser informada a mesma data do vencimento}
            Registro := Registro + Formatar('',15,false,'0'); {151 a 165 - Valor do desconto por dia}
         end;
         Registro := Registro + FormatCurr('000000000000000',Titulos[NumeroRegistro].ValorIOF * 100); {166 a 180 - Valor do IOF a ser recolhido}
         Registro := Registro + FormatCurr('000000000000000',Titulos[NumeroRegistro].ValorAbatimento * 100); {181 a 195 - Valor do abatimento}
         Registro := Registro + Formatar(Titulos[NumeroRegistro].SeuNumero,25); {196 a 220 - Identificação do título na empresa}
         if (Titulos[NumeroRegistro].DataProtesto <> null) and (Titulos[NumeroRegistro].DataProtesto > Titulos[NumeroRegistro].DataVencimento) then
         begin
            Registro := Registro + '1'; {221 - Código de protesto: Protestar em XX dias corridos}
            Registro := Registro + Formatar(IntToStr(DaysBetween(Titulos[NumeroRegistro].DataProtesto, Titulos[NumeroRegistro].DataVencimento)),2,false,'0'); {222 a 223 - Prazo para protesto (em dias corridos)}
         end
         else
         begin
            Registro := Registro + '3'; {221 - Código de protesto: Não protestar}
            Registro := Registro + Formatar('',2,false,'0'); {222 a 223 - Prazo para protesto (em dias corridos)}
         end;
         if (Titulos[NumeroRegistro].DataBaixa <> null) and (Titulos[NumeroRegistro].DataBaixa > Titulos[NumeroRegistro].DataVencimento) then
         begin
            Registro := Registro + '1'; {224 - Código para baixa/devolução: Baixar/devolver}
            Registro := Registro + Formatar(IntToStr(DaysBetween(Titulos[NumeroRegistro].DataBaixa,Titulos[NumeroRegistro].DataVencimento)),3,false,'0'); {225 a 227 - Prazo para baixa/devolução (em dias corridos)}
         end
         else
         begin
            Registro := Registro + '2'; {224 - Código para baixa/devolução: Não baixar/não devolver}
            Registro := Registro + Formatar('',3,false,'0'); {Prazo para baixa/devolução (225 a 227 - em dias corridos)}
         end;
         Registro := Registro + '09'; {228 a 229 - Código da moeda: Real}
         Registro := Registro + Formatar('',10); {230 a 239 - Uso exclusivo FEBRABAN/CNAB}
         Registro := Registro + Formatar('',1); {240 - Uso exclusivo FEBRABAN/CNAB}

         Remessa.Add(Registro);
         Registro := '';

         {SEGMENTO Q}
         case Titulos[NumeroRegistro].Sacado.TipoInscricao of
            tiPessoaFisica  : ASacadoTipoInscricao := '1';
            tiPessoaJuridica: ASacadoTipoInscricao := '2';
            tiOutro         : ASacadoTipoInscricao := '9';
         end;

         Registro := Formatar(CodigoBanco,3,false,'0'); {Código do banco}
         Registro := Registro + Formatar(IntToStr(NumeroLote),4,false,'0'); {Número do lote}
         Registro := Registro + '3'; {Tipo do registro: Registro detalhe}
         Registro := Registro + Formatar(IntToStr(2*NumeroRegistro+2),5,false,'0'); {Número seqüencial do registro no lote - Cada título tem 2 registros (P e Q)}
         Registro := Registro + 'Q'; {Código do segmento do registro detalhe}
         Registro := Registro + ' '; {Uso exclusivo FEBRABAN/CNAB: Branco}
         case Titulos[NumeroRegistro].TipoOcorrencia of {Código de movimento}
            toRemessaRegistrar                 : Registro := Registro + '01';
            toRemessaBaixar                    : Registro := Registro + '02';
            toRemessaConcederAbatimento        : Registro := Registro + '04';
            toRemessaCancelarAbatimento        : Registro := Registro + '05';
            toRemessaConcederDesconto          : Registro := Registro + '07';
            toRemessaCancelarDesconto          : Registro := Registro + '08';
            toRemessaAlterarVencimento         : Registro := Registro + '06';
            toRemessaProtestar                 : Registro := Registro + '09';
            toRemessaCancelarInstrucaoProtesto : Registro := Registro + '10';
            toRemessaDispensarJuros            : Registro := Registro + '31';
            toRemessaAlterarNomeEnderecoSacado : Registro := Registro + '31';
         else
            Raise Exception.CreateFmt('Ocorrência inválida em remessa - Nosso número: %s / Seu número: %s',[Titulos[NumeroRegistro].NossoNumero,Titulos[NumeroRegistro].SeuNumero]);
         end; {case Titulos[NumeroRegistro].TipoOcorrencia}
         {Dados do sacado}
         Registro := Registro + Formatar(ASacadoTipoInscricao,1,false,'0');
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Sacado.NumeroCPFCGC,15,false,'0');
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Sacado.Nome,40);
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Sacado.Endereco.Rua+' '+Titulos[NumeroRegistro].Sacado.Endereco.Numero+' '+Titulos[NumeroRegistro].Sacado.Endereco.Complemento,40);
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Sacado.Endereco.Bairro,15);
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Sacado.Endereco.CEP,8,true,'0');
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Sacado.Endereco.Cidade,15,true);
         Registro := Registro + Formatar(Titulos[NumeroRegistro].Sacado.Endereco.Estado,2,false);
         {Dados do sacador/avalista}
         Registro := Registro + '0'; {Tipo de inscrição: Não informado}
         Registro := Registro + Formatar('',15,false,'0'); {Número de inscrição}
         Registro := Registro + Formatar('',40); {Nome do sacador/avalista}

         Registro := Registro + Formatar('',3); {Uso exclusivo FEBRABAN/CNAB}
         Registro := Registro + Formatar('',20); {Uso exclusivo FEBRABAN/CNAB}
         Registro := Registro + Formatar('',8); {Uso exclusivo FEBRABAN/CNAB}

         Remessa.Add(Registro);
         NumeroRegistro := NumeroRegistro + 1;
      end; {GERAR TODOS OS REGISTROS DETALHE DA REMESSA}

      {REGISTRO TRAILER DO LOTE}
      Registro := Formatar(CodigoBanco,3,false,'0'); {Código do banco}
      Registro := Registro + Formatar(IntToStr(NumeroLote),4,false,'0'); {Número do lote}
      Registro := Registro + '5'; {Tipo do registro: Registro trailer do lote}
      Registro := Registro + Formatar('',9); {Uso exclusivo FEBRABAN/CNAB}
      {Quantidade de registros do lote, incluindo header e trailer do lote.
       Até este momento Remessa contém:
       1 registro header de arquivo - É preciso excluí-lo desta contagem
       1 registro header de lote
       Diversos registros detalhe
       Falta incluir 1 registro trailer de lote
       Ou seja Quantidade = Remessa.Count - 1 header de arquivo + 1 trailer de lote = Remessa.Count}
      Registro := Registro + Formatar(IntToStr(Remessa.Count),6,false,'0');
      {Totalização da cobrança simples - Só é usado no arquivo retorno}
      Registro := Registro + Formatar('',6,false,'0'); {Quantidade títulos em cobrança}
      Registro := Registro + Formatar('',17,false,'0'); {Valor dos títulos em carteiras}
      {Uso exclusivo FEBRABAN/CNAB}
      Registro := Registro + Formatar('',23); {Uso exclusivo FEBRABAN/CNAB}
      {Totalização da cobrança caucionada - Só é usado no arquivo retorno}
      Registro := Registro + Formatar('',6,false,'0'); {Quantidade títulos em cobrança}
      Registro := Registro + Formatar('',17,false,'0'); {Valor dos títulos em carteiras}
      {Uso exclusivo FEBRABAN/CNAB}
      Registro := Registro + Formatar('',31); {Uso exclusivo FEBRABAN/CNAB}
      Registro := Registro + Formatar('',117); {Uso exclusivo FEBRABAN/CNAB}

      Remessa.Add(Registro);
      Registro := '';

      {GERAR REGISTRO TRAILER DO ARQUIVO}
      Registro := Formatar(CodigoBanco,3,false,'0'); {Código do banco}
      Registro := Registro + '9999'; {Lote de serviço}
      Registro := Registro + '9'; {Tipo do registro: Registro trailer do arquivo}
      Registro := Registro + Formatar('',9); {Uso exclusivo FEBRABAN/CNAB}
      Registro := Registro + Formatar(IntToStr(NumeroLote),6,false,'0'); {Quantidade de lotes do arquivo}
      Registro := Registro + Formatar(IntToStr(Remessa.Count + 1),6,false,'0'); {Quantidade de registros do arquivo, inclusive este registro que está sendo criado agora}
      Registro := Registro + Formatar('',6); {Uso exclusivo FEBRABAN/CNAB}
      Registro := Registro + Formatar('',205); {Uso exclusivo FEBRABAN/CNAB}

      Remessa.Add(Registro);
   end;

   Result := TRUE;
        */
            return false;
        }
        private bool GerarRemessaCNAB400( blCobranca ACobranca, StringBuilder Remessa)
        {
            return false;
        }
        private bool LerRetornoCNAB240( blCobranca ACobranca, StringBuilder Retorno)
        {
            return false;
        }
        private bool LerRetornoCNAB400( blCobranca ACobranca, StringBuilder Retorno)
        {
            return false;
        }
        public string GetNomeBanco() //{Retorna o nome do banco}        
        {
            return "";
        }
        public string GetCampoLivreCodigoBarra(blTitulo ATitulo) //{Retorna o conteúdo da parte variável do código de barras}
        {
            return "";
        }
        public string CalcularDigitoNossoNumero(blTitulo ATitulo) //{Calcula o dígito do NossoNumero, conforme critérios definidos por cada banco}
        {
            return "";
        }
        public void FormatarBoleto(blTitulo ATitulo, string AAgenciaCodigoCedente, string ANossoNumero, string ACarteira, string AEspecieDocumento) //{Define o formato como alguns valores serão apresentados no boleto }
        {            
        }
        public bool LerRetorno(blCobranca ACobranca, StringBuilder Retorno)  //{Lê o arquivo retorno recebido do banco}
        {
            return false;
        }
        public bool GerarRemessa(blCobranca ACobranca, StringBuilder Remessa)  //{Gerar arquivo remessa para enviar ao banco}
        {
            return false;
        }
    }
}
