import { AuthResponse } from "types/auth/AuthResponse";
import { apiSlice } from "./apiSlice";
import { LoginRequest } from "types/auth/LoginRequest";
import { RegisterRequest } from "types/auth/RegisterRequest";

export const authApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    login: builder.mutation<AuthResponse, LoginRequest>({
      query: (request) => ({
        url: "/auth/login",
        method: "POST",
        body: request
      }),
      invalidatesTags: ["User"]
    }),
    register: builder.mutation<AuthResponse, RegisterRequest>({
      query: (request) => ({
        url: "/auth/register",
        method: "POST",
        body: request
      }),
      invalidatesTags: ["User"]
    }),
    logout: builder.mutation<void, void>({
      query: () => ({
        url: "/auth/logout",
        method: "POST"
      }),
      invalidatesTags: ["User"]
    })
  })
});

export const { useLoginMutation, useRegisterMutation, useLogoutMutation } =
  authApiSlice;
