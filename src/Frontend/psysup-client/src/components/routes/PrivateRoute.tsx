import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import TopBarProgress from "react-topbar-progress-indicator";
import { useGetProfileQuery } from "redux/api/profileApiSlice";

const PrivateRoute: React.FC = () => {
  const { isLoading, isFetching, isSuccess } = useGetProfileQuery();

  if (isLoading || isFetching) {
    return <TopBarProgress />;
  }

  if (isSuccess) {
    return <Outlet />;
  }

  return <Navigate to="/login" replace />;
};

export default PrivateRoute;
