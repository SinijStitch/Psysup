import { PaletteMode, ThemeOptions } from "@mui/material";

declare module "@mui/material/styles/createPalette" {
  interface TypeBackground {
    alt?: string;
  }
}

export const themeSettings = (mode: PaletteMode): ThemeOptions => {
  return {
    palette: {
      mode,
      ...(mode === "dark"
        ? {
            background: {
              default: "#212125",
              alt: "#1B1C21"
            }
          }
        : {
            background: {
              default: "#fafafa",
              alt: "#FFF"
            }
          })
    }
  };
};
