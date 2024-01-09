import { Injectable } from '@angular/core';
import { themeChange } from 'theme-change'
@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  currentTheme: string = 'sony';
  pathToSonyIcon: string = 'assets/images/ps4.png';
  pathToMicrosoftIcon: string = 'assets/images/xbox.png';
  constructor() { }

  setCurrentTheme(theme: string){
    this.currentTheme = theme;
    themeChange(true);
    localStorage.setItem("currentTheme", theme);
  }

  getCurrentTheme(){
    let savedTheme = localStorage.getItem("currentTheme");
    if(savedTheme){
      return savedTheme;
    }
    return this.currentTheme;
  }
}
