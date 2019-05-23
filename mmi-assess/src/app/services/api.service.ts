import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { IConversionResult } from '../models/conversion-result.interface';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiURL: string = 'https://localhost:44344/api/';

  constructor(private httpClient: HttpClient) { }

  public requestConversion(conversionType: string, convertFrom: string, convertTo: string, convertFromValue: number) {
    return this.httpClient.get<IConversionResult>(`${this.apiURL}/${convertFrom}/${convertTo}/${convertFromValue}`);
  }
}
