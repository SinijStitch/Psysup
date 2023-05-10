import { Button, CircularProgress } from "@mui/material";
import React from "react";

interface LoadingButtonProps extends React.PropsWithChildren {
  isLoading?: boolean;
  type?: "button" | "submit" | "reset" | undefined;
  fullWidth?: boolean;
  sx?: React.CSSProperties;
}

const LoadingButton: React.FC<LoadingButtonProps> = ({
  isLoading = false,
  type,
  fullWidth,
  sx,
  children
}) => {
  return (
    <Button
      type={type}
      variant="contained"
      fullWidth={fullWidth}
      sx={sx}
      disabled={isLoading}
    >
      {isLoading ? <CircularProgress size="24px" /> : children}
    </Button>
  );
};

export default LoadingButton;
