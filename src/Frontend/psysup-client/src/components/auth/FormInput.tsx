import { TextField, capitalize } from "@mui/material";
import React from "react";
import { Control, Controller, FieldError } from "react-hook-form";
import { FormData } from "types/auth/FormData";

interface FormInputProps {
  name: "email" | "password";
  type: string;
  control: Control<FormData, any>;
  fieldError: FieldError | undefined;
}

const FormInput: React.FC<FormInputProps> = ({
  name,
  type,
  control,
  fieldError
}) => {
  return (
    <Controller
      name={name}
      control={control}
      defaultValue=""
      render={({ field }) => (
        <TextField
          type={type}
          variant="outlined"
          fullWidth
          margin="normal"
          label={capitalize(name)}
          {...field}
          error={!!fieldError}
          helperText={fieldError?.message}
        />
      )}
    />
  );
};

export default FormInput;
