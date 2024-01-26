import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {FormValidatorsService} from "../../services/form-validators.service";
import {AuthenticationService} from "../services/authentication.service";
import {RegisterRequest} from "../../../shared/models/dtos/identity/register-request";
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
              private authenticationService: AuthenticationService,
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
    this.authenticationService.register(registerRequest).subscribe({
      next: value => {
        this.authenticationService.userJustRegistered = true;
        localStorage.setItem("configurable", JSON.stringify(true));
        this.router.navigateByUrl('auth/configure');
      },
      error: err => {
        this.toastr.error(err.error.description);
      }
    });
  }
}
