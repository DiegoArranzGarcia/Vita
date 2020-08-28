import { IconDefinition } from '@fortawesome/free-solid-svg-icons';

export class NavBarItem {
  label: string;
  icon: IconDefinition;
  navigateTo: string;
  class?: string;
}
