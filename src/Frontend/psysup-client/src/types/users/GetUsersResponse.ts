import GetUsersResponseItem from "./GetUsersResponseItem";

export default interface GetUsersResponse {
  totalCount: number;
  users: GetUsersResponseItem[];
}