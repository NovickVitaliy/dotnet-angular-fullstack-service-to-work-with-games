import { Injectable } from '@angular/core';
import {AbstractControl, ValidationErrors, ValidatorFn} from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class FormValidatorsService {

  constructor() { }

  public compare(compareFieldName: string): ValidatorFn{
    return (control: AbstractControl): ValidationErrors | null => {
      let controlToCompare = control.parent?.get(compareFieldName);

      if(!controlToCompare) return null;

      if(control.value === controlToCompare.value){
        return null;
      }
      return {comparePassword: {valid: false}}
    }
  }
}
