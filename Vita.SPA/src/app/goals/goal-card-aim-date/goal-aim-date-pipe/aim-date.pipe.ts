import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'aimDate',
})
export class GoalAimDatePipe implements PipeTransform {
  transform(value: { start: Date; end: Date }, selectedOption: string): any {
    if (!value) return null;

    switch (selectedOption) {
      case 'Year':
        return value.start.getFullYear();
      case 'Month':
        return new Intl.DateTimeFormat('default', { month: 'short', year: 'numeric' }).format(value.start);
      case 'Week':
        return `${new Intl.DateTimeFormat('en-GB', { month: 'short', day: 'numeric' }).format(
          value.start
        )} - ${new Intl.DateTimeFormat('en-GB', { month: 'short', day: 'numeric' }).format(value.end)}`;
      case 'Day':
        return new Intl.DateTimeFormat('en-GB', { month: 'short', day: 'numeric' }).format(value.start);
    }
  }
}
