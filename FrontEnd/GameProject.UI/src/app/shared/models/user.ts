export interface User {
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  accessToken: string;
  refreshToken: string;
  platforms: string[];
  description: string;
  location: string;
  profilePhotoUrl?: string;
}
