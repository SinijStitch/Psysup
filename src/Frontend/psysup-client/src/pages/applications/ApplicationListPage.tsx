import {
  Button,
  Card,
  CardActions,
  CardContent,
  Grid,
  MenuItem,
  Pagination,
  Skeleton,
  Stack,
  TextField,
  Typography
} from "@mui/material";
import ApplicationList from "components/applications/ApplicationList";
import PageTitle from "components/common/PageTitle";
import { RouteConstants } from "enums/RouteConstants";
import React from "react";
import { useNavigate } from "react-router-dom";
import { useGetApplicationsQuery } from "redux/api/applicationsApiSlice";

const categories = [
  {
    value: "All",
    label: "All"
  },
  {
    value: "USD",
    label: "First"
  },
  {
    value: "EUR",
    label: "Second"
  },
  {
    value: "BTC",
    label: "Third"
  }
];

const ApplicationListPage: React.FC = () => {
  const navigate = useNavigate();
  const { isLoading, data } = useGetApplicationsQuery({
    isPublic: false,
    pageNumber: 1,
    pageSize: 10
  });

  return (
    <Stack height="100%" gap={2}>
      <PageTitle text="Applications" />
      <Stack direction="row" gap={4}>
        <TextField placeholder="Search..." variant="standard" />
        <TextField
          select
          size="small"
          label="Categories"
          defaultValue="All"
          sx={{ minWidth: "100px" }}
        >
          {categories.map((option) => (
            <MenuItem key={option.value} value={option.value}>
              {option.label}
            </MenuItem>
          ))}
        </TextField>

        <Button
          variant="contained"
          sx={{ ml: "auto" }}
          onClick={() => navigate(RouteConstants.ADD_APPLICATION)}
        >
          Add Application
        </Button>
      </Stack>

      {isLoading ? (
        <Grid container component="ul" p={0} gap={2}>
          {[1, 2, 3, 4, 5, 6, 7, 8, 9, 10].map((item) => (
            <Grid key={item}>
              <Card component="li" sx={{ width: "300px" }}>
                <CardContent>
                  <Skeleton variant="text" animation="wave" />
                </CardContent>
                <CardActions>
                  <Skeleton variant="text" width={60} animation="wave" />
                </CardActions>
              </Card>
            </Grid>
          ))}
        </Grid>
      ) : data && data.applications.length ? (
        <ApplicationList applications={data.applications} />
      ) : (
        <Typography variant="h5" align="center">
          No Applications
        </Typography>
      )}

      {data ? (
        <Pagination
          count={1}
          page={1}
          variant="outlined"
          shape="rounded"
          sx={{ alignSelf: "center", mt: "auto" }}
        />
      ) : null}
    </Stack>
  );
};

export default ApplicationListPage;
