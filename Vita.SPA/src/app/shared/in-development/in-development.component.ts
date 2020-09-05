import { Component, OnInit } from '@angular/core';
import { faLaptopCode } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'vita-in-development',
  templateUrl: './in-development.component.html',
  styleUrls: ['./in-development.component.sass'],
})
export class InDevelopmentComponent implements OnInit {
  inDevelopmentIcon = faLaptopCode;

  constructor() {}

  ngOnInit() {}
}
