import { ERole } from "enums/ERole";

export interface GetProfileResponse {
  id: string;
  email: string;
  firstName: string;
  lastName: string;
  imagePath?: string;
  roles: ERole[];
}
