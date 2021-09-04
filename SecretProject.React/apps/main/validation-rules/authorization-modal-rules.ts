// @ts-nocheck
import LocalizeService from '@/shared/localization-service';
import * as yup from 'yup';
import { setLocale } from 'yup';

setLocale({
    mixed: {
        required: "Validation_Required"
    },
    string: {
        min: (min) => ({ key: "Validation_Required_Min", values: { min } }),
        max: (min) => ({ key: "Validation_Required_Max", values: { min } }),
        email: "Validation_Required_EmailTemplate"
    }
});

const RegistrationValidationSchema = yup.object().shape({
    FirstName: yup.string()
        .min(2)
        .max(20)
        .required(),
    LastName: yup.string()
        .min(2)
        .max(20),
    Email: yup.string()
        .email()
        .required(),
    Password: yup.string()
        .min(6)
        .max(20)
        .required(),
    ConfirmationPassword: yup.string()
        .required()
        .oneOf([yup.ref('Password'), null], LocalizeService.localize("RegistrationValidationSchema_ConfirmationPassword_Error")),
    ConfirmPersonalDataAgreement: yup.boolean()
        .required()
        .oneOf([true])
});

export default RegistrationValidationSchema;
