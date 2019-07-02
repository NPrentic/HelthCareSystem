using HealthCareSystem.Core;
using HealthCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Persistence
{
    public class AuthRepository : IAuthRepository { 

         private readonly IDoctorRepository doctorRepository;
         private readonly ITehnicianRepository tehnicianRepository;
        private readonly IAdminRepository adminRepository;

        public AuthRepository(IDoctorRepository doctorRepository, ITehnicianRepository tehnicianRepository,IAdminRepository adminRepository)
        {
             this.doctorRepository = doctorRepository;
             this.tehnicianRepository = tehnicianRepository;
            this.adminRepository = adminRepository;
        }

        public async Task<TokenModel> SearchUserByCredentials(LoginModel loginModel) {

            var admins = await adminRepository.GetAdminAsync();
            var admin = admins.FirstOrDefault(a => (a.UserId == loginModel.UserId && a.Password == loginModel.Password));
            if (admin != null) return new TokenModel() {
                Name = "Administrator",
                Role = admin.Role.Name,
                Facility = admin.Facility,
                Title = null,
                Id = admin.Id
            };
            else
            {
                var doctors = await doctorRepository.GetDoctorsAsync();
                var doctor = doctors.FirstOrDefault(d => (d.UserId == loginModel.UserId && d.Password == loginModel.Password));
                if (doctor != null) return new TokenModel() {
                    Name = doctor.Name,
                    Role = doctor.Role.Name,
                    Facility = doctor.Facility,
                    Title = doctor.Title.Name,
                    Id = doctor.Id 
                };

                else
                {
                    var tehnicians = await tehnicianRepository.GetTehniciansAsync();
                    var tehnician = tehnicians.FirstOrDefault(t => (t.UserId == loginModel.UserId && t.Password == loginModel.Password));
                    if (tehnician != null) return new TokenModel()
                    { Name = tehnician.Name,
                        Role = tehnician.Role.Name,
                        Facility = tehnician.Facility,
                        Title = tehnician.Gender.ToLower() == "male" ? "medicinski tehničar" : "medicinska sestra",
                        Id = tehnician.Id
                    };

                    else return null;
                }
            }
        }
    }
}
