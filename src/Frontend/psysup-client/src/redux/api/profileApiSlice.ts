import { GetProfileResponse } from "types/profile/GetProfileResponse";
import { apiSlice } from "./apiSlice";

export const profileApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getProfile: builder.query<GetProfileResponse, void>({
      query: () => "/profile",
      providesTags: ["User"]
    })
  })
});

export const { useGetProfileQuery } = profileApiSlice;
