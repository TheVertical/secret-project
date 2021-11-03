using SecretProject.BusinessProject.Models;

namespace SecretProject.Web.ViewModels
{
    public class ManufacturerViewModel
    {
        public ManufacturerViewModel(Manufacturer domain)
        {
            //TODO: move to Guid
            //Id = domain.Id;
            Name = domain.Name;
        }

        public int Id { get; set; }
        public string Type => this.GetType().Name;
        public string Name { get; set; }
    }
}
