import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { CreatePersonItemCommand, PersonItemsClient } from "../web-api-client";

@Component({
  selector: 'app-modal-create-person',
  templateUrl: './modal-create-person.component.html',
  styleUrls: ['./modal-create-person.component.scss']
})
export class ModalCreatePersonComponent implements OnInit {

  
  createItemForm = this.formBuilder.group({
    name : [''],
    price : [],
    notes : [''],
    personItemId : [],
  });

  newPersonItemModalTemplate: BsModalRef;

  constructor(
    private modalService: BsModalService,
    private formBuilder: FormBuilder,
    private personItemsClient: PersonItemsClient,
  ) { }

  ngOnInit(): void {
  }

  createItem(): void {
    console.log(this.createItemForm.value);
    
    this.personItemsClient.create(<CreatePersonItemCommand>{
      name: this.createItemForm.value.name,
      lastName: this.createItemForm.value.lastName,
    }).subscribe(
      result => {
        console.log(result);
        this.newPersonItemModalTemplate.hide();
      }
    )
  }

  // updatePersonIdSelected(personItemDto: PersonItemDto): void {
  //   this.createItemForm.patchValue({
  //     personItemId: personItemDto.id
  //   });
  // }

  showNewItemModal(template: TemplateRef<any>): void {
    this.newPersonItemModalTemplate = this.modalService.show(
      template,
      Object.assign({}, { keyboard: true, ignoreBackdropClick: false, id: 9996 })
      );
    setTimeout(() => document.getElementById("name").focus(), 250);
  }

}
