import {HttpClient, HttpParams, HttpStatusCode} from '@angular/common/http';
import {Inject, Injectable} from '@angular/core';
import {Observable, throwError} from 'rxjs';
import {catchError} from 'rxjs/operators';
import {Router} from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class HttpService {
    constructor(private http: HttpClient,
                @Inject('BASE_URL') private baseUrl: string,
                private router: Router) {
    }

    get<T>(url: string, params?: {}): Observable<T> {
        if (!params) {
            return this.http.get<T>(this.baseUrl + url).pipe(
                catchError(this.handleError<any>(`Failed to get records from ${url}`))
            );
        }

        let paramsObj = new HttpParams();
        for (const key in params) {
            if (!params[key]) {
                continue;
            }
            paramsObj = paramsObj.set(key, params[key]);
        }

        return this.http.get<T>(this.baseUrl + url, {params: paramsObj}).pipe(
            catchError(this.handleError<any>(`Failed to get records from ${url}`))
        );
    }

    getById<T>(url: string, id: string): Observable<T> {
        return this.http.get<T>(this.baseUrl + `${url}/` + id).pipe(
            catchError(this.handleError<any>(`Failed to get record with ID: ${id} from ${url}`))
        );
    }

    put<T>(url: string, id: any, data: T, message: ApiResultMessage, suppressMessages: boolean = false): Observable<void> {
        return this.http.put<T>(this.baseUrl + url + `/${id}`, data, {observe: 'response'}).pipe(
            catchError(this.handleError<any>(message.error, suppressMessages))
        );
    }

    post<T>(url: string, data: any | null, message: ApiResultMessage, suppressMessages: boolean = false): Observable<T> {
        return this.http.post<T>(this.baseUrl + url, data, {observe: 'response'}).pipe(
            catchError(this.handleError<any>(message.error, suppressMessages))
        );
    }

    delete(url: string, id: string, message: ApiResultMessage): Observable<unknown> {
        return this.http.delete(this.baseUrl + `${url}/` + id, {observe: 'response'}).pipe(
            catchError(this.handleError<any>(message.error))
        );
    }

    private handleError<T>(errorMessage: string, suppressMessages?: boolean, result?: T) {
        return (apiError: any): Observable<T> => {
            console.error(apiError); // log to console

            // change error message based on status code
            if (apiError.status === HttpStatusCode.Forbidden) {
                this.router.navigate(['/forbidden'], {state: {forceRedirect: true}}).then();
            }
            if (apiError.status === HttpStatusCode.NotFound) {
                this.router.navigate(['/notFound'], {state: {forceRedirect: true}}).then();
            }
            if (apiError.status === HttpStatusCode.InternalServerError) {
                errorMessage += '\n' + apiError.error;
            }
            if (apiError.status === HttpStatusCode.BadRequest && apiError.error) {
                if (typeof apiError.error === 'string') {
                    errorMessage = apiError.error;
                } else if (apiError.error.errors && apiError.error.title) {
                    errorMessage = this.generateValidationErrorPopupMessage(apiError);
                }
            }

            return throwError(() => result);
        };
    }

    private generateValidationErrorPopupMessage(apiError: any): string {
        let msg = apiError.error.title;
        Object.keys(apiError.error.errors).forEach(item => msg += '\n - ' + apiError.error.errors[item].join('\n - '));
        return msg;
    }
}

export interface ApiResultMessage {
    success: string;
    error?: string;
}
