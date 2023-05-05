import { Middleware, isRejectedWithValue } from "@reduxjs/toolkit";
import { toast, Flip } from "react-toastify";

export const errorMiddleware: Middleware = () => (next) => (action) => {
  if (isRejectedWithValue(action)) {
    if (action.payload.status === 401) {
      return next(action);
    }

    let toastId: string;
    let message: string;

    if (action.payload?.data) {
      toastId = action.payload.data.message;
      message = action.payload.data.message;
    } else {
      toastId = "general-error";
      message = "Something went wrong!";
    }

    toast.error(message, {
      toastId,
      transition: Flip
    });
  }

  return next(action);
};
