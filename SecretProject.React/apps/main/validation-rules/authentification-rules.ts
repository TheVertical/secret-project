// @ts-nocheck
import * as yup from 'yup';

const AuthentificationValidationSchema = yup.object().shape({
    Email: yup.string()
        .email()
        .required(),
    Password: yup.string()
        .min(6)
        .max(20)
        .required(),
});

export default AuthentificationValidationSchema;
