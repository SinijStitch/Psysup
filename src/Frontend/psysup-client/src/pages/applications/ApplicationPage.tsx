import { Stack, Button, Typography } from "@mui/material";
import PageTitle from "components/common/PageTitle";
import { RouteConstants } from "enums/RouteConstants";
import React from "react";
import ArrowBackOutlinedIcon from "@mui/icons-material/ArrowBackOutlined";
import { Link } from "react-router-dom";

const ApplicationPage: React.FC = () => {
  return (
    <Stack>
      <Stack direction="row" gap={2}>
        <PageTitle text="Application" />
        <Button component={Link} to={RouteConstants.APPLICATIONS}>
          <ArrowBackOutlinedIcon />
          <Typography>Back</Typography>
        </Button>
      </Stack>
    </Stack>
  );
};

export default ApplicationPage;
