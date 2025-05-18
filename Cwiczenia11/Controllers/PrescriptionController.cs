using Cwiczenia11.DTOs;
using Cwiczenia11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia11.Controllers;
[ApiController]
[Route("[controller]")]
public class PrescriptionController: ControllerBase
{
   private readonly IDbService _dbService;

   public PrescriptionController(IDbService dbService)
   {
       _dbService = dbService;
   }
   
    [HttpPost]
    public async Task<IActionResult> AddPrescription(NewPrescriptionDTO dto)
    {
        try
        {
            var result = await _dbService.createNewPrescripion(dto);
            return Created("", result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}