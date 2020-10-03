export enum GoalStatus {
  Completed = 'completed',
  ToDo = 'todo',
}

export class GoalDto {
  public id: string;
  public title: string;
  public description: string;
  public createdOn: Date;
  public status: GoalStatus;
}

export class CreateGoalDto {
  public title: string;
  public description: string;
  public createdBy: string;
}

export class UpdateGoalDto {
  public title: string;
  public description: string;
}
