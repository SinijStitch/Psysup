import {
  Avatar,
  Box,
  Button,
  CircularProgress,
  Paper,
  Stack,
  TextField,
  Typography
} from "@mui/material";
import PageTitle from "components/common/PageTitle";
import React from "react";
import {
  useGetProfileQuery,
  useUpdateProfileMutation
} from "redux/api/profileApiSlice";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { Controller, useForm } from "react-hook-form";
import { toast } from "react-toastify";
import { useAppSelector } from "redux/hooks";
import { selectImageUniqeId } from "redux/globalSlice";
import LoadingButton from "components/common/LoadingButton";
import FormInput from "components/common/FormInput";

interface ProfileFormData {
  email?: string;
  password?: string;
  firstName?: string;
  lastName?: string;
  imagePath?: string;
}

const schema = yup.object().shape({
  email: yup.string().email().required(),
  password: yup.string().notRequired(),
  firstName: yup.string().min(1).max(100).required().label('First Name'),
  lastName: yup.string().min(1).max(100).required().label('Last Name')
});

const ProfilePage: React.FC = () => {
  const { data } = useGetProfileQuery();
  const imageUniqueId = useAppSelector(selectImageUniqeId);
  const [selectedImage, setSelectedImage] = React.useState<File>();
  const [updateProfile, { isLoading, isSuccess, reset }] =
    useUpdateProfileMutation();

  const {
    handleSubmit,
    setValue,
    control,
    formState: { errors }
  } = useForm<ProfileFormData>({
    resolver: yupResolver(schema),
    defaultValues: {
      email: data?.email,
      firstName: data?.firstName,
      lastName: data?.lastName,
      imagePath: `${process.env.REACT_APP_BASE_URL}/${data?.imagePath}?${imageUniqueId}`
    }
  });

  if (isSuccess) {
    toast.success("Profile successfully updated", {
      toastId: "success"
    });
    reset();
  }

  const handleFormSubmit = handleSubmit(async (requestData) => {
    const formData = new FormData();
    if (requestData.email) {
      formData.append("email", requestData.email);
    }

    if (requestData.password) {
      formData.append("newPassword", requestData.password);
    }

    if (requestData.firstName) {
      formData.append("firstName", requestData.firstName);
    }

    if (requestData.lastName) {
      formData.append("lastName", requestData.lastName);
    }

    if (selectedImage) {
      formData.append("image", selectedImage, selectedImage.name);
    }

    await updateProfile(formData);
  });

  const handleImagePreview = async (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];

    if (file) {
      setSelectedImage(file);
      const url = URL.createObjectURL(file);
      setValue("imagePath", url);
    }
  };

  return (
    <Stack spacing={5} height="100%">
      <PageTitle text="Profile" />
      <Paper component={Box} p={5} alignSelf="center" width="600px">
        <Stack
          component="form"
          onSubmit={handleFormSubmit}
          alignItems="center"
          spacing={3}
        >
          <Stack>
            <Controller
              name="imagePath"
              control={control}
              defaultValue=""
              render={({ field }) => (
                <Avatar
                  src={field.value}
                  sx={{ width: "120px", height: "120px" }}
                />
              )}
            />
            <Button component="label">
              <Typography>Edit</Typography>
              <input
                type="file"
                accept="image/*"
                hidden
                multiple
                onChange={handleImagePreview}
              />
            </Button>
          </Stack>

          <Stack direction="row" useFlexGap spacing={2} width="100%">
            <FormInput
              name="firstName"
              type="text"
              label="First Name"
              control={control}
              fieldError={errors?.firstName}
            />
            <FormInput
              name="lastName"
              type="text"
              label="Last Name"
              control={control}
              fieldError={errors?.lastName}
            />
          </Stack>

          <FormInput
            name="email"
            type="text"
            label="Email"
            control={control}
            fieldError={errors?.email}
          />
          <FormInput
            name="password"
            type="password"
            label="New Password"
            control={control}
            fieldError={errors?.password}
          />

          <LoadingButton type="submit" fullWidth isLoading={isLoading}>
            <Typography>Update Profile</Typography>
          </LoadingButton>
        </Stack>
      </Paper>
    </Stack>
  );
};

export default ProfilePage;
