import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../_models/Todo';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseURL = 'https://localhost:44398/api/Todo';

  constructor(private http: HttpClient) { }

  getTodos(): Observable<Todo[]>{
    return this.http.get<Todo[]>(this.baseURL);
  }

  getTodoById(todoId: number): Observable<Todo>{
    return this.http.get<Todo>(`${this.baseURL}/${todoId}`);
  }
}
