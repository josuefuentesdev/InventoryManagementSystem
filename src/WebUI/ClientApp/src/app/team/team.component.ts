import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { PersonItemDto, PersonItemsClient } from "../web-api-client";
@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.scss']
})
export class TeamComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  private datatableElement: DataTableDirective;

  personItems: PersonItemDto[];

  dtOptions: DataTables.Settings = {};

  constructor(
    private personItemsClient: PersonItemsClient,
  ) { }

  ngOnInit(): void {
    // this.personItemsClient.getPersonItemsWithPagination(1, 10).subscribe(
    //   result => {
    //     this.personItems = result.items;
    //   }
    // );

    this.dtOptions = {
      pagingType: 'full_numbers',
      // pageLength: 10,
      searching: false,
      serverSide: true,
      processing: true,
      ajax: (dataTablesParameters: any, callback) => {
        console.log(dataTablesParameters);
        var pageNumber: number = ~~(dataTablesParameters.start / dataTablesParameters.length) + 1;
        this.personItemsClient.getPersonItemsWithPagination(pageNumber , dataTablesParameters.length).subscribe(
          result => {
            this.personItems = result.items;

            callback({
              recordsTotal: result.totalCount,
              recordsFiltered: result.totalCount,
              data: []
            });
          }
        );
      },
      columns: [{ data: 'id' }, { data: 'firstName' }, { data: 'lastName' }]
    };
  }

  async refreshTable() {
    let dtInstance = await this.datatableElement.dtInstance;
    dtInstance.ajax.reload()
  }

  ngOnDestroy(): void {
  }


}
