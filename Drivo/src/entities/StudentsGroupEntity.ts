import { LectureEntity } from "./LectureEntity"
import { StudentEntity } from "./StudentEntity"

export class StudentsGroupEntity {
    id: number;
    name: string;
    students: Array<StudentEntity> | null;
    lectures: Array<LectureEntity> | null;
}