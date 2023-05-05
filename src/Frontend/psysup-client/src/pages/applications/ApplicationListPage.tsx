import PageTitle from "components/common/PageTitle";
import React, { useEffect } from "react";
import { useLoginMutation } from "redux/api/authApiSlice";

const ApplicationListPage: React.FC = () => {
  return <PageTitle text="Applications" />;
};

export default ApplicationListPage;
