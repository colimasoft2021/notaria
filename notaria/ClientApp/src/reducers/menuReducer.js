import { OPEN, CLOSE } from "../types";

const initialState = true;

export default function menuReducer(state = initialState, action) {
    switch (action.type) {
        case OPEN:
            return (state = true);
        case CLOSE:
            return (state = false);
        default:
            return state;
    }
}
