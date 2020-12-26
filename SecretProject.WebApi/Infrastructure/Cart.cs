using SecretProject.BusinessProject.Models.Good;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.WebApi.Infrastructure
{
    [Serializable]
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines => lineCollection;
        public virtual void AddItem(Nomenclature nom, int amount)
        {
            CartLine line = lineCollection
                .Where(l => l.Nomenclature.Id == nom.Id)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine() { NomenclatureId = nom.Id, Amount = amount, Nomenclature = nom });
            }
            else
            {
                line.Amount += amount;
            }
        }
        public virtual void RemoveLine(Nomenclature nom) =>
            lineCollection.RemoveAll(l => l.NomenclatureId == nom.Id);
        public virtual float ComputeToValue() =>
            lineCollection.Sum(l => l.Nomenclature.Cost * l.Amount);
        public virtual void Clear() => lineCollection.Clear();
    }
    public class CartLine
    {
        public int NomenclatureId { get; set; }
        public Nomenclature Nomenclature { get; set; }
        public int Amount { get; set; }
    }
}
