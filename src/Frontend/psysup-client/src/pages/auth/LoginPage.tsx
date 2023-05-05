import AuthForm from "components/auth/AuthForm";
import React from "react";
import { Navigate } from "react-router-dom";
import { useLoginMutation } from "redux/api/authApiSlice";
import { FormData } from "types/auth/FormData";

const LoginPage: React.FC = () => {
  const [login, { isLoading, isSuccess }] = useLoginMutation();

  const onSubmit = (data: FormData) => {
    login(data);
  };

  if (isSuccess) {
    return <Navigate to="/" />;
  }

  return (
    <AuthForm
      title="Login"
      linkPath="/register"
      linkText="Are you new user?"
      isLoading={isLoading}
      onSubmit={onSubmit}
    />
  );
};

export default LoginPage;
