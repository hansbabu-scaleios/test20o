using System.ComponentModel.DataAnnotations;

namespace AI.Finder.BE.Service.Features.Candidate;

    public class CandidateRequestDTO{
        [RequiredAttribute(ErrorMessage ="Please enter full name.")]
        [StringLength(50)]
        public string Name { get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your gender.")]
        public long GenderId{ get; set; }
        public DateTime DOB { get; set; }
        public decimal HeightInCentimeter { get; set; }
        [RequiredAttribute(ErrorMessage ="Please select unit of measurement.")]
        public long HeightInUnitsId { get; set; }
        [RequiredAttribute(ErrorMessage ="Please enter your weight.")]
        public short WeightInKilogram { get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your complexion.")]
        public long ComplexionId { get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your bodytype.")]
        public long BodyTypeId { get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your maritalstatus.")]
        public long MaritalStatusId { get; set; }
        public int ChildrenWithMe { get; set; }
        public int ChildrenNotWithMe { get; set; }
        public Boolean IsSpecialNeed { get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your bloodgroup.")]
        public long BloodGroupId { get; set; }
        public Boolean IsResident { get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your residentcountry.")]
        public long ResidentCountryId { get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your residentstate.")]
        public long ResidentStateId {get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your residentdistrict.")]
        public long ResidentDistrictId {get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your residenttown.")]
        public long ResidentTownId {get; set; }
        public string ResidentTown {get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your residenttype.")]
        public long ResidentTypeId { get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your native district.")]
        public long NativeDistrictId {get; set; }
        public long NativeTownId{get; set; }
        public string NativeTown {get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your mothertongue.")]
        public long MotherTongueId { get; set; }
        [RequiredAttribute(ErrorMessage ="Please select your Religion.")]
        public long ReligionId { get; set; }
        public string OtherReligion { get; set; }
        public string OtherReligiousInformation { get; set; }
        public string AboutMe { get; set; }
        public string CandidateAssetDetails { get; set; }
        public long TwinsCandidateId {get; set; }
        public string RegistrationId {get; set; }
        [RequiredAttribute(ErrorMessage ="Please select created by.")]
        public long CreatedContactId {get; set; }
    }
