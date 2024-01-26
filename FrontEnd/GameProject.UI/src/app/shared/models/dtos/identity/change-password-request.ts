export interface ChangePasswordRequest {
  email: string;
  oldPassword: string;
  newPassword: string;
  newPasswordRepeat: string;
}
