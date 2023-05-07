import { PaletteMode, ThemeOptions } from "@mui/material";

export const themeSettings = (mode: PaletteMode): ThemeOptions => {
  return {
    palette: {
      mode,
    }
  };
};
