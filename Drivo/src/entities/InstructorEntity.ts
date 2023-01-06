import { StudentsGroupEntity } from "./StudentsGroupEntity"
import { UserEntity } from "./user.entity"

export class InstructorEntity extends UserEntity {
    public studentsGroup: Array<StudentsGroupEntity>;
}