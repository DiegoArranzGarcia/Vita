import { IconDefinition } from '@fortawesome/free-solid-svg-icons';

export class MenuOption {
  label: string;
  class?: string;
  icon?: IconDefinition;
  action?: () => void;
}
