using System;

namespace SecretProject.Web.Infrastructure
{
    /// <summary>
    /// Строка в корзине
    /// </summary>
    [Serializable]
    public class CartLine
    {
        public Guid NomenclatureId { get; set; }
        public float NomenclatureCost { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            string line = "-------------------\n";
            line += "NomId:" + NomenclatureId.ToString() + "\n";
            line += "Amount:" + Amount.ToString() + "\n";
            line += "-------------------\n";
            return line;

        }
    }
}