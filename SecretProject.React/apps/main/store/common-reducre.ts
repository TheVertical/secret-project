import { combineReducers } from "redux";
import layoutModalsReducer from "./layout-modals-reducer";

const rootReducer = combineReducers({
    layoutModals: layoutModalsReducer,
});

export default rootReducer;