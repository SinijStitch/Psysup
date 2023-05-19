import {
  Box,
  List,
  ListItem,
  ListItemText,
  Paper,
  Stack,
  TextField,
  Typography
} from "@mui/material";
import LoadingButton from "components/common/LoadingButton";
import PageTitle from "components/common/PageTitle";
import DeleteCancelDialog from "components/common/dialogs/DeleteCancelDialog";
import React from "react";
import TopBarProgress from "react-topbar-progress-indicator";
import {
  useCreateCategoryMutation,
  useDeleteCategoryMutation,
  useGetCategoriesQuery
} from "redux/api/categoriesApiSlice";

const CategoriesPage: React.FC = () => {
  const [categoryName, setCategoryName] = React.useState<string>("");
  const [categoryNameError, setCategoryNameError] = React.useState<string>("");
  const [deleteId, setDeleteId] = React.useState<string>("");
  const [isOpenDialog, setIsOpenDialog] = React.useState<boolean>(false);
  const getCategoryResult = useGetCategoriesQuery();
  const [createCategory, createCategoryResult] = useCreateCategoryMutation();
  const [deleteCategory, deleteCategoryResult] = useDeleteCategoryMutation();

  const handleCategoryNameChange = (newCategoryName: string) => {
    let error = "";

    if (!newCategoryName) {
      error = "The category name cannot be empty";
    } else if (newCategoryName.length < 2) {
      error = "The category name length must be greater that 1";
    } else if (newCategoryName.length > 50) {
      error = "The category name length must be less that 50";
    }

    setCategoryName(newCategoryName);
    setCategoryNameError(error);
  };

  if (getCategoryResult.isLoading) {
    return <TopBarProgress />;
  }

  if (createCategoryResult.isSuccess) {
    createCategoryResult.reset();
    setCategoryName("");
    setCategoryNameError("");
  }

  return (
    <Stack useFlexGap gap={5}>
      <PageTitle text="Categories" />

      <Paper component={Box} p={5} alignSelf="center" minWidth="600px">
        <Stack useFlexGap spacing={2}>
          <TextField
            fullWidth
            label="Category Name"
            value={categoryName}
            onChange={(e) => handleCategoryNameChange(e.target.value)}
            error={!!categoryNameError}
            helperText={categoryNameError}
          />

          <LoadingButton
            fullWidth
            variant="contained"
            disabled={!categoryName || !!categoryNameError}
            isLoading={createCategoryResult.isLoading}
            onClick={() => createCategory({ name: categoryName })}
          >
            Add Category
          </LoadingButton>

          {getCategoryResult.data &&
          getCategoryResult.data.categories.length > 0 ? (
            <List>
              {getCategoryResult.data.categories.map((category) => (
                <ListItem
                  key={category.id}
                  divider
                  secondaryAction={
                    <LoadingButton
                      variant="outlined"
                      color="error"
                      isLoading={
                        deleteCategoryResult.originalArgs === category.id &&
                        deleteCategoryResult.isLoading
                      }
                      disabled={deleteCategoryResult.isLoading}
                      onClick={() => {
                        setDeleteId(category.id);
                        setIsOpenDialog(true);
                      }}
                      sx={{ width: "100px" }}
                    >
                      Delete
                    </LoadingButton>
                  }
                >
                  <ListItemText primary={category.name} />
                </ListItem>
              ))}
            </List>
          ) : (
            <Typography variant="h6" align="center">There are no categories</Typography>
          )}
        </Stack>
      </Paper>
      <DeleteCancelDialog
        title="Delete category"
        content="Do you want to delete the category?"
        isOpen={isOpenDialog}
        onSuccess={() => {
          deleteCategory(deleteId);
          setDeleteId("");
          setIsOpenDialog(false);
        }}
        onCancel={() => {
          setDeleteId("");
          setIsOpenDialog(false);
        }}
      />
    </Stack>
  );
};

export default CategoriesPage;
