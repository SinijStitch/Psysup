import AuthForm from "components/auth/AuthForm";
import React from "react";
import { Navigate } from "react-router-dom";
import { useRegisterMutation } from "redux/api/authApiSlice";
import { FormData } from "types/auth/FormData";

const RegisterPage: React.FC = () => {
  const [register, { isLoading, isSuccess }] = useRegisterMutation();

  const onSubmit = (data: FormData) => {
    register(data);
  };

  if (isSuccess) {
    return <Navigate to="/" />;
  }

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
