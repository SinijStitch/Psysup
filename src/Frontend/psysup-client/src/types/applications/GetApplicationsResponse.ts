import { GetApplicationsResponseItem } from "./GetApplicationsResponseItem";

export interface GetApplicationsResponse {
  totalCount: number;
  applications: GetApplicationsResponseItem[];
}
