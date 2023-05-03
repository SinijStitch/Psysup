import MainLayout from "layouts/MainLayout";
import ProfilePage from "pages/ProfilePage";
import SettingsPage from "pages/SettingsPage";
import ApplicationListPage from "pages/applications/ApplicationListPage";
import ApplicationPage from "pages/applications/ApplicationPage";
import LoginPage from "pages/auth/LoginPage";
import RegisterPage from "pages/auth/RegisterPage";
import React from "react";
import { Navigate, Route, Routes } from "react-router-dom";

const App: React.FC = () => {
  return (
    <Routes>
      <Route path="/">
        <Route element={<MainLayout />}>
          <Route index element={<ApplicationListPage />} />
          <Route path="applications/:id" element={<ApplicationPage />} />
          <Route path="profile" element={<ProfilePage />} />
          <Route path="settings" element={<SettingsPage />} />
        </Route>

        <Route path="login" element={<LoginPage />} />
        <Route path="register" element={<RegisterPage />} />

        <Route path="*" element={<Navigate to="/" />} />
      </Route>
    </Routes>
  );
};

export default App;
