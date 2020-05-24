using HealthAndLifestyleMonitor;
using HealthAndLifestyleMonitor.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLWebAPI.Controllers
{
    [ApiController]
    [Route("hl/[controller]")]
    public class JadwalObatController : ControllerBase
    {
        private JadwalObat _jadwalObat = new JadwalObat();

        [HttpGet]
        [Route("")]
        [Route("daftar")]
        public List<JadwalObatModel> GetDaftarJadwalObat()
        {
            return _jadwalObat.GetDaftarJadwalObat();
        }

        [HttpGet]
        [Route("hariini")]
        public List<JadwalObatModel> GetJadwalHariIni()
        {
            return _jadwalObat.GetJadwalHariIni();
        }

        [HttpGet]
        [Route("hari/{hari}")]
        public ActionResult<List<JadwalObatModel>> GetHariSpesifik(string hari)
        {
            using (var db = new HLDatabaseContext())
            {
                if (HLBase.GetDaftarHari().Where(h => h.ToLower() == hari.ToLower()).Count() == 0 && hari.ToLower() != "setiaphari")
                    return NotFound();

                List<JadwalObatModel> result = db.DaftarJadwalObat.Where(h => h.Hari.ToLower() == hari.ToLower()).ToList();
                return result;
            }
        }
    }
}
