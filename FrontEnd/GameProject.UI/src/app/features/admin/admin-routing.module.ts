import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {AdminHomeComponent} from "./components/admin-home/admin-home.component";
import {AddNewsComponent} from "./components/add-news/add-news.component";

const routes: Routes = [
  {path: 'admin-home', component: AdminHomeComponent},
  {path: 'add-news', component: AddNewsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {
}
