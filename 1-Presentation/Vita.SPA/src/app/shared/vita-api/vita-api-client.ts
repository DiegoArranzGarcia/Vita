import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class VitaApiClient {

    private _apiUrl: string;
    private _apiServerUrl: string;

    constructor(private _httpClient: HttpClient)
    {
        this._apiServerUrl = "http://localhost:52895";
        this._apiUrl = `${this._apiServerUrl}/api`;
    }

    public get<Type>(url: string)
    {
        var headers = new HttpHeaders();
        headers.append("Access-Control-Allow-Origin", "*");

        var httpOptions = 
        {
            headers: headers
        };

        return this._httpClient.get<Type>(this._apiUrl + url, httpOptions);
    }
}      