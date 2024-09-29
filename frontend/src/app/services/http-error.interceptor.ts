import { Injectable, Pipe } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

  constructor(private toastr:ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    console.log("Http request started")
    return next.handle(request)
                .pipe(
                  catchError((err:HttpErrorResponse) => {
                    const errorMessage = this.setError(err);
                    console.log(err)
                    this.toastr.error(errorMessage);
                    return throwError(errorMessage)                
                  })
                )
  }

  setError(error: HttpErrorResponse): string {
    let errorMessage = 'Unknown error occurred'

    if (error.error instanceof ErrorEvent) {
      // Client side error
      errorMessage = error.error.message;
    } else {
      // Server side error
      if (error.status != 0)
        errorMessage = error.error.errorMessage;
    }
    return errorMessage;
  }
}
