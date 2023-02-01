namespace AI.Finder.BE.Service.Features.Unit;

    public class UnitModel{
         public long Id { get; set; }
         public string Name { get; set; }
         public string Code { get; set; }
         public decimal BaseValue { get; set; }
         public short ConversionUnit { get; set; }
         public Boolean IsVisible { get; set; }
    }
