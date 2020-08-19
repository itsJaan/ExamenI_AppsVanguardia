import { Component, OnInit } from '@angular/core';
import { Account } from '../shared/account';
import { AccountService } from '../core/account.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  accounts : Account[];

  accountSelected: Account;
  constructor(private accountService : AccountService) { }


  ngOnInit(): void {
    this.accountService.getAccounts()
      .subscribe(
        (accounts : Account[]) => this.accounts = accounts
      )

  }
  mostrarDatos(account: Account, event: any){
    this.accountSelected = account;
  }

}
