import { Component, Output, EventEmitter, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { PersonItemDto, PersonItemsClient } from '../web-api-client';
import { faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-modal-select-person',
  templateUrl: './modal-select-person.component.html',
  styleUrls: ['./modal-select-person.component.scss']
})
export class ModalSelectPersonComponent implements OnInit {

  @Output() personSelectedEvent = new EventEmitter<PersonItemDto>();


  personItems: PersonItemDto[];
  dtOptions: DataTables.Settings = {};

  // output
  personItemSelected: PersonItemDto;

  // ui
  selectPersonModalTemplate: BsModalRef;
  userIcon = faUser;

  constructor(
    private modalService: BsModalService,
    private personItemsClient: PersonItemsClient,
  ) { }

  ngOnInit(): void {
    this.personItemsClient.getPersonItemsWithPagination(1, 10).subscribe(
      result => {
        this.personItems = result.items;
      }
    );

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

  showPersonModal(template: TemplateRef<any>): void {
    this.selectPersonModalTemplate = this.modalService.show(template);
    setTimeout(() => document.getElementById("title").focus(), 250);
  }

  selectPerson(personItem: PersonItemDto): void {
    this.selectPersonModalTemplate.hide();
    this.personItemSelected = personItem;
    this.personSelectedEvent.emit(personItem);
  }

}
