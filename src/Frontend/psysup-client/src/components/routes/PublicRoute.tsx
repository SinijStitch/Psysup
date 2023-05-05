import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import TopBarProgress from "react-topbar-progress-indicator";
import { useGetProfileQuery } from "redux/api/profileApiSlice";

const PublicRoute: React.FC = () => {
  const { isLoading, isFetching, isSuccess } = useGetProfileQuery();

  if (isLoading || isFetching) {
    return <TopBarProgress />;
  }

  if (isSuccess) {
    return <Navigate to="/" replace />;
  }

  return <Outlet />;
};

export default PublicRoute;
