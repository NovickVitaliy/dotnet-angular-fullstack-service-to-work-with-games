import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {FormValidatorsService} from "../../services/form-validators.service";
import {AccountService} from "../services/account.service";
import {RegisterRequest} from "../../../shared/models/register-request";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup = new FormGroup<any>({});

  constructor(private formBuilder: FormBuilder,
              private validatorService: FormValidatorsService,
              private accountService: AccountService,
              private toastr: ToastrService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.initializeForm()
  }

  initializeForm() {
    this.registerForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required, this.validatorService.compare('password')]]
    });

    this.registerForm.controls['password'].valueChanges.subscribe({
      next: value => {
        this.registerForm.controls['confirmPassword'].updateValueAndValidity();
      }
    });
  }

  register() {
    let registerRequest: RegisterRequest = {...this.registerForm.value};
    console.log(registerRequest);
    this.accountService.register(registerRequest).subscribe({
      next: value => {
        this.router.navigateByUrl('');
      },
      error: err => {
        this.toastr.error(err.error.description);
      }
    });
  }
}
