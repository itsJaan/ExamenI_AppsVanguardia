export interface Transaction{
    id : number;
    accountId : number;
    account : string;
    amount: number;
    description : string; 
    transactionDate : Date;
}