import {
  Box,
  Divider,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText
} from "@mui/material";
import React from "react";
import FeaturedPlayListIcon from "@mui/icons-material/FeaturedPlayList";
import FeaturedPlayListOutlinedIcon from "@mui/icons-material/FeaturedPlayListOutlined";
import AccountBoxIcon from "@mui/icons-material/AccountBox";
import AccountBoxOutlinedIcon from "@mui/icons-material/AccountBoxOutlined";
import SettingsIcon from "@mui/icons-material/Settings";
import SettingsOutlinedIcon from "@mui/icons-material/SettingsOutlined";
import CategoryIcon from "@mui/icons-material/Category";
import CategoryOutlinedIcon from "@mui/icons-material/CategoryOutlined";
import GroupIcon from "@mui/icons-material/Group";
import GroupOutlinedIcon from "@mui/icons-material/GroupOutlined";
import ExitToAppOutlinedIcon from "@mui/icons-material/ExitToAppOutlined";
import { useLocation, useNavigate } from "react-router-dom";
import { RouteConstants } from "enums/RouteConstants";
import { useLogoutMutation } from "redux/api/authApiSlice";
import TopBarProgress from "react-topbar-progress-indicator";

interface NavItem {
  label: string;
  path: string;
  icon: React.ReactNode;
  selectedIcon: React.ReactNode;
}

const menuItems: (NavItem | null)[] = [
  {
    label: "Applications",
    path: RouteConstants.APPLICATIONS,
    icon: <FeaturedPlayListOutlinedIcon />,
    selectedIcon: <FeaturedPlayListIcon />
  },
  {
    label: "Categories",
    path: RouteConstants.CATEGORIES,
    icon: <CategoryOutlinedIcon />,
    selectedIcon: <CategoryIcon />
  },
  {
    label: "Users",
    path: RouteConstants.USERS,
    icon: <GroupOutlinedIcon />,
    selectedIcon: <GroupIcon />
  },
  null,
  {
    label: "Profile",
    path: RouteConstants.PROFILE,
    icon: <AccountBoxOutlinedIcon />,
    selectedIcon: <AccountBoxIcon />
  },
  {
    label: "Settings",
    path: RouteConstants.SETTINGS,
    icon: <SettingsOutlinedIcon />,
    selectedIcon: <SettingsIcon />
  }
];

const NavBar: React.FC = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const [logout, { isLoading }] = useLogoutMutation();

  if (isLoading) {
    return <TopBarProgress />;
  }

  return (
    <Box component="nav" minWidth="180px">
      <List>
        {menuItems.map((item) => {
          return item ? (
            <ListItemButton
              component="li"
              key={item.label}
              onClick={() => navigate(item.path)}
            >
              <ListItemIcon>
                {location.pathname.includes(item.path)
                  ? item.selectedIcon
                  : item.icon}
              </ListItemIcon>
              <ListItemText
                primary={item.label}
                primaryTypographyProps={{
                  fontWeight: location.pathname.includes(item.path) ? 700 : 400
                }}
              />
            </ListItemButton>
          ) : (
            <Divider key="divider" component="li" />
          );
        })}
        <ListItemButton component="li" key="Logout" onClick={() => logout()}>
          <ListItemIcon>
            <ExitToAppOutlinedIcon />
          </ListItemIcon>
          <ListItemText primary="Logout" />
        </ListItemButton>
      </List>
    </Box>
  );
};

export default NavBar;
