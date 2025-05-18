using Cwiczenia11.Data;
using Cwiczenia11.DTOs;
using Cwiczenia11.Models;

namespace Cwiczenia11.Services;

public class DbService : IDbService
{

    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }


    public async Task<int> createNewPrescripion(NewPrescriptionDTO prescription)
    {

        if (prescription.Medicaments.Count == 0 || prescription.Medicaments == null)
        {
            throw new ArgumentNullException("Medicaments cannot be null.");
        }

        if (prescription.Medicaments.Count > 10)
        {
            throw new ArgumentOutOfRangeException("Medicaments cannot be greater than 10.");
        }

        if (prescription.DueDate < prescription.Date)
        {
            throw new ArgumentException("Date prescripion cannot be earlier than due date.");
        }

        var doctor = await _context.Doctors.FindAsync(prescription.IdDoctor);
        if (doctor == null)
            throw  new ArgumentException("Doctor not found.");

        Patient patient;

        var patienteSearch = await _context.Patients.FindAsync(prescription.Patient.IdPatient);
        if (patienteSearch != null)
        {
            patient = patienteSearch;
        }
        else
        {
            patient = new Patient
            {
                FirstName = prescription.Patient.FirstName,
                LastName = prescription.Patient.LastName,
                BirthDate = prescription.Patient.BirthDate,
            };
            _context.Patients.Add(patient);
        }


        var newPrescription = new Prescription
        {
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            IdDoctor = doctor.IdDoctor,
            IdPatient = patient.IdPatient
        };
        _context.Prescriptions.Add(newPrescription);

        foreach (var med in prescription.Medicaments)
        {
            var medicament = await _context.Medicaments.FindAsync(med.IdMedicament);
            if (medicament == null)
                throw new ArgumentException("Medicament with id {med.IdMedicament} not found.");

            var pm = new Prescription_Medicament
            {
                IdPrescription = prescription.IdPrescription,
                IdMedicament = med.IdMedicament,
                Dose = med.Dose,
                Details = med.Description
            };
            _context.Prescription_Medicaments.Add(pm);
        }

        return prescription.IdPrescription;
    }
    
}