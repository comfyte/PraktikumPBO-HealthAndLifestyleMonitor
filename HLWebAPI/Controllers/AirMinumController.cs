using HealthAndLifestyleMonitor;
using HealthAndLifestyleMonitor.DatabaseModels;
using HLWebAPI.AdditionalModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLWebAPI.Controllers
{
    [ApiController]
    [Route("hl/[controller]")]
    public class AirMinumController : ControllerBase
    {
        private AirMinum _airMinum = new AirMinum();

        [HttpGet]
        [Route("hariini")]
        public AirMinumHariIni GetDaftarHariIni()
        {
            AirMinumHariIni result = new AirMinumHariIni
            {
                Tanggal = HLBase.TanggalSekarang,
                TotalLiter = _airMinum.TotalHariIni,
                Daftar = new List<AirMinumHariIniListItem>()
            };

            List<AirMinumModel> daftarHariIni = _airMinum.GetDaftarHariIni();
            foreach (AirMinumModel item in daftarHariIni)
            {
                result.Daftar.Add(new AirMinumHariIniListItem
                {
                    Waktu = item.Waktu,
                    Jumlah = item.Jumlah
                });
            }
            return result;
        }

        [HttpGet]
        [Route("riwayat")]
        public List<AirMinumModel> GetDaftarRiwayat()
        {
            return _airMinum.GetDaftarRiwayatHarian();
        }

        [HttpPost]
        [Route("tambah/{liter}")]
        public ActionResult<AirMinumModel> Tambah(float liter)
        {
            try
            {
                _airMinum.Tambah(liter);
                return CreatedAtAction(nameof(GetDaftarHariIni), GetDaftarHariIni());
            }
            catch (InvalidOperationException ex) when (ex.Message == "kurang-dari-nol")
            {
                return BadRequest();
            }
        }
    }
}
