import { Component, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { Subject } from "rxjs";
import { PersonItemDto, PersonItemsClient } from "../web-api-client";
@Component({
  selector: "app-team",
  templateUrl: "./team.component.html",
  styleUrls: ["./team.component.scss"],
})
export class TeamComponent implements OnInit, OnDestroy {
  dtOptions: DataTables.Settings = {};
  personItems: PersonItemDto[] = [];
  dtTrigger: Subject<any> = new Subject();

  constructor(private personItemsClient: PersonItemsClient) {}

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: "full_numbers",
      // pageLength: 2,
    };
    this.personItemsClient
      .getPersonItemsWithPagination(1, 500)
      .subscribe((result) => {
        this.personItems = result.items;
        this.dtTrigger.next();
      });
  }

  refreshTable(): void {
    this.personItemsClient
      .getPersonItemsWithPagination(undefined, undefined)
      .subscribe((result) => {
        this.personItems = result.items;
      });
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }
}
