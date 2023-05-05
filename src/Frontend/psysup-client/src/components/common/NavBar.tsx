import {
  Box,
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
import { useLocation, useNavigate } from "react-router-dom";

interface NavItem {
  label: string;
  path: string;
  icon: React.ReactNode;
  selectedIcon: React.ReactNode;
}

const menuItems: NavItem[] = [
  {
    label: "Applications",
    path: "/",
    icon: <FeaturedPlayListOutlinedIcon />,
    selectedIcon: <FeaturedPlayListIcon />
  },
  {
    label: "Profile",
    path: "/profile",
    icon: <AccountBoxOutlinedIcon />,
    selectedIcon: <AccountBoxIcon />
  },
  {
    label: "Settings",
    path: "/settings",
    icon: <SettingsOutlinedIcon />,
    selectedIcon: <SettingsIcon />
  }
];

const NavBar: React.FC = () => {
  const location = useLocation();
  const navigate = useNavigate();

  return (
    <Box component="nav" bgcolor="background.alt">
      <List>
        {menuItems.map((item) => (
          <ListItemButton key={item.label} onClick={() => navigate(item.path)}>
            <ListItemIcon>
              {location.pathname === item.path ? item.selectedIcon : item.icon}
            </ListItemIcon>
            <ListItemText
              primary={item.label}
              primaryTypographyProps={{
                fontWeight: location.pathname === item.path ? 700 : 400
              }}
            />
          </ListItemButton>
        ))}
      </List>
    </Box>
  );
};

export default NavBar;
