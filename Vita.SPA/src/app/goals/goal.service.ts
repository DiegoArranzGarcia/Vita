import { Injectable } from '@angular/core';
import { GoalDto, CreateGoalDto, UpdateGoalDto } from './goal.model';
import { Observable } from 'rxjs';
import { flatMap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { ConfigurationService } from '../core/configuration/configuration.service';

@Injectable()
export class GoalService {
  private _goalsEndpoint: string;

  constructor(configurationService: ConfigurationService, private _httpClient: HttpClient) {
    this._goalsEndpoint = `${configurationService.getConfiguration().vitaApiEndpoint}/api/goals`;
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

  public updateGoal(id: string, updateDto: UpdateGoalDto): Observable<GoalDto> {
    return this._httpClient.put<GoalDto>(this._goalsEndpoint + `/${id}`, updateDto);
  }
}
