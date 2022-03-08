import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalSelectPersonComponent } from './modal-select-person.component';

describe('ModalSelectPersonComponent', () => {
  let component: ModalSelectPersonComponent;
  let fixture: ComponentFixture<ModalSelectPersonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalSelectPersonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalSelectPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
