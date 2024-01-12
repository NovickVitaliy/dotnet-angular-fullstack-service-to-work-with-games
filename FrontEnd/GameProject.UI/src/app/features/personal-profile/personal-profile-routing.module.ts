import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {PersonalProfileComponent} from "./components/personal-profile/personal-profile.component";
import {personalProfileGuard} from "../../core/guards/personal-profile.guard";

const routes: Routes = [
  {path: '', component: PersonalProfileComponent, canActivate: [personalProfileGuard]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonalProfileRoutingModule {
}
