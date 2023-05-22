import { apiSlice } from "./apiSlice";
import { ERoute } from "enums/ERoute";
import GetUsersResponse from "types/users/GetUsersResponse";
import GetUsersRequest from "types/users/GetUsersRequest";
import ChangeUserRoleRequest from "types/users/ChangeUserRoleRequest";

export const usersApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getUsers: builder.query<GetUsersResponse, GetUsersRequest>({
      query: (params) => ({
        url: ERoute.USERS,
        method: "GET",
        params
      }),
      providesTags: (result) =>
        result
          ? [
              ...result.users.map(({ id }) => ({
                type: "User" as const,
                id
              })),
              { type: "User", id: "LIST" }
            ]
          : [{ type: "User", id: "LIST" }]
    }),
    deleteUser: builder.mutation<void, string>({
      query: (id) => ({
        url: ERoute.USER.replace(":id", id),
        method: "DELETE"
      }),
      invalidatesTags: (_result, _error, arg) => [{ type: "User", id: arg }]
    }),
    changeUserRole: builder.mutation<void, ChangeUserRoleRequest>({
      query: (request) => ({
        url: ERoute.USER.replace(":id", request.id),
        method: "PUT",
        body: {
          roles: request.roles
        }
      }),
      invalidatesTags: (_result, _error, arg) => [{ type: "User", id: arg.id }]
    })
  })
});

export const {
  useGetUsersQuery,
  useDeleteUserMutation,
  useChangeUserRoleMutation
} = usersApiSlice;
