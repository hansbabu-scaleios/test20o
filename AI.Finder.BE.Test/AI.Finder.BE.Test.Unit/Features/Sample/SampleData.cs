using System.Collections.Generic;
using AI.Finder.BE.Service.Features.Samples;

namespace AI.Finder.BE.Test.Unit.Features.Sample;

    public class SampleData{
        public static List<SampleModel> GetSampleData()
        {
            return new List<SampleModel>{
              new SampleModel{Code=1,AuditProp="{\"lead\": {\"name\": \"Paint house\", \"prep\": \"yes\"}, \"Secondary\": {\"name\": \"John\", \"prep\": \"No\"}}"},
              new SampleModel{Code=2,AuditProp="{\"lead\": {\"name\": \"Paint house\", \"prep\": \"yes\"}, \"Secondary\": {\"name\": \"John\", \"prep\": \"No\"}}"},
              new SampleModel{Code=3,AuditProp="{\"lead\": {\"name\": \"Paint house\", \"prep\": \"yes\"}, \"Secondary\": {\"name\": \"John\", \"prep\": \"No\"}}"},
              new SampleModel{Code=4,AuditProp="{\"lead\": {\"name\": \"Paint house\", \"prep\": \"yes\"}, \"Secondary\": {\"name\": \"John\", \"prep\": \"No\"}}"}
            };
        }
    }
