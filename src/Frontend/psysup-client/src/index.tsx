import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";
import "react-toastify/dist/ReactToastify.css";

import React from "react";
import { createRoot } from "react-dom/client";
import { Provider } from "react-redux";
import { store } from "./redux/store";
import { ToastContainer } from "react-toastify";
import { CssBaseline, ThemeProvider, createTheme } from "@mui/material";
import TopBarProgress from "react-topbar-progress-indicator";
import App from "App";
import { BrowserRouter } from "react-router-dom";

const container = document.getElementById("root")!;
const root = createRoot(container);

TopBarProgress.config({});

const theme = createTheme();

root.render(
  <React.StrictMode>
    <Provider store={store}>
      <CssBaseline />
      <ToastContainer position="top-center" />
      <ThemeProvider theme={theme}>
        <BrowserRouter>
          <App />
        </BrowserRouter>
      </ThemeProvider>
    </Provider>
  </React.StrictMode>
);
