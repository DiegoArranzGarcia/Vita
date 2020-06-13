import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable()
export class VitaApiClient {

    private _apiUrl: string;
    private _apiServerUrl: string;
    private _token: string;

    constructor(private _httpClient: HttpClient, private _oidcSecurityService: OidcSecurityService)
    {
        this._apiServerUrl = "https://localhost:44311";
        this._apiUrl = `${this._apiServerUrl}/api`;
        this._token = _oidcSecurityService.getToken();
    }

    public get<Type>(url: string)
    {
        var headers = new HttpHeaders();
        headers.append("Access-Control-Allow-Origin", "*");

        var httpOptions = 
        {
            headers: headers,
            Authorization: 'Bearer ' + this._token,
        };

        return this._httpClient.get<Type>(this._apiUrl + url, httpOptions);
    }
}      