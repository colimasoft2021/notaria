import { combineReducers } from "redux";
import menuReducer from "./menuReducer";

const reducer = combineReducers({
    stateMenu: menuReducer,
});

export default reducer;
