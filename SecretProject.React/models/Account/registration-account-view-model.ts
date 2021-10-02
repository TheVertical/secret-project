export default interface RegistrationAccountViewModel {
    FirstName: string,
    LastName: string,
    Email: string,
    Password: string
    ConfirmationPassword: string
    ConfirmPersonalDataAgreement: boolean
}

export interface RegistrationAccountModal {
    FirstName: string,
    LastName: string,
    Email: string,
    Password: string
}