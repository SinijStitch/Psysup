import { Typography } from "@mui/material";
import React from "react";

interface PageTitleProps {
  text: string;
}

const PageTitle: React.FC<PageTitleProps> = ({ text }) => {
  return <Typography component="h1" variant="h5" fontWeight={700}>{text}</Typography>;
};

export default PageTitle;
