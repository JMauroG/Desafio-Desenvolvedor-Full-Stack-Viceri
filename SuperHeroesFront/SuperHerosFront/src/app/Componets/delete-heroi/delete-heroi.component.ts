import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { HeroisService } from '../../Services/herois/herois.service';
import { Heroi } from '../../Interfaces/heroi';

@Component({
  selector: 'app-delete-heroi',
  templateUrl: './delete-heroi.component.html',
  styleUrl: './delete-heroi.component.css'
})
export class DeleteHeroiComponent {
  herois: Heroi[] = [];
  selectHeroiId: number = 0;

  constructor(
    public dialogRef: MatDialogRef<DeleteHeroiComponent>,
    private heroiService: HeroisService
  ){
    this.heroiService.herois
    .subscribe(
      herois =>{
        this.herois = herois;
      }
    )
  }

  Close(): void {
    this.dialogRef.close();
  }

  Delete(){
    this.heroiService.DeleteHeroi(this.selectHeroiId)
    .subscribe(
      resp =>{
        this.Close();
      }
    )
  }

}
