import CategoryViewModel from '@/models/category';
import ShortProductViewModel from '@/models/short-product';
import React from 'react';
import { Breadcrumb, Button, Card, Col, Container, Row } from 'react-bootstrap';
import ShortProductCard from '@/apps/main/common-components/short-product-card';

const CategoryPage: React.FC<CategoryViewModel> = (props) => {
    const { 
        Name,
        ShortProducts 
    } = props;

    const renderCard = function(shortProduct: ShortProductViewModel) {
        return (
            <Col key={shortProduct.Id} md={3} className="d-flex justify-content-center">
                <ShortProductCard shortProductViewModel={shortProduct} />
            </Col>
        );
    }
    var cards = ShortProducts.map(p => renderCard(p));

    return(
        <div className="category-page-container">
            <Container>
                <Row>
                    <Col>
                        <Breadcrumb>
                        </Breadcrumb>
                    </Col>
                </Row>
                <Row>
                    <Col md={12}>
                        <h1 className="category-name">
                            {Name}
                        </h1>
                    </Col>
                </Row>
                <hr />
                <Row className="d-flex justify-content-end">
                    {cards}
                </Row>
            </Container>
        </div>
    );
}

export default CategoryPage;