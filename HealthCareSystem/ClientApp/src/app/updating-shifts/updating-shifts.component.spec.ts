import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatingShiftsComponent } from './updating-shifts.component';

describe('UpdatingShiftsComponent', () => {
  let component: UpdatingShiftsComponent;
  let fixture: ComponentFixture<UpdatingShiftsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdatingShiftsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatingShiftsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
