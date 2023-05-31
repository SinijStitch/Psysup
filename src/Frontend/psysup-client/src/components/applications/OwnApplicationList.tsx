import React from "react";
import TopBarProgress from "react-topbar-progress-indicator";
import { useLazyGetOwnApplicationsQuery } from "redux/api/applicationsApiSlice";
import ApplicationList from "./ApplicationList";

const pageSize = 12;

const OwnApplicationList: React.FC = () => {
  const [pageNumber, setPageNumber] = React.useState<number>(1);
  const [requestApplications, { isLoading, isFetching, data }] =
    useLazyGetOwnApplicationsQuery();

  React.useEffect(() => {
    requestApplications({ pageNumber, pageSize }, true);
  }, [pageNumber, requestApplications]);

  if (isFetching || isLoading || !data) {
    return <TopBarProgress />;
  }

  return (
    <ApplicationList
      applications={data.applications}
      allowDelete={true}
      allowAssign={false}
      pageNumber={pageNumber}
      pageSize={pageSize}
      totalCount={data.totalCount}
      onPageChanged={setPageNumber}
    />
  );
};

export default OwnApplicationList;
