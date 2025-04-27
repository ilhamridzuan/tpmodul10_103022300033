using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using tpmodul10_103022300033;

namespace tpmodul10_103022300033.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        public static readonly List<Mahasiswa> mahasiswa = new()
        {
            new Mahasiswa("Muhammad Ilham Ridzuan", "103022300033"),
            new Mahasiswa("Alfian Rizky Sabian", "103022300038"),
            new Mahasiswa("Pieter Immanuel Sinaga", "103022330111"),
            new Mahasiswa("Avriela Nada Amara Putri", "103022300066"),

        };
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAllMahasiswa()
        {
            return Ok(mahasiswa);
        }
        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan" });
            }
            return Ok(mahasiswa[id]);
        }
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mhsBaru)
        {
            if (string.IsNullOrWhiteSpace(mhsBaru.Nama) || string.IsNullOrWhiteSpace(mhsBaru.Nim))
            {
                return BadRequest(new { message = "Nama dan NIM harus diisi" });
            }
            mahasiswa.Add(mhsBaru);
            return Ok(new { message = "Mahasiswa telah ditambahkan", id = mahasiswa.Count - 1 });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMahasiswa(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan" });
            }
            mahasiswa.RemoveAt(id);
            return Ok(new { message = "Mahasiswa berhasi dihapus" });
        }
    }
}
