using CriadorExcel.LeitorExcell.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CriadorExcel.LeitorExcell.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CriadorDeExcellController : ControllerBase
    {
        [HttpGet("criar-excel-jogos-cbf")]
        public IActionResult DownloadExcell()
        {

            var cbfInfo = CBFWebScrapingRepository.GetCBFInfo();
            var filePath = CBFWebScrapingRepository.SaveCBFInfo(cbfInfo);

            return Ok(filePath);
        }

    }
}
