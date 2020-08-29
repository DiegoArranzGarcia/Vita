import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from './configuration.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class ConfigurationService {
  private _configuration: Configuration;

  constructor(private httpClient: HttpClient) {}

  loadConfiguration(): Observable<Configuration> {
    return this.httpClient.get<Configuration>('/assets/app-settings.json').pipe(map((x) => (this._configuration = x)));
  }

  getConfiguration() {
    if (!this._configuration) throw new Error('The config is not loaded yet!');
    return this._configuration;
  }
}
