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
import CategoriesPage from "pages/categories/CategoriesPage";
import UsersPage from "pages/users/UsersPage";
import { ERoute } from "enums/ERoute";
import AuthLayout from "layouts/AuthLayout";
import AddApplicationPage from "pages/applications/AddApplicationPage";
import ProtectedRoute from "components/routes/ProtectedRoute";
import { ERole } from "enums/ERole";

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
            <Route element={<MainLayout />}>
              <Route index element={<Navigate to={ERoute.APPLICATIONS} />} />

              <Route element={<ProtectedRoute auth />}>
                <Route
                  path={ERoute.APPLICATIONS}
                  element={<ApplicationListPage />}
                />
              </Route>

              <Route element={<ProtectedRoute auth />}>
                <Route
                  path={ERoute.APPLICATION}
                  element={<ApplicationPage />}
                />
              </Route>

              <Route element={<ProtectedRoute auth />}>
                <Route
                  path={ERoute.ADD_APPLICATION}
                  element={<AddApplicationPage />}
                />
              </Route>

              <Route element={<ProtectedRoute auth allowedRoles={[ERole.Admin]} />}>
                <Route path={ERoute.CATEGORIES} element={<CategoriesPage />} />
              </Route>

              <Route element={<ProtectedRoute auth allowedRoles={[ERole.Admin]}/>}>
                <Route path={ERoute.USERS} element={<UsersPage />} />
              </Route>

              <Route element={<ProtectedRoute auth />}>
                <Route path={ERoute.PROFILE} element={<ProfilePage />} />
              </Route>

              <Route element={<ProtectedRoute auth />}>
                <Route path={ERoute.SETTINGS} element={<SettingsPage />} />
              </Route>
            </Route>

            <Route element={<AuthLayout />}>
              <Route element={<ProtectedRoute />}>
                <Route path={ERoute.LOGIN} element={<LoginPage />} />
              </Route>

              <Route element={<ProtectedRoute />}>
                <Route path={ERoute.REGISTER} element={<RegisterPage />} />
              </Route>
            </Route>

            <Route path="*" element={<Navigate to="/" />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </ThemeProvider>
  );
};

export default App;
