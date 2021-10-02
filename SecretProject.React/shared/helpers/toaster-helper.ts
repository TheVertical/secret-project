import { VisualConstants } from "@/apps/main/constants";
import { addToastItem } from "@/apps/main/store/reducers/toaster-reducer";
import { store } from "@/apps/main/store/store";
import ToastItem, { ToastType } from "@/models/toast-item";

const ToasterHelper = {
    addToast(message: string, title: string, toastType: ToastType) {
        const toastItem: ToastItem = {
            Id: Math.floor(Math.random() * 1000),
            Title: VisualConstants.title,
            Message: message,
            Type: toastType
        };

        store.dispatch(addToastItem(toastItem));
    },
    addErrorToasts: function (error: string, title: string): void {
        addToast(error, title, ToastType.Error)
    },
    addWarningToasts: function (warning: string, title: string): void {
        addToast(warning, error, title, ToastType.Error)
    },
    addInfoToasts: function (message: string, title: string): void {
        addToast(error, title)
    },
}

export default ToasterHelper;