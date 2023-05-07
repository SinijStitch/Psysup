import { Box, Stack, Typography } from "@mui/material";
import Footer from "components/common/Footer";
import ThemeToggler from "components/common/ThemeToggler";
import React from "react";
import { Outlet } from "react-router-dom";

const AuthLayout: React.FC = () => {
  return (
    <Stack height="100vh" spacing={5} pt={2} px={2}>
      <Box ml="auto">
        <ThemeToggler />
      </Box>

      <Box component="header">
        <Typography
          component="h2"
          variant="h3"
          noWrap
          fontFamily="monospace"
          fontWeight="bold"
          letterSpacing=".3rem"
          align="center"
        >
          Psysup
        </Typography>
      </Box>

      <Box component="main" flexGrow={1}>
        <Outlet />
      </Box>

      <Footer />
    </Stack>
  );
};

export default AuthLayout;
