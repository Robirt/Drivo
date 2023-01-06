import { EventEntity } from "./event.entity"
import { LecturerEntity } from "./LecturerEntity";
import { StudentsGroupEntity } from "./StudentsGroupEntity";

export class LectureEntity extends EventEntity {
    studentsGroup: StudentsGroupEntity | null;
    studentsGroupId: number | null;
    lecturer: LecturerEntity | null;
    lecturerId: number | null;
}