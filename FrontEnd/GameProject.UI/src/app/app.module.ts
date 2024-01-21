import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {FeaturesModule} from "./features/features.module";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {ToastrModule} from "ngx-toastr";
import {HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptors} from "@angular/common/http";
import {authenticationInterceptor} from "./core/interceptors/authentication.interceptor";
import {CoreModule} from "./core/core.module";
import {emailInterceptor} from "./core/interceptors/email.interceptor";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FeaturesModule,
    CoreModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass :'toast-bottom-right'
    }),
  ],
  providers: [
    provideHttpClient(withInterceptors([authenticationInterceptor, emailInterceptor]))
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
