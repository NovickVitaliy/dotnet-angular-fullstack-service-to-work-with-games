import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AccountService} from "../../../../core/services/account.service";
import {ToastrService} from "ngx-toastr";
import {FormValidatorsService} from "../../../../core/services/form-validators.service";
import {ChangePasswordRequest} from "../../../../shared/models/dtos/identity/change-password-request";
import {AuthenticationService} from "../../../../core/authentication/services/authentication.service";
import {SendConfirmEmailMessageRequest} from "../../../../shared/models/dtos/identity/send-confirm-email-message-request";
import {environment} from "../../../../../environments/environment.development";
import {ConfirmEmailService} from "../../../../core/services/confirm-email.service";
import {error} from "@angular/compiler-cli/src/transformers/util";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-edit-account-security',
  templateUrl: './edit-account-security.component.html',
  styleUrl: './edit-account-security.component.scss'
})
export class EditAccountSecurityComponent implements OnInit {
  changeAccountPasswordForm: FormGroup = new FormGroup<any>({});
  isEmailConfirmed: boolean;

  constructor(private accountService: AccountService,
              private formBuilder: FormBuilder,
              private toastrService: ToastrService,
              private formValidator: FormValidatorsService,
              private authenticationService: AuthenticationService,
              private confirmEmailService: ConfirmEmailService) {

  }

  ngOnInit(): void {
    this.initializeForm();
    this.authenticationService.currentUser$.subscribe({
      next: user => {
        this.isEmailConfirmed = user.emailConfirmed;
      }
    })
  }

  private initializeForm() {
    this.changeAccountPasswordForm = this.formBuilder.group({
      oldPassword: ['', [Validators.required]],
      newPassword: ['', [Validators.required]],
      newPasswordRepeat: ['', [Validators.required, this.formValidator.compare('newPassword')]]
    });

    this.changeAccountPasswordForm.controls['newPassword'].valueChanges.subscribe({
      next: value => {
        this.changeAccountPasswordForm.controls['newPasswordRepeat'].updateValueAndValidity();
      }
    });
  }

  changeAccountPassword(){
    const changePasswordRequest: ChangePasswordRequest = {...this.changeAccountPasswordForm.value};
    this.authenticationService.currentUserEmail.subscribe({
      next: email => {
        changePasswordRequest.email = email;
      }
    });
    this.accountService.changeAccountPassword(changePasswordRequest)
      .subscribe({
        next: _ => {
          this.toastrService.success("Password has been successfully changed");
        },
        error: error => {
          this.toastrService.error(error.error.description);
        }
      });
  }

  sendConfirmEmailMessage(){
    const confirmEmailRequest: SendConfirmEmailMessageRequest = {
      confirmUrl: environment.confirmEmailUrl
    }

    this.confirmEmailService.sendConfirmEmailMessage(confirmEmailRequest)
      .subscribe({
        next: _ => {
          this.toastrService.success("Confirmation email has been sent to your email")
        },
        error: (error: HttpErrorResponse) => {
          this.toastrService.error(error.message);
        }
      })
  }
}
