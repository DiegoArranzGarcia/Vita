export class GoalDto {
  public id: string;
  public title: string;
  public description: string;
  public createdOn: Date;
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
