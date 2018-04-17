import { IPrediction } from './IPrediction';

export interface ICustomVisionResponse {
    id: string;
    project: string;
    iteration: string;
    created: string;
    predictions: IPrediction[];
}