using System.Collections.Generic;

namespace SecretProject.Web.ViewModels
{
    public class NomenclatureResult
    {
        public NomenclatureResult()
        {

        }
        public NomenclatureResult(int totalFound, float minCost, float maxCost, IEnumerable<NomenclatureViewModel> nomenclatures)
        {
            TotalFound = totalFound;
            MinCost = minCost;
            MaxCost = maxCost;
            Nomenclatures = nomenclatures;
        }
        public int TotalFound { get; set; }
        public float MinCost { get; set; }
        public float MaxCost { get; set; }
        public IEnumerable<NomenclatureViewModel> Nomenclatures { get; set; }
    }
}
