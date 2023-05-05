import { Box, Stack } from "@mui/material";
import Footer from "components/common/Footer";
import Header from "components/common/Header";
import NavBar from "components/common/NavBar";
import React from "react";
import { Outlet } from "react-router-dom";

const MainLayout: React.FC = () => {
  return (
    <Stack height="100vh">
      <Header />

      <Stack direction="row" height="100%">
        <NavBar />

        <Stack width="100%">
          <Box component="main" padding={4} flexGrow={1}>
            <Outlet />
          </Box>
          <Footer />
        </Stack>
      </Stack>
    </Stack>
  );
};

export default MainLayout;
