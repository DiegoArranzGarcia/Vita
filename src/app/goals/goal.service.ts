import { Injectable } from '@angular/core';
import { Goal } from './goal.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class GoalService {
  private _goalsEndpoint: string;

  constructor(private _httpClient: HttpClient) {
    this._goalsEndpoint = `${environment.apiEndpoint}/goals`;
  }

  public getGoals(): Observable<Goal[]> {
    return this._httpClient.get<Goal[]>(this._goalsEndpoint);
  }
}
