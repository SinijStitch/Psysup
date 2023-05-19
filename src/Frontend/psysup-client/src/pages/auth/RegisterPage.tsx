import RegisterForm from "components/auth/RegisterForm";
import React from "react";
import { useRegisterMutation } from "redux/api/authApiSlice";
import { AuthFormData } from "types/auth/AuthFormData";

const RegisterPage: React.FC = () => {
  const [register, { isLoading }] = useRegisterMutation();

  const onSubmit = (data: AuthFormData) => {
    register(data);
  };

  return <RegisterForm isLoading={isLoading} onSubmit={onSubmit} />;
};

export default RegisterPage;
