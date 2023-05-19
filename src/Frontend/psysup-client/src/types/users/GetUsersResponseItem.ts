export default interface GetUsersResponseItem {
  id: string;
  email: string;
  firstName: string;
  lastName: string;
  imagePath?: string;
  roles: string[];
}
