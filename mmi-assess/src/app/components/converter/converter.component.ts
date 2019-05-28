import { Component, OnInit } from '@angular/core';
import { IConversionResult } from 'src/app/models/conversion-result.interface';
import { IConversion } from 'src/app/models/conversion.interface';
import { IUnitOfMeasure } from 'src/app/models/unit-of-measure.interface';
import { ApiService } from 'src/app/services/api.service';
import { DataService } from 'src/app/services/data.service';

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

  constructor(private apiService: ApiService, private dataService: DataService) {
    this.initialiseDataSource();
  }

  initialiseDataSource() {
    this.conversionsDS = this.dataService.getConversionData();
    this.selectedConversion = this.conversionsDS[0];
    this.toUnit = this.selectedConversion.unitsOfMeasure[0];
    this.fromUnit = this.selectedConversion.unitsOfMeasure[1];
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
