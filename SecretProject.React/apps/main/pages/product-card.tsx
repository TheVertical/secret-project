import ProductViewModel from '@/models/product-card-view-model';
import CurencyService from '@/shared/curency-service';
import LocalizeService from '@/shared/localization-service';
import React from 'react';
import { Button, Col, Row } from 'react-bootstrap';
import CounterButton from '../common-components/counter-button';

interface ProductCardProps {
    productViewModel: ProductViewModel
}

const ProductCard: React.FC<ProductCardProps> = (props) => {
    const { productViewModel } = props;
    // d-flex justify-content-center
    return (
        <div className="product-card">
            <div className="product-card-header p-2">
                <Row>
                    <Col>
                        <h1 className="product-card-title fw-bold ">{productViewModel.Title}</h1>
                    </Col>
                </Row>
            </div>
            <div className="product-card-body">
                <Row>
                    <Col>
                        <div className="p-4 product-image d-flex justify-content-center">
                            <img src={productViewModel.ImageUrl} alt={productViewModel.Title} />
                        </div>
                    </Col>
                    <Col>
                        <div className="px-3 product-card-cost-information">
                            <div>
                                <span className="product-cost">{productViewModel.IsDiscouted ? CurencyService.toRubles(productViewModel.DiscountedPrice) : CurencyService.toRubles(productViewModel.OriginalPrice)}</span>
                            </div>

                            <div className="px-3 mb-3">
                                <span className="product-code">{LocalizeService.localize("ProductCard_Code") + ": " + productViewModel.ProductCode}</span>
                            </div>

                            <div className="px-3 mb-5">
                                <CounterButton variant="tertiary" size="lg" minValue={0} maxValue={1000} updateCount={(count) => console.debug(count)} />
                            </div>

                            <div className="px-3 mb-3">
                                <Button className="w-100 p-3" variant="primary" size="lg">{LocalizeService.localize('ProductCard_Buy')}</Button>
                            </div>
                        </div>
                    </Col>
                </Row>
                <div className="px-3">
                    <h2 className="m-0">{LocalizeService.localize("ProductCard_Description")}</h2>
                    <hr />
                    <p className="product-description">
                        {productViewModel.Description}
                    </p>
                </div>
            </div>
        </div>
    );
}

export default ProductCard;