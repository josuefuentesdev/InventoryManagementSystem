import { Component, OnInit } from '@angular/core';
import { ItemDto, ItemsClient, AppFilesClient } from "../web-api-client";

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss']
})
export class InventoryComponent implements OnInit {

  items: ItemDto[];

  idFile: number;
  constructor(private itemsClient: ItemsClient, private appFilesClient: AppFilesClient) { }

  ngOnInit(): void {
    this.itemsClient.getItemsWithPagination(1, 10).subscribe(
      result => {
        this.items = result.items;
      }
    );
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
