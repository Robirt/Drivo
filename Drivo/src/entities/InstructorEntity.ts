import { StudentsGroupEntity } from "./StudentsGroupEntity"

export class InstructorEntity
{
    public id: number
    public firstName: string
    public surname: string
    public birthDate: Date
    public login: string
    public studentsGroup: StudentsGroupEntity[]
}