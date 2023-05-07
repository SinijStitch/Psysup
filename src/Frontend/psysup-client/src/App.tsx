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
import CategoriesPage from "pages/categories/CategoriesPage";
import UsersPage from "pages/users/UsersPage";
import { RouteConstants } from "enums/RouteConstants";
import AuthLayout from "layouts/AuthLayout";
import AddApplicationPage from "pages/applications/AddApplicationPage";

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
                <Route
                  index
                  element={<Navigate to={RouteConstants.APPLICATIONS} />}
                />
                <Route
                  path={RouteConstants.APPLICATIONS}
                  element={<ApplicationListPage />}
                />
                <Route
                  path={RouteConstants.APPLICATION}
                  element={<ApplicationPage />}
                />
                <Route
                  path={RouteConstants.ADD_APPLICATION}
                  element={<AddApplicationPage />}
                />
                <Route
                  path={RouteConstants.CATEGORIES}
                  element={<CategoriesPage />}
                />
                <Route path={RouteConstants.USERS} element={<UsersPage />} />
                <Route
                  path={RouteConstants.PROFILE}
                  element={<ProfilePage />}
                />
                <Route
                  path={RouteConstants.SETTINGS}
                  element={<SettingsPage />}
                />
              </Route>
            </Route>

            <Route element={<PublicRoute />}>
              <Route element={<AuthLayout />}>
                <Route path={RouteConstants.LOGIN} element={<LoginPage />} />
                <Route
                  path={RouteConstants.REGISTER}
                  element={<RegisterPage />}
                />
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
