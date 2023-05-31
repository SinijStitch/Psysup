import React from "react";
import TopBarProgress from "react-topbar-progress-indicator";
import {
  useLazyGetPublicApplicationsQuery
} from "redux/api/applicationsApiSlice";
import ApplicationList from "./ApplicationList";
import { useGetProfileQuery } from "redux/api/profileApiSlice";
import { ERole } from "enums/ERole";

const pageSize = 12;

const PublicApplicationList: React.FC = () => {
  const getProfileResult = useGetProfileQuery();
  const [pageNumber, setPageNumber] = React.useState<number>(1);
  const [requestApplications, getApplicationsResult] =
    useLazyGetPublicApplicationsQuery();

  React.useEffect(() => {
    requestApplications({ pageNumber, pageSize }, true);
  }, [pageNumber, requestApplications]);

  if (
    getApplicationsResult.isFetching ||
    getApplicationsResult.isLoading ||
    !getApplicationsResult.data ||
    !getProfileResult.data
  ) {
    return <TopBarProgress />;
  }

  return (
    <ApplicationList
      applications={getApplicationsResult.data.applications}
      allowDelete={getProfileResult.data.roles.includes(ERole.Admin)}
      allowAssign={getProfileResult.data.roles.includes(ERole.Doctor)}
      pageNumber={pageNumber}
      pageSize={pageSize}
      totalCount={getApplicationsResult.data.totalCount}
      onPageChanged={setPageNumber}
    />
  );
};

export default PublicApplicationList;
