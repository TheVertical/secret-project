import CategoryViewModel from '@/models/category';
import ShortProductViewModel from '@/models/short-product';
import React from 'react';
import { Breadcrumb, Col, Container, Row } from 'react-bootstrap';
import ShortProductCard from '@/apps/main/common-components/short-product-card';

interface CategoryPageProps {
    categoryViewModel: CategoryViewModel
}

const CategoryPage: React.FC<CategoryPageProps> = (props) => {
    const { 
        categoryViewModel
    } = props;

    const renderCard = function(shortProduct: ShortProductViewModel) {
        return (
            <Col key={shortProduct.Id} md={3} className="d-flex justify-content-center mb-2">
                <ShortProductCard shortProductViewModel={shortProduct} />
            </Col>
        );
    }

    var cards = categoryViewModel.ShortProducts.map(p => renderCard(p));
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
                            {categoryViewModel.Name}
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