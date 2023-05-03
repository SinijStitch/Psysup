import { Box, Button, Typography } from "@mui/material";
import React from "react";
import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";
import { yupResolver } from "@hookform/resolvers/yup";
import { FormData } from "types/auth/FormData";
import * as yup from "yup";
import FormInput from "./FormInput";

interface AuthFormProps {
  title: string;
  linkPath: string;
  linkText: string;
  onSubmit: (data: FormData) => void;
}

const schema = yup.object().shape({
  email: yup.string().email().required(),
  password: yup.string().min(8).required()
});

const AuthForm: React.FC<AuthFormProps> = ({
  title,
  linkPath,
  linkText,
  onSubmit
}) => {
  const {
    handleSubmit,
    control,
    formState: { errors }
  } = useForm<FormData>({
    resolver: yupResolver(schema)
  });

  const handleFormSubmit = handleSubmit((data) => onSubmit(data));

  return (
    <Box
      m="0 auto"
      mt="5%"
      p="24px"
      width="400px"
      textAlign="center"
      boxShadow={3}
      borderRadius={4}
    >
      <Typography variant="h4" component="h1">
        {title}
      </Typography>

      <Box component="form" autoComplete="off" onSubmit={handleFormSubmit}>
        <FormInput
          name="email"
          type="text"
          control={control}
          fieldError={errors?.email}
        />
        <FormInput
          name="password"
          type="password"
          control={control}
          fieldError={errors?.password}
        />

        <Box mt="8px">
          <Button type="submit" variant="contained" fullWidth>
            Submit
          </Button>
        </Box>
      </Box>

      <Box height={8} />
      <Link to={linkPath}>{linkText}</Link>
    </Box>
  );
};

export default AuthForm;
