import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../Model/Todo';
import { RequestService } from '../Service/request.service';

@Component({
    selector: 'app-todo',
    templateUrl: './todo.component.html',
    styleUrls: ['./todo.component.css']
})

/** todo component*/
export class TodoComponent implements OnInit {

  private readonly _request: RequestService;

  public todos: Todo;

    /** todo ctor */
  constructor(private request :RequestService) {
    this._request = request;
    console.log("this is  constructor TodoComponent  method");
    this.getTodos();
  }


  ngOnInit() {
    console.log("this is ngOnin TodoComponent method");
    }

  getTodos() {
    this._request.getAllTodos().subscribe(result => { this.todos = result }, error => console.error(error));
  }

}
