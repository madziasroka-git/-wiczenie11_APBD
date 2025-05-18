using Cwiczenia11.DTOs;
using Cwiczenia11.Models;

namespace Cwiczenia11.Services;

public interface IDbService
{
    Task<int> createNewPrescripion(NewPrescriptionDTO prescription);
}