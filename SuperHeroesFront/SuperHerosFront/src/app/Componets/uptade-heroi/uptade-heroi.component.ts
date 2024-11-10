import { Component, Inject } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Heroi } from '../../Interfaces/heroi';
import { HeroisService } from '../../Services/herois/herois.service';
import { SuperpoderesService } from '../../Services/superpoderes/superpoderes.service';
import { RegisterHero } from '../../Interfaces/registerHeroi';
import { UpdateHero } from '../../Interfaces/updateHeroi';

@Component({
  selector: 'app-uptade-heroi',
  templateUrl: './uptade-heroi.component.html',
  styleUrl: './uptade-heroi.component.css'
})
export class UptadeHeroiComponent {
  updateHeroiForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<UptadeHeroiComponent>,
    private heroisService: HeroisService,
    private superpoderesService: SuperpoderesService,
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.updateHeroiForm = this.formBuilder.group({
      id: [data.heroi.id],
      nome: [data.heroi.nome, Validators.required],
      nomeHeroi: [data.heroi.nomeHeroi, Validators.required],
      dataNascimento: [data.heroi.dataNascimento, Validators.required],
      altura: [data.heroi.altura, Validators.required],
      peso: [data.heroi.peso, Validators.required],
      superpoderes: this.populateSuperpoderes(data.superpoderes, data.heroi.superpoderes)
    })
  }

  get superpoderesArray(): FormArray {
    return this.updateHeroiForm.get('superpoderes') as FormArray;
  }

  populateSuperpoderes(superpoderes: any[], heroiSuperpoderes: any[]): FormArray {
    const arr = superpoderes.map(sp => {
      const isSelected = heroiSuperpoderes.some(heroiSp => heroiSp.poder === sp.poder);
      return this.formBuilder.control(isSelected);
    });
    return this.formBuilder.array(arr);
  }

  close() {
    this.dialogRef.close();
  }

  update() {
    if (this.updateHeroiForm.valid) {
      if (this.updateHeroiForm.valid) {
        const superpoderSelected = this.updateHeroiForm.value
          .superpoderes.map((selected: boolean, index: number) => selected ? this.data.superpoderes[index] : null)
          .filter((s: any) => s !== null);

        const date = new Date(this.updateHeroiForm.controls['dataNascimento'].value);

        const heroi: UpdateHero = {
          id: this.updateHeroiForm.controls['id'].value,
          nome: this.updateHeroiForm.controls['nome'].value,
          nomeHeroi: this.updateHeroiForm.controls['nomeHeroi'].value,
          dataNascimento: new Date(date),
          altura: this.updateHeroiForm.controls['altura'].value,
          peso: this.updateHeroiForm.controls['peso'].value,
          superpoderesIds: superpoderSelected.map((obj: any) => obj.id)
        }

        this.heroisService.UpdateHeroi(heroi)
        .subscribe(
          data => {
            this.close();
          }
        )
      }
    }
  }
}
