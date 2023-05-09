import {
  Avatar,
  Box,
  Button,
  Paper,
  Stack,
  TextField,
  Typography
} from "@mui/material";
import PageTitle from "components/common/PageTitle";
import UserAvatar from "components/profile/UserAvatar";
import React from "react";
import {
  useGetProfileQuery,
  useUpdateProfileMutation
} from "redux/api/profileApiSlice";

interface Data {
  email?: string;
}

const ProfilePage: React.FC = () => {
  const { data } = useGetProfileQuery();
  const [email, setEmail] = React.useState<string | undefined>(data?.email);
  const [updateProfile, { isLoading }] = useUpdateProfileMutation();

  const handleUpload = async (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];

    if (file) {
      const formData = new FormData();
      formData.append("image", file, file.name);
      await updateProfile(formData);
    }
  };

  return (
    <Stack spacing={5} height="100%">
      <PageTitle text="Profile" />
      <Paper component={Box} p={5} alignSelf="center" minWidth="500px">
        <Stack alignItems="center" spacing={3}>
          <Stack>
            <UserAvatar width="120px" height="120px" />
            <Button component="label">
              <Typography>Edit</Typography>
              <input
                type="file"
                accept="image/*"
                hidden
                multiple
                onChange={handleUpload}
              />
            </Button>
          </Stack>

          <TextField
            label="Email"
            fullWidth
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
          <TextField label="Old Password" fullWidth />
          <TextField label="New Password" fullWidth />

          <Button variant="contained">Update Profile</Button>
        </Stack>
      </Paper>
    </Stack>
  );
};

export default ProfilePage;
