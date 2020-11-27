using System;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.BusinessProject.Models.Nomeclature
{
    public enum CostVariations
    {
        None, BySelf, ByCategory, ByManufacturer
    }
    public class CostPolicy
    {
        #region Model
        public CostVariations Variation { get;private set; }
        #endregion

        #region Realization
        public CostPolicy(CostVariations variation = CostVariations.None)
        {
            this.Variation = variation;
        }
        #endregion

        #region Class Methods
        public float Correlate()
        {
            //TODO Продумать мехазим изменения цены по скидке
            switch (Variation)
            {
                case CostVariations.BySelf:
                    break;
                case CostVariations.ByCategory:
                    break;
                case CostVariations.ByManufacturer:
                    break;
                default:
                    break;
            }
            throw new NotImplementedException(this.GetType().FullName + " " + "Method: Correlate()");
            return 0;
        }

#if DEBUG
        public int CorrelateByProcentMock()
        {
            return 10;
        }
#endif
        #endregion

        #region Interface's Methods

        #endregion
    }
}
