import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalCreateItemComponent } from './modal-create-item.component';

describe('ModalCreateItemComponent', () => {
  let component: ModalCreateItemComponent;
  let fixture: ComponentFixture<ModalCreateItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalCreateItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalCreateItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
