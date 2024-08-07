import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Todo } from "../create/todo";

@Injectable({
    providedIn: 'root'
})
export class TodoService {
    baseApiUrl: string = "https://localhost:44343"; // swagger url address

    constructor(private http: HttpClient) { }

    getAllTodos(): Observable<Todo[]> {
        return this.http.get<Todo[]>(this.baseApiUrl + '/api/Todo/getAllTodos');
    }

    addTodo(newTodo: Todo): Observable<Todo> {
        newTodo.id = '00000000-0000-0000-0000-000000000000'; // this is the empty guid
        return this.http.post<Todo>(this.baseApiUrl + '/api/Todo', newTodo) // we need to give stored user input 
    }

    updateTodo(id: string, todo: Todo): Observable<Todo> {
        return this.http.put<Todo>(this.baseApiUrl + '/api/Todo/' + id, todo )
    }


    deleteTodo(id: string): Observable<Todo> {
        return this.http.delete<Todo>(this.baseApiUrl + '/api/Todo/' + id);
    }
}