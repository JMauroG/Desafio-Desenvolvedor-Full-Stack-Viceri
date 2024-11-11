import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './Componets/navbar/navbar.component';
import { HeroisListComponent } from './Componets/herois-list/herois-list.component';
import { RegisterHeroiComponent } from './Componets/register-heroi/register-heroi.component';
import { UptadeHeroiComponent } from './Componets/uptade-heroi/uptade-heroi.component';
import { DeleteHeroiComponent } from './Componets/delete-heroi/delete-heroi.component';
import { HttpClientModule } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatTableModule } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import {MatDialogModule} from '@angular/material/dialog';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { ResearchHeroiComponent } from './Componets/research-heroi/research-heroi.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HeroisListComponent,
    RegisterHeroiComponent,
    UptadeHeroiComponent,
    DeleteHeroiComponent,
    ResearchHeroiComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatTableModule,
    MatPaginator,
    MatDialogModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    FormsModule
  ],
  providers: [
    provideClientHydration(),
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
