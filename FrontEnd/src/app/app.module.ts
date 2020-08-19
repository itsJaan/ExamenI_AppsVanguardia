import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CoreModule } from './core/core.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountComponent } from './account/account.component';
import { AccountModule } from './account/account.module';
import { TransactionComponent } from './transaction/transaction.component';
import { TransactionModule } from './transaction/transaction.module';
import { CreateTransactionComponent } from './transaction/create-transaction/create-transaction.component';
import { ResumecomponentComponent } from './account/resumecomponent/resumecomponent.component';

@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    TransactionComponent,
    CreateTransactionComponent,
    ResumecomponentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    AccountModule,
    TransactionModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
