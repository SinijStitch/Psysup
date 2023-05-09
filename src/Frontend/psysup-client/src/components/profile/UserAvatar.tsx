import { Avatar } from "@mui/material";
import React from "react";
import { useGetProfileQuery } from "redux/api/profileApiSlice";

interface UserAvatarProps {
  width?: string;
  height?: string;
}

const UserAvatar: React.FC<UserAvatarProps> = ({ width, height }) => {
  const { data } = useGetProfileQuery();

  return (
    <Avatar
      src={`${process.env.REACT_APP_BASE_URL}/${data?.imagePath}`}
      sx={{ width, height }}
    />
  );
};

export default UserAvatar;
