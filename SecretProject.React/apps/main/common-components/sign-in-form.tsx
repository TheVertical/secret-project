import AuthentificationAccountViewModel from '@/models/Account/authentification-account-view-model';
import LocalizeService from '@/shared/localization-service';
import { Formik } from 'formik';
import React from 'react';
import { Form, Button } from 'react-bootstrap';
import AuthentificationValidationSchema from '../validation-rules/authentification-rules';

interface InAuthorizationProps {
    id: string,
    showRegistrationForm: () => void,
    sendSignIn: (data: AuthentificationAccountViewModel) => void
}

const SignInForm: React.FC<InAuthorizationProps> = (props) => {
    const { id, showRegistrationForm, sendSignIn } = props;

    const initialData: AuthentificationAccountViewModel = {
        Email: '',
        Password: ''
    };

    return (
        <Formik
            validationSchema={AuthentificationValidationSchema}
            validateOnBlur={true}
            validateOnChange={false}
            validateOnMount={false}
            onSubmit={(data) => sendSignIn(data)}
            initialValues={initialData}>
            {({
                handleSubmit,
                handleChange,
                values,
                errors,
            }) => (
                <Form id={id} className="mb-0" noValidate onSubmit={handleSubmit}>
                    <Form.Group className="mb-2 " controlId="formEmail">
                        <Form.Label>{LocalizeService.localize("Email")}</Form.Label>
                        <Form.Control
                            type="email"
                            name={"Email"}
                            value={values.Email}
                            onChange={handleChange}
                            isInvalid={!!errors.Email}
                            placeholder={LocalizeService.localize("Email_Enter")}
                            autoComplete="nickname" />

                    </Form.Group>
                    <Form.Group className="mb-3" controlId="formPassword">
                        <Form.Label>{LocalizeService.localize("Password")}</Form.Label>
                        <Form.Control
                            type="password"
                            name={"Password"}
                            value={values.Password}
                            onChange={handleChange}
                            isInvalid={!!errors.Password}
                            placeholder={LocalizeService.localize("Password_Enter")}
                            autoComplete="current-password" />
                    </Form.Group>
                    <Form.Group className="mb-0" controlId="formRememberAccount">
                        <Form.Check
                            className="mb-0"
                            type="checkbox"
                            label={LocalizeService.localize("Authorization_RememberAccount")}>
                        </Form.Check>
                    </Form.Group>
                    <Form.Group className="mb-0 d-flex justify-content-center">
                        <Button
                            type="submit"
                            variant="outline-primary"
                            size="sm"
                            onClick={showRegistrationForm}>
                            {LocalizeService.localize("Authorization_CreateAccount")}
                        </Button>
                    </Form.Group>
                </Form>
            )}
        </Formik>
    );
};

export default SignInForm;