import {Component, OnInit} from '@angular/core';
import {ConfirmEmailService} from "../../services/confirm-email.service";
import {ActivatedRoute, ActivatedRouteSnapshot, Router} from "@angular/router";
import {Toast, ToastrService} from "ngx-toastr";
import {ConfirmEmailRequest} from "../../../shared/models/dtos/identity/confirm-email-request";

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrl: './confirm-email.component.scss'
})
export class ConfirmEmailComponent implements OnInit {
  isEmailConfirmed: boolean = false;
  email: string;
  confirmEmailToken: string;

  constructor(private confirmEmailService: ConfirmEmailService,
              private activatedRoute: ActivatedRoute,
              private router: Router,
              private toastrService: ToastrService) {
  }

  ngOnInit(): void {
    console.log("Confirm email component")
    this.email = this.activatedRoute.snapshot.queryParams['email']
    this.confirmEmailToken = this.activatedRoute.snapshot.queryParams['token'];
  }

  confirmEmail() {
    const confirmEmailRequest: ConfirmEmailRequest = {
      confirmToken: this.confirmEmailToken,
      email: this.email
    }

    this.confirmEmailService.confirmEmail(confirmEmailRequest)
      .subscribe({
        next: _ => {
          this.toastrService.success("Email has been successfully confirmed");
          this.router.navigateByUrl('')
        }
      });
  }
}
