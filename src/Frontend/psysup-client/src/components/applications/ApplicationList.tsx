import {
  Button,
  Card,
  CardActions,
  CardContent,
  Grid,
  Typography
} from "@mui/material";
import DeleteCancelDialog from "components/common/dialogs/DeleteCancelDialog";
import { ERoute } from "enums/ERoute";
import React from "react";
import { useNavigate } from "react-router-dom";
import TopBarProgress from "react-topbar-progress-indicator";
import { useDeleteApplicationMutation } from "redux/api/applicationsApiSlice";
import { GetApplicationsResponseItem } from "types/applications/GetApplicationsResponseItem";

interface ApplicationListProps {
  applications: GetApplicationsResponseItem[];
}

const ApplicationList: React.FC<ApplicationListProps> = ({ applications }) => {
  const navigate = useNavigate();
  const [showPopup, setShowPopup] = React.useState<boolean>(false);
  const [applicationId, setApplicationId] = React.useState<string>();
  const [deleteAppliction, { isLoading }] = useDeleteApplicationMutation();

  const handleDeleteClick = (id: string) => {
    setApplicationId(id);
    setShowPopup(true);
  };

  const onPopupCancel = () => {
    setShowPopup(false);
    setApplicationId(undefined);
  };

  const onPopupSuccess = () => {
    setShowPopup(false);
    if (applicationId) {
      deleteAppliction(applicationId);
    }
    setApplicationId(undefined);
  };

  return (
    <>
      {isLoading ? <TopBarProgress /> : null}
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
                    navigate(ERoute.APPLICATION.replace(":id", application.id))
                  }
                >
                  More Details
                </Button>

                <Button
                  variant="text"
                  color="error"
                  onClick={() => handleDeleteClick(application.id)}
                >
                  Delete
                </Button>
              </CardActions>
            </Card>

            <DeleteCancelDialog
              title="Delete Application"
              content="Do you want to delete the application?"
              isOpen={showPopup}
              onCancel={onPopupCancel}
              onSuccess={onPopupSuccess}
            />
          </Grid>
        ))}
      </Grid>
    </>
  );
};

export default ApplicationList;
