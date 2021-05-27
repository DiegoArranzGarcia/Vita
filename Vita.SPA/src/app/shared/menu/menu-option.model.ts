import { IconDefinition } from '@fortawesome/free-solid-svg-icons';

export class MenuOption {
  label: string;
  icon?: IconDefinition;
  class?: string;
  action?: () => void;
  show?: () => boolean;
}
