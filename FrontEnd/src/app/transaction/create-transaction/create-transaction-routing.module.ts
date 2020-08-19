import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateTransactionComponent } from './create-transaction.component';

const routes: Routes = [
  {path: '/Transactions', component: CreateTransactionComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateTransactionRoutingModule { }
