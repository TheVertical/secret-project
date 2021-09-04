import { createSlice } from "@reduxjs/toolkit";

export interface LayoutModalsState {
    authorizationModal: boolean;
}

const initialState: LayoutModalsState = {
    authorizationModal: false
};

const layoutModalsSlice = createSlice({
    name: 'layout-modals',
    initialState,
    reducers: {
        toggleAuthorizationModal: state => {
            state.authorizationModal = !state.authorizationModal;
            return state;
        }
    }
});


export const { toggleAuthorizationModal } = layoutModalsSlice.actions

export default layoutModalsSlice.reducer;
