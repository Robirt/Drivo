import { EventEntity } from "./event.entity"
import { StudentEntity } from "./StudentEntity";

export class ExternalExamEntity extends EventEntity {
    student: StudentEntity | null;
    studentId: number | null;
}