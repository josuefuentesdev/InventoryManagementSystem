import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { ItemDto, ItemsClient, AppFilesClient, CreateItemCommand, PersonItemDto } from "../web-api-client";
import { FormControl, FormBuilder } from '@angular/forms';
import { ModalSelectPersonComponent } from "../modal-select-person/modal-select-person.component";
@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss']
})
export class InventoryComponent implements OnInit {

  items: ItemDto[];

  newItemModalTemplate: BsModalRef;

  createItemForm = this.formBuilder.group({
    name : [''],
    price : [],
    notes : [''],
    personItemId : [],
  });

  idFile: number;
  constructor(
    private itemsClient: ItemsClient,
    private appFilesClient: AppFilesClient,
    private modalService: BsModalService,
    private formBuilder: FormBuilder,
    ) { }

  ngOnInit(): void {
    this.itemsClient.getItemsWithPagination(1, 10).subscribe(
      result => {
        this.items = result.items;
      }
    );
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
        this.itemsClient.getItemsWithPagination(1, 10).subscribe(
          result => {
            this.items = result.items;
          }
        );
      }
    )
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

  showNewItemModal(template: TemplateRef<any>): void {
    this.newItemModalTemplate = this.modalService.show(template);
    setTimeout(() => document.getElementById("title").focus(), 250);
  }

  updatePersonIdSelected(personItemDto: PersonItemDto): void {
    this.createItemForm.patchValue({
      personItemId: personItemDto.id
    });
  }

}
