import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {ResetPasswordService} from "../../services/reset-password.service";
import {ToastrService} from "ngx-toastr";
import {FormValidatorsService} from "../../services/form-validators.service";
import {ResetPasswordRequest} from "../../../shared/models/dtos/identity/reset-password-request";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.scss'
})
export class ResetPasswordComponent implements OnInit {
  resetPasswordForm: FormGroup = new FormGroup<any>({});
  resetPasswordToken: string;
  email: string;
  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private resetPasswordService: ResetPasswordService,
              private toastr: ToastrService,
              private formValidatorsService: FormValidatorsService,
              private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.initializeForm();
    this.resetPasswordToken = this.activatedRoute.snapshot.queryParams['token'];
    this.email = this.activatedRoute.snapshot.queryParams['email'];
  }

  private initializeForm() {
    this.resetPasswordForm = this.formBuilder.group({
      newPassword: ['', [Validators.required]],
      newPasswordConfirm: ['', [Validators.required, this.formValidatorsService.compare('newPassword')]]
    });
  }

  resetPassword(){
    const resetPasswordRequest: ResetPasswordRequest = {
      newPassword: this.resetPasswordForm.value.newPassword,
      newPasswordConfirm: this.resetPasswordForm.value.newPasswordConfirm,
      token: this.resetPasswordToken,
      email: this.email
    }

    console.log(resetPasswordRequest)

    this.resetPasswordService.resetPassword(resetPasswordRequest)
      .subscribe({
        next: _ => {
          this.toastr.success("Password has been successfully changed");
          this.router.navigateByUrl('auth/login');
        },
        error: (error: HttpErrorResponse) => {
          this.toastr.error(error.message);
        }
      });
  }

  cancel(){
    this.router.navigateByUrl("home").catch(err => console.log(err));
  }
}
