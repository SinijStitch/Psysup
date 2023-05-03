import AuthForm from "components/auth/AuthForm";
import React from "react";
import { FormData } from "types/auth/FormData";

const LoginPage: React.FC = () => {
  const onSubmit = (data: FormData) => {
    console.log(data);
  };

  return (
    <AuthForm
      title="Login"
      linkPath="/register"
      linkText="Are you new user?"
      onSubmit={onSubmit}
    />
  );
};

export default LoginPage;
