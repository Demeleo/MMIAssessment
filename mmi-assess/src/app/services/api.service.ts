import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { IConversionResult } from '../models/conversion-result.interface';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  
  apiURL: string = 'http://localhost:3004/api';

  constructor(private httpClient: HttpClient) { }

  public requestConversion(conversionType: string, convertFrom: string, convertTo: string, convertFromValue: number) {
// tslint:disable-next-line: max-line-length
    return this.httpClient.get<IConversionResult>(`${this.apiURL}/convert/${conversionType}/${convertFrom}/${convertTo}/${convertFromValue}`);
  }
}
