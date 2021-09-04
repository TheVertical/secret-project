import RegistrationAccountViewModel from "@/models/registration-account-view-model";
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
        registerNewAccount: (state, action: PayloadAction<RegistrationAccountViewModel>) => {
            var result = RequestManager.sendRequest(HttpMethod.Post, ActionUrls.REGISTER_NEW_ACCOUNT, undefined, action.payload);
        }
    }
});


export const { registerNewAccount } = authorizationSlice.actions

export default authorizationSlice.reducer;
