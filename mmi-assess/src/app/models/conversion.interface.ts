import { IUnitOfMeasure } from './unit-of-measure.interface';

export interface IConversion{
    type: string;
    unitsOfMeasure: IUnitOfMeasure[];
}
