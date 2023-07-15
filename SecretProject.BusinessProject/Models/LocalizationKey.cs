namespace SecretProject.BusinessProject.Models
{
    public enum LocalizationKey
    {
        InStock,
        Not_InStock,
        Email,
        Email_Enter,
        Password,
        Password_Enter,
        Password_Confirm,
        FirstName,
        FirstName_Enter,
        LastName,
        LastName_Enter,
        Success,
        Error,
        
        Validation_Required,
        Validation_Required_EmailTemplate,
        Validation_Required_Min,
        Validation_Required_Max,

        Authorization_In,
        Authorization_Out,
        Authorization_ForgotPassword,
        Authorization_PasswordConfirm,
        Authorization_CreateAccount,
        Authorization_RememberAccount,
        Authorization_UserExists,
        Authorization_AccountWasCreatedSuccessfully,

        Authentification_AccountIsNotFound,
        Authentification_EmailOrPasswordIsWrong,

        Authorization_CreateAccount_Result_Success,

        Authorization_Registration_Title,
        Authorization_Registration_PersonalDataAgreement,
        Authorization_Registration_Create,
        RegistrationValidationSchema_ConfirmPersonalDataAgreement_Error,

        RegistrationValidationSchema_ConfirmationPassword_Error,

        Header_DeliveryAndPayment,
        Header_Return,
        Header_PickUPoint,
        Header_News,
        Header_PromotionsAndDiscounts,
        Header_Reviews,

        Toolbar_Catalog,
        Toolbar_Education,

        ContactForm_RequestCallBack,

        ProductCard_Buy,
        ProductCard_Description
    }
}