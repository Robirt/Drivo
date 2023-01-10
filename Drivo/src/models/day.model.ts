import { EventEntity } from "src/entities/event.entity";

export class DayModel {

    public date: Date;

    public events: Array<EventEntity> = new Array<EventEntity>();
    
}