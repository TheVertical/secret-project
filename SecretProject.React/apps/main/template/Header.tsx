import React, { FunctionComponent as FC } from 'react';
import LocalizeService from '@/shared/localization-service'
import { Col, Container, Nav, Row } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const Header: React.FC = (props) => {
    return (
        <div className='header'>
            <Container>
                <Row>
                    <Col md={12} className='d-flex justify-content-end'>
                        <Nav
                            activeKey='/home'
                        >
                            <Nav.Item>
                                <Link to="/Catalog/Category" className='p-1 nav-link'>{LocalizeService.localize('Header_DeliveryAndPayment')}</Link>
                            </Nav.Item>
                            <Nav.Item>
                                <Link to="/Catalog/Category" className='p-1 nav-link'>{LocalizeService.localize('Header_Return')}</Link>
                            </Nav.Item>
                            <Nav.Item>
                                <Link to="/Catalog/Category" className='p-1 nav-link'>{LocalizeService.localize('Header_PickUPoint')}</Link>
                            </Nav.Item>
                            <Nav.Item>
                                <Link to="/Catalog/Category" className='p-1 nav-link'>{LocalizeService.localize('Header_News')}</Link>
                            </Nav.Item>
                            <Nav.Item>
                                <Link to="/Catalog/Category" className='p-1 nav-link'>{LocalizeService.localize('Header_PromotionsAndDiscounts')}</Link>
                            </Nav.Item>
                            <Nav.Item>
                                <Link to="/Catalog/Category" className='p-1 nav-link'>{LocalizeService.localize('Header_Reviews')}</Link>
                            </Nav.Item>
                        </Nav>

                    </Col>
                </Row>
            </Container>
        </div>
    );
}

export default Header;