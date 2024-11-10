import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroisListComponent } from './Componets/herois-list/herois-list.component';

const routes: Routes = [
  {path: '', component:HeroisListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
