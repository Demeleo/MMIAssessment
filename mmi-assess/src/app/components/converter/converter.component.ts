import { Component, OnInit } from '@angular/core';
import { IConversion } from 'src/app/models/conversion.interface';

@Component({
  selector: 'app-converter',
  templateUrl: './converter.component.html',
  styleUrls: ['./converter.component.scss']
})
export class ConverterComponent implements OnInit {

  private conversion: IConversion[] = [
    {
      type: 'temperature', unitsOfMeasure: [
        { type: 'temperature', description: 'Kelvin' },
        { type: 'temperature', description: 'Fahrenheit' },
        { type: 'temperature', description: 'Celsius' }
      ]
    },
    {
      type: 'volume', unitsOfMeasure: [
        { type: 'volume', description: 'litre' },
        { type: 'volume', description: 'gallon' }
      ]
    },
    {
      type: 'mass', unitsOfMeasure: [
        { type: 'mass', description: 'kilogram' },
        { type: 'mass', description: 'pound' }
      ]
    },
    {
      type: 'length', unitsOfMeasure: [
        { type: 'length', description: 'kilometer' },
        { type: 'length', description: 'mile' }
      ]
    },
    {
      type: 'speed', unitsOfMeasure: [
        { type: 'speed', description: 'kmph' },
        { type: 'speed', description: 'mph' }
      ]
    }
  ]

  ngOnInit() {
  }

}
