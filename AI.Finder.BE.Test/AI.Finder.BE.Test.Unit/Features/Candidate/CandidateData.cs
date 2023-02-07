using System;
using System.Collections.Generic;
using AI.Finder.BE.Service.Features.AddressType;
using AI.Finder.BE.Service.Features.BloodGroup;
using AI.Finder.BE.Service.Features.BodyType;
using AI.Finder.BE.Service.Features.Candidate;
using AI.Finder.BE.Service.Features.Complexion;
using AI.Finder.BE.Service.Features.Country;
using AI.Finder.BE.Service.Features.District;
using AI.Finder.BE.Service.Features.Gender;
using AI.Finder.BE.Service.Features.Language;
using AI.Finder.BE.Service.Features.MaritalStatus;
using AI.Finder.BE.Service.Features.Religion;
using AI.Finder.BE.Service.Features.Resident;
using AI.Finder.BE.Service.Features.State;
using AI.Finder.BE.Service.Features.Town;
using AI.Finder.BE.Service.Features.Unit;

namespace AI.Finder.BE.Test.Unit.Features.Candidate;

public class CandidateData{
    public static CandidateModel GetCandidate(){
        return new CandidateModel{
            Id = 1,
            Gender = GetGender(),
            Units = GetUnit(),
            Complexion = GetComplexion(),
            BodyType = GetBodyType(),
            MaritalStatus = GetMaritalStatus(),
            ChildrenWithMe = 0,
            ChildrenNotWithMe = 0,
            BloodGroup = GetBloodGroup(),
            ResidentCountry = GetCountry(),
            ResidentTown = "Kochi",
            ResidentType = GetResidentType(),          
            NativeTown = "Kochi",
            MotherTongue = GetLanguage(),
            ReligionTreePath = "1.2.4.5",
            Name = "Akshay NR",
            DOB = Convert.ToDateTime("1997-09-24"),
            IsSpecialNeed = true,
            IsResident = true,
            HeightInCentimeter = 170,
            WeightInKilogram = 65,
            OtherReligion = "nil",
            OtherReligiousInformation = "nil",
            AboutMe = "nil",
            CandidateAssetDetails = "nil",
            TwinsCandidate = null,
            RegistrationId = "no",
            CreatedContact = GetAddressType(),
            ResidentDistrct = GetDistrict(),
            ResidentsTown = GetTown(),
            NativeDistrict = GetDistrict(),
            NativesTown = GetTown()
        };
    }

    public static GenderModel GetGender(){
        return new GenderModel{
            Id = 1,
            Name = "Male"
        };
    }
    public static UnitModel GetUnit(){
        return new UnitModel{
            Id = 1,
            Name = "Centimeter",
            Code = "Cm",
            BaseValue = 1,
            ConversionUnit = 1,
            IsVisible = true
        };
    }
    public static ComplexionModel GetComplexion(){
        return new ComplexionModel {
            Id = 1,
            Name = "Fair"
        };
    }
    public static BodyTypeModel GetBodyType(){
        return new BodyTypeModel {
            Id = 1,
            Name = "Slim"
        };
    }
    public static AddressTypeModel GetAddressType(){
        return new AddressTypeModel{
            Id = 1,
            Name = "Permanent"
        };
    }
    public static MaritalStatusModel GetMaritalStatus(){
        return new MaritalStatusModel{
            Id = 1,
            Name = "Unmarried"
        };
    }
    public static BloodGroupModel GetBloodGroup(){
        return new BloodGroupModel{
            Id = 1,
            Name = "O+VE"
        };
    }
    public static CountryModel GetCountry(){
        return new CountryModel{
            Id = 1,
            Name = "INDIA"
        };
    }
    public static StateModel GetState(){
        return new StateModel{
            Id=1,
            Name = "Kerala",
        };
    }
    public static DistrictModel GetDistrict(){
        return new DistrictModel{
            Id = 1,
            Name = "ERNAKULAM",
        };
    }
    public static TownModel GetTown(){
        return new TownModel{
            Id = 1,
            Name = "Kochi",
            IsVerified = true
        };
    }
    public static ResidentTypeModel GetResidentType(){
        return new ResidentTypeModel{
            Id = 1,
            Name = "Permanent"
        };
    }
    public static LanguageModel GetLanguage(){
        return new LanguageModel{
            Id = 1,
            Name = "Malayalam"
        };
    }
    public static List<ReligionModel> GetReligion(){
       return new List<ReligionModel>{
              new ReligionModel{
            Id = 1,
            ParentId = null,
            TreePath = "1",
            Name = "Christian",
            Type = "RELIGION",
            IsVerified = true
        }, new ReligionModel{
            Id = 2,
            ParentId = 1,
            TreePath = "1.2",
            Name = "Catholic",
            Type = "CAST",
            IsVerified = true
        },
       
         new ReligionModel{
            Id = 3,
            ParentId = 1,
            TreePath = "1.3",
            Name = "NonCatholic",
            Type = "CAST",
            IsVerified = true
        },
         new ReligionModel{
            Id = 4,
            ParentId = 2,
            TreePath = "1.2.4",
            Name = "Latin Catholic",
            Type = "SUBCAST",
            IsVerified = true
        },
         new ReligionModel{
            Id = 5,
            ParentId = 4,
            TreePath ="1.2.4.5",
            Name = "Varapoli Diocese",
            Type = "DIOCESE",
            IsVerified = true
        }        
        };
    }
}