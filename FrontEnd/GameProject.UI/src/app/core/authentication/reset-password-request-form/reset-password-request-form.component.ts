import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {SendResetPasswordRequest} from "../../../shared/models/dtos/identity/send-reset-password-request";
import {environment} from "../../../../environments/environment.development";
import {ResetPasswordService} from "../../services/reset-password.service";
import {ToastrService} from "ngx-toastr";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-reset-password-request-form',
  templateUrl: './reset-password-request-form.component.html',
  styleUrl: './reset-password-request-form.component.scss'
})
export class ResetPasswordRequestFormComponent implements OnInit {
  resetPasswordRequestForm: FormGroup = new FormGroup<any>({});

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private resetPasswordService: ResetPasswordService,
              private toastr: ToastrService) {
  }

  cancel() {
    console.log("cancel")
    this.router.navigateByUrl('home').then(r => console.log(r));
  }

  sendResetMessage() {
    const sendMessageRequest: SendResetPasswordRequest = {
      email: this.resetPasswordRequestForm.value.email,
      resetPasswordUrl: environment.resetPasswordUrl
    };

    this.resetPasswordService.sendResetPasswordMessage(sendMessageRequest)
      .subscribe({
        next: _ => {
          this.toastr.success("Password resetting email has been sent to you");
        },
        error: (error: HttpErrorResponse) => {
          this.toastr.error(error.message);
        }
      });
  }

  ngOnInit(): void {
    this.initializeForm();
  }

  private initializeForm() {
    this.resetPasswordRequestForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }
}
