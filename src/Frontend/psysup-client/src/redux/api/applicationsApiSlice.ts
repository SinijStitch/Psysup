import { GetApplicationsResponse } from "types/applications/GetApplicationsResponse";
import { apiSlice } from "./apiSlice";
import { GetApplicationsRequest } from "types/applications/GetApplicationsRequest";

export const applicationsApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getApplications: builder.query<
      GetApplicationsResponse,
      GetApplicationsRequest
    >({
      query: (request) => ({
        url: "/applications",
        params: request
      })
    })
  })
});

export const { useGetApplicationsQuery } = applicationsApiSlice;
