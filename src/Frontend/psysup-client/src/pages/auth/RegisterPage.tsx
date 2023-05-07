import AuthForm from "components/auth/AuthForm";
import React from "react";
import { useRegisterMutation } from "redux/api/authApiSlice";
import { FormData } from "types/auth/FormData";

const RegisterPage: React.FC = () => {
  const [register, { isLoading }] = useRegisterMutation();

  const onSubmit = (data: FormData) => {
    register(data);
  };

  return (
    <AuthForm
      title="Register"
      linkPath="/login"
      linkText="Do you have an account?"
      isLoading={isLoading}
      onSubmit={onSubmit}
    />
  );
};

export default RegisterPage;
