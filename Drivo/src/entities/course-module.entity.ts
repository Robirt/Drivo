import { ResourceEntity } from "./resource.entity";

export class CourseModuleEntity
{
    id: number;
    name: string;
    image: string;
    resources: Array<ResourceEntity> | null;
}