import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Transaction } from '../shared/transaction';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  baseUrl: string = "https://localhost:44343/api/Transactions";

  constructor(private httpClient : HttpClient) { }

  getTransactions(): Observable<Transaction[]>{
    return this.httpClient.get<Transaction[]>(this.baseUrl)
    .pipe(
      catchError(this.handleError)
    );
  }
  
  addTransaction(transaction : Transaction): Observable<Transaction>{
    return this.httpClient.post<Transaction>(this.baseUrl, transaction)
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
