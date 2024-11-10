import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Config } from '../../Config/Config';
import { Superpoder } from '../../Interfaces/superpoder';

@Injectable({
  providedIn: 'root'
})
export class SuperpoderesService {
  baseUrl: string = "";

  constructor(private httpClient: HttpClient) {
    this.baseUrl = Config.apiBaseUrl;
  }

  GetAllSuperpoderes() {
    return this.httpClient.get<Superpoder[]>(`${this.baseUrl}Superpoderes`)
  }
}
