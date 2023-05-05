import { AppBar, Menu, MenuItem, Toolbar, Typography } from "@mui/material";
import IconButton from "@mui/material/IconButton";
import AccountCircleIcon from "@mui/icons-material/AccountCircle";
import LightModeOutlinedIcon from "@mui/icons-material/LightModeOutlined";
import DarkModeOutlinedIcon from "@mui/icons-material/DarkModeOutlined";
import React from "react";
import { useAppDispatch, useAppSelector } from "redux/hooks";
import { selectMode, toggleMode } from "redux/globalSlice";

const Header: React.FC = () => {
  const dispatch = useAppDispatch();
  const mode = useAppSelector(selectMode);
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);

  const handleMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <AppBar
      component="header"
      position="static"
      elevation={0}
      sx={{
        bgcolor: "background.alt",
        color: "text.primary"
      }}
    >
      <Toolbar>
        <Typography
          variant="h5"
          noWrap
          sx={{
            fontFamily: "monospace",
            fontWeight: 700,
            letterSpacing: ".3rem",
            color: "inherit",
            textDecoration: "none",
            flexGrow: 1
          }}
        >
          Psysup
        </Typography>

        <IconButton onClick={() => dispatch(toggleMode())}>
          {mode === "dark" ? (
            <DarkModeOutlinedIcon sx={{ color: "text.primary" }} />
          ) : (
            <LightModeOutlinedIcon sx={{ color: "text.primary" }} />
          )}
        </IconButton>

        <IconButton
          size="large"
          aria-label="account of current user"
          aria-controls="menu-appbar"
          aria-haspopup="true"
          onClick={handleMenu}
          color="inherit"
        >
          <AccountCircleIcon />
        </IconButton>
        <Menu
          id="menu-appbar"
          anchorEl={anchorEl}
          keepMounted
          open={Boolean(anchorEl)}
          onClose={handleClose}
        >
          <MenuItem onClick={handleClose}>Profile</MenuItem>
          <MenuItem onClick={handleClose}>Logout</MenuItem>
        </Menu>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
