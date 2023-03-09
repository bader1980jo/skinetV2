import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
 baseUrl = "https://localhost:5001/";

  constructor(private http: HttpClient) { }

  register(userclass: any){
    return this.http.post<any>(`${this.baseUrl}register`,userclass);
  }


  login(userclass: any){
    return this.http.post<any>(`${this.baseUrl}login`,userclass);
  }
}
