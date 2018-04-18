import { Injectable } from "@angular/core";
import { Http, Response, Request, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { ICustomVisionTag } from '../_interfaces/ITagCustomVision';
import { ICustomeVisionProject } from '../_interfaces/IProjectCustomVision';


@Injectable()
export class UploadService {

    constructor(private _http: Http) { }

    private getTagsUrl = "/api/Upload/GetTags?projectId=";
    private getProjectsUrl = "/api/Upload/GetProjects";


    getProjects():Observable<ICustomeVisionProject[]> {
        return this._http.get(this.getProjectsUrl).map((res: Response) => <ICustomeVisionProject[]>res.json())
            .catch(this.handleError);
    }

    getTagsFormCustomVision(paramProject:ICustomeVisionProject):Observable<ICustomVisionTag> {
        return this._http.get(this.getTagsUrl+paramProject.id).map((res: Response) => <ICustomVisionTag>res.json())
            .catch(this.handleError);

    }


    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}