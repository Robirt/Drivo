import { CourseModuleEntity } from "./course-module.entity";

export class ResourceEntity {
    id: number;
    title: string;
    content: string;
    image: string;
    courseModule: CourseModuleEntity | null;
    courseModuleId: number | null;
}