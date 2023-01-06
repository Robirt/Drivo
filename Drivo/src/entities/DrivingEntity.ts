import { EventEntity } from "./event.entity"
import { InstructorEntity } from "./InstructorEntity";
import { StudentEntity } from "./StudentEntity";

export class DrivingEntity extends EventEntity {
    student: StudentEntity | null;
    studentId: number | null;
    instructor: InstructorEntity | null;
    instructorId: number | null;
}