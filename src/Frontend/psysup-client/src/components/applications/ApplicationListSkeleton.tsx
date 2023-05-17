import { Grid, Card, CardContent, Skeleton, CardActions } from "@mui/material";
import React from "react";

const ApplicationListSkeleton: React.FC = () => {
  return (
    <Grid container component="ul" p={0} gap={2}>
      {[
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
      ].map((item) => (
        <Grid key={item}>
          <Card component="li" sx={{ width: "300px" }}>
            <CardContent>
              <Skeleton variant="text" animation="wave" />
            </CardContent>
            <CardActions>
              <Skeleton variant="text" width={60} animation="wave" />
            </CardActions>
          </Card>
        </Grid>
      ))}
    </Grid>
  );
};

export default ApplicationListSkeleton;
