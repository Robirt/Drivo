import { LectureEntity } from "./LectureEntity"
import { StudentsGroupEntity } from "./StudentsGroupEntity"
import { UserEntity } from "./user.entity"

export class LecturerEntity extends UserEntity {
    public studentsGroups: Array<StudentsGroupEntity>
    public lectures: Array<LectureEntity>
}