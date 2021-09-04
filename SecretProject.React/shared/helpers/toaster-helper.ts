import { VisualConstants } from "@/apps/main/constants";
import { addToastItem } from "@/apps/main/store/reducers/toaster-reducer";
import { store } from "@/apps/main/store/store";
import ToastItem, { ToastType } from "@/models/toast-item";

const ToasterHelper = {
    addErrorToasts: function (errors: string[]): void {
        errors.map(errorMessage => {
            const toastItem: ToastItem = {
                Id: Math.floor(Math.random() * 1000),
                Title: VisualConstants.TOAST_ITEM,
                Message: errorMessage,
                Type: ToastType.Error
            };
    
            store.dispatch(addToastItem(toastItem));
        });
    },
    addWarningToasts: function (warnings: string[]): void {
        warnings.map(warningMessage => {
            const toastItem: ToastItem = {
                Id: Math.floor(Math.random() * 1000),
                Title: VisualConstants.TOAST_ITEM,
                Message: warningMessage,
                Type: ToastType.Error
            };
    
            store.dispatch(addToastItem(toastItem));
        });
    },
    addInfoToasts: function (messages: string[]): void {
        messages.map(message => {
            const toastItem: ToastItem = {
                Id: Math.floor(Math.random() * 1000),
                Title: VisualConstants.TOAST_ITEM,
                Message: message,
                Type: ToastType.Error
            };
    
            store.dispatch(addToastItem(toastItem));
        });
    },
}

export default ToasterHelper;