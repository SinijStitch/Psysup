import { ERole } from "enums/ERole";
import { ERoute } from "enums/ERoute";
import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import TopBarProgress from "react-topbar-progress-indicator";
import { useGetProfileQuery } from "redux/api/profileApiSlice";

interface ProtectedRouteProps {
  allowedRoles?: ERole[];
  auth?: boolean;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({
  allowedRoles,
  auth = false
}) => {
  const { isLoading, isFetching, isSuccess, data } = useGetProfileQuery();

  if (isLoading || isFetching) {
    return <TopBarProgress />;
  }

  if (isSuccess && !auth) {
    return <Navigate to="/" />;
  }

  if (!isSuccess && auth) {
    return <Navigate to={ERoute.LOGIN} />;
  }

  if (
    !allowedRoles ||
    data!.roles.some((role) => allowedRoles.includes(role))
  ) {
    return <Outlet />;
  }

  return <Navigate to="/" />;
};

export default ProtectedRoute;
