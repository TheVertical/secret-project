import LocalizeService from '@/shared/localization-service';
import React from 'react';
import { useState } from 'react';
import { Button, Col, Modal, Row } from 'react-bootstrap';
import RegistrationAccountViewModel from '@/models/Account/registration-account-view-model';
import RegistrationForm from './registration-form';
import SignInForm from './sign-in-form';
import AuthentificationAccountViewModel from '@/models/Account/authentification-account-view-model';

interface AuthorizationModalProps {
    closeModal: () => void
    sendRegistration: (registrationAccountViewModel: RegistrationAccountViewModel) => void
    sendSignIn: (authentificationAccountViewModel: AuthentificationAccountViewModel) => void
}

interface AuthorizationModalState {
    IsShowCreateAccountModalContent: boolean,
    Email: string,
    Password: string,
    ConfirmationPassword: string,
}

const AuthorizationModal: React.FC<AuthorizationModalProps> = function (props) {
    const {
        closeModal,
        sendRegistration,
        sendSignIn
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


    return (
        <Modal show={true} onHide={closeModal}>
            <Modal.Header className="p-2">
                {!modalState.IsShowCreateAccountModalContent ?
                    <>
                        <Modal.Title>{LocalizeService.localize("Authorization_In")}</Modal.Title>
                        <Button variant="secondary" onClick={closeModal}>
                            <i className="fas fa-times"></i>
                        </Button>
                    </>
                    :
                    <>
                        <Modal.Title>{LocalizeService.localize("Authorization_Registration_Title")}</Modal.Title>
                        <Button variant="secondary" onClick={hideCreateAccount}>
                            <i className="fas fa-arrow-left"></i>
                        </Button>
                    </>
                }
            </Modal.Header>
            <Modal.Body className="p-3 pb-1">
                {!modalState.IsShowCreateAccountModalContent ?
                    <SignInForm id="signIn-form" showRegistrationForm={showCreateAccount} sendSignIn={sendSignIn}/>
                    :
                    <RegistrationForm id="registration-form" sendRegistration={sendRegistration}/>
                }
            </Modal.Body>
            <Modal.Footer className="p-2 d-block">
                <Row className="justify-content-end">
                    <Col md={4}>
                        {/* <Button className="w-100" type="submit" form={!modalState.IsShowCreateAccountModalContent ? "signIn-form" : "registration-form"} variant="primary">
                            {!modalState.IsShowCreateAccountModalContent ?
                                LocalizeService.localize("Authorization_In")
                                :
                                LocalizeService.localize("Authorization_Registration_Create")
                            }
                        </Button> */}
                        {!modalState.IsShowCreateAccountModalContent ?
                                <Button className="w-100" type="submit" form="signIn-form" variant="primary">{LocalizeService.localize("Authorization_In")}</Button>
                                :
                                <Button className="w-100" type="submit" form="registration-form" variant="primary">{LocalizeService.localize("Authorization_Registration_Create")}</Button>
                            }
                    </Col>
                </Row>
            </Modal.Footer>
        </Modal>
    );
}

export default AuthorizationModal;
