using ABPD11.Models;
using System.Collections.Generic;

namespace APBD11.Services
{
    public interface IDoctorDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor GetDoctor(int id);
        public Doctor AddDoctor(Doctor doctor);
        public Doctor UpdateDoctor(Doctor doctor);
        public Doctor RemoveDoctor(int id);
    }
}
