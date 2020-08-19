import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TransactionService } from 'src/app/core/transaction.service'

@Component({
  selector: 'app-create-transaction',
  templateUrl: './create-transaction.component.html',
  styleUrls: ['./create-transaction.component.css']
})
export class CreateTransactionComponent implements OnInit {

  form: FormGroup;

  constructor(private transactionService : TransactionService, private router : Router) { }

  ngOnInit(): void {
    this.form = this.createForm();
  }

  createForm() : FormGroup{
    return new FormGroup({
      descripcion: new FormControl("", Validators.required),
      amount: new FormControl(0, Validators.required),
      account: new FormControl(0, Validators.required),
      date: new FormControl(0, Validators.required)
    });
  }

  onSubmit(){
    const transaction = this.form.value;
    this.transactionService.addTransaction({
      id : 0,
      accountId : transaction.account,
      account : transaction.account,
      amount: transaction.amount,
      description : transaction.descripcion, 
      transactionDate : transaction.date
    })
    .subscribe((data : any) => this.router.navigate(["/Accounts"]));
  }
}
