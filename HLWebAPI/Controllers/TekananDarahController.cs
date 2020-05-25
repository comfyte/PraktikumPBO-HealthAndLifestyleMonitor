using HealthAndLifestyleMonitor;
using HealthAndLifestyleMonitor.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLWebAPI.Controllers
{
    [ApiController]
    [Route("hl/[controller]")]
    public class TekananDarahController : ControllerBase
    {
        private TekananDarah _tekananDarah = new TekananDarah();

        [HttpGet]
        [Route("riwayat")]
        [Route("hasilpengukuran")]
        [Route("daftar")]
        public List<TekananDarahModel> GetDaftar()
        {
            return _tekananDarah.GetDaftarRiwayat();
        }

        [HttpPost]
        [Route("tambah")]
        [Route("baru")]
        [Route("pengukuranbaru")]
        public ActionResult<TekananDarahModel> Tambah(int sys, int dia)
        {
            try
            {
                _tekananDarah.Tambah(sys, dia);
                return CreatedAtAction(nameof(GetDaftar), GetDaftar());
            }
            catch (InvalidOperationException ex) when (ex.Message == "kurang-dari-nol")
            {
                return BadRequest(new { Error = "Nilai nol atau negatif" });
            }
        }
    }
}
