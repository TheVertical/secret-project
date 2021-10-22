import LocalizeService from '@/shared/localization-service';
import React from 'react';
import { Button, Col, Container, Row, Image } from 'react-bootstrap';
import { useDispatch } from 'react-redux';
import { Link } from 'react-router-dom';
import { toggleAuthorizationModal } from '../store/reducers/layout-modals-reducer';

interface ToolbarProps {

}
const Toolbar: React.FC<ToolbarProps> = () => {

    const dispatch = useDispatch();

    const onUserIconClick = () => dispatch(toggleAuthorizationModal());

    const isToolbarShow = true;
    return (
        <div className="toolbar-container p-2">
            <Container fluid>
                <Row>
                    <Col md={4} className="d-flex align-items-center justify-content-end">
                        <Link to="/" className="logo-company d-inline-flex align-items-start">
                            <div className="logo-img">
                                <Image src="/Images/LogoGradient.svg" />
                            </div>
                            &nbsp;
                            <div className="logo-text">
                                Olimp
                            </div>
                        </Link>
                        &emsp;
                        <Button variant="secondary">
                            {LocalizeService.localize('Toolbar_Catalog')}
                        </Button>
                        &emsp;
                        <Button variant="secondary">
                            {LocalizeService.localize('Toolbar_Education')}
                        </Button>
                    </Col>
                    <Col md={4}>
                        <div className="d-grid gap-2">
                            <Button variant="secondary">Search</Button>
                        </div>
                    </Col>
                    <Col md={3} className="d-flex justify-content-start">
                        <Button className="circle-border-radius toolbar-item ms-2" variant="secondary">
                            <i className="fas fa-phone"></i>
                        </Button>

                        <Button className="circle-border-radius toolbar-item ms-2" variant="secondary" onClick={onUserIconClick}>
                            <i className="fas fa-user"></i>
                        </Button>

                        <Button className="circle-border-radius toolbar-item ms-2" variant="secondary">
                            <i className="fas fa-shopping-cart"></i>
                        </Button>
                    </Col>
                    <Col md={1} className="d-flex justify-content-center">
                        <Button className="circle-border-radius toolbar-item hide-toolbar-button" variant="secondary">
                            {isToolbarShow ? <i className="fas fa-eye-slash"></i> : <i className="fas fa-eye"></i>}
                        </Button>
                    </Col>
                </Row>
            </Container>
        </div>
    );
}

export default Toolbar;