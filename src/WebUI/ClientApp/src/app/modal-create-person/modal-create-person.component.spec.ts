import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalCreatePersonComponent } from './modal-create-person.component';

describe('ModalCreatePersonComponent', () => {
  let component: ModalCreatePersonComponent;
  let fixture: ComponentFixture<ModalCreatePersonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalCreatePersonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalCreatePersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
