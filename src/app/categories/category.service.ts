import { Injectable } from '@angular/core';
import { Category } from './category.model';
import { Observable } from 'rxjs';
import { VitaApiClient } from '../shared/vita-api/vita-api-client';

@Injectable()
export class CategoryService {

  constructor(private _vitaApiClient: VitaApiClient) { 

  }

  public getCategories() : Observable<Category[]>  {
    return this._vitaApiClient.get<Category[]>(`/categories`);
  }

}
