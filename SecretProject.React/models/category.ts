import ShortProduct from "./short-product";

interface CategoryViewModel {
    Id: string,
    Name: string,
    ShortProducts: ShortProduct[],
}

export default CategoryViewModel;