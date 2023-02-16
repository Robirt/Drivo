import { ActionResponse } from "./action.response";

export class SignInResponse extends ActionResponse {

    constructor(init?: Partial<SignInResponse>) {
        super(init);
    }

    public jwtBearerToken: string;
    
}