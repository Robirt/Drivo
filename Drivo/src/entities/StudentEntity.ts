import { PaymentEntity } from "./PaymentEntity"

export class StudentEntity {
    public id: number
    public firstName: string
    public surname: string
    public birthDate: Date
    public payment: Array<PaymentEntity>
}