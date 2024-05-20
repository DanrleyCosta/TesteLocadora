using ClosedXML.Excel;
using RNlavaJato.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNlavaJato.Infra
{
    public class ExcelProcessor
    {
        public static List<LavaJatoData> LerDadosDoExcel(string caminhoArquivo)
        {
            List<LavaJatoData> listaLavaJatoData = new List<LavaJatoData>();

            try
            {
                using (var workbook = new XLWorkbook(caminhoArquivo))
                {
                    var worksheet = workbook.Worksheet(1); // Se a planilha estiver na primeira aba (índice 1)
                    var linhas = worksheet.Rows();

                    foreach (var linha in linhas)
                    {
                        // A primeira linha geralmente contém os cabeçalhos das colunas, então pulamos essa linha
                        if (linha.RowNumber() == 1)
                            continue;

                        LavaJatoData dados = new LavaJatoData
                        {
                            Data = Convert.ToDateTime(linha.Cell(1).Value),
                            Hora = TimeSpan.Parse(linha.Cell(2).Value.ToString()),
                            NomeCliente = linha.Cell(3).Value.ToString(),
                            EmailCliente = linha.Cell(4).Value.ToString(),
                            TelefoneCliente = linha.Cell(5).Value.ToString(),
                            EnderecoCliente = linha.Cell(6).Value.ToString(),
                            TipoServico = linha.Cell(7).Value.ToString(),
                            ValorServico = Convert.ToDecimal(linha.Cell(8).Value),
                            FuncionarioResponsavel = linha.Cell(9).Value.ToString(),
                            Observacoes = linha.Cell(10).Value.ToString()
                        };

                        listaLavaJatoData.Add(dados);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo Excel: {ex.Message}");
            }

            return listaLavaJatoData;
        }
    }
}
