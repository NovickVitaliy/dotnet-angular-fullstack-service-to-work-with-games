import { Injectable } from '@angular/core';
import {AbstractControl, Form, FormArray, ValidationErrors, ValidatorFn} from "@angular/forms";

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
      return {compare: {valid: false}}
    }
  }

  public atLeastOneItemSelected(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const formArray = control as FormArray;
      const atLeastOneSelected = formArray.controls.some(control => control.value === true);
      return atLeastOneSelected ? null : { atLeastOneItemSelected: true };
    }
  }
}
