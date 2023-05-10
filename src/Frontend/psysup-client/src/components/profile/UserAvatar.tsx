import { Avatar } from "@mui/material";
import React from "react";
import { useGetProfileQuery } from "redux/api/profileApiSlice";
import { selectImageUniqeId } from "redux/globalSlice";
import { useAppSelector } from "redux/hooks";

interface UserAvatarProps {
  width?: string;
  height?: string;
  imageUrl?: string;
}

const UserAvatar: React.FC<UserAvatarProps> = ({ width, height }) => {
  const { data } = useGetProfileQuery();
  const imageUniqueId = useAppSelector(selectImageUniqeId);

  return (
    <Avatar
      src={`${process.env.REACT_APP_BASE_URL}/${data?.imagePath}?${imageUniqueId}`}
      sx={{ width, height }}
    />
  );
};

export default UserAvatar;
