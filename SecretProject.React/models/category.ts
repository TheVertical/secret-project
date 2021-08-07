import ShortProduct from "./short-product";

interface Category {
    Id: string,
    Name: string,
    ShortProducts: ShortProduct[],
}

export default Category;