import LocalizeService from '@/shared/localization-service';
import React from 'react';
import { Button, Form, InputGroup, Modal } from 'react-bootstrap';
import ModalHeader from 'react-bootstrap/ModalHeader'

interface AuthorizationModalState {
    closeModal: () => void
}

const AuthorizationModal: React.FC<AuthorizationModalState> = (props) => {
    const {
        closeModal
    } = props;

    return (
        <Modal show={true} onHide={closeModal}> 
            <Modal.Header>
                <Modal.Title>{LocalizeService.localize('Authorization_In')}</Modal.Title>
                {/* //Insert directly because of styles */}
                <button onClick={closeModal} type="button" className="btn-close" aria-label="Close"></button>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label>{LocalizeService.localize('Email')}</Form.Label>
                        <Form.Control type="email" placeholder="Enter email" autoComplete="nickname"/>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formBasicPassword">
                        <Form.Label>{LocalizeService.localize("Authorization_Password")}</Form.Label>
                        <Form.Control type="password" placeholder="Password" autoComplete="current-password"/>
                    </Form.Group>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <InputGroup className="mb-3">
                    <InputGroup.Checkbox />
                    <InputGroup.Text>{LocalizeService.localize('Authorization_RememberAcount')}</InputGroup.Text>
                </InputGroup>
                <Button variant="primary">
                    {LocalizeService.localize('Authorization_In')}
                </Button>
            </Modal.Footer>
        </Modal>
    );
}

export default AuthorizationModal;