import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { HeroisService } from '../../Services/herois/herois.service';
import { Heroi } from '../../Interfaces/heroi';
import { MatTableDataSource } from '@angular/material/table';
import { Superpoder } from '../../Interfaces/superpoder';

@Component({
  selector: 'app-research-heroi',
  templateUrl: './research-heroi.component.html',
  styleUrl: './research-heroi.component.css'
})
export class ResearchHeroiComponent {
  heroiId: number = 0;
  success: boolean = true;
  heroiResearch: boolean = false;
  heroi: Heroi = <Heroi>{};

  tableColumns: string[] = ["Poder", "Descricao"]
  dataSource: MatTableDataSource<Superpoder> = new MatTableDataSource();
  
  errorMessages: any[]= [];

  constructor(
    public dialogRef: MatDialogRef<ResearchHeroiComponent>,
    private heroiService: HeroisService
  ) {

  }

  Close() {
    this.dialogRef.close();
  }

  Research() {
    this.heroiService.GetHeroiById(this.heroiId)
      .subscribe(
        heroi => {
          this.heroi = heroi;
          this.dataSource.data = heroi.superpoderes;
          this.success = true;
          this.heroiResearch = true;
        }, error => {
          debugger
          this.success = false;
          this.heroiResearch = false;
          this.heroi = <Heroi>{};
          this.dataSource.data = [];
          this.errorMessages = Array.isArray(error.error) ? error.error : [error.error];
        }
      )
  }
}
