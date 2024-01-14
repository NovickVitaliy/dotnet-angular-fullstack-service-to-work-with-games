import {Component, OnInit} from '@angular/core';
import {FormArray, FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthenticationService} from "../../../../core/authentication/services/authentication.service";
import {ChangeAccountDataRequest} from "../../../../shared/models/dtos/change-account-data-request";
import {FormValidatorsService} from "../../../../core/services/form-validators.service";
import {AccountService} from "../../../../core/services/account.service";
import {ToastrService} from "ngx-toastr";
import {map, take} from "rxjs";

@Component({
  selector: 'app-edit-account-data',
  templateUrl: './edit-account-data.component.html',
  styleUrl: './edit-account-data.component.scss'
})
export class EditAccountDataComponent implements OnInit {
  editForm: FormGroup = new FormGroup<any>({});
  userEmail: string = '';
  platforms = [
    {platform: 'Playstation', selected: false, id: 1},
    {platform: 'Xbox', selected: false, id: 2},
    {platform: 'Nintendo Switch', selected: false, id: 3},
    {platform: 'Pc', selected: false, id: 4}
  ];

  constructor(private formBuilder: FormBuilder,
              private authenticationService: AuthenticationService,
              private formValidator: FormValidatorsService,
              private accountService: AccountService,
              private toastrService: ToastrService) {
  }

  ngOnInit(): void {
    this.initializeForm();
    this.setCurrentUserEmail();
  }

  private setCurrentUserEmail(){
    this.authenticationService.currentUser$.subscribe({
      next: user => {
        if(user){
          this.userEmail = user.email;
        }
      },
      error: err => {
        console.log(err)
      }
    })
  }

  private initializeForm() {
    this.editForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      username: ['', [Validators.required]],
      location: ['', [Validators.required]],
      description: [''],
      platforms: this.createPlatformsControls()
    });

    this.authenticationService.currentUser$.subscribe({
      next: user => {
        if(user){
          this.editForm.patchValue(user);
        }
      }
    })
  }

  editAccountData() {
    const editRequest = this.getEditRequest();
    this.accountService.changeAccountData(editRequest).subscribe({
      next: _ => {
        this.editForm.patchValue(editRequest);
        this.toastrService.success("Editing account data was successfully");
        this.authenticationService.currentUser$.pipe(take(1)).subscribe(user => {
          if(user){
            Object.assign(user, editRequest);
            console.log("editAccountData" + user);
            this.authenticationService.setCurrentUser(user);
          } else {
            console.log("loh")
          }
        });
      },
      error: error => {
        this.toastrService.error(error.error);
      }
    });
  }

  private getEditRequest(){
    const selectedPlatforms = this.getPlatforms.controls
      .map((control, index) => control.value ? this.platforms[index].platform : null)
      .filter(platform => platform !== null);
    const editAccountDataRequest: ChangeAccountDataRequest = {...this.editForm.value, platforms: selectedPlatforms, email: this.userEmail};
    return editAccountDataRequest;
  }

  get getPlatforms(): FormArray {
    return this.editForm.get('platforms') as FormArray;
  }

  private createPlatformsControls() {
    const arr = this.platforms.map(platform => {
      return this.formBuilder.control(platform.selected);
    });
    return this.formBuilder.array(arr, this.formValidator.atLeastOneItemSelected());
  }
}