import { apiSlice } from "./apiSlice";
import { ERoute } from "enums/ERoute";
import GetUsersResponse from "types/users/GetUsersResponse";
import GetUsersRequest from "types/users/GetUsersRequest";

export const usersApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getUsers: builder.query<GetUsersResponse, GetUsersRequest>({
      query: (params) => ({
        url: ERoute.USERS,
        method: "GET",
        params
      })
    })
  })
});

export const { useGetUsersQuery } = usersApiSlice;
