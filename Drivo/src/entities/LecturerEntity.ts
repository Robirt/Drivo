export class LecturerEntity {
    public id: number
    public firstName: string
    public surname: string
    public birthDate: Date
    public login: string
    public studentsGroups: StudentsGroupEntity[]
}