using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AI.Finder.BE.Service.Features.Candidate;
[ApiController]
[Route("[controller]/[action]")]
[Authorize]
public class CandidateController : ControllerBase
{
    private readonly FinderDbContext context;
    public CandidateController(FinderDbContext context){
        this.context = context;
    }
    [HttpGet("{candidateId}")]
    public async Task<IActionResult> GetCandidate(long candidateId){
        var CandidatReliginTreePath = await context.Candidates.Where(e => e.Id == candidateId)
                                    .Select(e => e.ReligionTreePath).FirstOrDefaultAsync();
        var Religion = await context.Religions.FromSqlRaw("SELECT * FROM public.religion where treepath @> '" + CandidatReliginTreePath + "' ")
           .ToListAsync();
        try{
            var Candidate = await context.Candidates
              .Include(e => e.Units)
              .Include(e => e.Complexion)
              .Include(e => e.BodyType)
              .Include(e => e.MaritalStatus)
              .Include(e => e.BloodGroup)
              .Include(e => e.ResidentCountry)
              .Include(e => e.ResidentType)
              .Include(e => e.MotherTongue)
              .Include(e=>e.ResidentDistrct)
              .Include(e=>e.ResidentState)
              .Include(e=>e.ResidentsTown)
              .Select(e => new{
                  Id = e.Id,
                  Gender = e.Gender,
                  Units = e.Units,
                  Complexion = e.Complexion,
                  BodyType = e.BodyType,
                  MaritalStatus = e.MaritalStatus,
                  BloodGroup = e.BloodGroup,
                  ResidentCountry = e.ResidentCountry,
                  ResidentType = e.ResidentType,
                  ResidentState=e.ResidentState,
                  ResidentDistrct=e.ResidentDistrct,
                  ResidentsTown=e.ResidentsTown,
                  ResidentTown=e.ResidentTown,
                  MotherTongue = e.MotherTongue,
                  Religion = Religion,
                  Name = e.Name,
                  DOB = e.DOB,
                  IsSpecialNeed = e.IsSpecialNeed,
                  IsResident = e.IsResident,
                  HeightInCentimeter = (Math.Round((e.HeightInCentimeter) / Math.Round(Convert.ToDecimal(e.Units.BaseValue), 2), 1)),
                  WeightInKilogram = e.WeightInKilogram,
                  OtherReligion = e.OtherReligion,
                  OtherReligiousInformation = e.OtherReligiousInformation,
                  AboutMe = e.AboutMe
              })
              .ProjectToType<CandidateResponseDTO>()
            .Where(e => e.Id == candidateId)
            .FirstOrDefaultAsync();
            if (Candidate == null){
                return BadRequest();
            }
            return Ok(Candidate);
        }
        catch (Exception ex){
            return BadRequest(ex);
        }
    }
}
