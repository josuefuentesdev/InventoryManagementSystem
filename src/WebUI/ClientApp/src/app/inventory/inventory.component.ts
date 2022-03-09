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
}
