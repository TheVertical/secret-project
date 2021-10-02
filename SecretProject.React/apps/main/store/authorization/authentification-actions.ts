import MAIN_URLS from "@/constants/main-urls";
import AuthentificationAccountViewModel from "@/models/Account/authentification-account-view-model";
import RegistrationAccountViewModel, { RegistrationAccountModal } from "@/models/Account/registration-account-view-model";
import RequestManager, { HttpMethod } from "@/shared/request-manager";
import { AnyAction } from "redux";
import { ThunkDispatch } from "redux-thunk"
import { AuthorizationReducersState } from "./authorization-reducer";

export default function registerNewAccount(registrationAccountViewModel: RegistrationAccountViewModel) {
    return async (dispatch: ThunkDispatch<AuthorizationReducersState, undefined, AnyAction>) => {
        const model: RegistrationAccountModal = {
            FirstName: registrationAccountViewModel.FirstName,
            LastName: registrationAccountViewModel.LastName,
            Email: registrationAccountViewModel.Email,
            Password: registrationAccountViewModel.Password
        };

        const isAuthorized: boolean | undefined | null = await RequestManager.sendRequest(HttpMethod.Post, MAIN_URLS.REGISTER_NEW_ACCOUNT, undefined, model);
        dispatch({ type: "authorization/registerNewAccount", payload: !!isAuthorized });
        dispatch({type: "layout-modals/toggleAuthorizationModal"});
    }
};

export function sendSignIn(authentificationAccountViewModel: AuthentificationAccountViewModel) {
    return async (dispatch: ThunkDispatch<AuthorizationReducersState, undefined, AnyAction>) => {
        const isAuthorized: boolean | undefined | null = await RequestManager.sendRequest(HttpMethod.Post, MAIN_URLS.SINGIN, undefined, authentificationAccountViewModel);
        dispatch({ type: "authorization/sendSignIn", payload: !!isAuthorized });
        dispatch({type: "layout-modals/toggleAuthorizationModal"});
    }
}