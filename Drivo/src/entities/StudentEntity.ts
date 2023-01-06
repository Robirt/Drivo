import { DrivingEntity } from "./DrivingEntity";
import { ExternalExamEntity } from "./ExternalExamEntity";
import { InternalExamEntity } from "./InternalExamEntity";
import { PaymentEntity } from "./PaymentEntity"
import { StudentsGroupEntity } from "./StudentsGroupEntity";
import { UserEntity } from "./user.entity"

export class StudentEntity extends UserEntity {
    studentsGroup: StudentsGroupEntity | null;
    studentsGroupId: number | null;
    drivings: Array<DrivingEntity>;
    internalExams: Array<InternalExamEntity>;
    externalExams: Array<ExternalExamEntity>;
    payments: Array<PaymentEntity>;
}