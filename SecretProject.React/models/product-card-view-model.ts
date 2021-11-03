import ManufacturerViewModel from "./manufacturer-view-model";

export default interface ProductViewModel {
    Id: string,
    ProductCode: string,
    Title: string,
    Description: string,
    Manufacturer: ManufacturerViewModel,
    OriginalPrice: number,
    DiscountedPrice: number,
    ImageUrl: string,
    IsDiscouted: boolean,
    IsNew: boolean,
    IsPopular: boolean,
    IsInStock: boolean,
}