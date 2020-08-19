import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResumecomponentComponent } from './resumecomponent.component';

describe('ResumecomponentComponent', () => {
  let component: ResumecomponentComponent;
  let fixture: ComponentFixture<ResumecomponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResumecomponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResumecomponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
