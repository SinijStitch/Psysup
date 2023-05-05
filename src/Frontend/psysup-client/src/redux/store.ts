import { configureStore, ThunkAction, Action } from "@reduxjs/toolkit";
import { apiSlice } from "./api/apiSlice";
import globalReducer from "./globalSlice";
import { errorMiddleware } from "./middlewares/errorMiddleware";

export const store = configureStore({
  reducer: {
    global: globalReducer,
    [apiSlice.reducerPath]: apiSlice.reducer
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(errorMiddleware).concat(apiSlice.middleware),
  devTools: true
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
