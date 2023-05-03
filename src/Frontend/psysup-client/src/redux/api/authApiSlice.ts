import { AuthResponse } from "types/auth/AuthResponse";
import { apiSlice } from "./apiSlice";
import { LoginRequest } from "types/auth/LoginRequest";

export const authApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    login: builder.mutation<AuthResponse, LoginRequest>({
      query: (request) => ({
        url: "/auth/login",
        method: "POST",
        body: request
      })
    })
  })
});

export const { useLoginMutation } = authApiSlice;
