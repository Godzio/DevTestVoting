import { createSlice } from "@reduxjs/toolkit";


export const votingSlice = createSlice({
    name: 'voting',
    initialState: {
        voters: [],
        candidates: []
    },
    reducers: {
        setAll: (state, action) => {
            state.voters = action.payload.voters;
            state.candidates = action.payload.candidates;
        },
        setCandidates: (state, action) => {
            state.candidates = action.payload;
        },
        setVoters: (state, action) => {
            state.voters = action.payload;
        },
    }
})

export const votingSliceReducer = votingSlice.reducer;

export const voters = state => state.votingSliceReducer.voters;

export const candidates = state => state.votingSliceReducer.candidates;

export const { setAll, setCandidates, setVoters } = votingSlice.actions;