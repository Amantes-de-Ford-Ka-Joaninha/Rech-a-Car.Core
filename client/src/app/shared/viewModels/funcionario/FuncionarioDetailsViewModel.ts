import { CargoType } from "../../models/CargoType";

export class FuncionarioDetailsViewModel{
    id : number;
    nome : string;
    telefone : string;
    endereco : string;
    cargo : CargoType;
    documento : string;
    usuario : string;
}