import { Box, Button, Stack, Tab, Tabs, TextField } from "@mui/material";
import AppliedApplicationList from "components/applications/AppliedApplicationList";
import OwnApplicationList from "components/applications/OwnApplicationList";
import PublicApplicationList from "components/applications/PublicApplicationList";
import PageTitle from "components/common/PageTitle";
import { ERole } from "enums/ERole";
import { ERoute } from "enums/ERoute";
import React from "react";
import { useNavigate } from "react-router-dom";
import TopBarProgress from "react-topbar-progress-indicator";
import { useGetProfileQuery } from "redux/api/profileApiSlice";

enum ETab {
  MyApplications = "MyApplications",
  PublicApplications = "PublicApplications",
  AppliedApplications = "AppliedApplications"
}

const ApplicationListPage: React.FC = () => {
  const navigate = useNavigate();
  const { data } = useGetProfileQuery();
  const [selectedTab, setSelectedTab] = React.useState<ETab>();

  const handleChange = (_: React.SyntheticEvent, newTab: ETab) => {
    setSelectedTab(newTab);
  };

  React.useEffect(() => {
    if (data) {
      if (data.roles.includes(ERole.User)) {
        setSelectedTab(ETab.MyApplications);
      } else if (
        data.roles.includes(ERole.Doctor) ||
        data.roles.includes(ERole.Admin)
      ) {
        setSelectedTab(ETab.PublicApplications);
      }
    }
  }, [data]);

  if (!data) {
    return <TopBarProgress />;
  }

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

        {data.roles.includes(ERole.User) && (
          <Button
            variant="contained"
            onClick={() => navigate(ERoute.ADD_APPLICATION)}
            sx={{ minWidth: "158px" }}
          >
            Add Application
          </Button>
        )}
      </Stack>

      {selectedTab && (
        <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
          <Tabs
            value={selectedTab}
            onChange={handleChange}
            aria-label="basic tabs example"
          >
            {data.roles.includes(ERole.User) && (
              <Tab label="My Applications" value={ETab.MyApplications} />
            )}

            {(data.roles.includes(ERole.Doctor) ||
              data.roles.includes(ERole.Admin)) && (
              <Tab label="Public Applictions" value={ETab.PublicApplications} />
            )}

            {data.roles.includes(ERole.Doctor) && (
              <Tab
                label="Applied Applictions"
                value={ETab.AppliedApplications}
              />
            )}
          </Tabs>
        </Box>
      )}

      {selectedTab === ETab.MyApplications && <OwnApplicationList />}
      {selectedTab === ETab.PublicApplications && <PublicApplicationList />}
      {selectedTab === ETab.AppliedApplications && <AppliedApplicationList />}
    </Stack>
  );
};

export default ApplicationListPage;
