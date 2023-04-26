import React from "react";
import { Route, Routes } from "react-router-dom";
import MainLayout from "common/layouts/MainLayout";
import HomePage from "features/dashboard/pages/HomePage";
import ApplicationListPage from "features/application/pages/ApplicationListPage";
import ApplicationPage from "features/application/pages/ApplicationPage";
import AuthLayout from "common/layouts/AuthLayout";
import LoginPage from "features/auth/pages/LoginPage";
import RegisterPage from "features/auth/pages/RegisterPage";

const App: React.FC = () => {
  return (
    <Routes>
      <Route path="/">
        <Route element={<MainLayout />}>
          <Route index element={<HomePage />} />
          <Route path="applications" element={<ApplicationListPage />} />
          <Route path="applications/:id" element={<ApplicationPage />} />
        </Route>
        <Route element={<AuthLayout />}>
          <Route path="login" element={<LoginPage />} />
          <Route path="register" element={<RegisterPage />} />
        </Route>
      </Route>
    </Routes>
  );
};

export default App;
