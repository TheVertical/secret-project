import ToastItem from "@/models/toast-item";
import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export interface ToasterReducersState {
    ToastItems: ToastItem[]
}

const initialState: ToasterReducersState = {
    ToastItems: []
};

const toasterSlice = createSlice({
    name: 'toaster-reducer',
    initialState,
    reducers: {
        addToastItem: (state, action: PayloadAction<ToastItem>) => {
            const toastItems = state.ToastItems.slice();
            toastItems.push(action.payload);

            return {...state, ToastItems: toastItems};
        },
        deleteToastItem: (state, action: PayloadAction<ToastItem>) => {
            const toastItems = state.ToastItems.slice();
            const index = toastItems.indexOf(action.payload, 1);
            toastItems.splice(index, 1);

            return {...state, ToastItems: toastItems};
        }
    }
});


export const { addToastItem, deleteToastItem } = toasterSlice.actions;

export default toasterSlice.reducer;
