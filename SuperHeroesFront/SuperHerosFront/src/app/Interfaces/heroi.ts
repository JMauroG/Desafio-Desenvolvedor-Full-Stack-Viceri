import { Superpoder } from "./superpoder";

export interface Heroi {
    id: number,
    nome: string,
    nomeHeroi: string,
    dataNascimento: Date|string,
    altura: number,
    peso:number,
    superpoderes: Superpoder[]
}
