import AuthForm from "components/auth/LoginForm";
import React from "react";
import { useLoginMutation } from "redux/api/authApiSlice";
import { AuthFormData } from "types/auth/AuthFormData";

const LoginPage: React.FC = () => {
  const [login, { isLoading }] = useLoginMutation();

  const onSubmit = (data: AuthFormData) => {
    login(data);
  };

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
