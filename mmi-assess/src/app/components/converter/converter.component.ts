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

  constructor(private apiService: ApiService, private dataService: DataService) {
    this.initialiseDataSource();
  }

  public get selectedConversion(): IConversion { return this._selectedConversion; }
  public set selectedConversion(newValue: IConversion) {
    // logic
    this._selectedConversion = newValue;
    this.toUnit = this._selectedConversion.unitsOfMeasure[0];
    this.fromUnit = this._selectedConversion.unitsOfMeasure[1];
  }
  conversionsDS: IConversion[] = [];
  toUnit: IUnitOfMeasure;
  fromUnit: IUnitOfMeasure;
  fromValue = 0;
  toValue = 0;
  conversionResult: IConversionResult;
  resultExpression: string;
  private _selectedConversion: IConversion;

  initialiseDataSource() {
    this.conversionsDS = this.dataService.getConversionData();
    this.selectedConversion = this.conversionsDS[0];

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
