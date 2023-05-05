import { PaletteMode } from "@mui/material";
import { createSlice } from "@reduxjs/toolkit";
import { RootState } from "./store";

const mode = localStorage.getItem("mode") as PaletteMode;

interface GlobalSliceState {
  mode: PaletteMode;
}

const initialState: GlobalSliceState = {
  mode: mode || "dark"
};

const globalSlice = createSlice({
  name: "global",
  initialState,
  reducers: {
    toggleMode: (state) => {
      state.mode = state.mode === "light" ? "dark" : "light";
      localStorage.setItem("mode", state.mode);
    }
  }
});

export const selectMode = (state: RootState) => state.global.mode;
export const { toggleMode } = globalSlice.actions;
export default globalSlice.reducer;
