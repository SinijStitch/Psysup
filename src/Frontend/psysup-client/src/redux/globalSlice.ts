import { PaletteMode } from "@mui/material";
import { createSlice } from "@reduxjs/toolkit";
import { RootState } from "./store";
import { v4 as uuidv4 } from "uuid";
import { profileApiSlice } from "./api/profileApiSlice";

const mode = localStorage.getItem("mode") as PaletteMode;

interface GlobalSliceState {
  mode: PaletteMode;
  imageUniqeId: string;
}

const initialState: GlobalSliceState = {
  mode: mode || "dark",
  imageUniqeId: uuidv4()
};

const globalSlice = createSlice({
  name: "global",
  initialState,
  reducers: {
    toggleMode: (state) => {
      state.mode = state.mode === "light" ? "dark" : "light";
      localStorage.setItem("mode", state.mode);
    }
  },
  extraReducers: (builder) =>
    builder.addMatcher(
      profileApiSlice.endpoints.updateProfile.matchFulfilled,
      (state) => {
        state.imageUniqeId = uuidv4();
      }
    )
});

export const selectImageUniqeId = (state: RootState) =>
  state.global.imageUniqeId;
export const selectMode = (state: RootState) => state.global.mode;
export const { toggleMode } = globalSlice.actions;
export default globalSlice.reducer;
