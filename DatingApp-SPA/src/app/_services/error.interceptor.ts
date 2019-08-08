import {Injectable} from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HTTP_INTERCEPTORS} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IfStmt } from '@angular/compiler';
import { Key } from 'protractor';

// intercept takes http request and http handler and returns observable httpevent type
// we will return handle request with rxjs pipe operator
@Injectable()
export class ErrorInterceptor implements HttpInterceptor  {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError(error => {
                if (error instanceof HttpErrorResponse) {
                    if (error.status === 401) {
                        return throwError(error.statusText);
                    }
                    const applicationError = error.headers.get('Application-Error');
                    if (applicationError) {
                        console.error(applicationError);
                        return throwError(applicationError);
                    }

                    const serverError = error.error; // in 2.2 use error.error.errors
                    let modelStateErrors = '';

                     if (serverError && typeof serverError === 'object') {
                        for (const key in serverError) {
                            if (serverError[key]) {
                                modelStateErrors += serverError[key] + '\n';
                            }
                        }
                    }
                    return throwError(modelStateErrors || serverError || 'Server Error');
                }
            })
        );
    }
}


// error interceptor provider allows access through appsettings.module. after adding below and 
// add ErrorInterceptorProvider to appsettings.module
export const ErrorInterceptorProvider = {
    provide: HTTP_INTERCEPTORS, // multiprovide token
    useClass: ErrorInterceptor, // we tell the above class
    multi: true // we dont want to replace existing interceptor and want to add to array
};

