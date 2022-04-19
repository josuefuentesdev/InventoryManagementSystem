import { Component, Output, EventEmitter, OnInit, TemplateRef, OnDestroy } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { PersonItemDto, PersonItemsClient } from '../web-api-client';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-modal-select-person',
  templateUrl: './modal-select-person.component.html',
  styleUrls: ['./modal-select-person.component.scss']
})
export class ModalSelectPersonComponent implements OnInit, OnDestroy {

  @Output() personSelectedEvent = new EventEmitter<PersonItemDto>();


  personItems: PersonItemDto[];
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();

  // output
  personItemSelected: PersonItemDto;

  // ui
  selectPersonModalTemplateRef: BsModalRef;
  userIcon = faUser;

  constructor(
    private modalService: BsModalService,
    private personItemsClient: PersonItemsClient,
  ) { }

  ngOnInit(): void {
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

  showPersonModal(template: TemplateRef<any>): void {
    this.selectPersonModalTemplateRef = this.modalService.show(template);
    setTimeout(() => document.getElementById("name").focus(), 250);
  }

  selectPerson(personItem: PersonItemDto): void {
    this.selectPersonModalTemplateRef.hide();
    this.personItemSelected = personItem;
    this.personSelectedEvent.emit(personItem);
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }
}
