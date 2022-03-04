import { Component, OnInit } from '@angular/core';
import { ItemDto, ItemsClient } from "../web-api-client";

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss']
})
export class InventoryComponent implements OnInit {

  items: ItemDto[];
  constructor(private itemsClient: ItemsClient) { }

  ngOnInit(): void {
    this.itemsClient.getItemsWithPagination(1, 10).subscribe(
      result => {
        this.items = result.items;
      }
    );
  }

}
