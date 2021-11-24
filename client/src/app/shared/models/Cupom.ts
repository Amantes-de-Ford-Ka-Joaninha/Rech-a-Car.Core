import { Parceiro } from "./Parceiro";

export class Cupom {
    id: number;
    nome: string;
    valorPercentual: number;
    valorFixo: number;
    valorMinimo: number;
    dataValidade: Date;
    parceiro: Parceiro;
    usos: number;
}