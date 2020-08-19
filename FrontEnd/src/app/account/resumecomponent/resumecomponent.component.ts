import { Component, OnInit, Input } from '@angular/core';
import { Resume } from 'src/app/shared/resume';
import { Account } from 'src/app/shared/account'
import { AccountService } from 'src/app/core/account.service';

@Component({
  selector: 'app-resumecomponent',
  templateUrl: './resumecomponent.component.html',
  styleUrls: ['./resumecomponent.component.css']
})
export class ResumecomponentComponent implements OnInit {
  resume : Resume;
  @Input() accountSelected : Account;
  
  constructor(private accountService : AccountService) { }

  ngOnInit(): void {
    this.accountService.getResume(this.accountSelected.id)
      .subscribe(
        (resume : Resume) => this.resume = resume
    )
  }
  
}
