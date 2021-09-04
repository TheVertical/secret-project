import LocalizeService from '@/shared/localization-service';
import React from 'react';
import { useState } from 'react';
import { Button, Col, Form, Modal, Row } from 'react-bootstrap';
import { Formik } from 'formik';
import RegistrationValidationSchema from '../validation-rules/authorization-modal-rules';
import RegistrationAccountViewModel from '@/models/registration-account-view-model';
import RegistrationForm from './registration-form';

interface AuthorizationModalProps {
    closeModal: () => void
    sendRegistration: (registrationAccountViewModel: RegistrationAccountViewModel) => void
}

interface AuthorizationModalState {
    IsShowCreateAccountModalContent: boolean,
    Email: string,
    Password: string,
    ConfirmationPassword: string,
}

const AuthorizationModal: React.FC<AuthorizationModalProps> = function (props) {
    const {
        closeModal
    } = props;

    const [modalState, setModalState] = useState<AuthorizationModalState>({ IsShowCreateAccountModalContent: false, Email: "", Password: "", ConfirmationPassword: "" });

    // #region event handlers
    const showCreateAccount = function (): void {
        setModalState({ ...modalState, IsShowCreateAccountModalContent: true });
    }

    const hideCreateAccount = function (): void {
        setModalState({ ...modalState, IsShowCreateAccountModalContent: false })
    }
    // #endregion

    const renderInModalBody = function (): React.ReactFragment {
        return (
            <>
                <Modal.Header>
                    <Modal.Title>{LocalizeService.localize("Authorization_In")}</Modal.Title>
                    {/* //Insert directly because of styles */}
                    <Button variant="secondary" onClick={closeModal}>
                        <i className="fas fa-times"></i>
                    </Button>
                </Modal.Header>
                <Modal.Body className="p-2">
                    <Form className="mb-0">
                        <Form.Group className="mb-2 " controlId="formBasicEmail">
                            <Form.Label>{LocalizeService.localize("Email")}</Form.Label>
                            <Form.Control
                                type="email"
                                placeholder={LocalizeService.localize("Email_Enter")}
                                autoComplete="nickname" />

                        </Form.Group>
                        <Form.Group className="mb-1" controlId="formBasicPassword">
                            <Form.Label>{LocalizeService.localize("Password")}</Form.Label>
                            <Form.Control
                                type="password"
                                placeholder={LocalizeService.localize("Password_Enter")}
                                autoComplete="current-password" />
                        </Form.Group>
                        <Form.Group className="mb-2">
                            <Row>
                                <Col className="d-flex justify-content-center" onClick={() => showCreateAccount()}>
                                    <Button
                                        variant="outline-primary"
                                        size="sm"
                                    >
                                        {LocalizeService.localize("Authorization_CreateAccount")}
                                    </Button>
                                </Col>
                            </Row>
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer className="d-inline">
                    <Row>
                        <Col md="8" className="d-flex align-items-center justify-content-center">
                            <Form.Check
                                type="checkbox"
                                label={LocalizeService.localize("Authorization_RememberAccount")}>
                            </Form.Check>

                        </Col>
                        <Col md="4" className="d-grid gap-2">
                            <Button variant="primary">
                                {LocalizeService.localize("Authorization_In")}
                            </Button>
                        </Col>
                    </Row>
                </Modal.Footer>
            </>
        );
    };

    const initialRegistrationFromValues: RegistrationAccountViewModel = {
        FirstName: '',
        LastName: '',
        Email: '',
        Password: '',
    }

    const renderRegistratinModalContent = function (): React.ReactFragment {
        return (
                <>
                    <Modal.Header closeButton={false}>
                        <Modal.Title>{LocalizeService.localize("Authorization_Registration_Title")}</Modal.Title>

                        <Button variant="secondary" onClick={hideCreateAccount}>
                            <i className="fas fa-arrow-left"></i>
                        </Button>
                    </Modal.Header>
                    <Modal.Body className="p-2">
                        <RegistrationForm />
                    </Modal.Body>
                </>
        );
    }

    return (
        <Modal show={true} onHide={closeModal}>
            {!modalState.IsShowCreateAccountModalContent ?
                renderInModalBody()
                :
                renderRegistratinModalContent()}
        </Modal>
    );
}

export default AuthorizationModal;
