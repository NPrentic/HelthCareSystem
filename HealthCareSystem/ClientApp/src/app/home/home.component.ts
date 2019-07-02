import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {


 

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
  }
}

enum Role{ administrator = 1, nonspecialist = 2, specialist = 3, tehnician = 4 }
