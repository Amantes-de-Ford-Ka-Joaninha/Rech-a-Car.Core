import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IHttpFuncionarioService } from 'src/app/shared/interfaces/IHttpFuncionarioService';
import { FuncionarioDetailsViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioDetailsViewModel';
import { FuncionarioEditViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioEditViewModel';

@Component({
  selector: 'app-funcionario-editar',
  templateUrl: './funcionario-editar.component.html'
})
export class FuncionarioEditarComponent implements OnInit {

  id: any;
  funcionario: FuncionarioEditViewModel;
  cadastroForm: FormGroup;

  constructor(private _Activatedroute: ActivatedRoute, @Inject('IHttpFuncionarioServiceToken') private servicoFuncionario: IHttpFuncionarioService, private router: Router) { }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");

    this.cadastroForm = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl('')
    });
  }

  atualizarFuncionario() {
    this.funcionario = Object.assign({}, this.funcionario, this.cadastroForm.value);
    this.funcionario.id = this.id;

    this.servicoFuncionario.editarFuncionario(this.funcionario)
      .subscribe(() => {
        this.router.navigate(['funcionario/listar']);
      });
  }

  carregarFuncionario() {
    this.servicoFuncionario.obterFuncionarioPorId(this.id)
      .subscribe((funcionario: FuncionarioDetailsViewModel) => {
        this.carregarFormulario(funcionario);
      });
  }

  cancelar(): void {
    this.router.navigate(['funcionario/listar']);
  }

  carregarFormulario(funcionario: FuncionarioDetailsViewModel) {
    this.cadastroForm = new FormGroup({
      id: new FormControl(funcionario.id),
      nome: new FormControl(funcionario.nome),
    });
  }
}