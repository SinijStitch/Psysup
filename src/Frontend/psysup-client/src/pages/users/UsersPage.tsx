import {
  Button,
  Paper,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow
} from "@mui/material";
import LoadingButton from "components/common/LoadingButton";
import PageTitle from "components/common/PageTitle";
import DeleteCancelDialog from "components/common/dialogs/DeleteCancelDialog";
import ChangeUserRoleDialog from "components/users/ChangeUserRoleDialog";
import { ERole } from "enums/ERole";
import React from "react";
import TopBarProgress from "react-topbar-progress-indicator";
import {
  useChangeUserRoleMutation,
  useDeleteUserMutation,
  useGetUsersQuery
} from "redux/api/usersApiSlice";
import GetUsersResponseItem from "types/users/GetUsersResponseItem";

const UsersPage: React.FC = () => {
  const [isOpenDeleteUserDialog, setIsOpenDeleteUserDialog] =
    React.useState<boolean>(false);
  const [isOpenChangeUserRoleDialog, setIsOpenChangeUserRoleDialog] =
    React.useState<boolean>(false);
  const [user, setUser] = React.useState<GetUsersResponseItem>();
  const getUsersResult = useGetUsersQuery({
    pageNumber: 1,
    pageSize: 10
  });
  const [deleteUser, deleteUserResult] = useDeleteUserMutation();
  const [changeUserRole, changeUserRoleResult] = useChangeUserRoleMutation();

  const handleShowDeleteUserDialog = (user: GetUsersResponseItem) => {
    setUser(user);
    setIsOpenDeleteUserDialog(true);
  };

  const handleDeleteUserCancel = () => {
    setIsOpenDeleteUserDialog(false);
    setUser(undefined);
  };

  const handleDeleteUserSuccess = () => {
    if (user) {
      deleteUser(user.id);
    }
    setIsOpenDeleteUserDialog(false);
    setUser(undefined);
  };

  const handleShowChangeRoleDialog = (user: GetUsersResponseItem) => {
    setUser(user);
    setIsOpenChangeUserRoleDialog(true);
  };

  const handleChangeRoleCancel = () => {
    setIsOpenChangeUserRoleDialog(false);
    setUser(undefined);
  };

  const handleChangeRoleSave = (newRoles: ERole[]) => {
    if (user) {
      changeUserRole({ id: user.id, roles: newRoles });
    }
    setIsOpenChangeUserRoleDialog(false);
  };

  if (getUsersResult.isLoading) {
    return <TopBarProgress />;
  }

  if (!getUsersResult.data || getUsersResult.isError) {
    return null;
  }

  return (
    <Stack useFlexGap spacing={5}>
      {getUsersResult.isFetching && <TopBarProgress />}
      <PageTitle text="Users" />
      <TableContainer
        component={Paper}
        sx={{ maxWidth: "1200px", alignSelf: "center" }}
      >
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>ID</TableCell>
              <TableCell align="right">Email</TableCell>
              <TableCell align="right">First Name</TableCell>
              <TableCell align="right">Last Name</TableCell>
              <TableCell align="right">Roles</TableCell>
              <TableCell align="right">Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {getUsersResult.data.users.map((user) => (
              <TableRow
                key={user.id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {user.id}
                </TableCell>
                <TableCell align="right">{user.email}</TableCell>
                <TableCell align="right">{user.firstName}</TableCell>
                <TableCell align="right">{user.lastName}</TableCell>
                <TableCell align="right">{user.roles.join(", ")}</TableCell>
                <TableCell align="right">
                  <LoadingButton
                    variant="outlined"
                    sx={{ marginRight: "8px", width: "139px" }}
                    isLoading={
                      changeUserRoleResult.isLoading &&
                      changeUserRoleResult.originalArgs?.id === user.id
                    }
                    disabled={changeUserRoleResult.isLoading || user.roles.includes(ERole.Admin)}
                    onClick={() => handleShowChangeRoleDialog(user)}
                  >
                    Change Roles
                  </LoadingButton>
                  <LoadingButton
                    variant="outlined"
                    color="error"
                    sx={{ width: "84px" }}
                    isLoading={
                      deleteUserResult.isLoading &&
                      deleteUserResult.originalArgs === user.id
                    }
                    disabled={
                      deleteUserResult.isLoading ||
                      user.roles.includes(ERole.Admin)
                    }
                    onClick={() => handleShowDeleteUserDialog(user)}
                  >
                    Delete
                  </LoadingButton>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <DeleteCancelDialog
        isOpen={isOpenDeleteUserDialog}
        title="Delete User"
        content="Do you want to delete user?"
        onSuccess={handleDeleteUserSuccess}
        onCancel={handleDeleteUserCancel}
      />

      {user && (
        <ChangeUserRoleDialog
          isOpen={isOpenChangeUserRoleDialog}
          roles={user.roles as ERole[]}
          onCancel={handleChangeRoleCancel}
          onSave={(newRoles) => handleChangeRoleSave(newRoles)}
        />
      )}
    </Stack>
  );
};

export default UsersPage;
