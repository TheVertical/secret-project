import RegistrationAccountViewModel from "@/models/Account/registration-account-view-model";
import RequestManager, { HttpMethod } from "@/shared/request-manager";
import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import ActionUrls from "../../constants";

export interface AuthorizationReducersState {
    IsAuthorize: boolean
}

const initialState: AuthorizationReducersState = {
    IsAuthorize: false
};

const authorizationSlice = createSlice({
    name: 'authorization-reducer',
    initialState,
    reducers: {
        registerNewAccount: (state, action: PayloadAction<boolean>) => {
            state.IsAuthorize = action.payload;
            return state;
        },
        sendSignIn: (state, action: PayloadAction<boolean>) => {
            state.IsAuthorize = action.payload;
            return state;
        }
    }
});

export const { registerNewAccount, sendSignIn } = authorizationSlice.actions;

export default authorizationSlice.reducer;
