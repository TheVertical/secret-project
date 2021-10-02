import { ToastType } from "./toast-item";

export default interface ExtraInformation {
    Title: string,
    Message: string,
    Data: any,
    Type: ToastType
}