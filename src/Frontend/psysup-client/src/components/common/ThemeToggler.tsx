import { IconButton } from "@mui/material";
import LightModeOutlinedIcon from "@mui/icons-material/LightModeOutlined";
import DarkModeOutlinedIcon from "@mui/icons-material/DarkModeOutlined";
import React from "react";
import { selectMode, toggleMode } from "redux/globalSlice";
import { useAppDispatch, useAppSelector } from "redux/hooks";

const ThemeToggler: React.FC = () => {
  const dispatch = useAppDispatch();
  const mode = useAppSelector(selectMode);

  return (
    <IconButton onClick={() => dispatch(toggleMode())}>
      {mode === "dark" ? (
        <DarkModeOutlinedIcon sx={{ color: "text.primary" }} />
      ) : (
        <LightModeOutlinedIcon sx={{ color: "text.primary" }} />
      )}
    </IconButton>
  );
};

export default ThemeToggler;
