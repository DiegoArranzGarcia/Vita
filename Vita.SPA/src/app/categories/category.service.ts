import { Injectable } from '@angular/core';
import { Category } from './category.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ConfigurationService } from '../core/configuration/configuration.service';

@Injectable()
export class CategoryService {
  private _categoriesEndpoint: string;

  constructor(configurationService: ConfigurationService, private _httpClient: HttpClient) {
    this._categoriesEndpoint = `${configurationService.getConfiguration().vitaApiEndpoint}/api/categories`;
  }

  public getCategories(): Observable<Category[]> {
    return this._httpClient.get<Category[]>(this._categoriesEndpoint);
  }
}
