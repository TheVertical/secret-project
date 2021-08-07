import LocalizeService from '@/shared/localization-service';
import { trackForMutations } from '@reduxjs/toolkit/dist/immutableStateInvariantMiddleware';
import React from 'react';
import { Button, Col, Container, Row } from 'react-bootstrap';
import { useDispatch } from 'react-redux';
import { toggleAuthorizationModal } from '../store/layout-modals-reducer';

interface ToolbarViewModel {

}
const Toolbar: React.FC<ToolbarViewModel> = () => {

    const dispatch = useDispatch();

    const onUserIconClick = () => dispatch(toggleAuthorizationModal());

    const isToolbarShow = true;
    return(
        <div className="toolbar-container p-2">
            <Container fluid>
                <Row>
                    <Col md={4} className="d-flex justify-content-end">
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
                        <Button className="toolbar-item" variant="secondary" onClick={onUserIconClick}>
                            <i className="fas fa-user"></i>
                        </Button>
                        &emsp;
                        <Button className="toolbar-item" variant="secondary">
                            <i className="fas fa-shopping-cart"></i>
                        </Button>
                    </Col>
                    <Col md={1} className="d-flex justify-content-center">
                        <Button className="toolbar-item hide-toolbar-button" variant="secondary">
                            {isToolbarShow ? <i className="fas fa-eye-slash"></i> : <i className="fas fa-eye"></i>}
                        </Button>
                    </Col>
                </Row>
            </Container>
        </div>
    );
}

export default Toolbar;