import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserDetailsService {
  url = 'https://localhost:5001/AppUser';
  constructor(private http: HttpClient) { }
  users() {
    return this.http.get(this.url);
  }
}
