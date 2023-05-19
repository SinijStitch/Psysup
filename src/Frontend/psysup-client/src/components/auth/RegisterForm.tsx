import { Box, Link, Paper, Stack, Typography } from "@mui/material";
import React from "react";
import { useForm } from "react-hook-form";
import { Link as RouteLink } from "react-router-dom";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import FormInput from "../common/FormInput";
import LoadingButton from "components/common/LoadingButton";
import { ERoute } from "enums/ERoute";

interface RegisterFormData {
  email: string;
  password: string;
  firstName: string;
  lastName: string;
}

interface RegisterFormProps {
  isLoading: boolean;
  onSubmit: (data: RegisterFormData) => void;
}

const schema = yup.object().shape({
  email: yup.string().email().required(),
  password: yup.string().min(2).required(),
  firstName: yup.string().min(2).max(100).required(),
  lastName: yup.string().min(2).max(100).required()
});

const RegisterForm: React.FC<RegisterFormProps> = ({ isLoading, onSubmit }) => {
  const {
    handleSubmit,
    control,
    formState: { errors }
  } = useForm<RegisterFormData>({
    resolver: yupResolver(schema)
  });

  const handleFormSubmit = handleSubmit((data) => onSubmit(data));

  return (
    <Box
      component={Paper}
      m="0 auto"
      p="24px"
      maxWidth="500px"
      textAlign="center"
      boxShadow={3}
      borderRadius={4}
      elevation={1}
    >
      <Typography variant="h4" component="h1">
        Register
      </Typography>

      <Box component="form" autoComplete="off" onSubmit={handleFormSubmit}>
        <Stack direction="row" useFlexGap spacing={2}>
          <FormInput
            name="firstName"
            type="text"
            label="First Name"
            control={control}
            fieldError={errors?.firstName}
          />
          <FormInput
            name="lastName"
            type="text"
            label="Last Name"
            control={control}
            fieldError={errors?.lastName}
          />
        </Stack>

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
      <Link component={RouteLink} to={ERoute.LOGIN}>
        Do you have an account?
      </Link>
    </Box>
  );
};

export default RegisterForm;
