import {Component, OnInit} from '@angular/core';
import {QuoteService} from "../../services/quote.service";
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {ConfigureAccountRequest} from "../../../shared/models/configure-account-request";
import {AccountService} from "../services/account.service";
import {ToastrService} from "ngx-toastr";

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
              private toastrService: ToastrService) {
  }

  ngOnInit(): void {
    this.initializeForm();
    this.quote = this.quoteService.getRandomQuote();
  }

  initializeForm(){
    this.configureForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      location: ['', [Validators.required]],
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
        this.toastrService.success("Configuration finished. Welcome!")
      },
      error: err => {
        this.toastrService.error(err.error.description);
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
