import { TypeEntity } from "./TypeEntity"

export class EventEntity
{
    public id: number
    public type: TypeEntity
    public place: string
    public date: Date
}