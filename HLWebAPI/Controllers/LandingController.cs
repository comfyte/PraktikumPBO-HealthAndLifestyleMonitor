using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLWebAPI.Controllers
{
    [ApiController]
    [Route("hl")]
    public class LandingController : ControllerBase
    {
        [HttpGet]
        public string AvailableCommands()
        {
            return "Perintah API yang tersedia:\r\n\r\n" +
                "GET /hl/airminum/hariini\r\n" +
                "GET /hl/airminum/riwayat\r\n" +
                "POST /hl/airminum/tambah/{liter}\r\n\r\n" +
                "GET /hl/jadwalobat\r\n" +
                "GET /hl/jadwalobat/hariini\r\n" +
                "GET /hl/jadwalobat/hari/{hari}\r\n\r\n" +
                "GET /hl/tekanandarah/riwayat\r\n" +
                "POST /hl/tekanandarah/pengukuranbaru?sys={sistolik}&dia={diastolik}\r\n";
        }
    }
}
