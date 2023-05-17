import {
  AppBar,
  Button,
  Menu,
  MenuItem,
  Toolbar,
  Typography
} from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";
import { useLogoutMutation } from "redux/api/authApiSlice";
import TopBarProgress from "react-topbar-progress-indicator";
import { useGetProfileQuery } from "redux/api/profileApiSlice";
import { ERoute } from "enums/ERoute";
import ThemeToggler from "./ThemeToggler";
import UserAvatar from "components/profile/UserAvatar";

const Header: React.FC = () => {
  const navigate = useNavigate();
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const [logout, { isLoading }] = useLogoutMutation();
  const { data } = useGetProfileQuery();

  const handleMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  if (isLoading) {
    return <TopBarProgress />;
  }

  return (
    <AppBar
      component="header"
      position="static"
      elevation={0}
      color="transparent"
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
            flexGrow: 1,
            cursor: "pointer"
          }}
          onClick={() => navigate(ERoute.APPLICATIONS)}
        >
          Psysup
        </Typography>

        <ThemeToggler />

        <Button size="small" onClick={handleMenu} color="inherit">
          <UserAvatar />
        </Button>
        <Menu
          id="menu-appbar"
          anchorEl={anchorEl}
          keepMounted
          open={Boolean(anchorEl)}
          onClose={handleClose}
        >
          <MenuItem
            onClick={() => {
              navigate(ERoute.PROFILE);
              handleClose();
            }}
          >
            Profile
          </MenuItem>
          <MenuItem onClick={() => logout()}>Logout</MenuItem>
        </Menu>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
