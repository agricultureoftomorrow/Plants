export interface ICustomVisionTag {
    tags: ITag[];
    totalTaggedImages: number;
    totalUntaggedImages:number;
}


export interface ITag {
    id: string;
    name: string;
    description: string;
    imageCount:string;
}