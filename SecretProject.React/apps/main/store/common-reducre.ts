import { combineReducers } from "redux";
import layoutModalsReducer from "./reducers/layout-modals-reducer";
import toasterReducer from "./reducers/toaster-reducer";

const rootReducer = combineReducers({
    layoutModals: layoutModalsReducer,
    toaster: toasterReducer
});

export default rootReducer;