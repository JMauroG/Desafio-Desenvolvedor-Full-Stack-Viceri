import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { HeroisService } from '../../Services/herois/herois.service';
import { DeleteHeroiComponent } from '../delete-heroi/delete-heroi.component';
import { RegisterHeroiComponent } from '../register-heroi/register-heroi.component';
import { ResearchHeroiComponent } from '../research-heroi/research-heroi.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  constructor(private matDialog: MatDialog,
    private heroisServices: HeroisService
  ){

  }

  ngOnInit(){
    this.heroisServices.populateHerois();
  }

  openRegister(){
    const dialogRef = this.matDialog.open(RegisterHeroiComponent, {
      width: '500px',
      data:{}
    })

    dialogRef.afterClosed()
    .subscribe(
      s =>{
        this.heroisServices.populateHerois();
      }
    )
  }

  openDelete(){
    const dialogRef = this.matDialog.open(DeleteHeroiComponent, {
      width: '500px',
      data: {}
    })

    dialogRef.afterClosed()
    .subscribe(
      s =>{
        this.heroisServices.populateHerois();
      }
    )
  }

  openResarch(){
    const dialogRef = this.matDialog.open(ResearchHeroiComponent,
      {
        width: "500px"
      }
    )
  }

}
