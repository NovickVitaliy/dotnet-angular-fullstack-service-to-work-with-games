import {Component, OnInit} from '@angular/core';
import {User} from "../../../../shared/models/user";
import {AdminNewsService} from "../../../../core/services/admin-news.service";
import {HttpErrorResponse} from "@angular/common/http";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-news',
  templateUrl: './add-news.component.html',
  styleUrl: './add-news.component.scss'
})
export class AddNewsComponent implements OnInit {
  adminEmail: string = '';
  newsTitle: string = '';
  newsContent: string = '';

  constructor(private adminNewsService: AdminNewsService,
              private toastr: ToastrService,
              private router: Router) {
  }
  ngOnInit(): void {
    this.loadUserEmail();
  }

  private loadUserEmail() {
    let userString  = localStorage.getItem('user');
    let user: User = JSON.parse(userString);
    this.adminEmail = user.email;
  }

  publishNews(){
    this.adminNewsService.publishNews({
      title: this.newsTitle,
      author: this.adminEmail,
      content: this.newsContent
    })
      .subscribe({
        next: _ => {
          this.toastr.success('News has been published');
          this.router.navigateByUrl('admin/admin-home').catch();
        },
        error: (err: HttpErrorResponse) => {
          this.toastr.error(err.message);
        }
      });
  }
}
