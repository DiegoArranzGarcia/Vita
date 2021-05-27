export enum GoalStatus {
  Completed = 'completed',
  ToDo = 'todo',
}

export class Goal {
  public id: string;
  public title: string;
  public description: string;
  public createdOn: Date;
  public status: GoalStatus;
  public aimDateStart: Date;
  public aimDateEnd: Date;
}

export class CreateGoalDto {
  public title: string;
  public description: string;
  public createdBy: string;
}

export class UpdateGoalDto {
  public title: string;
  public description: string;
  public aimDateStart: Date;
  public aimDateEnd: Date;
}
