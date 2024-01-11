import {Component, OnInit} from '@angular/core';
import {QuoteService} from "../../services/quote.service";
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {ConfigureAccountRequest} from "../../../shared/models/configure-account-request";
import {AccountService} from "../services/account.service";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

@Component({
  selector: 'app-configure-account',
  templateUrl: './configure-account.component.html',
  styleUrl: './configure-account.component.scss'
})
export class ConfigureAccountComponent implements OnInit{
  quote: {quote: string, author: string} | null = null;
  platforms = [
    {platform: 'Playstation', selected: false, id:1 },
    {platform: 'Xbox', selected: false, id: 2 },
    {platform: 'Nintendo Switch', selected: false, id: 3 },
    {platform: 'Pc', selected: false, id: 4 }
  ];
  configureForm: FormGroup = new FormGroup<any>({});
  constructor(private quoteService: QuoteService,
              private formBuilder: FormBuilder,
              private accountService: AccountService,
              private toastrService: ToastrService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.initializeForm();
    this.quote = this.quoteService.getRandomQuote();
  }

  initializeForm(){
    this.configureForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      country: ['', [Validators.required]],
      description: [''],
      platforms: this.createPlatformsControls()
    });
  }

  configureAccount(){
    const selectedPlatforms = this.getPlatforms.controls
      .map((control, index) => control.value ? this.platforms[index].platform : null)
      .filter(platform => platform !== null);
    const configureRequest: ConfigureAccountRequest = {...this.configureForm.value, platforms: selectedPlatforms};

    this.accountService.configureAccount(configureRequest).subscribe({
      next: response => {
        this.accountService.userJustRegistered = false;
        this.toastrService.success("Configuration finished. Welcome!");
        localStorage.removeItem('configurable')
        this.router.navigateByUrl('/');
      },
      error: err => {
        console.log(err)
        this.toastrService.error(err.error);
      }
    });
  }

  get getPlatforms(): FormArray {
    return this.configureForm.get('platforms') as FormArray;
  }

  private createPlatformsControls() {
    const arr = this.platforms.map(platform => {
      return this.formBuilder.control(platform.selected);
    });
    return this.formBuilder.array(arr);
  }

}
