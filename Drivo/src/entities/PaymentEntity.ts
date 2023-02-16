import { StudentEntity } from "./StudentEntity";

export class PaymentEntity {
    id: number;
    date: Date;
    endDate: Date;
    number: number;
    ammount: number;
    isApproved: boolean;
    student: StudentEntity | null;
    studentId: number | null;
}