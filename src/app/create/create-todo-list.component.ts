import { Component, OnInit } from '@angular/core';
import { Todo } from './todo';
import { TodoService } from '../services/todo.service';

@Component({
  selector: 'app-create-todo-list',
  templateUrl: './create-todo-list.component.html'
})
export class CreateTodoList implements OnInit {
  task: any;
  
  todos: Todo[] = [];
  newTodo: Todo = {
    id: '',
    description: '',
    createdDate: new Date(),
    isCompleted: false,
    completedDate: new Date()
  }
checked:boolean = false;

isTodoDisabled = true;

  constructor(private todoservice: TodoService) { } 

  ngOnInit(): void {
     this.getTodo();
  }

  getTodo(){
    this.todoservice.getAllTodos().subscribe({
      next: (todos) => {
        this.todos = todos;
      }
    })
  }
  
  onCheck(){
    this.todoservice.addTodo(this.newTodo)
    .subscribe({
      next: (todo) => {
        this.getTodo(); 
      }
    })
  }

  OnCompletedChange(id: string, todo: Todo) {
    todo.isCompleted = !todo.isCompleted
    this.todoservice.updateTodo(id, todo)
    .subscribe({
      next: (response) => {
        this.getTodo();
      }
    });
  }
  
  deleteTodo(id: string) {
    this.todoservice.deleteTodo(id)
    .subscribe({
      next: (response) => { 
        this.getTodo();
      }
    })
      
  }

  onDisable() {

  }
}

