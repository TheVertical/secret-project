using SecretProject.BusinessProject.Models.Good;
using SecretProject.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SecretProject.WebApi.Infrastructure
{
    [Serializable]
    public class Cart
    {

        #region Model
        private List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines => lineCollection;
        #endregion

        #region Class Methods
        public virtual void AddLine(Nomenclature nom, int amount)
        {
            CartLine line = lineCollection
                .Where(l => l.NomenclatureId == nom.Id)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine() { NomenclatureId = nom.Id, Amount = amount, NomenclatureCost = nom.Cost});
            }
            else
            {
                line.Amount += amount;
            }
        }
        public virtual void RemoveLine(Nomenclature nom) =>
            lineCollection.RemoveAll(l => l.NomenclatureId == nom.Id);
        public virtual float ComputeToValue() =>
            lineCollection.Sum(l => l.NomenclatureCost * l.Amount);
        public virtual void Clear() => lineCollection.Clear();

        public override string ToString()
        {
            string list = "";
            Lines.ToList().ForEach(l => list += l.ToString());
            return list;
        }
        #endregion
    }
    /// <summary>
    /// Строка в корзине
    /// </summary>
    [Serializable]
    public class CartLine
    {
        public int NomenclatureId { get; set; }
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
