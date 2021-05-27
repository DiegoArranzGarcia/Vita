import { Injectable } from '@angular/core';
import { Goal, CreateGoalDto, UpdateGoalDto } from './goal.model';
import { Observable } from 'rxjs';
import { flatMap, map } from 'rxjs/operators';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ConfigurationService } from '../core/configuration/configuration.service';

@Injectable()
export class GoalService {
  private _goalsEndpoint: string;

  constructor(configurationService: ConfigurationService, private _httpClient: HttpClient) {
    this._goalsEndpoint = `${configurationService.getConfiguration().vitaApiEndpoint}/api/goals`;
  }

  public getGoal(id: string): Observable<Goal> {
    return this._httpClient.get<Goal>(this._goalsEndpoint + `/${id}`).pipe(map(goal => this.mapGoal(goal)));
  }

  public getGoals(startDate?: Date, endDate?: Date, showCompleted?: boolean): Observable<Goal[]> {
    let params = new HttpParams();

    if (startDate) params = params.set('startDate', startDate.toISOString());
    if (endDate) params = params.set('endDate', endDate.toISOString());
    if (showCompleted) params = params.set('showCompleted', showCompleted.toString());

    return this._httpClient
      .get<Goal[]>(this._goalsEndpoint, { params: params })
      .pipe(map(goals => goals.map(goal => this.mapGoal(goal))));
  }

  public createGoal(createDto: CreateGoalDto): Observable<Goal> {
    return this._httpClient
      .post(this._goalsEndpoint, createDto, { observe: 'response' })
      .pipe(flatMap((response: any) => this._httpClient.get<Goal>(response.headers.get('location'))));
  }

  public deleteGoal(id: string): Observable<void> {
    return this._httpClient.delete<void>(this._goalsEndpoint + `/${id}`);
  }

  public updateGoal(id: string, updateDto: UpdateGoalDto): Observable<void> {
    return this._httpClient.put<void>(this._goalsEndpoint + `/${id}`, updateDto);
  }

  public completeGoal(id: string): Observable<void> {
    return this._httpClient.post<void>(this._goalsEndpoint + `/${id}/complete`, null);
  }

  private mapGoal(goalDto: Goal): Goal {
    return {
      ...goalDto,
      aimDateStart: goalDto.aimDateStart ? new Date(goalDto.aimDateStart) : null,
      aimDateEnd: goalDto.aimDateEnd ? new Date(goalDto.aimDateEnd) : null,
      createdOn: goalDto.createdOn ? new Date(goalDto.createdOn) : null,
    };
  }
}
