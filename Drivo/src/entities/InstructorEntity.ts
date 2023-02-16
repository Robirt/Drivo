import { DrivingEntity } from "./DrivingEntity";
import { InternalExamEntity } from "./InternalExamEntity";
import { StudentEntity } from "./StudentEntity";
import { UserEntity } from "./user.entity"

export class InstructorEntity extends UserEntity {
    students: Array<StudentEntity>;
    drivings: Array<DrivingEntity>;
    internalExams: Array<InternalExamEntity>;
}