using AI.Finder.BE.Service.Features.Gender;
using AI.Finder.BE.Service.Features.Unit;
using AI.Finder.BE.Service.Features.Complexion;
using AI.Finder.BE.Service.Features.BodyType;
using AI.Finder.BE.Service.Features.BloodGroup;
using AI.Finder.BE.Service.Features.MaritalStatus;
using AI.Finder.BE.Service.Features.Country;
using AI.Finder.BE.Service.Features.District;
using AI.Finder.BE.Service.Features.State;
using AI.Finder.BE.Service.Features.Town;
using AI.Finder.BE.Service.Features.Resident;
using AI.Finder.BE.Service.Features.Language;
using AI.Finder.BE.Service.Features.AddressType;

namespace AI.Finder.BE.Service.Features.Candidate;

    public class CandidateModel{
        public long Id { get; set; }
        public GenderModel Gender { get; set; }
        public UnitModel Units { get; set; }
        public ComplexionModel Complexion { get; set; }
        public BodyTypeModel BodyType { get; set; }
        public MaritalStatusModel MaritalStatus { get; set; }
        public int ChildrenWithMe { get; set; }
        public int ChildrenNotWithMe { get; set; }
        public BloodGroupModel BloodGroup { get; set; }
        public CountryModel ResidentCountry { get; set; }
        public StateModel ResidentState {get; set; }
        public DistrictModel ResidentDistrct {get; set; }
        public TownModel ResidentsTown{get; set; }
        public string ResidentTown {get; set; }
        public ResidentTypeModel ResidentType { get; set; }
        public DistrictModel NativeDistrict {get; set; }
        public TownModel NativesTown {get; set; }
        public string NativeTown {get; set; }
        public LanguageModel MotherTongue { get; set; }
        public string ReligionTreePath { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public Boolean IsSpecialNeed { get; set; }
        public Boolean IsResident { get; set; }
        public long HeightInCentimeter { get; set; }
        public short WeightInKilogram { get; set; }
        public string OtherReligion { get; set; }
        public string OtherReligiousInformation { get; set; }
        public string AboutMe { get; set; }
        public string CandidateAssetDetails { get; set; }
        public CandidateModel TwinsCandidate {get; set; }
        public string RegistrationId {get; set; }
        public AddressTypeModel CreatedContact {get; set; }
    }
