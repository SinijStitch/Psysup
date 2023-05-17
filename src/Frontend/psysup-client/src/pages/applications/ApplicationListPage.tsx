import {
  Button,
  Pagination,
  Stack,
  TextField,
  Typography
} from "@mui/material";
import ApplicationList from "components/applications/ApplicationList";
import ApplicationListSkeleton from "components/applications/ApplicationListSkeleton";
import PageTitle from "components/common/PageTitle";
import { ERoute } from "enums/ERoute";
import React from "react";
import { useNavigate } from "react-router-dom";
import { useLazyGetApplicationsQuery } from "redux/api/applicationsApiSlice";

const pageSize = 12;

const ApplicationListPage: React.FC = () => {
  const navigate = useNavigate();
  const [pageNumber, setPageNumber] = React.useState<number>(1);
  const [loadApplications, loadApplicationsResult] =
    useLazyGetApplicationsQuery();

  React.useEffect(() => {
    loadApplications({
      isPublic: false,
      pageSize,
      pageNumber
    });
  }, [loadApplications, pageNumber]);

  return (
    <Stack height="100%" gap={2}>
      <PageTitle text="Applications" />
      <Stack direction="row" gap={4}>
        <TextField
          fullWidth
          label="Search..."
          type="search"
          variant="standard"
        />

        <Button
          variant="contained"
          onClick={() => navigate(ERoute.ADD_APPLICATION)}
          sx={{ minWidth: "158px" }}
        >
          Add Application
        </Button>
      </Stack>

      {loadApplicationsResult.isLoading ? (
        <ApplicationListSkeleton />
      ) : loadApplicationsResult.data &&
        loadApplicationsResult.data.applications.length ? (
        <ApplicationList
          applications={loadApplicationsResult.data.applications}
        />
      ) : (
        <Typography variant="h5" align="center">
          No Applications
        </Typography>
      )}

      {loadApplicationsResult.data &&
      loadApplicationsResult.data.totalCount > pageSize ? (
        <Pagination
          count={Math.ceil(loadApplicationsResult.data.totalCount / pageSize)}
          page={pageNumber}
          onChange={(_e, value) => setPageNumber(value)}
          variant="outlined"
          shape="rounded"
          sx={{ alignSelf: "center", mt: "auto" }}
        />
      ) : null}
    </Stack>
  );
};

export default ApplicationListPage;
