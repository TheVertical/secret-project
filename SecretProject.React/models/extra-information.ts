export enum ExtraInformationType {
    Info,
    Warning,
    Error
}

export default interface ExtraInformation {
    Title: string,
    Message: string,
    Data: any,
    Type: ExtraInformationType
}