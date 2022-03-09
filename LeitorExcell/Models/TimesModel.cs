using Dapper.Contrib.Extensions;
using System;

namespace LeitorDeExcel.LeitorExcell.Models
{
    [Table("Rodadas")]
    public class TimesModel
    {
        public string NomeTimeCasa { get; set; }
        public int PlacarTimeCasa { get; set; }
        public string NomeTimeVisitante { get; set; }
        public int PlacarTimeVisitante { get; set; }
        public int Rodada { get; set; }
        public DateTime DataHoraJogo { get; set; }
    }
}
