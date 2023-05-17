import { GetApplicationsResponse } from "types/applications/GetApplicationsResponse";
import { apiSlice } from "./apiSlice";
import { GetApplicationsRequest } from "types/applications/GetApplicationsRequest";
import { ERoute } from "enums/ERoute";
import CreateApplicationRequest from "types/applications/CreateApplicationRequest";

export const applicationsApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getApplications: builder.query<
      GetApplicationsResponse,
      GetApplicationsRequest
    >({
      query: (request) => ({
        url: ERoute.APPLICATIONS,
        params: request
      }),
      providesTags: (result) =>
        result
          ? [
              ...result.applications.map(({ id }) => ({
                type: "Application" as const,
                id
              })),
              { type: "Application", id: "LIST" }
            ]
          : [{ type: "Application", id: "LIST" }]
    }),
    createApplication: builder.mutation<void, CreateApplicationRequest>({
      query: (body) => ({
        url: ERoute.APPLICATIONS,
        method: "POST",
        body
      }),
      invalidatesTags: [{ type: "Application", id: "LIST" }]
    }),
    deleteApplication: builder.mutation<void, string>({
      query: (id) => ({
        url: ERoute.APPLICATION.replace(":id", id),
        method: "DELETE"
      }),
      invalidatesTags: (_result, _error, arg) => [
        { type: "Application", id: arg }
      ]
    })
  })
});

export const {
  useGetApplicationsQuery,
  useLazyGetApplicationsQuery,
  useCreateApplicationMutation,
  useDeleteApplicationMutation
} = applicationsApiSlice;
