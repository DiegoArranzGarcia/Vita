import { Component, OnInit, Input, ViewEncapsulation, ChangeDetectionStrategy } from '@angular/core';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'vita-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None,
})
export class LoadingComponent implements OnInit {
  loadingIcon = faSpinner;

  @Input() loading: boolean;
  @Input() text: string;

  constructor() {}

  ngOnInit() {}
}
