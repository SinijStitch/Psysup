import {
  Paper,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow
} from "@mui/material";
import PageTitle from "components/common/PageTitle";
import React from "react";
import TopBarProgress from "react-topbar-progress-indicator";
import { useGetUsersQuery } from "redux/api/usersApiSlice";

const UsersPage: React.FC = () => {
  const { data, isLoading, isError } = useGetUsersQuery({
    pageNumber: 1,
    pageSize: 10
  });

  if (isLoading) {
    return <TopBarProgress />;
  }

  if (!data || isError) {
    return null;
  }

  return (
    <Stack useFlexGap spacing={5}>
      <PageTitle text="Users" />
      <TableContainer component={Paper} sx={{ maxWidth: "1200px", alignSelf: "center" }}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>ID</TableCell>
              <TableCell align="right">Email</TableCell>
              <TableCell align="right">First Name</TableCell>
              <TableCell align="right">Last Name</TableCell>
              <TableCell align="right">Roles</TableCell>
              <TableCell align="right">Image Path</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data.users.map((user) => (
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
                <TableCell align="right">{user.imagePath}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Stack>
  );
};

export default UsersPage;
