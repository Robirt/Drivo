import { DrivingEntity } from "./DrivingEntity";
import { InternalExamEntity } from "./InternalExamEntity";
import { StudentEntity } from "./StudentEntity";
import { UserEntity } from "./user.entity"

export class InstructorEntity extends UserEntity {
    students: Array<StudentEntity> | null;
    drivings: Array<DrivingEntity> | null;
    internalExams: Array<InternalExamEntity> | null;
}