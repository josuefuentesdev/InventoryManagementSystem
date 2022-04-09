import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { param } from 'jquery';
import { PersonItemDto, PersonItemsClient } from "../web-api-client";

@Component({
  selector: 'app-team-member-detail',
  templateUrl: './team-member-detail.component.html',
  styleUrls: ['./team-member-detail.component.scss']
})
export class TeamMemberDetailComponent implements OnInit {

  personDetail: PersonItemDto


  constructor(
    private route: ActivatedRoute,
    private personItemsClient: PersonItemsClient,
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      console.log(params);
      this.loadViewPerson(params["id"]);
    });
  }

  loadViewPerson(id: number): void {
    this.personItemsClient.get(id).subscribe(
      result => {
        this.personDetail = result;
      }
    )
  }

}
