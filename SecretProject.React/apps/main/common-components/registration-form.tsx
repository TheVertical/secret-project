import RegistrationAccountViewModel from '@/models/Account/registration-account-view-model';
import LocalizeService from '@/shared/localization-service';
import { Formik } from 'formik';
import React from 'react';
import { Form } from 'react-bootstrap';
import RegistrationValidationSchema from '../validation-rules/authorization-modal-rules';

interface RegistrationFormProps {
    id: string,
    sendRegistration: (registrationAccountViewModel: RegistrationAccountViewModel) => void
}
const RegistrationForm: React.FC<RegistrationFormProps> = (props) => {

    const { id, sendRegistration } = props;

    const initialData: RegistrationAccountViewModel = {
        FirstName: '',
        LastName: '',
        Email: '',
        Password: '',
        ConfirmationPassword: '',
        ConfirmPersonalDataAgreement: false
    }

    return (
        <Formik
            validationSchema={RegistrationValidationSchema}
            validateOnBlur={false}
            validateOnChange={false}
            onSubmit={(data) => sendRegistration(data)}
            initialValues={initialData}>
            {({
                handleSubmit,
                handleChange,
                handleBlur,
                values,
                errors,
            }) => (
                <Form id={id} className="mb-0" noValidate onSubmit={handleSubmit} autoComplete="off">
                    <Form.Group className="mb-2" controlId="registrationModalContentFirstName">
                        <Form.Label>{LocalizeService.localize("FirstName")}</Form.Label>
                        <Form.Control
                            type="string"
                            name={"FirstName"}
                            value={values.FirstName}
                            onChange={handleChange}
                            onBlur={handleBlur}
                            isInvalid={!!errors.FirstName}
                            placeholder={LocalizeService.localize("FirstName_Enter")} />
                    </Form.Group>
                    <Form.Group className="mb-2" controlId="registrationModalContentFirstName">
                        <Form.Label>{LocalizeService.localize("LastName")}</Form.Label>
                        <Form.Control
                            type="string"
                            name={"LastName"}
                            value={values.LastName}
                            onChange={handleChange}
                            isInvalid={!!errors.LastName}
                            placeholder={LocalizeService.localize("LastName_Enter")} />
                    </Form.Group>
                    <Form.Group className="mb-2" controlId="registrationModalContentEmail">
                        <Form.Label>{LocalizeService.localize("Email")}</Form.Label>
                        <Form.Control
                            type="string"
                            name={"Email"}
                            value={values.Email}
                            onChange={handleChange}
                            isInvalid={!!errors.Email}
                            placeholder={LocalizeService.localize("Email_Enter")} />
                    </Form.Group>
                    <Form.Group className="mb-2" controlId="registrationModalContentPassword">
                        <Form.Label>{LocalizeService.localize("Password")}</Form.Label>
                        <Form.Control
                            type="password"
                            name={"Password"}
                            value={values.Password}
                            autoComplete="new-password"
                            onChange={handleChange}
                            isInvalid={!!errors.Password}
                            placeholder={LocalizeService.localize("Password_Enter")} />
                    </Form.Group>
                    <Form.Group className="mb-3" controlId="registrationModalContentConfirmationPassword">
                        <Form.Label>{LocalizeService.localize("Password_Confirm")}</Form.Label>
                        <Form.Control
                            type="password"
                            name={"ConfirmationPassword"}
                            value={values.ConfirmationPassword}
                            onChange={handleChange}
                            isInvalid={!!errors.ConfirmationPassword}
                            placeholder={LocalizeService.localize("Password_Confirm")} />
                    </Form.Group>
                    <Form.Group className="mb-1" controlId="registrationModalContentConfirmationPersonalDataAgrement">
                        <Form.Check
                            type="checkbox"
                            name={"ConfirmPersonalDataAgreement"}
                            onChange={handleChange}
                            onBlur={handleBlur}
                            isInvalid={!!errors.ConfirmPersonalDataAgreement}
                            label={LocalizeService.localize("Authorization_Registration_PersonalDataAgreement")}>
                        </Form.Check>
                    </Form.Group>
                </Form>
            )}
        </Formik>
    );
}

export default RegistrationForm;