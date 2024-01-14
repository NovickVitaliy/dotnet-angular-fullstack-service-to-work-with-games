import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AccountService} from "../../../../core/services/account.service";
import {ToastrService} from "ngx-toastr";
import {FormValidatorsService} from "../../../../core/services/form-validators.service";
import {ChangePasswordRequest} from "../../../../shared/models/dtos/change-password-request";
import {AuthenticationService} from "../../../../core/authentication/services/authentication.service";

@Component({
  selector: 'app-edit-account-security',
  templateUrl: './edit-account-security.component.html',
  styleUrl: './edit-account-security.component.scss'
})
export class EditAccountSecurityComponent implements OnInit {
  changeAccountPasswordForm: FormGroup = new FormGroup<any>({});

  constructor(private accountService: AccountService,
              private formBuilder: FormBuilder,
              private toastrService: ToastrService,
              private formValidator: FormValidatorsService,
              private authenticationService: AuthenticationService) {

  }

  ngOnInit(): void {
    this.initializeForm();
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
}
