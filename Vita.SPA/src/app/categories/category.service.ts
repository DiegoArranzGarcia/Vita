import { Injectable } from '@angular/core';
import { Category } from './category.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class CategoryService {
  private _categoriesEndpoint: string;

  constructor(private _httpClient: HttpClient) {
    this._categoriesEndpoint = `${environment.apiEndpoint}/categories`;
  }

  public getCategories(): Observable<Category[]> {
    return this._httpClient.get<Category[]>(this._categoriesEndpoint);
  }
}
