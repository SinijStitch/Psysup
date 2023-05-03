import { Box, Stack } from "@mui/material";
import Header from "components/common/Header";
import NavBar from "components/common/NavBar";
import React from "react";
import { Outlet } from "react-router-dom";

const MainLayout: React.FC = () => {
  return (
    <Stack sx={{ height: "100vh" }}>
      <Header />

      <Stack direction="row" sx={{ height: "100%" }}>
        <NavBar />

        <Box component="main" bgcolor="grey.50" padding={2.5} flexGrow={1}>
          <Outlet />
        </Box>
      </Stack>
    </Stack>
  );
};

export default MainLayout;
