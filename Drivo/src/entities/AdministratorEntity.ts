import { InstructorEntity } from "./InstructorEntity"
import { StudentEntity } from "./StudentEntity"

export class AdministratorEntity
{
    public id: number
    public firstName: string
    public surname: string
    public birthDate: Date
    public login: string
    public students: StudentEntity[]
    public instructors: Array<InstructorEntity>
}