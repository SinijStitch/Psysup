import { Box, Button, Paper, Stack, Typography } from "@mui/material";
import PageTitle from "components/common/PageTitle";
import { ERoute } from "enums/ERoute";
import React from "react";
import ArrowBackOutlinedIcon from "@mui/icons-material/ArrowBackOutlined";
import { Link, Navigate } from "react-router-dom";
import { useGetCategoriesQuery } from "redux/api/categoriesApiSlice";
import TopBarProgress from "react-topbar-progress-indicator";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import FormInput from "components/common/FormInput";
import LoadingButton from "components/common/LoadingButton";
import MultiSelectFormInput from "components/common/MultiSelectFormInput";
import { useCreateApplicationMutation } from "redux/api/applicationsApiSlice";

interface AddApplicationFormData {
  title: string;
  description: string;
  price: number;
}

const schema = yup.object().shape({
  title: yup.string().min(10).max(100).required(),
  description: yup.string().max(1000).required(),
  price: yup.number().min(1).required()
});

const AddApplicationPage: React.FC = () => {
  const getCategoriesResult = useGetCategoriesQuery();
  const [createApplication, createApplicationResult] =
    useCreateApplicationMutation();
  const [categories, setCategories] = React.useState<string[]>([]);

  const {
    handleSubmit,
    control,
    formState: { errors }
  } = useForm<AddApplicationFormData>({
    resolver: yupResolver(schema)
  });

  const handleCategoriesChange = (newCategories: string[]) => {
    setCategories(newCategories);
  };

  const handleFormSubmit = handleSubmit((data) => {
    createApplication({
      title: data.title,
      description: data.description,
      price: data.price,
      categories
    });
  });

  if (getCategoriesResult.isLoading || getCategoriesResult.isFetching) {
    return <TopBarProgress />;
  }

  if (getCategoriesResult.isError || !getCategoriesResult.data) {
    return <Typography variant="h1">Something went worg</Typography>;
  }

  if (createApplicationResult.isSuccess) {
    return <Navigate to={ERoute.APPLICATIONS} />;
  }

  return (
    <Stack spacing={5} useFlexGap>
      <Stack direction="row" gap={2}>
        <PageTitle text="Add Application" />
        <Button component={Link} to={ERoute.APPLICATIONS}>
          <ArrowBackOutlinedIcon />
          <Typography>Back</Typography>
        </Button>
      </Stack>

      <Box
        component={Paper}
        m="0 auto"
        p="24px"
        width="600px"
        textAlign="center"
        boxShadow={3}
        borderRadius={4}
        elevation={1}
      >
        <Typography variant="h4" component="h1">
          Appliction
        </Typography>

        <Box component="form" autoComplete="off" onSubmit={handleFormSubmit}>
          <FormInput
            name="title"
            type="text"
            label="Title"
            control={control}
            fieldError={errors?.title}
          />
          <Stack direction="row" useFlexGap spacing={2}>
            <FormInput
              name="price"
              type="number"
              label="Price"
              control={control}
              fieldError={errors?.price}
            />

            <MultiSelectFormInput
              label="Categories"
              values={getCategoriesResult.data.categories.map(
                (category) => category.name
              )}
              selectedValues={categories}
              onChange={handleCategoriesChange}
            />
          </Stack>

          <FormInput
            name="description"
            type="text"
            label="Description"
            multiline
            rows={6}
            control={control}
            fieldError={errors?.description}
          />

          <Box mt="8px">
            <LoadingButton
              type="submit"
              fullWidth
              isLoading={createApplicationResult.isLoading}
            >
              <Typography>Submit</Typography>
            </LoadingButton>
          </Box>
        </Box>
      </Box>
    </Stack>
  );
};

export default AddApplicationPage;
