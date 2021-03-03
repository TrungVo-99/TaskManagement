import { Injectable, Injector } from "@angular/core";
import { Observable } from "rxjs";
import { TransferState, makeStateKey } from '@angular/platform-browser';
import 'rxjs/Rx';
import { map, catchError } from 'rxjs/operators';

import { unescape } from "querystring";
import { Router } from '@angular/router';


import * as _ from 'lodash';
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { environment } from "../../environments/environment";



@Injectable()
export class ApiService {
  private _baseURl = "";


  constructor(private http: HttpClient) {
    //super(http, configurations, injector);
    this._baseURl = environment.apiBaseUrl;

  }
  private handleError(error: Response) {

    return Observable.throw(error);
  }

  getAllTaskList(): Observable<any> {
    return this.http
      .get(this._baseURl + `api/tasks/get-all-task`).pipe(
        map((res: Response) => {
          return res;
        }),
        catchError(this.handleError)
      )
  }

  updateTask(task): Observable<any> {
    return this.http
      .post(this._baseURl + `api/tasks/update/${task.taskId}`, task).pipe(
        map((res: Response) => {
          return res;
        }),
        catchError(this.handleError)
      )
  }


  deleteTask(task): Observable<any> {
    return this.http
      .post(this._baseURl + `api/tasks/delete/${task.taskId}`, task).pipe(
        map((res: Response) => {
          return res;
        }),
        catchError(this.handleError)
      )
  }


  createTask(task): Observable<any> {
    console.log(task)

    return this.http
      .post(this._baseURl + `api/tasks/create`, task).pipe(
        map((res: Response) => {
          return res;
        }),
        catchError(this.handleError)
      )
  }


}
