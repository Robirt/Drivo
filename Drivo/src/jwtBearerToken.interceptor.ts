import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserService } from "./app/services/user.service";

@Injectable()
export class JwtBearerTokenInterceptor implements HttpInterceptor {
    
    constructor(private userService: UserService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var jwtBearerToken = this.userService.getJwtBearerToken();
        if (jwtBearerToken == null) return next.handle(req);

        req = req.clone({ setHeaders: { authorization: `Bearer ${jwtBearerToken}` } });

        return next.handle(req);
    }
    
}