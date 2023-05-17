import { TextField } from "@mui/material";
import React from "react";
import { Control, Controller, FieldError } from "react-hook-form";

interface FormInputProps {
  name: string;
  type: string;
  label: string;
  multiline?: boolean;
  rows?: number;
  control: Control<any, any>;
  fieldError: FieldError | undefined;
}

const FormInput: React.FC<FormInputProps> = ({
  name,
  type,
  label,
  multiline = false,
  rows = 0,
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
          multiline={multiline}
          rows={rows}
          fullWidth
          margin="normal"
          label={label}
          {...field}
          error={!!fieldError}
          helperText={fieldError?.message}
        />
      )}
    />
  );
};

export default FormInput;
