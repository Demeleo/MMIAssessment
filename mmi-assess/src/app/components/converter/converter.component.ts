import { Component, OnInit } from '@angular/core';
import { IConversionResult } from 'src/app/models/conversion-result.interface';
import { IConversion } from 'src/app/models/conversion.interface';
import { IUnitOfMeasure } from 'src/app/models/unit-of-measure.interface';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-converter',
  templateUrl: './converter.component.html',
  styleUrls: ['./converter.component.scss']
})
export class ConverterComponent implements OnInit {
  conversionsDS: IConversion[] = [];
  selectedConversion: IConversion;
  toUnit: IUnitOfMeasure;
  fromUnit: IUnitOfMeasure;
  fromValue = 0;
  toValue = 0;
  conversionResult: IConversionResult;
  resultExpression: string;

  constructor(private apiService: ApiService) { this.initialiseDataSource(); }

  initialiseDataSource() {

    this.conversionsDS = [
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
    ];

    this.selectedConversion = this.conversionsDS[0];
    this.toUnit = this.selectedConversion.unitsOfMeasure[0];
    this.fromUnit = this.selectedConversion.unitsOfMeasure[0];
  }

  ngOnInit() {
  }

  convert() {
    this.resultExpression = '';
    this.apiService.requestConversion(this.selectedConversion.type, this.fromUnit.description, this.toUnit.description, this.fromValue)
      .subscribe((res) => {
        this.conversionResult = res;
        this.toValue = this.conversionResult.convertedResult;
        this.updateResultExpression(this.conversionResult);
      });
  }

  updateResultExpression(result: IConversionResult) {
    this.toValue = this.conversionResult.convertedResult;
    this.resultExpression = `${this.conversionResult.fromValue}${this.conversionResult.fromSymbol} converts to ${this.conversionResult.convertedResult}${this.conversionResult.toSymbol}`;
  }

}
