import { Injectable, Pipe } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, concatMap, Observable, of, retry, retryWhen, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { ErrorCode } from 'src/enums/enums';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

  constructor(private toastr:ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    console.log("Http request started")
    return next.handle(request)
                .pipe(
                  // retry(10),
                  retryWhen(error=> this.retryRequest(error,10)),
                  catchError((err:HttpErrorResponse) => {
                    const errorMessage = this.setError(err);
                    console.log(err)
                    this.toastr.error(errorMessage);
                    return throwError(errorMessage)                
                  })
                )
  }


  // Retry the request incase of error
  retryRequest(error : Observable<HttpErrorResponse>, retryCount:number) :Observable<HttpErrorResponse> {
    return error.pipe(
      concatMap((checkErr: HttpErrorResponse, count: number) => {
        // // Retry incase WebAPI is down
        // if (checkErr.status === ErrorCode.serverDown && count<= retryCount) {
        //   return of(checkErr);
        // }

        // // Retry incase unauthorized error
        // if (checkErr.status === ErrorCode.unAuthorized && count<= retryCount) {
        //   return of(checkErr);
        // } 

        if (count <= retryCount) {
          switch(checkErr.status) {
            case ErrorCode.serverDown:
              return of(checkErr)
              break

            // case ErrorCode.unAuthorized:
            //   return of(checkErr)
          }
        }
        return throwError(checkErr)
      })
    )
  }

  setError(error: HttpErrorResponse): string {
    let errorMessage = 'Unknown error occurred'

    if (error.error instanceof ErrorEvent) {
      // Client side error
      errorMessage = error.error.message;
    } else {

      if (error.status === 401) {
        return error.statusText
      }
      // Server side error
      if (error.error.errorMessage && error.status != 0)
        errorMessage = error.error.errorMessage;
    }
    return errorMessage;
  }
}
