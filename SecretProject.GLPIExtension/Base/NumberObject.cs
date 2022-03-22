using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Base
{
    [XmlType(TypeName = "Number")]
    public class NumberObject : RangeObject<int?>
    {
        public override bool IsValueOutOfRange
        {
            get => Value != null && Max != null && Min != null && Value > Min && Value < Max;
        }
    }
}