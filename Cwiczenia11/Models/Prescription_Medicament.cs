using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia11.Models;
[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class Prescription_Medicament
{
    [ForeignKey(nameof(Medicament))]
    public int IdMedicament { get; set; }
    [ForeignKey(nameof(Prescription))]
    public int IdPrescription { get; set; }
    [NotNull]
    public int Dose { get; set; }
    public string Details { get; set; }
    
    public Medicament Medicament { get; set; }
    public Prescription Prescription { get; set; }
    
}