import AuthForm from "components/auth/AuthForm";
import React from "react";
import { useLoginMutation } from "redux/api/authApiSlice";
import { FormData } from "types/auth/FormData";

const LoginPage: React.FC = () => {
  const [login, { isLoading }] = useLoginMutation();

  const onSubmit = (data: FormData) => {
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