import {
  Box,
  Button,
  CircularProgress,
  Link,
  Paper,
  Typography
} from "@mui/material";
import React from "react";
import { useForm } from "react-hook-form";
import { Link as RouteLink } from "react-router-dom";
import { yupResolver } from "@hookform/resolvers/yup";
import { AuthFormData } from "types/auth/FormData";
import * as yup from "yup";
import FormInput from "../common/FormInput";
import LoadingButton from "components/common/LoadingButton";

interface AuthFormProps {
  title: string;
  linkPath: string;
  linkText: string;
  isLoading: boolean;
  onSubmit: (data: AuthFormData) => void;
}

const schema = yup.object().shape({
  email: yup.string().email().required(),
  password: yup.string().min(2).required()
});

const AuthForm: React.FC<AuthFormProps> = ({
  title,
  linkPath,
  linkText,
  isLoading,
  onSubmit
}) => {
  const {
    handleSubmit,
    control,
    formState: { errors }
  } = useForm<AuthFormData>({
    resolver: yupResolver(schema)
  });

  const handleFormSubmit = handleSubmit((data) => onSubmit(data));

  return (
    <Box
      component={Paper}
      m="0 auto"
      p="24px"
      width="400px"
      textAlign="center"
      boxShadow={3}
      borderRadius={4}
      elevation={1}
    >
      <Typography variant="h4" component="h1">
        {title}
      </Typography>

      <Box component="form" autoComplete="off" onSubmit={handleFormSubmit}>
        <FormInput
          name="email"
          type="text"
          label="Email"
          control={control}
          fieldError={errors?.email}
        />
        <FormInput
          name="password"
          type="password"
          label="Password"
          control={control}
          fieldError={errors?.password}
        />

        <Box mt="8px">
          <LoadingButton type="submit" fullWidth isLoading={isLoading}>
            <Typography>Submit</Typography>
          </LoadingButton>
        </Box>
      </Box>

      <Box height={8} />
      <Link component={RouteLink} to={linkPath}>
        {linkText}
      </Link>
    </Box>
  );
};

export default AuthForm;
