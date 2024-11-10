import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Heroi } from '../../Interfaces/heroi';
import { Config } from '../../Config/Config';
import { BehaviorSubject } from 'rxjs';
import { RegisterHero } from '../../Interfaces/registerHeroi';
import { UpdateHero } from '../../Interfaces/updateHeroi';

@Injectable({
  providedIn: 'root'
})
export class HeroisService {
  baseUrl: string = "";

  constructor(private httpClient: HttpClient) {
    this.baseUrl = Config.apiBaseUrl;
  }

  GetAllHerois() {
    return this.httpClient.get<Heroi[]>(`${this.baseUrl}Herois`);
  }

  populateHerois(){
    this.GetAllHerois()
    .subscribe(
      resp => {
        this.setHerois(resp);
      }
    )
  }

  GetHeroiById(id: number) {
    return this.httpClient.get<Heroi>(`${this.baseUrl}Herois/${id}`);
  }

  RegisterHeroi(heroi: RegisterHero) {
    return this.httpClient.post<Heroi>(`${this.baseUrl}Herois`, heroi);
  }

  UpdateHeroi(heroi: UpdateHero) {
    return this.httpClient.put<Heroi>(`${this.baseUrl}Herois`, heroi)
  }

  DeleteHeroi(id: number) {
    return this.httpClient.delete<string>(`${this.baseUrl}Herois?heroiId=${id}`)
  }


  herois = new BehaviorSubject<Heroi[]>([]);
  setHerois(herois: Heroi[]){
    this.herois.next(herois);
  }
}
