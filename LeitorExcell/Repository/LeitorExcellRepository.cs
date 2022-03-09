using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using LeitorDeExcel.LeitorExcell.Models;
using OfficeOpenXml;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace LeitorDeExcel.LeitorExcell.Repository
{
    public class LeitorExcellRepository
    {
        public static void SalvaJogosBanco(List<TimesModel> timesModels)
        {
            using (var connection = new SqlConnection("Server=localhost; Database=CBF; Trusted_Connection=True"))
            {
                string delete = "TRUNCATE FROM Rodadas";

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(delete, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    connection.Insert(timesModels);
                }
                catch (System.Exception ex)
                {
                }
            }

        }

        public static List<TimesModel> LeitorExcel(Stream stream)
        {
            var resultado = new List<TimesModel>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[0];
                int colCount = excelWorksheet.Dimension.End.Column;

                int rowCount = excelWorksheet.Dimension.End.Row;

                for (int row = 2; row <= rowCount; row++)
                {
                    var jogo = new TimesModel();
                    jogo.NomeTimeCasa = excelWorksheet.Cells[row, 1].Value.ToString();
                    jogo.PlacarTimeCasa = Convert.ToInt32(excelWorksheet.Cells[row, 2].Value);
                    jogo.NomeTimeVisitante = excelWorksheet.Cells[row, 3].Value.ToString();
                    jogo.PlacarTimeVisitante = Convert.ToInt32(excelWorksheet.Cells[row, 4].Value);
                    jogo.Rodada = Convert.ToInt32(excelWorksheet.Cells[row, 5].Value);
                    jogo.DataHoraJogo = Convert.ToDateTime(excelWorksheet.Cells[row, 6].Value);

                    resultado.Add(jogo);
                }
            }

            return resultado;
        }

        public static Stream LerStreamEConverterEmMemory(IFormFile formFile)
        {
            using (var stream = new MemoryStream())
            {
                formFile?.CopyTo(stream);

                var byteArray = stream.ToArray();

                return new MemoryStream(byteArray);
            }
        }
    }
}