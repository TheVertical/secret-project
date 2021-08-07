import React, { FunctionComponent as FC} from 'react';
import ContactForm from '../common-components/contact-form';
import LocalizeService from '@/shared/localization-service'
import { Col, Container, Nav, Row } from 'react-bootstrap';
import { Link } from 'react-router-dom';

interface HeaderInfo {
    PhoneNumber: string,
    WorkTime: string
}

const Header: React.FC<HeaderInfo> = (props) => {

    const { PhoneNumber, WorkTime } = props;
    const showCallBack = true;
    return(
        <div className='header'>
            <Container>
                <Row>
                    <Col md={4} className='d-flex align-items-center justify-content-center'>
                        <a href="/Home/Index" className='logo-company text-center'>Olimp-dental</a>
                    </Col>
                    <Col md={5} className='d-flex align-items-center'>
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
                    <Col md={3}>
                        <ContactForm
                            PhoneNumber={PhoneNumber}
                            WorkTime={WorkTime}
                            ShowCallback={showCallBack}/>
                    </Col>
                </Row>
            </Container>
        </div>
    );

}

export default Header;