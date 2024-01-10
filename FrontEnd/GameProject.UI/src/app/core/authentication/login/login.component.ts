import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AccountService} from "../services/account.service";
import {LoginRequest} from "../../../shared/models/login-request";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder,
              private accountService: AccountService,
              private toastrService: ToastrService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
  }

  login() {
    let loginRequest: LoginRequest = {...this.loginForm.value};
    this.accountService.login(loginRequest).subscribe({
      next: _ => {
          this.router.navigateByUrl('');
      },
      error: err => {
        this.toastrService.error(err.error.description);
      }
    });
  }
}
