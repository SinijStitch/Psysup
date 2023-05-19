import { GetProfileResponse } from "types/profile/GetProfileResponse";
import { apiSlice } from "./apiSlice";

export const profileApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getProfile: builder.query<GetProfileResponse, void>({
      query: () => "/profile",
      providesTags: ["User"]
    }),
    updateProfile: builder.mutation<void, FormData>({
      query: (body) => ({
        url: "/profile",
        method: "PUT",
        body
      }),
      invalidatesTags: ["User"]
    })
  })
});

export const { useGetProfileQuery, useUpdateProfileMutation } = profileApiSlice;
