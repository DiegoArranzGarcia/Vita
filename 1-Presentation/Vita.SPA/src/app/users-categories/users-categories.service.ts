import { Injectable } from '@angular/core';
import { UserCategory } from './user-category.model';
import { Observable } from 'rxjs';
import { VitaApiClient } from '../shared/vita-api/vita-api-client';

@Injectable()
export class UsersCategoriesService {

  constructor(private _vitaApiClient: VitaApiClient) { 

  }

  public getAllUserCategories(userId: number) : Observable<UserCategory[]>  {
    return this._vitaApiClient.get<UserCategory[]>(`/users/${userId}/categories`);
  }

}
