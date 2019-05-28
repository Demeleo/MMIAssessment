import { HttpClientModule } from '@angular/common/http';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { MatButtonModule, MatFormFieldModule, MatInputModule, MatSelectModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ApiService } from 'src/app/services/api.service';
import { DataService } from 'src/app/services/data.service';

import { ConverterComponent } from './converter.component';


describe('ConverterComponent', () => {
  let component: ConverterComponent;
  let fixture: ComponentFixture<ConverterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        ConverterComponent
      ],
      imports: [
        HttpClientModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        FormsModule,
        BrowserAnimationsModule
      ],
      providers: [ApiService]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConverterComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it(`should call data service 'getConversionData' on create`, () => {
    const data = TestBed.get(DataService);
    const api = TestBed.get(ApiService);
    spyOn(data, 'getConversionData').and.callThrough();
    const mock = new ConverterComponent(api, data);
    expect(data.getConversionData).toHaveBeenCalled();
  });
});
