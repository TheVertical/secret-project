export enum ToastType {
    Info = 'info',
    Warning = 'warning',
    Error = 'error',
};

interface ToastItem {
    Id: number
    Title: string,
    Message: string,
    Type: ToastType
};

export default ToastItem;