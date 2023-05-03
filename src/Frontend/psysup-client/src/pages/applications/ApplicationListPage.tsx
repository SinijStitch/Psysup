import PageTitle from "components/common/PageTitle";
import React, { useEffect } from "react";
import { useLoginMutation } from "redux/api/authApiSlice";

const ApplicationListPage: React.FC = () => {
  const [login, result] = useLoginMutation();

  useEffect(() => {
    login({ email: "ihor.matiev@gmail.com", password: "asd" });
  }, [login]);

  return <PageTitle text="Applications" />;
};

export default ApplicationListPage;
