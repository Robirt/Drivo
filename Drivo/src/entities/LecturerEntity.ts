import { LectureEntity } from "./LectureEntity"
import { StudentsGroupEntity } from "./StudentsGroupEntity"
import { UserEntity } from "./user.entity"

export class LecturerEntity extends UserEntity {
    public studentsGroups: Array<StudentsGroupEntity> | null;
    public lectures: Array<LectureEntity> | null;
}