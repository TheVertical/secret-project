import { AnyAction, applyMiddleware, Dispatch, Middleware } from "@reduxjs/toolkit"
import { ThunkMiddleware } from "redux-thunk"
import { AuthorizationReducersState } from "./authorization/authorization-reducer"

const RequestManagerMiddleware: ThunkMiddleware<AuthorizationReducersState, AnyAction> = storeAPI => next => action => {
    // If the "action" is actually a function instead...
    if (typeof action === 'function') {
        // then call the function and pass `dispatch` and `getState` as arguments
        return action(storeAPI.dispatch, storeAPI.getState)
    }

    return next(action)
}

export default RequestManagerMiddleware;

export const RequestManagerMiddlewareEnhancer = applyMiddleware(RequestManagerMiddleware);