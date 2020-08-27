import { Injectable } from '@angular/core';
import { GoalDto, CreateGoalDto } from './goal.model';
import { Observable } from 'rxjs';
import { flatMap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class GoalService {
  private _goalsEndpoint: string;

  constructor(private _httpClient: HttpClient) {
    this._goalsEndpoint = `${environment.apiEndpoint}/goals`;
  }

  public getGoals(): Observable<GoalDto[]> {
    return this._httpClient.get<GoalDto[]>(this._goalsEndpoint);
  }

  public createGoal(createDto: CreateGoalDto): Observable<GoalDto> {
    return this._httpClient
      .post(this._goalsEndpoint, createDto, { observe: 'response' })
      .pipe(flatMap((response: any) => this._httpClient.get<GoalDto>(response.headers.get('location'))));
  }

  public deleteGoal(id: string): Observable<void> {
    return this._httpClient.delete<void>(this._goalsEndpoint + `/${id}`);
  }
}
