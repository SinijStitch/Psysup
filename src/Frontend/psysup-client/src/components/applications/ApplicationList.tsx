import {
  Button,
  Card,
  CardActions,
  CardContent,
  Grid,
  Typography
} from "@mui/material";
import { RouteConstants } from "enums/RouteConstants";
import React from "react";
import { useNavigate } from "react-router-dom";
import { GetApplicationsResponseItem } from "types/applications/GetApplicationsResponseItem";

interface ApplicationListProps {
  applications: GetApplicationsResponseItem[];
}

const ApplicationList: React.FC<ApplicationListProps> = ({ applications }) => {
  const navigate = useNavigate();

  return (
    <Grid container component="ul" p={0} gap={2}>
      {applications.map((application) => (
        <Grid key={application.id}>
          <Card component="li" sx={{ width: "300px" }}>
            <CardContent>
              <Typography variant="h5">{application.title}</Typography>
            </CardContent>
            <CardActions>
              <Button
                onClick={() =>
                  navigate(
                    RouteConstants.APPLICATION.replace(":id", application.id)
                  )
                }
              >
                More Details
              </Button>
            </CardActions>
          </Card>
        </Grid>
      ))}
    </Grid>
  );
};

export default ApplicationList;
