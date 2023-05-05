import { CssBaseline, ThemeProvider, createTheme } from "@mui/material";
import MainLayout from "layouts/MainLayout";
import ProfilePage from "pages/ProfilePage";
import SettingsPage from "pages/SettingsPage";
import ApplicationListPage from "pages/applications/ApplicationListPage";
import ApplicationPage from "pages/applications/ApplicationPage";
import LoginPage from "pages/auth/LoginPage";
import RegisterPage from "pages/auth/RegisterPage";
import React, { useMemo } from "react";
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import TopBarProgress from "react-topbar-progress-indicator";
import { themeSettings } from "theme";
import { useAppSelector } from "redux/hooks";
import { selectMode } from "redux/globalSlice";

import "react-toastify/dist/ReactToastify.css";
import PrivateRoute from "components/routes/PrivateRoute";
import PublicRoute from "components/routes/PublicRoute";

TopBarProgress.config({});

const App: React.FC = () => {
  const mode = useAppSelector(selectMode);
  const theme = useMemo(() => createTheme(themeSettings(mode)), [mode]);

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <ToastContainer position="top-center" />
      <BrowserRouter>
        <Routes>
          <Route path="/">
            <Route element={<PrivateRoute />}>
              <Route element={<MainLayout />}>
                <Route index element={<ApplicationListPage />} />
                <Route path="applications/:id" element={<ApplicationPage />} />
                <Route path="profile" element={<ProfilePage />} />
                <Route path="settings" element={<SettingsPage />} />
              </Route>
            </Route>

            <Route element={<PublicRoute />}>
              <Route path="login" element={<LoginPage />} />
              <Route path="register" element={<RegisterPage />} />
            </Route>

            <Route path="*" element={<Navigate to="/" />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </ThemeProvider>
  );
};

export default App;
