import { Observable } from "rxjs/internal/Observable";
import { FuncionarioCreateViewModel } from "../viewModels/funcionario/FuncionarioCreateViewModel";
import { FuncionarioDetailsViewModel } from "../viewModels/funcionario/FuncionarioDetailsViewModel";
import { FuncionarioEditViewModel } from "../viewModels/funcionario/FuncionarioEditViewModel";
import { FuncionarioListViewModel } from "../viewModels/funcionario/FuncionarioListViewModel";

export interface IHttpFuncionarioService {

    obterFuncionarios(): Observable<FuncionarioListViewModel[]>

    adicionarFuncionario(funcionario: FuncionarioCreateViewModel): Observable<FuncionarioCreateViewModel>

    obterFuncionarioPorId(funcionarioId: number): Observable<FuncionarioDetailsViewModel>

    editarFuncionario(funcionario: FuncionarioEditViewModel): Observable<FuncionarioEditViewModel>

    excluirFuncionario(funcionarioId: number): Observable<number>
}