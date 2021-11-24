import { toBase64String } from '@angular/compiler/src/output/source_map';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, ReplaySubject } from 'rxjs';
import { IHttpFuncionarioService } from 'src/app/shared/interfaces/IHttpFuncionarioService';
import { CargoType } from 'src/app/shared/models/CargoType';
import { FuncionarioCreateViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioCreateViewModel';

@Component({
  selector: 'app-funcionario-criar',
  templateUrl: './funcionario-criar.component.html'
})
export class FuncionarioCriarComponent implements OnInit {

  cadastroForm: FormGroup;
  funcionario: FuncionarioCreateViewModel;

  cargos = CargoType;
  chaves: any[];

  constructor(@Inject('IHttpFuncionarioServiceToken') private servicoFuncionario: IHttpFuncionarioService, private router: Router) { }

  ngOnInit(): void {
    this.chaves = Object.keys(this.cargos).filter(t => !isNaN(Number(t)));

    this.cadastroForm = new FormGroup({
      nome: new FormControl(''),
      telefone : new FormControl(''),
      endereco: new FormControl(''),
      cargo: new FormControl(''),
      documento: new FormControl(''),
      usuario: new FormControl(''),
      senha: new FormControl(''),
      foto: new FormControl('')
    });
  }

  
  adicionarFuncionario() {

    var reader  = new FileReader();
    reader.readAsArrayBuffer(this.cadastroForm.get('foto')?.value);

    this.cadastroForm.get('foto')?.setValue(reader.result);

    this.funcionario = Object.assign({}, this.funcionario, this.cadastroForm.value);

    this.servicoFuncionario.adicionarFuncionario(this.funcionario)
      .subscribe(() => {
        this.router.navigate(['funcionario/listar']);
      });
  }  
  cancelar(): void {
    this.router.navigate(['funcionario/listar']);
  }

}