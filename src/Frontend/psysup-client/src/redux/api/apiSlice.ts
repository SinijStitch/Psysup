import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const apiSlice = createApi({
  baseQuery: fetchBaseQuery({
    baseUrl: process.env.REACT_APP_BASE_URL,
    credentials: "include"
  }),
  tagTypes: ["User", "OwnApplication", "PublicApplication", "AppliedApplication", "Category"],
  endpoints: () => ({})
});
