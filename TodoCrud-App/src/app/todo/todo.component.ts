import { _ParseAST } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Todo } from '../_models/Todo';
import { TodoService } from '../_services/Todo.service';
import { defineLocale, ptBrLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';

defineLocale('pt-br', ptBrLocale); 

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {

  title = 'Todos';

  Todos: Todo[];
  todo: Todo;
  registerForm: FormGroup;
  saveMode = 'post';
  bodyDeleteTodo = '';
  
  constructor(
    private toastr: ToastrService,
    private todoService: TodoService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private localeService: BsLocaleService
    ) { 
      this.localeService.use('pt-br');
    }
    
    editTodo(todo: Todo, template: any){
      this.saveMode = 'put';
      this.openModal(template);
      this.todo = todo;
      this.registerForm.patchValue(todo);
    }  
    
    newTodo(template: any){
      this.saveMode = 'post';
      this.openModal(template);
    }
    
    openModal(template: any){
      this.registerForm.reset();
      template.show();
    }
    
    ngOnInit() {
      this.validation();
      this.getTodos();
    }
    
    validation(){
      this.registerForm = this.fb.group({
        name: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        isComplete: ['', Validators.required],
        dueDate: ['', Validators.required]
      });
    }
    
    saveTodo(template: any){
      debugger
      if(this.registerForm.valid){
        if(this.saveMode == 'post'){
          
          this.todo = Object.assign({}, this.registerForm.value);
          this.todoService.postTodo(this.todo).subscribe(
            (newTodo: Todo) => {
              console.log(newTodo);
              template.hide();
              this.getTodos();
              this.toastr.success('Saved!');
            }, error => {
              this.toastr.error(`Error in saving: ${error}`);
              console.log(error);
            }
            );
          } else{
            this.todo = Object.assign({id: this.todo.id}, this.registerForm.value);
            this.todoService.putTodo(this.todo).subscribe(
              (newTodo: Todo) => {
                console.log(newTodo);
                template.hide();
                this.getTodos();
                this.toastr.success('Saved!');
              }, error => {
                this.toastr.error(`Error in saving: ${error}`);
                console.log(error);
              }
              );
            }
          }
        }
        
        getTodos(){
          console.log();
          this.todoService.getTodos().subscribe(
            (_todos: Todo[]) => {
              this.Todos = _todos;
              console.log(_todos)
            }, error => {
              this.toastr.error(`Loading Todos failed: ${error}`);
            });
          }
          
          deleteTodo(todo: Todo, template: any) {
            this.openModal(template);
            this.todo = todo;
            this.bodyDeleteTodo = `Are you sure about deleting Todo: ${todo.name}, Code: ${todo.id}`;
          }
          
          confirmDelete(template: any) {
            this.todoService.deleteTodo(this.todo.id).subscribe(
              () => {
                template.hide();
                this.getTodos();
              }, error => {
                this.toastr.error('Deleting error');
                console.log(error);
              }
              );
            }
            
          }
          