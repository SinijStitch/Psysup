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
import { ERoute } from "enums/ERoute";
import { useLogoutMutation } from "redux/api/authApiSlice";
import TopBarProgress from "react-topbar-progress-indicator";
import { ERole } from "enums/ERole";
import { useGetProfileQuery } from "redux/api/profileApiSlice";

interface NavItem {
  label: string;
  path: string;
  icon: React.ReactNode;
  selectedIcon: React.ReactNode;
  allowedRoles?: string[];
}

const menuItems: (NavItem | null)[] = [
  {
    label: "Applications",
    path: ERoute.APPLICATIONS,
    icon: <FeaturedPlayListOutlinedIcon />,
    selectedIcon: <FeaturedPlayListIcon />
  },
  {
    label: "Categories",
    path: ERoute.CATEGORIES,
    icon: <CategoryOutlinedIcon />,
    selectedIcon: <CategoryIcon />,
    allowedRoles: [ERole.Admin]
  },
  {
    label: "Users",
    path: ERoute.USERS,
    icon: <GroupOutlinedIcon />,
    selectedIcon: <GroupIcon />,
    allowedRoles: [ERole.Admin]
  },
  null,
  {
    label: "Profile",
    path: ERoute.PROFILE,
    icon: <AccountBoxOutlinedIcon />,
    selectedIcon: <AccountBoxIcon />
  },
  {
    label: "Settings",
    path: ERoute.SETTINGS,
    icon: <SettingsOutlinedIcon />,
    selectedIcon: <SettingsIcon />
  }
];

const NavBar: React.FC = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const profileResult = useGetProfileQuery();
  const [logout, logoutResult] = useLogoutMutation();

  if (profileResult.isLoading || logoutResult.isLoading) {
    return <TopBarProgress />;
  }

  return (
    <Box component="nav" minWidth="180px">
      <List>
        {menuItems
          .filter(
            (item) =>
              !item ||
              !item.allowedRoles ||
              profileResult.data?.roles.some(
                (role) => item.allowedRoles?.includes(role) ?? false
              )
          )
          .map((item) => {
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
                    fontWeight: location.pathname.includes(item.path)
                      ? 700
                      : 400
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
