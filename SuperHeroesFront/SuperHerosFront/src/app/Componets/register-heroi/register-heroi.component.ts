import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { UpdateHero } from '../../Interfaces/updateHeroi';
import { Superpoder } from '../../Interfaces/superpoder';
import { HeroisService } from '../../Services/herois/herois.service';
import { SuperpoderesService } from '../../Services/superpoderes/superpoderes.service';
import { RegisterHero } from '../../Interfaces/registerHeroi';

@Component({
  selector: 'app-register-heroi',
  templateUrl: './register-heroi.component.html',
  styleUrl: './register-heroi.component.css'
})
export class RegisterHeroiComponent {

  createHeroForm: FormGroup;
  superpoderes: Superpoder[] = [];
  error: boolean = false;
  errorMessages: any[] = [];


  constructor(
    public dialogRef: MatDialogRef<RegisterHeroiComponent>,
    private formBuilder: FormBuilder,
    private heroiService: HeroisService,
    private superpoderService: SuperpoderesService) {
    this.createHeroForm = this.formBuilder.group({
      nome: ['', Validators.required],
      nomeHeroi: ['', Validators.required],
      dataNascimento: ['',],
      altura: ['', Validators.required],
      peso: ['', Validators.required],
      superpoderes: this.formBuilder.array([])
    });

    this.superpoderService.GetAllSuperpoderes()
      .subscribe(
        response => {
          this.superpoderes = response;
          this.populateFormArray();
        }
      )
  }

  get formArray() {
    return this.createHeroForm.get('superpoderes') as FormArray;
  }

  populateFormArray() {
    this.formArray.clear();
    this.superpoderes.forEach(() => {
      this.formArray.push(this.formBuilder.control(false));
    })
  }

  UpdateValue(index: number) {

  }

  Close(): void {
    this.dialogRef.close();
  }

  Save() {
    if (this.createHeroForm.valid) {
      const superpoderSelected = this.createHeroForm.value
        .superpoderes.map((selected: boolean, index: number) => selected ? this.superpoderes[index] : null)
        .filter((s: any) => s !== null);

      const date = new Date(this.createHeroForm.controls['dataNascimento'].value);

      const heroi: RegisterHero = {
        nome: this.createHeroForm.controls['nome'].value,
        nomeHeroi: this.createHeroForm.controls['nomeHeroi'].value,
        dataNascimento: new Date(date),
        altura: this.createHeroForm.controls['altura'].value,
        peso: this.createHeroForm.controls['peso'].value,
        superpoderesIds: superpoderSelected.map((obj: any) => obj.id)
      }

      this.heroiService.RegisterHeroi(heroi)
        .subscribe(
          data => {
            console.log(data);
            this.dialogRef.close();
          },
          error => {
            this.error = true;
            this.errorMessages = Array.isArray(error.error) ? error.error : [error.error];
          }
        )
    }
  }

}
