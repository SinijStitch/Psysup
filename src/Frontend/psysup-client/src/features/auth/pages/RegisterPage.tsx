import { Box, Button, TextField, Typography } from "@mui/material";
import React from "react";

const RegisterPage: React.FC = () => {
  return (
    <Box p="24px" width="400px" height="200px" m="0 auto" textAlign="center">
      <Typography variant="h4" component="h1">
        Registration
      </Typography>

      <form>
        <TextField
          type="email"
          variant="outlined"
          fullWidth
          margin="normal"
          label="Email"
        />
        <TextField
          type="password"
          variant="outlined"
          fullWidth
          margin="normal"
          label="Password"
        />

        <Box mt="8px">
          <Button type="submit" variant="contained" fullWidth>
            Submit
          </Button>
        </Box>
      </form>
    </Box>
  );
};

export default RegisterPage;
