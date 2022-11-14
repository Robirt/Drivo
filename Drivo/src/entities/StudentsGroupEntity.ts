import { DrivingEntity } from "./DrivingEntity"
import { LectureEntity } from "./LectureEntity"
import { StudentEntity } from "./StudentEntity"

export class StudentsGroupEntity
{
    public id: number
    public name: string
    public students: StudentEntity[]
    public lecture: Array<LectureEntity>
    public driving: Array<DrivingEntity>
}