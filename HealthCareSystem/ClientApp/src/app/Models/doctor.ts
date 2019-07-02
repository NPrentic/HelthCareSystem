
class Doctor{

  id: number;

  name: string;

  titleId: number;

  title: DoctorTitle;

  facilityId: number;

  facility: Facility;

  ambulance: number;

  password: string;

  userId: number;

  roleId: number;

  role: Role;

  patients: Patient[];

  appointments: Appointment[];

  doctorShifts: DoctorShift[];

}
