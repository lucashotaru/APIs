using LeitorDeExcel.LeitorExcell.Models;
using LeitorDeExcel.LeitorExcell.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace LeitorDeExcel.LeitorExcell.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeitorCSVController : ControllerBase
    {
        [Consumes("multipart/form-data")]
        [HttpPost("input-file")]
        public ActionResult InputFile(IFormFile cbfInfo)
        {
            var times = LeitorExcellRepository.LeitorExcel(LeitorExcellRepository.LerStreamEConverterEmMemory(cbfInfo));

            LeitorExcellRepository.SalvaJogosBanco(times);

            return Ok();
        }

    }
}
