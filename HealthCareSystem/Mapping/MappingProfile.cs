using AutoMapper;
using HealthCareSystem.Models;
using HealthCareSystem.ModelsResources;
using HealthCareSystem.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace VegaProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping and Reverese mapping:

            CreateMap<Title, TitleResource>().ReverseMap();
            CreateMap<GetTehnicians, GetTehniciansResult>().ReverseMap();
            CreateMap<GetTehnicianShifts, GetTehnicianShiftsResult>().ReverseMap();
            CreateMap<Tehnician, TehnicianResource>().ReverseMap();
            CreateMap<Time, TimeResource>().ReverseMap();
            CreateMap<Facility, FacilityResource>().ReverseMap();
            CreateMap<Appointment, AppointmentResource>().ReverseMap();
            CreateMap<Patient, PatientResource>().ReverseMap();
            CreateMap<DoctorShift, DoctorShiftResource>().ReverseMap();
            CreateMap<TehnicianShift, TehnicianShiftResource>().ReverseMap();
            CreateMap<DoctorQuery, QueryResource>().ReverseMap();
            CreateMap<GetDoctorShifts, GetDoctorShiftsResource>().ReverseMap();
            CreateMap<Role, RoleResource>().ReverseMap();
            CreateMap<Admin, AdminResource>().ReverseMap();

            // Mapping Models to ModelResorces:
            CreateMap<Doctor, DoctorResource>()
               .ForMember(dr => dr.Patients, opt => opt.MapFrom(d => d.Patients))
               .ForMember(dr => dr.Appointments, opt => opt.Ignore())
               .ForMember(dr => dr.DoctorShifts, opt => opt.Ignore());
            // Mapping ModelResources to Models:
        }
    }
}
