import Category from '@/models/category';
import ShortProduct from '@/models/short-product';

const MockService = {
    getShortProducts(count: number):ShortProduct[] {
        const shortProducts: ShortProduct[] = [];
        for (let i = 0; i < count; i++) {
            const shortProduct:ShortProduct = {
                Id: 'sp-'+i,
                Name: 'Лампа полимеризационная с принадлежностями LED.L (WOODPECKER)',
                ImageUrl: '/Images/Mock.jpg',
                Cost: Math.round(Math.abs(Math.random() * 1000)),
                InStock: Math.random() > 0.5 ? true : false
            };
            
            shortProducts.push(shortProduct);
        }

        return shortProducts;
    },
    getCategory(productsCount: number):Category {
        const products: ShortProduct[] = productsCount > 0 ? this.getShortProducts(productsCount) : [];

        const categoryMock:Category = {
            Id: 'c-1',
            Name: 'Гигиена и профилактика',
            ShortProducts: products
        }

        return categoryMock;
    }
}

export default MockService;