import AuthForm from "components/auth/AuthForm";
import React from "react";
import { FormData } from "types/auth/FormData";

const RegisterPage: React.FC = () => {
  const onSubmit = (data: FormData) => {
    console.log(data);
  };

  return (
    <AuthForm
      title="Register"
      linkPath="/login"
      linkText="Do you have an account?"
      onSubmit={onSubmit}
    />
  );
};

export default RegisterPage;
