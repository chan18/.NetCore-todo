import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../Model/Todo';


@Injectable()
export class RequestService {

  private readonly _baseUrl;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  getAllTodos(): Observable<Todo> {
    return this.httpClient.get<Todo>(`${this._baseUrl}api\\todo`);
  }

}
