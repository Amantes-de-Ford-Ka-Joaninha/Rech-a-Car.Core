import { CargoType } from "../../models/CargoType";

export class FuncionarioEditViewModel{
    id : number;
    nome : string;
    telefone : string;
    endereco : string;
    cargo : CargoType;
    documento : string;
    usuario : string;
    senha : string;
}