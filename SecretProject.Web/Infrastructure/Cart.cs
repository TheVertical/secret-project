using System;
using System.Collections.Generic;
using System.Linq;
using SecretProject.BusinessProject.Models.Nomenclature;

namespace SecretProject.Web.Infrastructure
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
}
