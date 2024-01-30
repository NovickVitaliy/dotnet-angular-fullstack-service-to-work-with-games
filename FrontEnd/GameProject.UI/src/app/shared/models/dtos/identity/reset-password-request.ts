export interface ResetPasswordRequest{
  newPassword: string;
  newPasswordConfirm: string;
  token: string;
  email: string;
}
