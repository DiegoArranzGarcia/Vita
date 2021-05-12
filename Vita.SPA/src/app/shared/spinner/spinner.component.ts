import { Component, OnInit, Input, ViewEncapsulation, ChangeDetectionStrategy } from '@angular/core';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'vita-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None,
})
export class Spinner {
  loadingIcon = faSpinner;

  @Input() loading: boolean;
  @Input() text: string;
}
