import { ERole } from "enums/ERole";

export interface GetProfileResponse {
  id: string;
  email: string;
  imagePath?: string;
  roles: ERole[];
}
