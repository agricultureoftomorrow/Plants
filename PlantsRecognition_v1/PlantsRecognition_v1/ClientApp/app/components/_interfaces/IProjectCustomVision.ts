export interface ICustomeVisionProject {
    id: string;
    name: string;
    description: string;
    currentIterationId: string;
    created: string;
    lastModified: string;
    settings: IProject[];
    thumbnailUri: string;

}

export interface IProject {
    domainId: string;
    classification: string;
    useNegativeSet: boolean;
}