import { _ParseAST } from '@angular/compiler';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Todo } from '../_models/Todo';
import { TodoService } from '../_services/Todo.service';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {

  Todos: Todo[];
  modalRef: BsModalRef;

  constructor(
    private todoService: TodoService,
    private modalService: BsModalService
    ) { }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
    this.getTodos();
  }

  getTodos(){
    console.log();
    this.todoService.getTodos().subscribe(
      (_todos: Todo[]) => {
      this.Todos = _todos;
      console.log(_todos)
    }, error => {
      console.log(error);
    });
  }

}
