import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CardModule } from 'primeng/card';
import { TableModule } from 'primeng/table';
import { CheckboxModule } from 'primeng/checkbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { HttpClientModule } from '@angular/common/http';
import { CreateTodoList } from './create/create-todo-list.component';

@NgModule({
  declarations: [
    AppComponent,
    CreateTodoList
  ],
  imports: [
    BrowserModule,
    CardModule,
    TableModule,
    CheckboxModule,
    FormsModule,
    ButtonModule,
    InputTextModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
