import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { RecognitionComponent } from './components/recognition/recognition.component';
import {UploadComponent} from './components/upload/upload.component';

import {
    ButtonModule,
    GrowlModule,
    FileUploadModule,
    DataTableModule,
    SharedModule, 
    SelectItem,
    DropdownModule,
    DataListModule
} from 'primeng/primeng';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        RecognitionComponent,
        UploadComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'recognition', component: RecognitionComponent },
            { path: 'upload', component: UploadComponent },
            { path: '**', redirectTo: 'home' }
        ]),
        BrowserAnimationsModule,
        ButtonModule,
        GrowlModule,
        DropdownModule,
        FileUploadModule,
        DataTableModule,
        SharedModule
    ]
})
export class AppModuleShared {
}
