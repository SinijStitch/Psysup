import { Button, CircularProgress } from "@mui/material";
import React from "react";

interface LoadingButtonProps extends React.PropsWithChildren {
  isLoading?: boolean;
  type?: "button" | "submit" | "reset" | undefined;
  fullWidth?: boolean;
  sx?: React.CSSProperties;
  variant?: "text" | "outlined" | "contained";
  disabled?: boolean;
  color?:
    | "inherit"
    | "primary"
    | "secondary"
    | "success"
    | "error"
    | "info"
    | "warning";
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
}

const LoadingButton: React.FC<LoadingButtonProps> = ({
  isLoading = false,
  type,
  fullWidth,
  sx,
  children,
  variant = "contained",
  disabled,
  color,
  onClick
}) => {
  return (
    <Button
      type={type}
      variant={variant}
      fullWidth={fullWidth}
      sx={sx}
      disabled={isLoading || disabled}
      color={color}
      onClick={onClick}
    >
      {isLoading ? <CircularProgress size="24px" /> : children}
    </Button>
  );
};

export default LoadingButton;
