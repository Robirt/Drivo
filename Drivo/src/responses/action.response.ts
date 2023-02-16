export class ActionResponse {

    public constructor(init?: Partial<ActionResponse>) {
        Object.assign(this, init);
    }

    public isSucceeded: boolean;

    public message: string;
    
}