import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { FormBuilder } from '@angular/forms';
import { ItemDto, ItemsClient, CreateItemCommand, PersonItemDto, AppFilesClient } from "../web-api-client";
@Component({
  selector: 'app-modal-create-item',
  templateUrl: './modal-create-item.component.html',
  styleUrls: ['./modal-create-item.component.scss']
})
export class ModalCreateItemComponent implements OnInit {

  idFile: number;
  
  createItemForm = this.formBuilder.group({
    name : [''],
    price : [],
    notes : [''],
    personItemId : [],
  });

  newItemModalTemplate: BsModalRef;
  
  constructor(
    private modalService: BsModalService,
    private formBuilder: FormBuilder,
    private itemsClient: ItemsClient,
    private appFilesClient: AppFilesClient,
  ) { }

  ngOnInit(): void {
  }



  createItem(): void {
    console.log(this.createItemForm.value);
    
    this.itemsClient.create(<CreateItemCommand>{
      name: this.createItemForm.value.name,
      price: this.createItemForm.value.price,
      notes: this.createItemForm.value.notes,
      personItemId: this.createItemForm.value.personItemId,
    }).subscribe(
      result => {
        console.log(result);
        this.newItemModalTemplate.hide();
      }
    )
  }

  updatePersonIdSelected(personItemDto: PersonItemDto): void {
    this.createItemForm.patchValue({
      personItemId: personItemDto.id
    });
  }

  showNewItemModal(template: TemplateRef<any>): void {
    this.newItemModalTemplate = this.modalService.show(
      template,
      Object.assign({}, { keyboard: true, ignoreBackdropClick: false, id: 9996 })
      );
    setTimeout(() => document.getElementById("name").focus(), 250);
  }

  addFile(event): void {
    var firstFile = event.target.files[0];
    this.appFilesClient.create({
      data: firstFile,
      fileName: firstFile.name
    },
    'Juan',
    ).subscribe(
      result => {
        this.idFile = result;
      }
    );
  }
}
