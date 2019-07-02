import { Component, OnInit } from '@angular/core';
import { FacilityService } from '../Services/facility.service';

@Component({
  selector: 'app-informations',
  templateUrl: './informations.component.html',
  styleUrls: ['./informations.component.css']
})
export class InformationsComponent implements OnInit {

  constructor(private facilityService: FacilityService) { }

  facilities: any[];
  hideSpinner: boolean;

  ngOnInit() {
    this.hideSpinner = false;

    this.facilityService.getAll()
      .subscribe((res: any) => {
        this.facilities = res;
        this.hideSpinner = true;
      });
  }
}
