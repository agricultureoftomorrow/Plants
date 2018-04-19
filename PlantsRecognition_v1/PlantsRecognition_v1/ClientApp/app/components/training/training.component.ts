import { Component, OnInit } from '@angular/core';
import {
    FileUploadModule,
    DataTableModule,
    SharedModule,
    SelectItem
} from 'primeng/primeng';

import { UploadService } from '../_services/upload.service';
import { ICustomeVisionProject, IProject } from '../_interfaces/IProjectCustomVision';
import { ICustomVisionTag, ITag } from '../_interfaces/ITagCustomVision';

@Component({
    selector: "training",
    templateUrl: "training.component.html",
    providers:[UploadService]
    
})

export class TrainingComponent implements OnInit {
   

    constructor(private _service:UploadService) {}

    errorMessage: string;
    customVisionProject: ICustomeVisionProject;
    projectsDropDown: SelectItem[] = [];
    tagsDropDown:SelectItem[]=[];
    selectedProject: ICustomeVisionProject;
    selectedTag:ITag;
    totalRecord:number;

    ngOnInit(): void {

        this.selectedProject = {
            id: '',
            name: '',
            description: '',
            currentIterationId: '',
            created: '',
            lastModified: '',
            settings: [],
            thumbnailUri: ''
        };
        this.getProjectsList();
    }


    getProjectsList() {
        this.errorMessage = "";
        this.projectsDropDown = [];
        this._service.getProjects().subscribe((projects) => {

                var tempProjectsDropdown: SelectItem[] = [];

                for (let project of projects) {

                    let newSelectedItem: SelectItem = {
                        label: project.name + ' - ' + project.description,
                        value: project
                    }

                    tempProjectsDropdown.push(newSelectedItem);
                }
                this.projectsDropDown = tempProjectsDropdown;

                if (this.projectsDropDown[0].value !== 'undefined') {
                    this.selectedProject = this.projectsDropDown[0].value;
                    this.getTags();
                }
            },
            error => this.errorMessage = <any>error);
    }

    getTags() {
        this.errorMessage = "";
        this.totalRecord = 0;

        this._service.getTagsFormCustomVision(this.selectedProject).subscribe((tags) => {

            var tempTagDropDown: SelectItem[] = [];

            for (let tag of tags.tags) {
                let newSelectedItem: SelectItem = {
                    label: tag.name,
                    value: tag
                }
                tempTagDropDown.push(newSelectedItem);
            }
            this.tagsDropDown = tempTagDropDown;

            if (this.tagsDropDown[0].value !== 'undefined') {
                this.selectedTag = this.tagsDropDown[0].value;
            }
        },
        error=>this.errorMessage=<any>error);

    }
    public onBeforeUploadHandler(event) {
        // called before the file(s) are uploaded
        // Send the currently selected Project and Tag in the Header
        event.formData.append("selectedProject", this.selectedProject.id);
        event.formData.append("selectedTag", this.selectedTag.id);
    }

    public onUpload(event) {
        // This is called after the upload
        console.log(event);
    }
}