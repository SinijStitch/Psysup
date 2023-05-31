import {
  Grid,
  Card,
  CardContent,
  Typography,
  CardActions,
  Button
} from "@mui/material";
import DeleteCancelDialog from "components/common/dialogs/DeleteCancelDialog";
import { ERoute } from "enums/ERoute";
import React from "react";
import { useNavigate } from "react-router-dom";
import TopBarProgress from "react-topbar-progress-indicator";
import {
  useApplyApplicationMutation,
  useDeleteApplicationMutation
} from "redux/api/applicationsApiSlice";
import { GetApplicationsResponseItem } from "types/applications/GetApplicationsResponseItem";

interface ApplicationListItemProps {
  application: GetApplicationsResponseItem;
  allowAssign: boolean;
  allowDelete: boolean;
}

const ApplicationListItem: React.FC<ApplicationListItemProps> = ({
  application,
  allowAssign,
  allowDelete
}) => {
  const navigate = useNavigate();
  const [showPopup, setShowPopup] = React.useState<boolean>(false);
  const [applicationId, setApplicationId] = React.useState<string>();
  const [deleteAppliction, deleteApplicationResult] =
    useDeleteApplicationMutation();
  const [assignApplication, assignApplicationResult] =
    useApplyApplicationMutation();

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

  const handleAssignClick = (id: string) => {
    assignApplication(id);
  };

  return (
    <Grid>
      {(deleteApplicationResult.isLoading ||
        assignApplicationResult.isLoading) && <TopBarProgress />}
      <Card component="li" sx={{ width: "300px" }}>
        <CardContent>
          <Typography variant="h5" noWrap>
            {application.title}
          </Typography>
        </CardContent>
        <CardActions>
          <Button
            onClick={() =>
              navigate(ERoute.APPLICATION.replace(":id", application.id))
            }
          >
            More Details
          </Button>

          {allowAssign && (
            <Button
              variant="text"
              color="success"
              disabled={assignApplicationResult.isLoading}
              onClick={() => handleAssignClick(application.id)}
            >
              Assign
            </Button>
          )}

          {allowDelete && (
            <Button
              variant="text"
              color="error"
              disabled={deleteApplicationResult.isLoading}
              onClick={() => handleDeleteClick(application.id)}
            >
              Delete
            </Button>
          )}
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
  );
};

export default ApplicationListItem;
