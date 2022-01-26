import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { votingSliceReducer } from "./votingSlice";

const reducer = combineReducers({
    votingSliceReducer
})

export const store = configureStore({
    reducer
})