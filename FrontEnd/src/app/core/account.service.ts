import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Account } from '../shared/account';
import { catchError } from 'rxjs/operators';
import { Resume } from '../shared/resume';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl: string = "https://localhost:44343/api/Accounts";

  constructor(private httpClient : HttpClient) { }

  getAccounts(): Observable<Account[]>{
    return this.httpClient.get<Account[]>(this.baseUrl)
    .pipe(
      catchError(this.handleError)
    );
  }
  getResume(id : number): Observable<Resume>{
    return this.httpClient.get<Resume>(`${this.baseUrl}/${id}/Resume`)
    .pipe(
      catchError(this.handleError)
    );
  }
  private handleError(error : any){
    console.error('server error:', error);
    if(error.error instanceof Error){
      const errorMessage = error.error.message;
      return Observable.throw(errorMessage);
    }

    return Observable.throw(error || 'Server error');
  }
}
