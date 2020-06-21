using ABPD11.Models;
using APBD11.Services;
using System.Collections.Generic;
using System.Linq;

namespace Cw11.Services
{
    public class SqlServerDoctorDbService : IDoctorDbService
    {
        private readonly ClinicDbContext _dbContext;

        public SqlServerDoctorDbService(ClinicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            var doctorEntity = _dbContext.Doctors.Add(doctor);
            _dbContext.SaveChanges();
            return doctorEntity.Entity;
        }

        public Doctor GetDoctor(int id)
        {
            return _dbContext.Doctors.Find(id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _dbContext.Doctors.ToList();
        }

        public Doctor RemoveDoctor(int id)
        {
            var doctor = GetDoctor(id);
            if (doctor == null)
                return null;
            _dbContext.Doctors.Remove(doctor);
            _dbContext.SaveChangesAsync();
            return doctor;
        }

        public Doctor UpdateDoctor(Doctor newDoctor)
        {
            var currentDoctor = GetDoctor(newDoctor.IdDoctor);
            if (currentDoctor == null)
                return null;

            if (newDoctor.FirstName != null)
                currentDoctor.FirstName = newDoctor.FirstName;
            if (newDoctor.LastName != null)
                currentDoctor.LastName = newDoctor.LastName;
            if (newDoctor.Email != null)
                currentDoctor.Email = newDoctor.Email;

       
             _dbContext.SaveChanges();

            return newDoctor;
        }
    }
}
