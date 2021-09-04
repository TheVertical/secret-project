import RegistrationAccountViewModel from '@/models/registration-account-view-model';
import LocalizeService from '@/shared/localization-service';
import { Formik } from 'formik';
import React from 'react';
import { Button, Form } from 'react-bootstrap';
import RegistrationValidationSchema from '../validation-rules/authorization-modal-rules';

interface RegistrationFormProps {
    
}
const RegistrationForm: React.FC<RegistrationFormProps> = (props) => {

    const initialRegistrationFromValues: RegistrationAccountViewModel = {
        FirstName: '',
        LastName: '',
        Email: '',
        Password: '',
    }
    
    return(
        <Formik
                validationSchema={RegistrationValidationSchema}
                validateOnBlur={true}
                validateOnChange={false}
                onSubmit={console.log}
                initialValues={initialRegistrationFromValues}>
                {({
                    handleSubmit,
                    handleChange,
                    handleBlur,
                    values,
                    errors,
                }) => (
                    <>
                        <Form id="registration-form" className="mb-0" noValidate onSubmit={handleSubmit}>
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
                                    value={values.ConfirmPersonalDataAgreement}
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    isInvalid={!!errors.ConfirmPersonalDataAgreement}
                                    label={LocalizeService.localize("Authorization_Registration_PersonalDataAgreement")}>
                                </Form.Check>
                            </Form.Group>
                        </Form>
                        <div className="d-flex justify-content-end">
                            <Button type="submit" form="registration-form" variant="primary">
                                {LocalizeService.localize("Authorization_Registration_Create")}
                            </Button>
                        </div>
                    </>
                )}
            </Formik>
    );
}

export default RegistrationForm;