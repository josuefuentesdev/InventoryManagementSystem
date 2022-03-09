import { Component, OnInit } from '@angular/core';
import { PersonItemDto, PersonItemsClient } from "../web-api-client";

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.scss']
})
export class TeamComponent implements OnInit {

  personItems: PersonItemDto[];

  constructor(
    private personItemsClient: PersonItemsClient,
  ) { }

  ngOnInit(): void {
    this.personItemsClient.getPersonItemsWithPagination(1, 10).subscribe(
      result => {
        this.personItems = result.items;
      }
    );
  }

}
