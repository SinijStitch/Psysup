import { GetApplicationsResponse } from "types/applications/GetApplicationsResponse";
import { apiSlice } from "./apiSlice";
import { GetApplicationsRequest } from "types/applications/GetApplicationsRequest";
import { ERoute } from "enums/ERoute";
import CreateApplicationRequest from "types/applications/CreateApplicationRequest";

export const applicationsApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getOwnApplications: builder.query<
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
                type: "OwnApplication" as const,
                id
              })),
              { type: "OwnApplication", id: "LIST" }
            ]
          : [{ type: "OwnApplication", id: "LIST" }],
      keepUnusedDataFor: 3600
    }),
    getPublicApplications: builder.query<
      GetApplicationsResponse,
      GetApplicationsRequest
    >({
      query: (request) => ({
        url: ERoute.APPLICATIONS_PUBLIC,
        params: request
      }),
      providesTags: (result) =>
        result
          ? [
              ...result.applications.map(({ id }) => ({
                type: "PublicApplication" as const,
                id
              })),
              { type: "PublicApplication", id: "LIST" }
            ]
          : [{ type: "PublicApplication", id: "LIST" }],
      keepUnusedDataFor: 3600
    }),
    getAppliedApplications: builder.query<
      GetApplicationsResponse,
      GetApplicationsRequest
    >({
      query: (request) => ({
        url: ERoute.APPLICATIONS_APPLIED,
        params: request
      }),
      providesTags: (result) =>
        result
          ? [
              ...result.applications.map(({ id }) => ({
                type: "AppliedApplication" as const,
                id
              })),
              { type: "AppliedApplication", id: "LIST" }
            ]
          : [{ type: "AppliedApplication", id: "LIST" }],
      keepUnusedDataFor: 3600
    }),
    createApplication: builder.mutation<void, CreateApplicationRequest>({
      query: (body) => ({
        url: ERoute.APPLICATIONS,
        method: "POST",
        body
      }),
      invalidatesTags: [{ type: "OwnApplication", id: "LIST" }]
    }),
    deleteApplication: builder.mutation<void, string>({
      query: (id) => ({
        url: ERoute.APPLICATION.replace(":id", id),
        method: "DELETE"
      }),
      invalidatesTags: (_result, _error, arg) => [
        { type: "OwnApplication", id: arg },
        { type: "PublicApplication", id: arg }
      ]
    }),
    applyApplication: builder.mutation<void, string>({
      query: (id) => ({
        url: `/applications/apply/${id}`,
        method: "POST"
      }),
      invalidatesTags: () => [
        { type: "AppliedApplication", id: "LIST" },
        { type: "PublicApplication", id: "LIST" }
      ]
    })
  })
});

export const {
  useLazyGetOwnApplicationsQuery,
  useLazyGetPublicApplicationsQuery,
  useLazyGetAppliedApplicationsQuery,
  useCreateApplicationMutation,
  useDeleteApplicationMutation,
  useApplyApplicationMutation
} = applicationsApiSlice;
