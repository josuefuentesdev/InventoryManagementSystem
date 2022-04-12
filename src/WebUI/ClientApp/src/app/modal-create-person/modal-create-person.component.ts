import { Component, OnInit, Output, TemplateRef, EventEmitter } from '@angular/core';
import { AbstractControl, Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { CreatePersonItemCommand, PersonItemsClient } from "../web-api-client";
import Countries from "../../assets/countries.json";

interface COUNTRIES {
  name: string
  id: string
}
@Component({
  selector: 'app-modal-create-person',
  templateUrl: './modal-create-person.component.html',
  styleUrls: ['./modal-create-person.component.scss']
})
export class ModalCreatePersonComponent implements OnInit {

  @Output() createdEvent = new EventEmitter<void>();

  submitted = false;

  countries: COUNTRIES[] = Countries;

  createItemForm: FormGroup;

  newPersonItemModalRef: BsModalRef;

  constructor(
    private modalService: BsModalService,
    private formBuilder: FormBuilder,
    private personItemsClient: PersonItemsClient,
  ) { }

  ngOnInit(): void {
    this.createItemForm = this.formBuilder.group({
      name : ['', Validators.required],
      lastName : ['', Validators.required],
      region: ['', Validators.required],
    });
  }

  get f(): { [key: string]: AbstractControl } { return this.createItemForm.controls; }

  createItem(): void {
    this.submitted = true;
    if (this.createItemForm.valid) {
      this.personItemsClient.create(this.createItemForm.value).subscribe(
        result => {
          console.log(result);
          this.createdEvent.emit();
          this.newPersonItemModalRef.hide();
        }
      )
    } else {
      this.createItemForm.markAllAsTouched();
    }
  }

  // updatePersonIdSelected(personItemDto: PersonItemDto): void {
  //   this.createItemForm.patchValue({
  //     personItemId: personItemDto.id
  //   });
  // }

  showNewItemModal(template: TemplateRef<any>): void {
    this.newPersonItemModalRef = this.modalService.show(
      template,
      Object.assign({}, { keyboard: true, ignoreBackdropClick: false, id: 9996 })
      );
    setTimeout(() => document.getElementById("name").focus(), 250);
  }

}
