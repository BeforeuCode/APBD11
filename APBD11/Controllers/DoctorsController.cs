using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using APBD11.Services;
using APBD11.DTOs.Requests;
using ABPD11.Models;
using APBD11.DTOs.Responses;

namespace Cw11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorDbService _dbService;

        public DoctorsController(IDoctorDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoctorResponse>> GetDoctors()
        {
            var doctors =  _dbService.GetDoctors();
            return Ok(doctors.Select(d => new DoctorResponse
            {
                IdDoctor = d.IdDoctor,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email
            }));
        }

        [HttpGet("{id}")]
        public ActionResult<DoctorResponse> GetDoctor(int id)
        {
            var doctor =  _dbService.GetDoctor(id);
            if (doctor == null)
                return NotFound();

            return new DoctorResponse
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
        }

        [HttpPut("{id}")]
        public IActionResult PutDoctor(int id, PutDoctorRequest request)
        {
            if (id != request.IdDoctor)
                return BadRequest();

            var doctor = new Doctor
            {
                IdDoctor = request.IdDoctor,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            doctor = _dbService.UpdateDoctor(doctor);
            if (doctor == null)
                return NotFound();

            return Ok(new DoctorResponse
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            });
        }

        [HttpPost]
        public ActionResult<DoctorResponse> PostDoctor(PostDoctorRequest request)
        {
            var doctor = new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
            doctor = _dbService.AddDoctor(doctor);

            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.IdDoctor }, new DoctorResponse
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            });
        }

        [HttpDelete("{id}")]
        public ActionResult<DoctorResponse> DeleteDoctor(int id)
        {
            var doctor = _dbService.RemoveDoctor(id);
            if (doctor == null)
                return NotFound();

            return new DoctorResponse
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
        }
    }
}
