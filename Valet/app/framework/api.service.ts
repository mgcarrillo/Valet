import { Injectable }     from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable }     from 'rxjs/Rx';

@Injectable()
export class ApiService {

    private baseUrl: string = 'http://parkingservice.us-east-1.elasticbeanstalk.com/api';
    private headers: Headers = new Headers();
    constructor(private http: Http
    ) { 
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }   

    public get<T>(path: string): Observable<T> {
        return this.http.get(`${this.baseUrl}/${path}`, { headers: this.headers})
            .map(this.extractData.bind(this))
            .catch(this.handleError.bind(this));
    }

    public post<T>(path: string, data: any): Observable<T> {
        return this.http.post(`${this.baseUrl}/${path}`, data, { headers: this.headers})
            .map(this.extractData.bind(this))
            .catch(this.handleError.bind(this));
    }

    public put<T>(path: string, data: any): Observable<T> {
        return this.http.put(`${this.baseUrl}/${path}`, data, { headers: this.headers})
            .map(this.extractData.bind(this))
            .catch(this.handleError.bind(this));
    }

  
     private extractData<T>(response: Response): T {
        if(response == null || response.text() == "")
            return null;
        let json = response.json();
        return <T> (json || null);
    }

    private handleError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}