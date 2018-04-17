import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {
    FileUploadModule,
    DataTableModule,
    SharedModule
} from 'primeng/primeng';

import { RecognitionService } from '../_services/recognition.service';
import { ICustomVisionResponse } from '../_interfaces/IVisionResponse';
import {IPrediction} from '../_interfaces/IPrediction';

@Component({
    selector: "recognition",
    templateUrl: './recognition.component.html',
    providers:[RecognitionService]
})
export class RecognitionComponent implements OnInit {
    showPredictedImage: boolean;
    predictedImage: string;
    myImage:string;
    customVisionResponse: ICustomVisionResponse;
    predictions:IPrediction[];

    ngOnInit(): void {
        this.showPredictedImage = false;
        this.predictedImage = "";
    }

    public onSelect(event) {
        
        this.predictedImage = event.files[0].objectURL;
        this.myImage = this.predictedImage;
        //this.showPredictedImage = false;
    }

    public onUpload(event) {

        this.customVisionResponse = JSON.parse(event.xhr.responseText);
        this.predictions = this.customVisionResponse.predictions;
        //console.log(this.predictions);
        //this.showPredictedImage = true;
    }
}