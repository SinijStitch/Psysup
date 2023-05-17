import GetCategoriesResponse from "types/categories/GetCategoriesResponse";
import CreateCategoryRequest from "types/categories/CreateCategoryRequest";
import { apiSlice } from "./apiSlice";
import { ERoute } from "enums/ERoute";

const categoriesApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getCategories: builder.query<GetCategoriesResponse, void>({
      query: () => ERoute.CATEGORIES,
      providesTags: (result) =>
        result
          ? [
              ...result.categories.map(({ id }) => ({
                type: "Category" as const,
                id
              })),
              { type: "Category", id: "LIST" }
            ]
          : [{ type: "Category", id: "LIST" }]
    }),
    createCategory: builder.mutation<void, CreateCategoryRequest>({
      query: (body) => ({
        url: ERoute.CATEGORIES,
        method: "POST",
        body
      }),
      invalidatesTags: [{ type: "Category", id: "LIST" }]
    }),
    deleteCategory: builder.mutation<void, string>({
      query: (id) => ({
        url: ERoute.CATEGORY.replace(":id", id),
        method: "DELETE"
      }),
      invalidatesTags: (_result, _error, arg) => [{ type: "Category", id: arg }]
    })
  })
});

export const {
  useGetCategoriesQuery,
  useCreateCategoryMutation,
  useDeleteCategoryMutation
} = categoriesApiSlice;
