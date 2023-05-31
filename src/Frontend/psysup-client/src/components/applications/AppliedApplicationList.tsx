import React from "react";
import TopBarProgress from "react-topbar-progress-indicator";
import { useLazyGetAppliedApplicationsQuery } from "redux/api/applicationsApiSlice";
import { useGetProfileQuery } from "redux/api/profileApiSlice";
import ApplicationList from "./ApplicationList";

const pageSize = 12;

const AppliedApplicationList: React.FC = () => {
  const getProfileResult = useGetProfileQuery();
  const [pageNumber, setPageNumber] = React.useState<number>(1);
  const [requestApplications, getApplicationsResult] =
    useLazyGetAppliedApplicationsQuery();

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
      allowDelete={false}
      allowAssign={false}
      pageNumber={pageNumber}
      pageSize={pageSize}
      totalCount={getApplicationsResult.data.totalCount}
      onPageChanged={setPageNumber}
    />
  );
};

export default AppliedApplicationList;
