using Cwiczenia11.Models;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia11.Data;

public class DatabaseContext :DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
    
    protected DatabaseContext()
    {
    }
    
    public DatabaseContext(DbContextOptions options) : base(options) { }

    protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prescription_Medicament>()
            .HasKey(pm => new { pm.IdPrescription, pm.IdMedicament });
    }

  

}