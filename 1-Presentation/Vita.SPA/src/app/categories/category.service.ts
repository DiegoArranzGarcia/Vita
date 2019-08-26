import { Injectable } from '@angular/core';
import { Category } from './category.model';
import { Observable } from 'rxjs';
import { VitaApiClient } from '../shared/vita-api/vita-api-client';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private _vitaApiClient: VitaApiClient) { 
  }

  public getAllCategories() : Observable<Category[]>  {
    return this._vitaApiClient.get<Category[]>("/categories");
  }

}
