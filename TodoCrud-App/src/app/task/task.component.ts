import { HttpClient} from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  Tasks: any = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getTasks();
  }

  getTasks(){
    debugger
    console.log();
    //this.Tasks = this.http.get('https://localhost:44383/api/TodoItems').subscribe(response => {this.Tasks = response});

    this.Tasks = this.http.get('https://localhost:44398/api/Todo').subscribe(response => {
      this.Tasks = response;
      console.log()
    }, error => {
      console.log(error);
    });
  }

}
