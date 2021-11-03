import Category from '@/models/category';
import ManufacturerViewModel from '@/models/manufacturer-view-model';
import ProductViewModel from '@/models/product-card-view-model';
import ShortProduct from '@/models/short-product';
import ToastItem, { ToastType } from '@/models/toast-item';

const MockService = {
    Visual: {
        getToasts(count: number): ToastItem[] {
            const toastItems: ToastItem[] = [];

            if (count > 0) {
                const errorItem: ToastItem = {
                    Id: 0,
                    Title: "SecretProject",
                    Type: ToastType.Error,
                    Message: "Error message for SecretProject"
                };

                toastItems.push(errorItem);
            }

            if (count > 1) {
                const warningItem: ToastItem = {
                    Id: 1,
                    Title: "SecretProject",
                    Type: ToastType.Warning,
                    Message: "Warning message for SecretProject"
                };

                toastItems.push(warningItem);
            }
            if (count > 2) {
                const infoItem: ToastItem = {
                    Id: 2,
                    Title: "SecretProject",
                    Type: ToastType.Info,
                    Message: "Info message for SecretProject"
                };

                toastItems.push(infoItem);
            }

            return toastItems;
        },
        getToast(): ToastItem {
            const array: string[] = ["error", "warning", "info"];
            const type = array[Math.floor(Math.random() * 3)] as ToastType;

            const item: ToastItem = {
                Id: 0,
                Title: "SecretProject",
                Type: type,
                Message: type + " message for SecretProject"
            };

            return item;
        }
    },
    getShortProducts(count: number): ShortProduct[] {
        const shortProducts: ShortProduct[] = [];

        for (let i = 0; i < count; i++) {
            const shortProduct: ShortProduct = {
                Id: 'sp-' + i,
                Name: 'Лампа полимеризационная с принадлежностями LED.L (WOODPECKER)',
                ImageUrl: '/Images/Mock.jpg',
                Cost: Math.round(Math.abs(Math.random() * 1000)),
                InStock: Math.random() > 0.5 ? true : false
            };

            shortProducts.push(shortProduct);
        }

        return shortProducts;
    },
    getProduct(): ProductViewModel {
        const manufacturer: ManufacturerViewModel = {
            Id: '1',
            Name: 'Alias'
        };
        const product: ProductViewModel = {
            Id: 'sp-2',
            ProductCode: 'sp-2',
            Title: 'Лампа полимеризационная с принадлежностями LED.L (WOODPECKER)',
            Description: 'Беспроводная лампа LED- L предназначена для полимеризации композитных светоотверждаемых материалов при проведении реставрационных работ. Семь рабочих режимов времени работы 3, 5, 10, 20 с, 1, 3, 5 мин. Также 3 режима работы:',
            Manufacturer: manufacturer,
            OriginalPrice: 4950,
            DiscountedPrice: 200,
            ImageUrl: '/Images/Mock.jpg',
            IsDiscouted: false,
            IsNew: false,
            IsPopular: false,
            IsInStock: false,
        };

        return product;
    },
    getCategory(productsCount: number): Category {
        const products: ShortProduct[] = productsCount > 0 ? this.getShortProducts(productsCount) : [];

        const categoryMock: Category = {
            Id: 'c-1',
            Name: 'Гигиена и профилактика',
            ShortProducts: products
        }

        return categoryMock;
    }
}

export default MockService;