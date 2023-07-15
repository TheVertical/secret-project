namespace SecretProject.Web.ViewModels
{
    public class CartLineViewModel
    {
        public CartLineViewModel(NomenclatureViewModel model,int amount)
        {
            Model = model;
            Amount = amount;
        }
        public NomenclatureViewModel Model { get; set; }
        public int Amount { get; set; }
    }
}
