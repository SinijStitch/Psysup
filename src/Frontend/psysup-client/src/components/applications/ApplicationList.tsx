import { Grid, Pagination, Stack } from "@mui/material";
import React from "react";
import { GetApplicationsResponseItem } from "types/applications/GetApplicationsResponseItem";
import ApplicationListItem from "./ApplicationListItem";

interface ApplicationListProps {
  applications: GetApplicationsResponseItem[];
  allowAssign: boolean;
  allowDelete: boolean;
  pageNumber: number;
  pageSize: number;
  totalCount: number;
  onPageChanged: (page: number) => void;
}

const ApplicationList: React.FC<ApplicationListProps> = ({
  applications,
  allowAssign,
  allowDelete,
  pageSize,
  pageNumber,
  totalCount,
  onPageChanged
}) => {
  const totalPages = Math.ceil(totalCount / pageSize);

  return (
    <Stack>
      <Grid container component="ul" p={0} gap={2}>
        {applications.map((application) => (
          <ApplicationListItem
            key={application.id}
            application={application}
            allowAssign={allowAssign}
            allowDelete={allowDelete}
          />
        ))}
      </Grid>
      {totalPages > 1 && (
        <Pagination
          count={totalPages}
          page={pageNumber}
          onChange={(_e, value) => onPageChanged(value)}
          variant="outlined"
          shape="rounded"
          sx={{ alignSelf: "center", mt: "auto" }}
        />
      )}
    </Stack>
  );
};

export default ApplicationList;
