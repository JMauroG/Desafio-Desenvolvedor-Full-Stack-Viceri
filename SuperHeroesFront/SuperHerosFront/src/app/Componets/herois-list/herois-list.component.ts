import { Component, ViewChild } from '@angular/core';
import { HeroisService } from '../../Services/herois/herois.service';
import { MatTableDataSource } from '@angular/material/table';
import { Heroi } from '../../Interfaces/heroi';
import { MatPaginator } from '@angular/material/paginator';
import { SuperpoderesService } from '../../Services/superpoderes/superpoderes.service';
import { Superpoder } from '../../Interfaces/superpoder';
import { MatDialog } from '@angular/material/dialog';
import { UptadeHeroiComponent } from '../uptade-heroi/uptade-heroi.component';

@Component({
  selector: 'app-herois-list',
  templateUrl: './herois-list.component.html',
  styleUrl: './herois-list.component.css'
})
export class HeroisListComponent {
  loading: boolean = false;
  error: boolean = false;

  errorMessage: string = '';

  herois: Heroi[] = [];
  superpoderes: Superpoder[] = [];
  dataSource: MatTableDataSource<Heroi> = new MatTableDataSource();

  tableColumns: string[] = ["Id", "Nome", "NomeHeroi", "DataDeNascimento", "Altura", "Peso", "Poderes", "acao"];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private heroisService: HeroisService,
    private superPoderService: SuperpoderesService,
    private matDialog: MatDialog
  ) {
  }

  ngOnInit(): void {
    this.heroisService.herois
      .subscribe(
        heroisResponse => {
          this.dataSource.data = heroisResponse;
          this.dataSource.paginator = this.paginator;
          this.herois = heroisResponse;
        }
      );

    this.loadSuperPoderes();
  }

  loadSuperPoderes() {
    this.superPoderService.GetAllSuperpoderes()
      .subscribe(
        resp => {
          this.superpoderes = resp;
        }
      )
  }

  openUpdate(heroi: Heroi) {
    const dialogRef = this.matDialog.open(UptadeHeroiComponent, {
      width: '500px',
      data: {
        heroi: heroi,
        superpoderes: this.superpoderes
      }
    });

    dialogRef.afterClosed()
      .subscribe(
        c => {
          this.heroisService.populateHerois();
        }
      )
  }
}
