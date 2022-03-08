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

  personItemSelected: PersonItemDto;

  @Output() personSelectedEvent = new EventEmitter<PersonItemDto>();

  selectPersonModalTemplate: BsModalRef;

  currentPageListPerson : PersonItemDto[];

  totalItems = 0;
  currentPage = 1;

  userIcon = faUser;

  constructor(
    private modalService: BsModalService,
    private personItemsClient: PersonItemsClient,
  ) { }

  ngOnInit(): void {
    this.personItemsClient.getPersonItemsWithPagination(1, 10).subscribe(
      result => {
        this.totalItems = result.totalCount;
        this.currentPageListPerson = result.items;
        console.log(result);
      }
    );
  }

  showPage(event: any): void {
    var page = event.page;
    this.personItemsClient.getPersonItemsWithPagination(page, 10).subscribe(
      result => {
        this.totalItems = result.totalCount;
        this.currentPage = page;
        this.currentPageListPerson = result.items;
        console.log(result);
      }
    );
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
