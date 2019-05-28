import { Injectable } from '@angular/core';

import { IConversion } from '../models/conversion.interface';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }

  getConversionData(): IConversion[] {
    return [
      {
        type: 'temperature', unitsOfMeasure: [
          { type: 'temperature', description: 'Kelvin' },
          { type: 'temperature', description: 'Fahrenheit' },
          { type: 'temperature', description: 'Celsius' }
        ]
      },
      {
        type: 'volume', unitsOfMeasure: [
          { type: 'volume', description: 'Litre' },
          { type: 'volume', description: 'Gallon' }
        ]
      },
      {
        type: 'mass', unitsOfMeasure: [
          { type: 'mass', description: 'Kilogram' },
          { type: 'mass', description: 'Pound' }
        ]
      },
      {
        type: 'length', unitsOfMeasure: [
          { type: 'length', description: 'Kilometer' },
          { type: 'length', description: 'Mile' }
        ]
      },
      {
        type: 'speed', unitsOfMeasure: [
          { type: 'speed', description: 'Kmph' },
          { type: 'speed', description: 'Mph' }
        ]
      }
    ];
  }
}
